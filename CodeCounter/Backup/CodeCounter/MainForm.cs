/*
 * Created by SharpDevelop.
 * User: wr8662
 * Date: 4/15/2014
 * Time: 9:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;
namespace CodeCounter
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		delegate void UpdateResult(string text);
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			LoadSelections();
			
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			//PathBox.Text=@"C:\Users\wr8662\Desktop\Files\Java\CalcComponent.java";
		}
		void LoadSelections()
		{
			int left=0;
			int width=80;
			foreach(CodeFile se in Counter.SupportFormats.Values)
			{
				CheckBox c=new CheckBox();
				c.Text= se.FileType+"(*."+se.FileFormat+")";
				c.Left=left;
				c.Width=width;
				left+=width;
				FormatSelection.Controls.Add(c);
	
			}
		}
		string GenerateFilter()
		{
			
		}
		void BrowseButtonClick(object sender, EventArgs e)
		{
			MessageBox.Show(Counter.FileFilter);
			OpenFilePath.Filter=Counter.FileFilter;
			if(OpenFilePath.ShowDialog()==DialogResult.OK)
			{
				PathBox.Text=OpenFilePath.FileName;
			}
		}
		
		void StartButtonClick(object sender, EventArgs e)
		{
			
			try
			{
				Counter count=new Counter ();
				int result=count.CountSingleFile(PathBox.Text.Trim());
				PrintReport("File: "+PathBox.Text+Environment.NewLine+"Total Lines:"+result.ToString());
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void BrowseFolderClick(object sender, EventArgs e)
		{
			if(OpenFolderPath.ShowDialog()==DialogResult.OK)
			{
				FolderPathBox.Text=OpenFolderPath.SelectedPath;
			}
					
		}
		void PrintReport (string text)
		{
			OutputArea.Text=text;
		}
		void StartFoldersClick(object sender, System.EventArgs e)
		{
			if(FolderPathBox.Text.Trim()!="")
			{
				
				Thread ScanFolder=new Thread (()=>CountFolderTask(FolderPathBox.Text.Trim()));
				ScanFolder.Start();
				LoadingPanel.Visible=true;	
			}
		}
		void UpdateReport(string text)
		{
			PrintReport(text);
			LoadingPanel.Visible=false;
			
		}
		void CountFolderTask(string path)
		{
				Counter count=new Counter ();
				int total=count.CountWholeFolder(path);
				UpdateResult handler=new UpdateResult(this.UpdateReport);
				string result="Total: "+total +" Lines"+Environment.NewLine+count.SplitLine+count.SplitLine+count.Report;
				this.OutputArea.Invoke(handler,result);
		}
		void Button1Click(object sender, System.EventArgs e)
		{
			SaveReport.FileName="Code Counter Report.txt";
			if(SaveReport.ShowDialog()==DialogResult.OK)
			{
				File.WriteAllText(SaveReport.FileName,OutputArea.Text);
				MessageBox.Show("The Report has been successfully saved.");
			}
		}

	}
}
