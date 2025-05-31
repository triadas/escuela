using static System.Runtime.InteropServices.JavaScript.JSType;

namespace script
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ShowValue_Click(object sender, EventArgs e)
        {
            try
            {
                double number = Convert.ToDouble(enterNumberValue.Text.Replace('.', ','));
                MessageBox.Show("Вы ввели: " + number.ToString(), "Вывод:");
            }
            catch (FormatException) 
            {
                MessageBox.Show("Вы ввели не число.\nвведите целое число или число с плавающей точкой");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка:");
            }

        }
    }
}
