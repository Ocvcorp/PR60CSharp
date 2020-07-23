using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace lab16_WinFormsChart
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            AtextBox.Validating += ATextBox_Validating;
            BtextBox.Validating += BTextBox_Validating;
            X0textBox.Validating += X0TextBox_Validating;
            XNtextBox.Validating += XNTextBox_Validating;
        }

        //Валидация данных
        private void ATextBox_Validating(object sender, EventArgs e)
        {
            double d;
            if (!Double.TryParse(AtextBox.Text, out d))
            {
                errorProvider.SetError(AtextBox, "Должно быть число с разделителем \",\"");
                UpdateDataButton.Enabled = false;
            }
            else
            {
                errorProvider.Clear();
                UpdateDataButton.Enabled = true;
            }
        }
        private void BTextBox_Validating(object sender, EventArgs e)
        {
            double d;
            if (!Double.TryParse(BtextBox.Text, out d))
            {
                errorProvider.SetError(BtextBox, "Должно быть число с разделителем \",\"");
                UpdateDataButton.Enabled = false;
            }
            else
            {
                errorProvider.Clear();
                UpdateDataButton.Enabled = true;
            }
        }
        private void X0TextBox_Validating(object sender, EventArgs e)
        {
            double d;
            if (!Double.TryParse(X0textBox.Text, out d))
            {
                errorProvider.SetError(X0textBox, "Должно быть число с разделителем \",\"");
                UpdateDataButton.Enabled = false;
            }
            else
            {
                errorProvider.Clear();
                UpdateDataButton.Enabled = true;
            }
        }
        private void XNTextBox_Validating(object sender, EventArgs e)
        {
            double d;
            if (!Double.TryParse(XNtextBox.Text, out d))
            {
                errorProvider.SetError(XNtextBox, "Должно быть число с разделителем \",\"");
                UpdateDataButton.Enabled = false;
            }
            else
            {
                errorProvider.Clear();
                UpdateDataButton.Enabled = true;
            }
        }

        /// <summary>
        /// Левая граница графика
        /// </summary>
        private double XMin = -5;

        /// <summary>
        /// Правая граница графика
        /// </summary>
        private double XMax = 5;

        /// <summary>
        /// Шаг графика
        /// </summary>
        private double Step = .5;

        // Массив значений X - общий для обоих графиков
        private double[] x;

        // Два массива Y - по одному для каждого графика
        private double[] y1;
        private double[] y2;

        //"Константы" функций
        private double A = 0.0;
        private double B = 0.0;

        Chart chart;
        /// <summary>
        /// Расчёт значений графика
        /// </summary>
        private void CalcFunction()
        {
            // Количество точек графика
            int count = (int)Math.Ceiling((XMax - XMin) / Step)
                        + 1;
            // Создаём массивы нужных размеров
            x = new double[count];
            y1 = new double[count];
            y2 = new double[count];
            // Расчитываем точки для графиков функции
            for (int i = 0; i < count; i++)
            {
                // Вычисляем значение X
                x[i] = XMin + Step * i;
                // Вычисляем значение функций в точке X
                y1[i] = A * x[i] * x[i] * x[i] + Math.Cos(x[i] * x[i] * x[i] - B) * Math.Cos(x[i] * x[i] * x[i] - B);
                y2[i] = 9 * (x[i] + 15 * Math.Sqrt(x[i] * x[i] * x[i] + B * B * B));
            }
        }

        /// <summary>
        /// Создаём элемент управления Chart и настраиваем его
        /// </summary>
        private void CreateChart()
        {
            // Создаём новый элемент управления Chart
            chart = new Chart();
            // Помещаем его на форму
            chart.Parent = this;
            // Задаём размеры элемента
            chart.SetBounds(10, 10, 600, 350);

            // Создаём новую область для построения графика
            ChartArea area = new ChartArea();
            // Даём ей имя (чтобы потом добавлять графики)
            area.Name = "myGraph";
            // Задаём левую и правую границы оси X
            area.AxisX.Minimum = XMin;
            area.AxisX.Maximum = XMax;
            //задаем степень округления подписей оси Х
            area.AxisX.LabelStyle.Format = "F2";
            // Определяем шаг сетки
            area.AxisX.MajorGrid.Interval = Step;
            // Добавляем область в диаграмму
            chart.ChartAreas.Add(area);

            // Создаём объект для первого графика
            Series series = new Series();
            // Ссылаемся на область для построения графика
            series.ChartArea = "myGraph";
            // Задаём тип графика - сплайны
            series.ChartType = SeriesChartType.Spline;
            // Указываем ширину линии графика
            series.BorderWidth = 3;
            // Добавляем в список графиков диаграммы
            chart.Series.Add(series);



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Заполняем поля
            X0textBox.Text = XMin.ToString();
            XNtextBox.Text = XMax.ToString();
            StepComboBox.SelectedIndex = 1;
            BtextBox.Text = B.ToString();
            AtextBox.Text = A.ToString();

            // Создаём элемент управления
            CreateChart();

            // Расчитываем значения точек графиков функций
            CalcFunction();

            // Добавляем график первой функции по умолчанию
            chart.Series[0].Points.DataBindXY(x, y1);

        }

        private void RadioButton_Checked(object sender, EventArgs e)
        {
            //CalcFunction();
            // Добавляем вычисленные значения в графики
            if (radioButtonFunc1.Checked)
            {
                chart.Series[0].Points.DataBindXY(x, y1);
                AtextBox.Visible = true;
                label5.Visible = true;
            }
            if (radioButtonFunc2.Checked)
            {
                chart.Series[0].Points.DataBindXY(x, y2);
                AtextBox.Visible = false;
                label5.Visible = false;
            }
        }

        private void UpdateDataButton_Click(object sender, EventArgs e)
        {
            //изменение параметров модели
            XMin = Double.Parse(X0textBox.Text);
            XMax = Double.Parse(XNtextBox.Text);
            Step = Double.Parse(StepComboBox.SelectedItem.ToString());
            A = Double.Parse(AtextBox.Text);
            B = Double.Parse(BtextBox.Text);
            //изменение параметров области построения
            chart.ChartAreas[0].AxisX.Minimum = XMin;
            chart.ChartAreas[0].AxisX.Maximum = XMax;
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "F2";
            chart.ChartAreas[0].AxisX.MajorGrid.Interval = Step;
            //перестраивание графика
            CalcFunction();
            if (radioButtonFunc1.Checked)
            {
                chart.Series[0].Points.DataBindXY(x, y1);
                AtextBox.Visible = true;
                label5.Visible = true;
            }
            if (radioButtonFunc2.Checked)
            {
                chart.Series[0].Points.DataBindXY(x, y2);
                AtextBox.Visible = false;
                label5.Visible = false;
            }
        }
    }
}
