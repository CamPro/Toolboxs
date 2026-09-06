using AutoIt;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

class Program
{
    static void Main()
    {
        string fileSettings = Path.Combine(Environment.CurrentDirectory, "settings.txt");

        int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;   // Chiều rộng (không tính Taskbar)
        int screenHeight = Screen.PrimaryScreen.WorkingArea.Height; // Chiều cao (không tính Taskbar)

        string explorerClass = "[CLASS:CabinetWClass]";

        string leftFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        string rightFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

        while (AutoItX.WinExists(explorerClass) == 1)
        {
            AutoItX.WinClose(explorerClass);
            AutoItX.Sleep(200);
        }

        if (File.Exists(fileSettings))
        {
            string[] lines = File.ReadAllLines(fileSettings);
            if (lines.Length > 0)
            {
                string folder = lines[0];
                if (Directory.Exists(folder))
                {
                    leftFolder = lines[0];
                }
            }
            if (lines.Length > 1)
            {
                string folder = lines[1];
                if (Directory.Exists(folder))
                {
                    rightFolder = lines[1];
                }
            }
        }

        // Nửa bên trái
        Process process1 = Process.Start("explorer.exe", leftFolder);
        process1.WaitForInputIdle(3000);
        Thread.Sleep(200);
        AutoItX.WinWaitActive(explorerClass, "", 3);
        IntPtr leftHandle = AutoItX.WinGetHandle(explorerClass);
        int leftX = 0 - 8;
        int leftY = 0;
        int leftWidth = screenWidth / 2 + 8 + 6;
        int leftHeight = screenHeight + 6;
        AutoItX.WinMove(leftHandle, leftX, leftY, leftWidth, leftHeight);
        Thread.Sleep(100);

        // Nửa bên phải
        Process process2 = Process.Start("explorer.exe", rightFolder);
        process2.WaitForInputIdle(3000);
        Thread.Sleep(200);
        AutoItX.WinWaitActive(explorerClass, "", 3);
        IntPtr rightHandle = AutoItX.WinGetHandle(explorerClass);
        int rightX = screenWidth / 2 - 8;
        int rightY = 0;
        int rightWidth = screenWidth / 2 + 8 + 6;
        int rightHeight = screenHeight + 6;
        AutoItX.WinMove(rightHandle, rightX, rightY, rightWidth, rightHeight);

        string[] settings = new string[] { leftFolder, rightFolder };
        File.WriteAllLines(fileSettings, settings, System.Text.Encoding.UTF8);

        Environment.Exit(0);
    }
}