using System.Drawing.Drawing2D;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        double[,] matrix;
        int rows, cols;

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadMatrix(string path)
        {
            var lines = File.ReadAllLines(path);
            if (lines.Length == 0)
            {
                throw new Exception("Файл пуст.");
            }

            this.rows = lines.Length; // Изменено на this.rows
            this.cols = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length; // Изменено на this.cols
            matrix = new double[this.rows, this.cols]; // Изменено на this.rows и this.cols

            for (int i = 0; i < this.rows; i++)
            {
                var values = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (values.Length != this.cols)
                {
                    throw new Exception("Несоответствие количества столбцов в строках.");
                }
                for (int j = 0; j < this.cols; j++)
                {
                    matrix[i, j] = double.Parse(values[j]);
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            LoadMatrix("C:\\Users\\que mienten\\Documents\\GitHub\\escuela\\tecnologías de programación\\lab-8\\matrix.txt");

            hScrollBar.Minimum = 0;
            hScrollBar.Maximum = cols - 1;
            vScrollBar.Minimum = 0;
            vScrollBar.Maximum = rows - 1;

            hScrollBar.ValueChanged += UpdateValue;
            vScrollBar.ValueChanged += UpdateValue;

            chkPositive.CheckedChanged += FilterLogic;
            chkNegative.CheckedChanged += FilterLogic;
            chkZero.CheckedChanged += FilterLogic;
            chkNonZero.CheckedChanged += (s, ev) =>
            {
                if (chkNonZero.Checked)
                {
                    chkPositive.Checked = true;
                    chkNegative.Checked = true;
                }
            };

            ShowMatrix();
            UpdateValue(null, null);
        }

        private void UpdateValue(object sender, EventArgs e)
        {
            int r = vScrollBar.Value;
            int c = hScrollBar.Value;
            double val = matrix[r, c];

            bool show =
                (val > 0 && chkPositive.Checked) ||
                (val < 0 && chkNegative.Checked) ||
                (val == 0 && chkZero.Checked);

            txtValue.Text = val.ToString("0.###");
            txtValue.BackColor = show ? Color.White : Color.Red;

            if (val == 0)
            {
                txtValue.ForeColor = Color.Black;
                txtValue.Font = new Font(txtValue.Font, FontStyle.Italic);
            }
            else if (val > 0)
            {
                txtValue.ForeColor = Color.Green;
                txtValue.Font = new Font(txtValue.Font, FontStyle.Bold);
            }
            else
            {
                txtValue.ForeColor = Color.Red;
                txtValue.Font = new Font(txtValue.Font, FontStyle.Bold | FontStyle.Italic);
            }
        }

        private void FilterLogic(object sender, EventArgs e)
        {
            if (!chkPositive.Checked || !chkNegative.Checked)
                chkNonZero.Checked = false;
            UpdateValue(null, null);
        }

        private void ShowMatrix()
        {
            dataGridViewMatrix.ColumnCount = cols;
            dataGridViewMatrix.RowCount = rows;
            dataGridViewMatrix.RowHeadersVisible = false;
            dataGridViewMatrix.ColumnHeadersVisible = false;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    double val = matrix[r, c];
                    var cell = new DataGridViewTextBoxCell();
                    cell.Value = val.ToString("0.###");

                    if (val == 0)
                    {
                        cell.Style.ForeColor = Color.Black;
                        cell.Style.Font = new Font(dataGridViewMatrix.Font, FontStyle.Italic);
                    }
                    else if (val > 0)
                    {
                        cell.Style.ForeColor = Color.Green;
                        cell.Style.Font = new Font(dataGridViewMatrix.Font, FontStyle.Bold);
                    }
                    else
                    {
                        cell.Style.ForeColor = Color.Red;
                        cell.Style.Font = new Font(dataGridViewMatrix.Font, FontStyle.Bold | FontStyle.Italic);
                    }

                    dataGridViewMatrix.Rows[r].Cells[c] = cell;
                }
            }
        }


    }
}
