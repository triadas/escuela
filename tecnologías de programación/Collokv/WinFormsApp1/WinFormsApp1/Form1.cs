using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using OxyPlot; 
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.Render; 
using System.Drawing.Imaging; 



namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPostroit_Click(object sender, EventArgs e)
        {
            double x;
            if (double.TryParse(textBoxX.Text, out x) && x > 0)
            {
                // Создание графика с использованием определённой библиотеки (например, OxyPlot)
                var plotModel = new PlotModel { Title = "График функции f(x) = lg(sin(x))" };

                var series = new LineSeries();
                for (double i = 0; i <= x; i += 0.1)
                {
                    if (Math.Sin(i) > 0) // Проверка на корректность
                    {
                        series.Points.Add(new DataPoint(i, Math.Log10(Math.Sin(i))));
                    }
                }

                plotModel.Series.Add(series);
                plotView.Model = plotModel; // plotView - элемент управления для отображения графика
            }
            else
            {
                MessageBox.Show("Введите корректное значение X.");
            }
        }

        private void buttonSokhranit_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Image Files|*.bmp;*.jpg;*.gif";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Здесь код для сохранения изображения графика
                    SavePlotImage(sfd.FileName);
                }
            }
        }

        private void SavePlotImage(string filepath)
        {
            // Пример сохранения изображения графика в выбранный файл
            var bitmap = new RenderTargetBitmap((Visual)plotView, 0, 0);
            using (FileStream stream = new FileStream(filepath, FileMode.Create))
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                encoder.Save(stream);
            }
        }

        private void buttonSchnit_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedFile = listBox1.SelectedItem.ToString();
            }
        }

        private void buttonOchinyt_Click(object sender, EventArgs e)
        {
            plotView.Model.Series.Clear(); 
            listBox1.Items.Clear(); 
        }
    }
}
