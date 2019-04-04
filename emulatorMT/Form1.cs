using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using static emulatorMT.Tester;

namespace emulatorMT {

    public partial class Form1 : Form, ITesterListener {
        private const int TAPE_HEIGHT = 60;// высота ленты
        private const int FIRST_TAPE_INDEX = 3;// индекс первого символа на ленте
        private const String DEFAULT_CMD_FILE_NAME = "МТ.txt";// Файл с командами

        private List<Panel> tapes = new List<Panel>();// ленты
        private List<Command> commands;// система команд
        private const int WORD_LENGHT = 10;// длинна слова при тестировании
        BackgroundWorker backgroundTestMT;
        bool isPause = false;
        private String lastAnalyzedWord;

        // Переменные для тестирования и графика
        private int N = 0;// количество шагов, которое потребовалось на текущем этапе

        public Form1() {
            InitializeComponent();
            startStateTextBox.Text = Command.STATE_START;
            wordLenghtNumUpDown.Value = WORD_LENGHT;
            loadCommands(DEFAULT_CMD_FILE_NAME);
        }

        /// <summary>
        /// Загружает команды из файла
        /// </summary>
        private void loadCommands(string fileName) {
            commands = new List<Command>();
            StreamReader file = new StreamReader(fileName);
            String str;
            while ((str = file.ReadLine()) != null) {
                Command command = Command.create(str);
                if (command != null) {
                    if(commands.Count > 0) {
                        if(commands[0].getTapesCount() != command.getTapesCount()) {
                            Console.Out.WriteLine("Ошибка! Команды расчитаны на разное количество лент");
                            MessageBox.Show("Команды расчитаны на разное количество лент", "Ошибка!",
                                 MessageBoxButtons.OK);
                            onFileLoad(false);
                            return;
                        } 
                    }
                    commands.Add(command);
                } else {
                    Console.Out.WriteLine("Команда \"" + str + "\" не соответствует поддерживаемому формату");
                    MessageBox.Show("Команда \"" + str + "\" не соответствует поддерживаемому формату", "Ошибка!",
                                 MessageBoxButtons.OK);
                    onFileLoad(false);
                    return;
                }
            };
            onFileLoad(true);

            commandsTextBox.Text = String.Join(Environment.NewLine, File.ReadLines(fileName));

            // Создаем ленты
            initTapes(commands[0].getTapesCount());
        }

        private void onFileLoad(bool isSuccess) {
            fastRadioButton.Checked = isSuccess;
            wordTextBox.Enabled = isSuccess;
            fastRadioButton.Enabled = isSuccess;
            normalRadioButton.Enabled = isSuccess;
            slowRadioButton.Enabled = isSuccess;
            startMTBtn.Enabled = isSuccess;
            //resumeMTBtn.Enabled = isSuccess;
            saveLog.Enabled = isSuccess;
            createAndShowChartBtn.Enabled = isSuccess;
            startMTBtn.Enabled = isSuccess;
            //pauseMTBtn.Enabled = isSuccess;
            createAndShowChartBtn.Enabled = isSuccess;
        }

        /// <summary>
        /// Инициализация лент
        /// </summary>
        /// <param name="tapeCount">Количество лент</param>
        private void initTapes(int tapeCount) {
            tapeContainer.Controls.Clear();
            tapeContainer.AutoScroll = true;
            for (int i = 0; i < tapeCount; i++) {
                Panel tapeHolder = new Panel();
                tapeHolder.Location = new Point(0, i * TAPE_HEIGHT);
                tapeHolder.Size = new Size(tapeContainer.Width, 47);
                tapeHolder.Anchor = (AnchorStyles.Left | AnchorStyles.Right);

                Label tapeNumber = new Label();
                tapeNumber.Location = new Point(0, 0);
                tapeNumber.Text = (i + 1).ToString();
                tapeNumber.Font = new Font(FontFamily.GenericSansSerif, 14);
                tapeNumber.Size = new Size(47, 47);
                tapeNumber.TextAlign = ContentAlignment.MiddleCenter;

                Panel tape = createTape(tapeContainer.Width - 47);
                tape.Location = new Point(47, 0);

                tapeHolder.Controls.Add(tapeNumber);
                tapeHolder.Controls.Add(tape);

                tapes.Add(tape);
                tapeContainer.Controls.Add(tapeHolder);
            }
        }

        /// <summary>
        /// Создает ленту
        /// </summary>
        /// <returns></returns>
        private Panel createTape(int width) {
            Panel t = new Panel();
            t.AutoScroll = true;
            t.Size = new Size(width, 47);
            t.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
            int cellSize = 30;
            int x1 = 0;
            int y1 = 0;
            List<Label> tape = new List<Label>();
            for (int i = 0; i < 100; i++) {
                Label cell = new Label();
                cell.Text = "λ";
                cell.BackColor = Color.White;
                cell.BorderStyle = BorderStyle.Fixed3D;
                cell.Size = new Size(cellSize, cellSize);
                cell.Location = new Point(x1, y1);
                cell.TextAlign = ContentAlignment.MiddleCenter;
                cell.Font = new Font("TimesNewRoman", 14);
                x1 += cellSize;
                tape.Add(cell);
                t.Controls.Add(tape[i]);
            }
            return t;
        }

        private void startTuringMachine(int sleepTime) {
            N = 0;// кол-во шагов
            String state = startStateTextBox.Text;// текущее состояние
            int[] tapeIndexes = new int[tapes.Count];// позиции на лентах
            String[] symbols = new string[tapes.Count];// текущие видимые символы на лентах

            for (int i = 0; i < tapeIndexes.Length; i++) {
                tapeIndexes[i] = FIRST_TAPE_INDEX;
                tapes[i].Controls[tapeIndexes[i]].BackColor = Color.LightBlue;
            }

            // пока не перейдем в конечное состояние
            while (!state.Equals(Command.STATE_END)) {
                Application.DoEvents();
                if (isPause) {
                    LabelNumberProcessedWords.Text = "Работа приостановлена. " + LabelNumberProcessedWords.Text;
                    while (isPause) Application.DoEvents();
                }
                N++;

                for (int i = 0; i < tapes.Count; i++) {
                    symbols[i] = tapes[i].Controls[tapeIndexes[i]].Text;// считываем символы с лент
                }

                for (int i = 0; i < commands.Count; i++) {
                    if (commands[i].isEquals(state, symbols)) {
                        // переходим в новое состояние
                        state = commands[i].newState;

                        // записываем на ленты новые символы
                        for (int j = 0; j < tapes.Count; j++) {
                            tapes[j].Controls[tapeIndexes[j]].Text = commands[i].newSymbols[j];
                        }

                        // сдвигаем УУ
                        for (int j = 0; j < tapes.Count; j++) {
                            tapes[j].Controls[tapeIndexes[j]].BackColor = Color.White;
                            switch (commands[i].moves[j]) {
                                case Command.MOVE_LEFT: tapeIndexes[j]--; break;
                                case Command.MOVE_RIGHT: tapeIndexes[j]++; break;
                                case Command.MOVE_EMPTY: break;
                            }
                            tapes[j].Controls[tapeIndexes[j]].BackColor = Color.LightBlue;
                        }

                        //вывод в лог
                        logTextBox.Text += "Шаг " + N + ":\t" + commands[i].commandString + Environment.NewLine;
                        break;
                    }
                }
                Application.DoEvents();
                Thread.Sleep(sleepTime);
            }
        }

        /// <summary>
        /// Очищает ленты и лог
        /// </summary>
        private void reset() {
            for (int i = 0; i < tapeContainer.Controls.Count; i++) {
                for (int j = 0; j < 100; j++) {
                    tapes[i].Controls[j].Text = "λ";
                    tapes[i].Controls[j].BackColor = Color.White;
                }
            }
            logTextBox.Text = null;
        }

        /// <summary>
        /// Сохраняет последний лог в файл
        /// </summary>
        private void saveResults() {
            SaveFileDialog res = new SaveFileDialog();
            res.FileName = "mt_out.txt";
            res.Filter = "(*.txt)|*.txt";
            res.Title = "Сохранение результатов";
            if (res.ShowDialog() == DialogResult.OK) {
                StreamWriter sw = File.CreateText(res.FileName);
                sw.WriteLine(lastAnalyzedWord);
                sw.WriteLine(logTextBox.Text);
                for(int i = 0; i < tapes.Count; i++) {
                    String symbolsOnTape = "Лента " + (i + 1) + ": ";
                    for(int j = FIRST_TAPE_INDEX; j < tapes[i].Controls.Count; j++) {
                        String symbol = tapes[i].Controls[j].Text;
                        if (symbol.Equals("λ")) {
                            continue;
                        }
                        symbolsOnTape += symbol;
                    }
                    sw.WriteLine(symbolsOnTape);
                }
                sw.Close();
            }
        }

        /// <summary>
        /// Обработчик кнопки "startMTBtn"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startMT_Click(object sender, EventArgs e) {
            // проверяем существует ли состояние указанное как начальное
            String startState = startStateTextBox.Text;
            if (!isStartStateCorrect(startState)) {
                MessageBox.Show("Неверное начальное состояние!", "Ошибка!", MessageBoxButtons.OK);
                return;
            }

            // отключаем кнопки
            startMTBtn.Enabled = false;
            createAndShowChartBtn.Enabled = false;
            fastRadioButton.Enabled = false;
            normalRadioButton.Enabled = false;
            slowRadioButton.Enabled = false;
            reset();

            // записываем слово на ленту
            lastAnalyzedWord = wordTextBox.Text;
            for (int i = 0, n = FIRST_TAPE_INDEX; i < lastAnalyzedWord.Length; i++, n++) {
                tapes[0].Controls[n].Text = Convert.ToString(lastAnalyzedWord[i]);
            }

            // пауза между шагами
            int sleepTime = 0;
            if (normalRadioButton.Checked == true) sleepTime = 500;
            if (slowRadioButton.Checked == true) sleepTime = 1000;

            // старт
            startTuringMachine(sleepTime);

            // включаем кнопки
            startMTBtn.Enabled = true;
            createAndShowChartBtn.Enabled = true;
            fastRadioButton.Enabled = true;
            normalRadioButton.Enabled = true;
            slowRadioButton.Enabled = true;
        }

        /// <summary>
        /// Проверяет существует ли вообще такое состояние
        /// </summary>
        /// <returns></returns>
        private bool isStartStateCorrect(String state) {
            for(int i = 0; i < commands.Count; i++) {
                if (state.Equals(commands[i].currentState)) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Обработчик "wordTextBox". Проверяет вводимые символы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (!((e.KeyChar == 8) || (e.KeyChar == 48) || (e.KeyChar == 49) || (e.KeyChar == 96) || (e.KeyChar == 97))) {
                e.Handled = true;
            }
        }

        /// <summary>
        /// запуск тестирования МТ и построения графика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createAndShowChart_Click(object sender, EventArgs e) {
            String startState = startStateTextBox.Text;
            if (!isStartStateCorrect(startState)) {
                MessageBox.Show("Неверное начальное состояние!", "Ошибка!", MessageBoxButtons.OK);
                return;
            }

            backgroundTestMT = new BackgroundWorker();
            backgroundTestMT.WorkerReportsProgress = true;
            backgroundTestMT.DoWork += backgroundTestMT_DoWork;// добавляем задачу
            backgroundTestMT.RunWorkerAsync();// Запуск
            while (backgroundTestMT.IsBusy) {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Показывает график
        /// </summary>
        /// <param name="numberSteps"></param>
        private void showChart(int[] numberSteps) {
            Graphic ChartWorkMT = new Graphic();
            ChartWorkMT.DrawGraph(((int)wordLenghtNumUpDown.Value) + 1, numberSteps);
            ChartWorkMT.Show();
        }

        /// <summary>
        /// Задача тестирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundTestMT_DoWork(object sender, EventArgs e) {
            Tester tester = new Tester(this, ((int) wordLenghtNumUpDown.Value));
            tester.start();
        }
        
        private void saveLog_Click(object sender, EventArgs e) {
            saveResults();
        }

        private void pauseMT_Click(object sender, EventArgs e) {
            isPause = true;
            pauseMTBtn.Enabled = false;
            resumeMTBtn.Enabled = true;
        }

        private void resumeMT_Click(object sender, EventArgs e) {
            isPause = false;
            resumeMTBtn.Enabled = false;
            pauseMTBtn.Enabled = true;
        }

        private void loadCmdFromFileBtn_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Загрузка файла с командами";
            openFileDialog.Filter = "(*.txt)|*.txt";
            if(openFileDialog.ShowDialog() == DialogResult.OK) {
                loadCommands(openFileDialog.FileName);
            }
        }

        ///// Для обратной связи с Tester

        public void onTestStart() {
            if (InvokeRequired) {
                Invoke(new Action(onTestStart));
                return;
            }

            // отключаем кнопки
            fastRadioButton.Checked = true;
            wordTextBox.Enabled = false;
            fastRadioButton.Enabled = false;
            normalRadioButton.Enabled = false;
            slowRadioButton.Enabled = false;
            startMTBtn.Enabled = false;
            resumeMTBtn.Enabled = false;
            saveLog.Enabled = false;
            createAndShowChartBtn.Enabled = false;
            startMTBtn.Enabled = false;
            pauseMTBtn.Enabled = true;
            createAndShowChartBtn.Enabled = false;
            loadCmdFromFileBtn.Enabled = false;
        }

        public void onTestEnd(int[] numberSteps) {
            if (InvokeRequired) {
                Invoke(new Action<int[]>(onTestEnd), numberSteps);
                return;
            }

            // включаем кнопки
            wordTextBox.Enabled = true;
            fastRadioButton.Enabled = true;
            normalRadioButton.Enabled = true;
            slowRadioButton.Enabled = true;
            startMTBtn.Enabled = true;
            saveLog.Enabled = true;
            createAndShowChartBtn.Enabled = true;
            startMTBtn.Enabled = true;
            pauseMTBtn.Enabled = false;
            resumeMTBtn.Enabled = false;
            createAndShowChartBtn.Enabled = true;
            loadCmdFromFileBtn.Enabled = true;
            LabelNumberProcessedWords.Text = "";

            showChart(numberSteps);
        }

        /// <summary>
        /// Вывод прогресса тестирования
        /// </summary>
        /// <param name="progress"></param>
        public void updateProgress(string progress) {
            if (InvokeRequired) {
                Invoke(new Action<string>(updateProgress), progress);
                return;
            }
            LabelNumberProcessedWords.Text = progress;
        }

        /// <summary>
        /// Тестирует переданое слово
        /// </summary>
        /// <param name="word">Слово</param>
        /// <returns></returns>
        public int startMTWithWord(string word) {
            if (InvokeRequired) {
                StartMTWithWord func = startMTWithWord;
                return (int) Invoke(func, word);
            }

            wordTextBox.Text = word; // Записываем слово в TextBox
            startMT_Click(this, null); // Нажимаем на кнопку "Старт"

            return N; // количество шагов
        }

        private delegate int StartMTWithWord(string word);
    }
}
