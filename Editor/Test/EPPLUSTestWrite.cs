using System.Collections;
using System.Collections.Generic;
using OfficeOpenXml;
using System.IO;
using UnityEngine;

public class EPPLUSTestWrite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string filePath = "Assets/Editor/LevelBluePrint/Excel/";
        //获取Excel文件信息
        FileInfo fileInfo = new FileInfo(filePath);
        //通过Excel表格的文件信息打开Excel表格
        using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))//打开Excel表格
        {
            //取得Excel文件中的第一张表
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[1];

            //取得表中第一行第一列中的数据
            worksheet.Cells[4, 1].Value = "哦豁";

            //Debug.Log(s);
            excelPackage.Save();

        }//关闭Excel表格

        
    }


}
