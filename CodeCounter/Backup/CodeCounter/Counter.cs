/*
 * Created by SharpDevelop.
 * User: wr8662
 * Date: 4/15/2014
 * Time: 9:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections;
using System.Text;
namespace CodeCounter
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Counter:IDisposable
	{
		private int NumLine;
		private int TotalNumLine;
		private bool CommentBlock;
		private object LockObject=new object();
		private StringBuilder report;
		private string CurrentFormat;
		//public section
		//split line, programmer can customize
		public string SplitLine="-----------------------------------------------------------"+Environment.NewLine;
		public static string[] FileFormat;//=Comment.SupportedFormats()
		public static Hashtable SupportFormats=Comment.AllSupportedCodeFile();
		//public static string FileFilter=Comment.FileNameFilter();
		public string Report{
			get{
				return report.ToString();
			}
		}
		public Counter()
		{
			NumLine=0;
			TotalNumLine=0;
			CommentBlock=false;
			report=new StringBuilder();
		}
		public int CountSingleFile(string path)
		{
			try
			{
				string ext=path.Substring(path.LastIndexOf('.')+1);
				CurrentFormat=ext;
				return Count(File.ReadAllLines(path));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int CountWholeFolder(string path)
		{
			TotalNumLine=0;
			report.Remove(0,report.Length);
			CountFolder(path);
			return TotalNumLine;
		}
		private void CountFolder(string path)
		{
			lock(LockObject)
			{
				string []dirs;
				try{
					dirs=Directory.GetDirectories(path);
				}
				catch(Exception ex)
				{
					report.Append(Environment.NewLine+"Couldn't access the path:"+path+ex.Message+Environment.NewLine);
					return;
				}
				foreach(var folder in dirs)
				{
					CountFolder(folder);
				}
				var files=Directory.GetFiles(path);
				foreach (var file in files)
				{
					string fi=file.ToLower();
					string ext;
					try{
						ext=fi.Substring(fi.LastIndexOf('.')+1);
						CurrentFormat=ext;
						
					}
					catch(Exception ex)
					{
						report.Append("Invalid File Name:"+ex.Message+"\n");
						continue;
						
					}
					if(IsFormatAllowed(ext))
					{//start to count
						report.Append("Path:"+file+Environment.NewLine);
						report.Append("Number of lines:"+CountSingleFile(file)+Environment.NewLine);
						report.Append(this.SplitLine);
						TotalNumLine+=NumLine;
					}
				}
			}
		}
		private bool IsFormatAllowed(string ext)
		{
			foreach(var format in FileFormat)
			{
				if(ext==format)
					return true;
			}
			return false;
		}
		public int Count(string [] lines)
		{
			lock(LockObject)
			{
				NumLine=0;
				for(int i=0;i<lines.Length;i++)
					if(IsCode(lines[i]))
						NumLine++;
			}
			return NumLine;
		}
		private bool IsCode(string line)
		{
			if(!IsComment(line)&&line.Trim().Length!=0)
				return true;
			else 
				return false;
		}
		private bool IsComment(string line)
		{
			lock(LockObject)
			{
				if(CommentBlock==true)
				{
					if(line.Contains(Comment.GetByFormat(CurrentFormat).AreaEndSymbal))
					{
						CommentBlock=false;
						//it's where a comment block ends
						//this line is still a comment
						//so return true
						return true;
					}
				}
				else
				{
					if(line.Contains(Comment.GetByFormat(CurrentFormat).AreaStartSymbol))
					{
						CommentBlock=true;
						//detected where the comment block start
						//this line is counted comment
						return true;
					}
				}
				//after updating the value of CommentBlock
				//I can use it the tell 
				if(CommentBlock==true)
					return true;
				if(line.Trim().IndexOf(Comment.GetByFormat(CurrentFormat).SingleLineSymbol)==0)
					return true;
				else 
					return false;
			}
		}
		public void Dispose()
		{
		}
		 ~Counter()
		{
			
		}
	}
}
