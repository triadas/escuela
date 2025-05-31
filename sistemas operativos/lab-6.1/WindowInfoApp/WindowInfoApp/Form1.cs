using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WindowInfoApp
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public Form1()
        {
            InitializeComponent();
            LoadActiveWindows();
        }

        private void LoadActiveWindows()
        {
            lstWindows.Items.Clear();
            EnumWindows(new EnumWindowsProc(EnumWindow), IntPtr.Zero);
        }

        private bool EnumWindow(IntPtr hWnd, IntPtr lParam)
        {
            int length = GetWindowTextLength(hWnd);
            if (length == 0) return true; // Пропустить окна без заголовка

            StringBuilder windowText = new StringBuilder(length + 1);
            GetWindowText(hWnd, windowText, windowText.Capacity);
            lstWindows.Items.Add(new WindowItem(hWnd, windowText.ToString()));
            return true;
        }

        private void lstWindows_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstWindows.SelectedItem is WindowItem selectedWindow)
            {
                DisplayWindowInfo(selectedWindow.Handle);
            }
        }

        private void DisplayWindowInfo(IntPtr hWnd)
        {
            int length = GetWindowTextLength(hWnd);
            StringBuilder windowText = new StringBuilder(length + 1);
            GetWindowText(hWnd, windowText, windowText.Capacity);

            if (GetWindowRect(hWnd, out RECT rect))
            {
                string info = $"Название: {windowText}\n" +
                              $"Позиция: ({rect.Left}, {rect.Top})\n" +
                              $"Размер: {rect.Right - rect.Left} x {rect.Bottom - rect.Top}\n" +
                              $"Процесс: {Process.GetProcessById(Process.GetCurrentProcess().Id).ProcessName}";

                lblInfo.Text = info;
            }
        }

        private void btnSetWindow_Click(object sender, EventArgs e)
        {
            if (lstWindows.SelectedItem is WindowItem selectedWindow)
            {
                IntPtr hWnd = selectedWindow.Handle;
                int x = int.Parse(txtX.Text);
                int y = int.Parse(txtY.Text);
                int width = int.Parse(txtWidth.Text);
                int height = int.Parse(txtHeight.Text);

                // Изменение положения и размера окна
                MoveWindow(hWnd, x, y, width, height, true);
            }
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        private class WindowItem
        {
            public IntPtr Handle { get; }
            public string Title { get; }

            public WindowItem(IntPtr handle, string title)
            {
                Handle = handle;
                Title = title;
            }

            public override string ToString()
            {
                return Title;
            }
        }
    }
}
