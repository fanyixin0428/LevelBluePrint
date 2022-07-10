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
		[Tooltip("Sheetҳ����")] public string name;
		[Tooltip("Sheetҳ��������")] public List<ExcelDataInfo> list;
	}

	[System.Serializable]
	public class ExcelDataInfo
	{
		[Tooltip("��")] public int row;
		[Tooltip("��")] public int col;
		[Tooltip("����")] public string text;
	}
}
