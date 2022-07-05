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
        //��ȡExcel�ļ���Ϣ
        FileInfo fileInfo = new FileInfo(filePath);
        //ͨ��Excel�����ļ���Ϣ��Excel���
        using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))//��Excel���
        {
            //ȡ��Excel�ļ��еĵ�һ�ű�
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[1];

            //ȡ�ñ��е�һ�е�һ���е�����
            string s = worksheet.Cells[1, 1].Value.ToString();

            //Debug.Log(s);

            for (int i = 1; i < 4; i++)
            {
                Debug.Log(worksheet.Cells[i, 1].Value.ToString());
                Debug.Log(worksheet.Cells[i, 2].Value.ToString());
                Debug.Log(worksheet.Cells[i, 3].Value.ToString());
            }
        
        }//�ر�Excel���

        
    }


}
