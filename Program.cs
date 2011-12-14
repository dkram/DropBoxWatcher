using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace DropBoxWatcher
{
	public class SysTrayApp : Form
	{
		private NotifyIcon  _trayIcon;
        private ContextMenu _trayMenu;
		private WatchDropBoxPublicFolder _DBWatcher;
		

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new SysTrayApp());
		}

        public SysTrayApp()
        {
            _trayMenu = new ContextMenu();
			_trayMenu.MenuItems.Add("Settings", OpenSettings_Click);
			//TODO: Combine these 2 lines into 1.
			_trayMenu.MenuItems.Add("Start Watching", StartWatching_Click);
			_trayMenu.MenuItems.Add("Stop Watching", StopWatching_Click);
            _trayMenu.MenuItems.Add("Exit", OnExit_Click);
            _trayIcon      = new NotifyIcon();
            _trayIcon.Text = "DropBox Watcher";
            //_trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
			//_trayIcon.Icon = new Icon("DropBoxWatcher.ico", 40, 40);

			Icon theIcon = new Icon(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DropBoxWatcher.DropBoxWatcher.ico"));
			_trayIcon.Icon = theIcon;


            // Add menu to tray icon and show it.
            _trayIcon.ContextMenu = _trayMenu;
            _trayIcon.Visible     = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible       = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.
			_DBWatcher = new WatchDropBoxPublicFolder();

			if (string.IsNullOrEmpty(DBSettings.DBPublicPath))
			{
				OpenSettings();
			} else {
				_DBWatcher.StartWatching();
			}

            base.OnLoad(e);
		}

#region Context Menu Methods
		private void OpenSettings()
		{
			FormSettings fSettings = new FormSettings();
			fSettings.Show(this);
		}

		private void StartWatching_Click(object sender, EventArgs e)
		{
			_DBWatcher.StartWatching();
		}

		private void StopWatching_Click(object sender, EventArgs e)
		{
			_DBWatcher.StopWatching();
			//MenuItem[] menuItemStartWatching;
			//menuItemStartWatching = _trayMenu.MenuItems.Find("Start Watching", false);
			//if (menuItemStartWatching.Count > 0)
			//{
			//}
		}

		private void OpenSettings_Click(object sender, EventArgs e)
		{
			OpenSettings();
		}

        private void OnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
#endregion

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                // Release the icon resource.
                _trayIcon.Dispose();
				_DBWatcher.StopWatching();
            }

            base.Dispose(isDisposing);
        }

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysTrayApp));
			this.SuspendLayout();
			// 
			// SysTrayApp
			// 
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SysTrayApp";
			this.ResumeLayout(false);

		}
	}
}
