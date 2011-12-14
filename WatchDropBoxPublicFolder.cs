using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace DropBoxWatcher
{
	class WatchDropBoxPublicFolder
	{
		static string _dropboxURL;
		static Thread _threadClipboard;
		static FileSystemWatcher _fileSystemWatcher;
		static bool _isStopped;

		public bool isStopped
		{
			get { return _isStopped; }
			set { _isStopped = value; }
		}

		public void main()
		{
			_isStopped = true;
		}

		//[STAThreadAttribute()]
		public void StartWatching()
		{
			_dropboxURL = string.Empty;

			if (_fileSystemWatcher == null)
				_fileSystemWatcher = new FileSystemWatcher();

			try
			{

				string dbpublicfolder = DBSettings.DBPublicPath;
				if (string.IsNullOrEmpty(dbpublicfolder))
					throw new Exception("DropBox Public Folder is not set");

				//_fileSystemWatcher.Path = @"C:\Users\mardef\Documents\My Dropbox\Public";
				_fileSystemWatcher.Path = dbpublicfolder;
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show("Error setting file path: " + ex.Message);
				return;
			}
			_fileSystemWatcher.IncludeSubdirectories = true;
			_fileSystemWatcher.NotifyFilter = NotifyFilters.LastAccess
				| NotifyFilters.LastWrite
				| NotifyFilters.FileName
				| NotifyFilters.DirectoryName;
			//_fileSystemWatcher.Filter = "*.txt";
			//_fileSystemWatcher.Changed += new FileSystemEventHandler(OnChanged);
			//_fileSystemWatcher.Renamed += new RenamedEventHandler(OnRenamed);
			_fileSystemWatcher.Created += new FileSystemEventHandler(OnCreated);
			_fileSystemWatcher.EnableRaisingEvents = true;
			_isStopped = false;
		}

		public void StopWatching()
		{
			if (_fileSystemWatcher != null)
			{
				_fileSystemWatcher.EnableRaisingEvents = false;
				if (_threadClipboard != null && _threadClipboard.IsAlive)
				{
					_threadClipboard.Abort();
				}
			}
			_isStopped = true;
		}


		[STAThreadAttribute()]
		private static void OnRenamed(object source, RenamedEventArgs e)
		{
			//SetClipboardData(e.FullPath);
			//System.Windows.Forms.MessageBox.Show("OnRenamed");
		}

		[STAThreadAttribute()]
		private static void OnChanged(object source, FileSystemEventArgs e)
		{
			//SetClipboardData(e.FullPath);
			//System.Windows.Forms.MessageBox.Show("OnChanged");
		}


		[STAThreadAttribute()]
		private static void OnCreated(object source, FileSystemEventArgs e)
		{
			//System.Windows.Forms.MessageBox.Show("OnCreated");
			SetClipboardData(e.FullPath);
		}

		private static void SetClipboardData(string fullPath)
		{
			//strip the local folder path and just return the subfolders and file name
			string subFolderPath = fullPath.Replace(DBSettings.DBPublicPath, string.Empty).Replace(@"\", "/");
			//make sure subfolder path does not start with a slash
			if (subFolderPath.StartsWith("/"))
			{
				subFolderPath = subFolderPath.Substring(1);
			}
			_dropboxURL = DBSettings.PublicURL + subFolderPath;
			//System.Windows.Forms.MessageBox.Show("_dropboxURL: " + _dropboxURL);
			if (_threadClipboard != null && _threadClipboard.IsAlive)
			{
				_threadClipboard.Abort();
			}
			_threadClipboard = new Thread(new ThreadStart(CopySTA));
			_threadClipboard.SetApartmentState(ApartmentState.STA);
			_threadClipboard.Start();
		}

		[STAThread]
		private static void CopySTA()
		{
			Clipboard.SetDataObject(_dropboxURL);
			Thread.CurrentThread.Join();
		}
	}
}
