using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emulatorMT
{
    class Tester {

        public interface ITesterListener {
            void onTestStart();
            void onTestEnd(int[] numberSteps);
            void updateProgress(String progress);
            int startMTWithWord(String word);
        }

        private ITesterListener testerListener;
        private int maxWordLenght;// максимальная длинна слова при тестировании

        private int wordsCount; // Количество слов, которые нужно обработать
        private int handledWordsCount;// Количество обработаных слов
        private int[] numberSteps;// хранит количество шагов, которое потребовалось для для обработки слов разной длины (в худшем случае)

        public Tester(ITesterListener testerListener, int maxWordLenght) {
            this.testerListener = testerListener;
            this.maxWordLenght = maxWordLenght;

            numberSteps = new int[maxWordLenght + 1];
            handledWordsCount = 0;
        }

        /// <summary>
        /// Запускает тестирование
        /// </summary>
        public void start() {
            testerListener.onTestStart();

            wordsCount = calcCoutWords(maxWordLenght);

            // обнуляем шаги для слов разной длины
            for (int i = 0; i < maxWordLenght + 1; i++) {
                numberSteps[i] = 0;
            }

            for (int i = 0; i < maxWordLenght + 1; i++) {
                if (i == 0) {
                    handleWord("");// пустое слово
                } else {
                    int numberWords = (int) Math.Pow(2, i); // количество слов длины i
                    for (int j = 0; j < numberWords; j++) {
                        handleWord(createWord(j, i));// создаем новое слово и подставляем в машину
                    }
                }
            }

            testerListener.onTestEnd(numberSteps);
        }

        /// <summary>
        /// Начинает обработку слова (тестирование)
        /// </summary>
        /// <param name="word">Слово</param>
        /// <param name="wordLenght"></param>
        private void handleWord(String word) {
            int N = testerListener.startMTWithWord(word);
            // Если результат хуже предыдущего, то записываем его
            if (numberSteps[word.Length] < N) {
                numberSteps[word.Length] = N;
            }
            handledWordsCount++;

            testerListener.updateProgress("Обработано " + handledWordsCount + " слов из " + wordsCount);
        }

        /// <summary>
        /// Считает существующее количество слов длиной от 0 до заданной
        /// </summary>
        /// <param name="wordLenght">Длинна</param>
        /// <returns></returns>
        private static int calcCoutWords(int wordLenght) {
            if (wordLenght == 0) {
                return 1;
            }
            return (int) Math.Pow(2, wordLenght) + calcCoutWords(wordLenght - 1);
        }

        /// <summary>
        /// Генерирует следующее слово
        /// </summary>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        private static string createWord(int N, int M) {
            string word = "";
            int K = N;
            for (int i = 0; i < M; i++) {
                word += (K % 2);
                K = K / 2;
            }
            return word;
        }
    }
}