using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            double[] inputArr = GetData();

            if (inputArr == null || inputArr.Length == 0)
            {
                inputArrText.Text = "Ошибка: массив данных пуст. ";
                return;
            }
            else
            {
                inputArrText.Text = string.Join(" ", inputArr);
            }

        }

        static public double[] GetData(string path = "C:\\Users\\que mienten\\Documents\\GitHub\\escuela\\waste\\vector.txt")
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    double[] arr = sr.ReadLine()
                                     .Replace('.', ',')
                                     .Split(' ', '\t', '\n')
                                     .Select(s => Convert.ToDouble(s))
                                     .ToArray();
                    return arr;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private void cntRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChooseMatrixBox();
        }

        private void cntCols_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChooseMatrixBox();
        }

        public void UpdateChooseMatrixBox()
        {
            if (cntRows.SelectedItem == null || cntCols.SelectedItem == null)
                return;

            int value1 = Convert.ToInt32(cntRows.SelectedItem);
            int value2 = Convert.ToInt32(cntCols.SelectedItem);

            chooseMatrixBox.Items.Clear();

            // Пример логики: отображаем числа от суммы до суммы + 10
            int start = 1;
            int end = GetData().Length/(value1 * value2) + 1;

            for (int i = start; i <= end; i++)
            {
                chooseMatrixBox.Items.Add(i);
            }

            if (chooseMatrixBox.Items.Count > 0)
                chooseMatrixBox.SelectedIndex = 0;
        }

        private void showMatrixButton_Click(object sender, EventArgs e)
        {
            matrix.Rows.Clear();
            matrix.Columns.Clear();

            int rows = Convert.ToInt32(cntRows.SelectedItem);
            int cols = Convert.ToInt32(cntCols.SelectedItem);

            double[] inputArr = GetData();

            for (int col = 0; col < cols; col++)
            {
                var column = new DataGridViewTextBoxColumn();
                column.Width = 40; // задай нужную ширину
                matrix.Columns.Add(column);
            }

            // Добавляем строки
            matrix.Rows.Add(rows);

            GetOutputArr(inputArr);
        }



        //    if (arr == null)
        //    {
        //        Console.WriteLine("Массив пуст (null). Невозможно отобразить.\n");
        //        return;
        //    }

        //    int rows = arr.GetLength(0);
        //    int cols = arr.GetLength(1);

        //    for (int i = 0; i < rows; i++)
        //    {
        //        for (int j = 0; j < cols; j++)
        //        {
        //            Console.Write(arr[i, j] + "\t");
        //        }
        //        Console.WriteLine();
        //    }
        //

        public void GetOutputArr(double[] arr)
        {
            string method = chooseMethodBox.Text;


            int N = Convert.ToInt32(cntRows.SelectedItem);
            int M = Convert.ToInt32(cntCols.SelectedItem);
            int G = arr.Length / (M * N) + 1;

            double[,,] outputArr = new double[G, N, M];

            int k = 0;

            void FillSnake(double[,,] target, int arrNum)
            {

                for (int i = 0; i < N; i++)
                {
                    if (i % 2 == 0)
                    {
                        for (int j = 0; j < M && k < arr.Length; j++)
                            target[arrNum, i, j] = arr[k++];
                    }
                    else
                    {
                        for (int j = M - 1; j >= 0 && k < arr.Length; j--)
                            target[arrNum, i, j] = arr[k++];
                    }
                }
            }

            void FillRows(double[,,] target, int arrNum)
            {
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < M && k < arr.Length; j++)
                        target[arrNum, i, j] = arr[k++];
            }

            void FillCols(double[,,] target, int arrNum)
            {
                for (int j = 0; j < M; j++)
                    for (int i = 0; i < N && k < arr.Length; i++)
                        target[arrNum, i, j] = arr[k++];
            }

            if (method == "змейкой")
                for (int i = 0; i < G; i++)
                    FillSnake(outputArr, i);

            else if (method == "по строкам")
                for (int i = 0; i < G; i++)
                    FillRows(outputArr, i);

            else if (method == "по столбцам")
                for (int i = 0; i < G; i++)
                    FillCols(outputArr, i);

            int indexArr = chooseMatrixBox.SelectedIndex;
            for(int i = 0; i<N; i++)
                for(int j = 0; j<M; j++)
                    matrix.Rows[i].Cells[j].Value = outputArr[indexArr, i, j];
        }

    }
}
