using System.Collections.Generic;
using UnityEngine;

namespace Example_01.Scripts
{
	public class ExcelData : ScriptableObject
	{
		public List<ExcelDataSheet> sheets = new List<ExcelDataSheet>();
	}

	[System.Serializable]
	public class ExcelDataSheet
	{
		[Tooltip("Sheet页名称")] public string name;
		[Tooltip("Sheet页具体内容")] public List<ExcelDataInfo> list;
	}

	[System.Serializable]
	public class ExcelDataInfo
	{
		[Tooltip("行")] public int row;
		[Tooltip("列")] public int col;
		[Tooltip("内容")] public string text;
	}
}
