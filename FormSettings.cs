using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DropBoxWatcher
{
	public partial class FormSettings : Form
	{
		private bool _isSaved;
		private bool isSaved
		{
			get { return _isSaved; }
			set
			{
				_isSaved = value;
				buttonSave.Enabled = !_isSaved;
			}
		}

		public FormSettings()
		{
			InitializeComponent();
		}

		private void buttonDBPublicFolder_Click(object sender, EventArgs e)
		{
			folderBrowserDialog1.Description = "Select DropBox Public Folder";
			folderBrowserDialog1.ShowNewFolderButton = false;
			if (Directory.Exists(DBSettings.DBPublicPath))
			{
				folderBrowserDialog1.SelectedPath = DBSettings.DBPublicPath;
			}
			if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
			{
				textBoxDBPublicPath.Text = folderBrowserDialog1.SelectedPath;
				isSaved = false;
			}
		}

		private void FormSettings_Load(object sender, EventArgs e)
		{
			textBoxDBPublicPath.Text = DBSettings.DBPublicPath;
			textBoxPublicURL.Text = DBSettings.PublicURL;
			isSaved = true;
		}

		private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!isSaved && MessageBox.Show("You haven't saved.  Exit?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				isSaved = true;
				e.Cancel = true;
			}
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			Save();	
		}

		private void Save()
		{
			if (!String.IsNullOrEmpty(textBoxDBPublicPath.Text))
			{
				if (!Directory.Exists(textBoxDBPublicPath.Text))
				{
					MessageBox.Show("Dropbox public folder path does not exist.");
				}
				else
				{
					DBSettings.DBPublicPath = textBoxDBPublicPath.Text;
				}
			}
			DBSettings.PublicURL = textBoxPublicURL.Text;
			isSaved = true;
		}

		private void textBoxDBPublicPath_TextChanged(object sender, EventArgs e)
		{
			isSaved = false;
		}

		private void textBoxPublicURL_TextChanged(object sender, EventArgs e)
		{
			isSaved = false;
		}
	}
}
