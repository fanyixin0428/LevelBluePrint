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
        
        //��Ϊ�ļ������ڣ�����ȡ����Excel��Ϣ
        FileInfo fileInfo = new FileInfo(filePath);
        //ͨ��Excel�����ļ���Ϣ��Excel���
        using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))//��Excel���
        {
            //ȡ��Excel�ļ��еĵ�һ�ű�
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

            excelPackage.Save();
            //ȡ�ñ��е�һ�е�һ���е�����

        }//�ر�Excel���

        
    }


}
