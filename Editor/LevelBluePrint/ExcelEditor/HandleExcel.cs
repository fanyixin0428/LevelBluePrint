using System;
using System.Collections.Generic;
using System.IO;
using Example_01.Scripts;
using OfficeOpenXml;
using UnityEditor;
using UnityEngine;

public class HandleExcel
{
	/// <summary>
	/// ��ȡExcel���ݲ�����Asset��̬��Դ�ļ�
	/// </summary>
	[MenuItem("Assets/Excel/Create Asset File", false, 2)]

	public static void CreateExcelData()
	{
		ExcelData script = ScriptableObject.CreateInstance<ExcelData>();
		string[] ids = Selection.assetGUIDs;
		foreach (var id in ids)
		{
			string path = $"{Environment.CurrentDirectory}/{AssetDatabase.GUIDToAssetPath(id)}";

			using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

			//ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			using ExcelPackage excel = new ExcelPackage(fs);

			// ��ȡSheet����
			ExcelWorksheets worksheets = excel.Workbook.Worksheets;
			foreach (var worksheet in worksheets)
			{
				List<ExcelDataInfo> list = new List<ExcelDataInfo>();

				int colCount = worksheet.Dimension.End.Column;
				int rowCount = worksheet.Dimension.End.Row;
				for (int row = 1; row <= rowCount; row++)
				{
					for (int col = 1; col <= colCount; col++)
					{
						string text = worksheet.Cells[row, col].Text;
						list.Add(new ExcelDataInfo {
							row = row,
							col = col,
							text = text
						});
					}
				}

				script.sheets.Add(new ExcelDataSheet {
					name = worksheet.Name,
					list = list
				});
			}
		}

		// ����ת����json
		string json = JsonUtility.ToJson(script.sheets);
		Debug.Log(json);
		// jsonת���ɶ���
		List<ExcelDataInfo> data = JsonUtility.FromJson<List<ExcelDataInfo>>(json);
		Debug.Log(data);

		// ����Դ���浽����
		string savePath =
			$"Assets/Example_01/Resources/ExcelAssetData {DateTime.Now:yyyy-MM-dd hhmmss}.asset";
		AssetDatabase.CreateAsset(script, savePath);
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
	}
}
