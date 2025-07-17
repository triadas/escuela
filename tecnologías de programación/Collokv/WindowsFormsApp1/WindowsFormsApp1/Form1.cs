using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem eachItem in listView1.SelectedItems)
                {
                    listView1.Items.Remove(eachItem);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Элемент не выбран или остался только 1 элемент.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void add_Click(object sender, EventArgs e)
        {
            listView1.Items.Add("Пункт ");
        }

        private void up_Click(object sender, EventArgs e)
        {
          
        }

        private void down_Click(object sender, EventArgs e)
        {
           
        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
