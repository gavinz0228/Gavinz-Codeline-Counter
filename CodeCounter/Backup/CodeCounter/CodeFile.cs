﻿/*
 * Created by SharpDevelop.
 * User: wr8662
 * Date: 4/15/2014
 * Time: 3:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace CodeCounter
{
	/// <summary>
	/// Description of CodeFile.
	/// </summary>
	public class CodeFile
	{
		public string FileFormat{get;set;}
		public string FileType{get;set;}
		public string SingleLineSymbol{get;set;}
		public string AreaStartSymbol{get;set;}
		public string AreaEndSymbal{get;set;}
		public CodeFile(string type,string format,string linesymbol,string areastart,string areaend)		
		{
			FileType=type;
			FileFormat=format;
			SingleLineSymbol=linesymbol;
			AreaStartSymbol=areastart;
			AreaEndSymbal=areaend;
		}
	}
}
