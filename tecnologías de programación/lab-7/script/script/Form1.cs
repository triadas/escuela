using System.Windows.Forms;

namespace script
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.bmp; *.jpg; *.png)|*.bmp;*.jpg;*.png|All files (*.*)|*.*";
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        // Добавление выбранных файлов в список
                        selectedFiles.Items.Add(file);
                    }
                }
            }
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (selectedFiles.SelectedItem != null)
            {
                // Отображение выбранного изображения в PictureBox
                picture.Image = Image.FromFile(selectedFiles.SelectedItem.ToString());
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("savedPaths.dat"))
            {
                foreach (var item in selectedFiles.Items)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (File.Exists("savedPaths.dat"))
            {
                selectedFiles.Items.Clear();

                using (StreamReader reader = new StreamReader("savedPaths.dat"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        selectedFiles.Items.Add(line);
                    }
                }
            }
        }
    }
}
