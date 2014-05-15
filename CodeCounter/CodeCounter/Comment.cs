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
	/// a class defines what type of files will be scaned, and generates certain needed informations of the supported formats
	/// </summary>
	public class Comment
	{
		private static Hashtable formats=new Hashtable();
		private static string FileFilter;
		private static bool HasLoaded=false;
		private static List<string> supportedformats=new List<string>();
		public Comment()
		{

		}
        //loads the types that are supported
		private static void Load()
		{
			var csharp=new CodeFile("C #","cs",@"//","/*","*/");
			formats.Add(csharp.FileFormat,csharp);
			var java=new CodeFile("Java","java",@"//","/*","*/");
			formats.Add(java.FileFormat,java);
			var sql=new CodeFile("SQL","sql",@"--","/*","*/");
			formats.Add(sql.FileFormat,sql);
            foreach (string extention in formats.Keys)
            { 
                supportedformats.Add(extention);
            }

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
        //get the information of a type by its extention
		public static CodeFile GetByFormat(string format)
		{
			if(HasLoaded==false)
			{
				Load();
				HasLoaded=true;
			}
			return (CodeFile)formats["java"];
		}
		public static List<string> SupportedFormats()
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
