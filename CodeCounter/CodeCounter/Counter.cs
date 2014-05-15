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
using System.Collections.Generic;

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
		// this is the list of formats that are selected by the user, so, let the mainform to assign the value to it
        public static List<string> FileFormat;//=Comment.SupportedFormats()
		public static Hashtable SupportFormats=Comment.AllSupportedCodeFile();
		public static string FileFilter=Comment.FileNameFilter();
		//the property of the return report
        public string Report{
			get{
				return report.ToString();
			}
		}
        //initialize the object
		public Counter()
		{
			NumLine=0;
			TotalNumLine=0;
			CommentBlock=false;
			report=new StringBuilder();
		}
        //count a single file, so there is no recursion
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
        //count the whole folder start the recursive function from here
		public int CountWholeFolder(string path)
		{
			TotalNumLine=0;
			report.Remove(0,report.Length);
			CountFolder(path);
			return TotalNumLine;
		}
        // the recursive function that is used to go through all files and folders in the current folder
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
                    //access dinial or something else is wrong.
					report.Append(Environment.NewLine+"Couldn't access the path:"+path+ex.Message+Environment.NewLine);
					return;
				}
				foreach(var folder in dirs)
				{
					CountFolder(folder);//recursion..
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
                        //there is no . or there is nothing after . so throw a exception
						report.Append("Invalid File Name:"+ex.Message+"\n");
						continue;
						
					}
					if(IsFormatAllowed(ext))
					{//print the needed information to the property Report
						report.Append("Path:"+file+Environment.NewLine);
						report.Append("Number of lines:"+CountSingleFile(file)+Environment.NewLine);
						report.Append(this.SplitLine);
						TotalNumLine+=NumLine;
					}
				}
			}
		}
        //iterate the supported format list see if it's contained
		private bool IsFormatAllowed(string ext)
		{
			foreach(var format in FileFormat)
			{
				if(ext==format)
					return true;
			}
			return false;
		}
        //mainly call the function IsCode() to check every line, and count
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
        //if it's not comment then is a line of code
		private bool IsCode(string line)
		{
			if(!IsComment(line)&&line.Trim().Length!=0)
				return true;
			else 
				return false;
		}
        //to check if the line is a single line comment or it's in a comment block
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
