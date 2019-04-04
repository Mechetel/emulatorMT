using System.Drawing;
using System.Windows.Forms;
using ZedGraph;


namespace emulatorMT
{
    public partial class Graphic : Form
    {
        public Graphic()
        {
            InitializeComponent();
        }
        public void DrawGraph(int maxLenghtWord, int[] numberSteps)
        {
            GraphPane pane = chartWorkMT.GraphPane;
            pane.XAxis.Title.FontSpec.FontColor = Color.Blue;
            pane.YAxis.Title.FontSpec.FontColor = Color.Blue;
            pane.XAxis.Title.Text = "Длина слова N";
            pane.YAxis.Title.Text = "Количество шагов";
            pane.Title.Text = "График";
            pane.CurveList.Clear();
            PointPairList realSteps = new PointPairList();
            PointPairList analiticSteps = new PointPairList();
            for (int i = 0; i < maxLenghtWord; i++)
            {
                realSteps.Add(i, numberSteps[i]);
                analiticSteps.Add(i, analiticChart(i));
            }
            LineItem analiticLine = pane.AddCurve("Аналитический", analiticSteps, Color.Red, SymbolType.None);
            LineItem experimentalLine = pane.AddCurve("Экспериментальный", realSteps, Color.Blue, SymbolType.Circle);
            analiticLine.Line.Width = 2;
            experimentalLine.Line.Width = 2;
            chartWorkMT.AxisChange();
            chartWorkMT.Invalidate();
        }

        /// <summary>
        /// Считает аналитическую сложность
        /// </summary>
        /// <param name="wordLength">Длина слова</param>
        /// <returns></returns>
        public static double analiticChart(int wordLength) {
            if (wordLength == 0) return 3;
            if (wordLength == 1) return 4;

            return wordLength + 3 + wordLength / 2;

            /*
            if (wordLength == 0) {
                return 1;
            }

            if (wordLength % 2 == 0) {
                return 2.5 * wordLength + 3;
            }

            return 2 * wordLength + 2;*/
        }
    }
}
