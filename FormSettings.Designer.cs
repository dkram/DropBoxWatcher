namespace DropBoxWatcher
{
	partial class FormSettings
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.buttonDBPublicFolder = new System.Windows.Forms.Button();
			this.textBoxDBPublicPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonSave = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxPublicURL = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// buttonDBPublicFolder
			// 
			this.buttonDBPublicFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDBPublicFolder.Location = new System.Drawing.Point(297, 46);
			this.buttonDBPublicFolder.Name = "buttonDBPublicFolder";
			this.buttonDBPublicFolder.Size = new System.Drawing.Size(75, 23);
			this.buttonDBPublicFolder.TabIndex = 0;
			this.buttonDBPublicFolder.Text = "Browse...";
			this.buttonDBPublicFolder.UseVisualStyleBackColor = true;
			this.buttonDBPublicFolder.Click += new System.EventHandler(this.buttonDBPublicFolder_Click);
			// 
			// textBoxDBPublicPath
			// 
			this.textBoxDBPublicPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDBPublicPath.Location = new System.Drawing.Point(12, 49);
			this.textBoxDBPublicPath.Name = "textBoxDBPublicPath";
			this.textBoxDBPublicPath.Size = new System.Drawing.Size(279, 20);
			this.textBoxDBPublicPath.TabIndex = 1;
			this.textBoxDBPublicPath.TextChanged += new System.EventHandler(this.textBoxDBPublicPath_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(137, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "DropBox Public Folder Path";
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.buttonSave.Location = new System.Drawing.Point(156, 126);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 3;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 81);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(266, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Public URL (Newly created file name will be appended)";
			// 
			// textBoxPublicURL
			// 
			this.textBoxPublicURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPublicURL.Location = new System.Drawing.Point(12, 100);
			this.textBoxPublicURL.Name = "textBoxPublicURL";
			this.textBoxPublicURL.Size = new System.Drawing.Size(279, 20);
			this.textBoxPublicURL.TabIndex = 4;
			this.textBoxPublicURL.TextChanged += new System.EventHandler(this.textBoxPublicURL_TextChanged);
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(386, 174);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxPublicURL);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxDBPublicPath);
			this.Controls.Add(this.buttonDBPublicFolder);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormSettings";
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.FormSettings_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button buttonDBPublicFolder;
		private System.Windows.Forms.TextBox textBoxDBPublicPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxPublicURL;
	}
}

