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
using System.Text;
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
			//-------------------------------------------------------------------
            //list the supported file formats with checkbox
			LoadSelections();	
		}
        private enum FilterGenerator { All,SelectedFormats};
		void MainFormLoad(object sender, EventArgs e)
		{
			//PathBox.Text=@"C:\Users\wr8662\Desktop\Files\Java\CalcComponent.java";
		}
        //generates a list of supported file formats and display on the panel
		void LoadSelections()
		{
			int left=0;
			int width=60;
			foreach(CodeFile se in Counter.SupportFormats.Values)
			{
				CheckBox c=new CheckBox();
				c.Text= "*."+se.FileFormat;
				c.Left=left;
				c.Width=width;
				left+=width;
                if (se.FileFormat == "cs")
                    c.Checked = true;
				FormatSelection.Controls.Add(c);
			}
		}
        //check what kind of files formats are selected by the user
        //and assign it to the the Counter's static field 'FileFormat' as a filter when it's scanning folders
		void GenerateFilter(FilterGenerator op)
		{
            if (op == FilterGenerator.SelectedFormats)
            {
                var formats = new List<string>();
                foreach (CheckBox cb in FormatSelection.Controls)
                {
                    if (cb.Checked)
                        formats.Add(cb.Text.Replace("*.", ""));
                }
                Counter.FileFormat = formats;
            }
            else
            {
                Counter.FileFormat = Comment.SupportedFormats();       
            }
		}
		void BrowseButtonClick(object sender, EventArgs e)
		{
			//MessageBox.Show(Counter.FileFilter);
            //since, the user has selected to just scan one file, it allows all the file formats when 
            // 
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
                //count a single file
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
                GenerateFilter(FilterGenerator.All);
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
                GenerateFilter(FilterGenerator.SelectedFormats);
                ////-------------------------------------------------------
                //Create a Thread and start a thread here
				Thread ScanFolder=new Thread (()=>CountFolderTask(FolderPathBox.Text.Trim()));
				ScanFolder.Start();
				LoadingPanel.Visible=true;	
			}
		}
        //this function will be send to the UI thread to be invoked by the new thread 
		void UpdateReport(string text)
		{
			PrintReport(text);
			LoadingPanel.Visible=false;
			
		}//the function that is run in the new thread
		void CountFolderTask(string path)
		{
				Counter count=new Counter ();
				int total=count.CountWholeFolder(path);
				UpdateResult handler=new UpdateResult(this.UpdateReport);
				string result="Total: "+total +" Lines"+Environment.NewLine+count.SplitLine+count.SplitLine+count.Report;
				this.OutputArea.Invoke(handler,result);
		}
        //write the file to the selected path
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
