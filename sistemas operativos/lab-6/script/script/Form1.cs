using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace script
{
    public partial class Form1 : Form
    {
        // Импортируем необходимые функции из user32.dll
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        private List<IntPtr> windowHandles = new List<IntPtr>();

        public Form1()
        {
            InitializeComponent();
            LoadWindows();
        }

        private void LoadWindows()
        {
            EnumWindows(new EnumWindowsProc(EnumWindow), IntPtr.Zero);
            foreach (var handle in windowHandles)
            {
                System.Text.StringBuilder windowText = new System.Text.StringBuilder(256);
                GetWindowText(handle, windowText, windowText.Capacity);
                listBoxWindows.Items.Add(windowText.ToString());
            }
        }

        private bool EnumWindow(IntPtr hWnd, IntPtr lParam)
        {
            windowHandles.Add(hWnd);
            return true; // Продолжаем перечисление
        }

        private void buttonResize_Click(object sender, EventArgs e)
        {
            if (listBoxWindows.SelectedItem != null)
            {
                // Получаем выбранное окно
                IntPtr selectedHandle = windowHandles[listBoxWindows.SelectedIndex];

                // Изменяем размер и положение окна
                SetWindowPos(selectedHandle, IntPtr.Zero, 100, 100, 800, 600, 0);
            }
        }
    }
}
