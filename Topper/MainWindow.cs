using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Topper
{
    public partial class MainWindow : Form
    {
        #region DLL Imports
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        static extern uint GetLastError();//shouldn't use. see https://stackoverflow.com/questions/17918266/winapi-getlasterror-vs-marshal-getlastwin32error

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr handle, int handleInsertAfter, int x, int y, int width, int height, uint flags);

        //not being used
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(int hWnd);

        //not being used
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        //not being used
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);

        //not being used
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int FindWindowEx(int parentHandle, int childAfter, string lclassName, string windowTitle);
        #endregion

        #region Attributes
        KeysConverter keysConverter = new KeysConverter();
        bool HotkeysActive = true;
        #endregion

        #region Constroctor
        public MainWindow()
        {
            ConfigManager.Initialize();
            VerifyHotkeys();
            SetFormAttributes();
            InitializeComponent();
        }
        #endregion

        #region Events
        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (ConfigManager.ConfigFileExists)
                Location = ConfigManager.Config.StartPosition;
            SetButtonsText();
            RegisterHotKeys();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HotkeysActive)
                UnregisterHotKeys();
            ConfigManager.Config.StartPosition = Location;
            ConfigManager.Save();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                int keyValue = m.WParam.ToInt32();
                if (keyValue == ConfigManager.Config.MakeTopMostKey)
                    MakeTopMost();
                if (keyValue == ConfigManager.Config.UnmakeTopMostKey)
                    UnmakeTopMost();
            }
            base.WndProc(ref m);
        }

        private void BtnMakeTopMost_Click(object sender, EventArgs e)
        {
            if (HotkeysActive)
                UnregisterHotKeys();
            GetKeyStroke getKeyStroke = GenNewKeystrokeForm();
            getKeyStroke.ShowDialog();
            if (getKeyStroke.KeyPressed != Keys.None && (int)getKeyStroke.KeyPressed != ConfigManager.Config.UnmakeTopMostKey)
            {
                ConfigManager.Config.MakeTopMostKey = (int)getKeyStroke.KeyPressed;
                SetButtonsText();
            }
            getKeyStroke.Dispose();
            if (HotkeysActive)
                RegisterHotKeys();
            ConfigManager.Save();
        }

        private void BtnUnmakeTopMost_Click(object sender, EventArgs e)
        {
            if (HotkeysActive)
                UnregisterHotKeys();
            GetKeyStroke getKeyStroke = GenNewKeystrokeForm();
            getKeyStroke.ShowDialog();
            if (getKeyStroke.KeyPressed != Keys.None && (int)getKeyStroke.KeyPressed != ConfigManager.Config.MakeTopMostKey)
            {
                ConfigManager.Config.UnmakeTopMostKey = (int)getKeyStroke.KeyPressed;
                SetButtonsText();
            }
            getKeyStroke.Dispose();
            if (HotkeysActive)
                RegisterHotKeys();
            ConfigManager.Save();
        }

        private void BtnSwitchHotkeys_Click(object sender, EventArgs e)
        {
            HotkeysActive = !HotkeysActive;
            BtnSwitchHotkeys.Text = HotkeysActive ? "Active" : "Deactive";
            if (HotkeysActive)
                RegisterHotKeys();
            else
                UnregisterHotKeys();
        }
        #endregion

        #region Methods
        private void VerifyHotkeys()
        {
            if (ConfigManager.Config.MakeTopMostKey == ConfigManager.Config.UnmakeTopMostKey)
            {
                ConfigManager.Config.MakeTopMostKey = ConfigManager.DefaultConfig.MakeTopMostKey;
                ConfigManager.Config.UnmakeTopMostKey = ConfigManager.DefaultConfig.UnmakeTopMostKey;
            }
        }

        private void SetFormAttributes()
        {
            if (!ConfigManager.ConfigFileExists)
                StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Icon = Properties.Resources.Icon;
        }

        private void RegisterHotKeys()
        {
            RegisterHotKey(this.Handle, ConfigManager.Config.MakeTopMostKey, 0, ConfigManager.Config.MakeTopMostKey);
            RegisterHotKey(this.Handle, ConfigManager.Config.UnmakeTopMostKey, 0, ConfigManager.Config.UnmakeTopMostKey);
        }

        private void UnregisterHotKeys()
        {
            UnregisterHotKey(this.Handle, ConfigManager.Config.MakeTopMostKey);
            UnregisterHotKey(this.Handle, ConfigManager.Config.UnmakeTopMostKey);
        }

        private void MakeTopMost()
        {
            IntPtr hWnd = GetForegroundWindow();
            if (hWnd == IntPtr.Zero || hWnd == this.Handle)
                return;
            SetWindowPos(hWnd, -1, 0, 0, 0, 0, 0x0001 | 0x0002);
            //int err = Marshal.GetLastWin32Error(); 
        }

        private void UnmakeTopMost()
        {
            IntPtr hWnd = GetForegroundWindow();
            if (hWnd == IntPtr.Zero || hWnd == this.Handle)
                return;
            SetWindowPos(hWnd, -2, 0, 0, 0, 0, 0x0002 | 0x0001);
        }

        private void SetButtonsText()
        {
            BtnMakeTopMost.Text = keysConverter.ConvertToString(ConfigManager.Config.MakeTopMostKey);
            BtnUnmakeTopMost.Text = keysConverter.ConvertToString(ConfigManager.Config.UnmakeTopMostKey);
        }

        private GetKeyStroke GenNewKeystrokeForm()
        {
            return new GetKeyStroke()
            {
                Icon = Properties.Resources.Icon,
                Owner = this,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                TopMost = this.TopMost,
                MaximizeBox = false
            };
        }
        #endregion
    }
}
