using System.Collections;
using System.Collections.Generic;
using OfficeOpenXml;
using System.IO;
using UnityEngine;

public class EPPLUSTestCreate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string filePath = @"Assets\Test\TestExcelCreate.xlsx";
        
        //因为文件不存在，所以取不到Excel信息
        FileInfo fileInfo = new FileInfo(filePath);
        //通过Excel表格的文件信息打开Excel表格
        using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))//打开Excel表格
        {
            //取得Excel文件中的第一张表
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

            excelPackage.Save();
            //取得表中第一行第一列中的数据

        }//关闭Excel表格

        
    }


}
