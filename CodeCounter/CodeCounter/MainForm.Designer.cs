/*
 * Created by SharpDevelop.
 * User: wr8662
 * Date: 4/15/2014
 * Time: 9:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CodeCounter
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PathBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.OpenFilePath = new System.Windows.Forms.OpenFileDialog();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.OutputArea = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.FilePanel = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.FormatSelection = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.StartFolders = new System.Windows.Forms.Button();
            this.BrowseFolder = new System.Windows.Forms.Button();
            this.FolderPathBox = new System.Windows.Forms.TextBox();
            this.OpenFolderPath = new System.Windows.Forms.FolderBrowserDialog();
            this.LoadingPanel = new System.Windows.Forms.Panel();
            this.LoadingLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SaveReport = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.FilePanel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.LoadingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PathBox
            // 
            this.PathBox.Enabled = false;
            this.PathBox.Location = new System.Drawing.Point(2, 26);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(337, 20);
            this.PathBox.TabIndex = 0;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(152, 52);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButtonClick);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(345, 23);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(96, 23);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Browse My FIles";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButtonClick);
            // 
            // OutputArea
            // 
            this.OutputArea.Location = new System.Drawing.Point(10, 146);
            this.OutputArea.Multiline = true;
            this.OutputArea.Name = "OutputArea";
            this.OutputArea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputArea.Size = new System.Drawing.Size(448, 165);
            this.OutputArea.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.FilePanel);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(10, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(452, 133);
            this.tabControl1.TabIndex = 4;
            // 
            // FilePanel
            // 
            this.FilePanel.Controls.Add(this.label2);
            this.FilePanel.Controls.Add(this.PathBox);
            this.FilePanel.Controls.Add(this.StartButton);
            this.FilePanel.Controls.Add(this.BrowseButton);
            this.FilePanel.Location = new System.Drawing.Point(4, 22);
            this.FilePanel.Name = "FilePanel";
            this.FilePanel.Padding = new System.Windows.Forms.Padding(3);
            this.FilePanel.Size = new System.Drawing.Size(444, 107);
            this.FilePanel.TabIndex = 0;
            this.FilePanel.Text = "File";
            this.FilePanel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(20, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "The File scaning will only scan the selected file.";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.FormatSelection);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.StartFolders);
            this.tabPage2.Controls.Add(this.BrowseFolder);
            this.tabPage2.Controls.Add(this.FolderPathBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(444, 107);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Folder";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormatSelection
            // 
            this.FormatSelection.Location = new System.Drawing.Point(5, 78);
            this.FormatSelection.Name = "FormatSelection";
            this.FormatSelection.Size = new System.Drawing.Size(432, 23);
            this.FormatSelection.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "The Folder scaning will scan all the files whose format is supported in the selec" +
    "ted folder. ";
            // 
            // StartFolders
            // 
            this.StartFolders.Location = new System.Drawing.Point(152, 52);
            this.StartFolders.Name = "StartFolders";
            this.StartFolders.Size = new System.Drawing.Size(75, 23);
            this.StartFolders.TabIndex = 4;
            this.StartFolders.Text = "Start";
            this.StartFolders.UseVisualStyleBackColor = true;
            this.StartFolders.Click += new System.EventHandler(this.StartFoldersClick);
            // 
            // BrowseFolder
            // 
            this.BrowseFolder.Location = new System.Drawing.Point(322, 23);
            this.BrowseFolder.Name = "BrowseFolder";
            this.BrowseFolder.Size = new System.Drawing.Size(116, 23);
            this.BrowseFolder.TabIndex = 3;
            this.BrowseFolder.Text = "Browse My Folders";
            this.BrowseFolder.UseVisualStyleBackColor = true;
            this.BrowseFolder.Click += new System.EventHandler(this.BrowseFolderClick);
            // 
            // FolderPathBox
            // 
            this.FolderPathBox.Enabled = false;
            this.FolderPathBox.Location = new System.Drawing.Point(3, 26);
            this.FolderPathBox.Name = "FolderPathBox";
            this.FolderPathBox.Size = new System.Drawing.Size(313, 20);
            this.FolderPathBox.TabIndex = 0;
            // 
            // LoadingPanel
            // 
            this.LoadingPanel.Controls.Add(this.LoadingLabel);
            this.LoadingPanel.Location = new System.Drawing.Point(4, 81);
            this.LoadingPanel.Name = "LoadingPanel";
            this.LoadingPanel.Size = new System.Drawing.Size(461, 59);
            this.LoadingPanel.TabIndex = 5;
            this.LoadingPanel.Visible = false;
            // 
            // LoadingLabel
            // 
            this.LoadingLabel.Location = new System.Drawing.Point(18, 6);
            this.LoadingLabel.Name = "LoadingLabel";
            this.LoadingLabel.Size = new System.Drawing.Size(438, 30);
            this.LoadingLabel.TabIndex = 0;
            this.LoadingLabel.Text = "Please wait........\r\nThe Code Counter is counting all the files in this folder.\r\n" +
    "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 315);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Export as a txt file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 340);
            this.Controls.Add(this.LoadingPanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.OutputArea);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "CodeCounter";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.tabControl1.ResumeLayout(false);
            this.FilePanel.ResumeLayout(false);
            this.FilePanel.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.LoadingPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Panel FormatSelection;
		private System.Windows.Forms.SaveFileDialog SaveReport;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel LoadingPanel;
		private System.Windows.Forms.Label LoadingLabel;
		private System.Windows.Forms.TextBox FolderPathBox;
		private System.Windows.Forms.OpenFileDialog OpenFilePath;
		private System.Windows.Forms.FolderBrowserDialog OpenFolderPath;
		private System.Windows.Forms.Button BrowseFolder;
		private System.Windows.Forms.Button StartFolders;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage FilePanel;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TextBox PathBox;
		private System.Windows.Forms.Button StartButton;
		private System.Windows.Forms.Button BrowseButton;
		private System.Windows.Forms.TextBox OutputArea;
		

		

	}
}
