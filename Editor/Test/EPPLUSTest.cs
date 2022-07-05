using System.Collections;
using System.Collections.Generic;
using OfficeOpenXml;
using System.IO;
using UnityEngine;

public class EPPLUSTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string filePath = @"Assets\Test\TestExcel.xlsx";
        //获取Excel文件信息
        FileInfo fileInfo = new FileInfo(filePath);
        //通过Excel表格的文件信息打开Excel表格
        using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))//打开Excel表格
        {
            //取得Excel文件中的第一张表
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[1];

            //取得表中第一行第一列中的数据
            string s = worksheet.Cells[1, 1].Value.ToString();

            //Debug.Log(s);

            for (int i = 1; i < 4; i++)
            {
                Debug.Log(worksheet.Cells[i, 1].Value.ToString());
                Debug.Log(worksheet.Cells[i, 2].Value.ToString());
                Debug.Log(worksheet.Cells[i, 3].Value.ToString());
            }
        
        }//关闭Excel表格

        
    }


}
