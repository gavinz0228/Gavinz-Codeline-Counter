/*
 * Created by SharpDevelop.
 * User: wr8662
 * Date: 4/15/2014
 * Time: 2:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace CodeCounter
{
	/// <summary>
	/// Defines the comment symbal
	/// </summary>
	public class Comment
	{
		private static Hashtable formats=new Hashtable();
		private static string FileFilter;
		private static bool HasLoaded=false;
		private static string [] supportedformats;
		public Comment()
		{

		}
		private static void Load()
		{
			var csharp=new CodeFile("C #","cs",@"//","/*","*/");
			formats.Add(csharp.FileFormat,csharp);
			var java=new CodeFile("Java","java",@"//","/*","*/");
			formats.Add(java.FileFormat,java);
			var sql=new CodeFile("SQL","sql",@"--","/*","*/");
			formats.Add(sql.FileFormat,sql);
			supportedformats=new string[formats.Keys.Count];
			formats.Keys.CopyTo(supportedformats,0);
			//generate a file format filter
			StringBuilder filter=new StringBuilder ();
			foreach(var f in formats.Values)
			{
				CodeFile cf=(CodeFile)f;
				filter.Append(cf.FileType+ " "+"("+cf.FileFormat+".*)|*."+cf.FileFormat+"|");
			}
			filter.Remove(filter.Length-1,1);
			FileFilter=filter.ToString();
		}
		public static CodeFile GetByFormat(string format)
		{
			if(HasLoaded==false)
			{
				Load();
				HasLoaded=true;
			}
			return (CodeFile)formats["java"];
		}
		public static string[] SupportedFormats()
		{
			if(HasLoaded==false)
			{
				Load();
				HasLoaded=true;
			}
			return supportedformats;
		}
		public static string FileNameFilter()
		{
			if(HasLoaded==false)
			{
				Load();
				HasLoaded=true;
			}
			return FileFilter;
		}
		public static Hashtable AllSupportedCodeFile()
		{
			if(HasLoaded==false)
			{
				Load();
				HasLoaded=true;
			}
			return formats;
		}
		
	}
}
