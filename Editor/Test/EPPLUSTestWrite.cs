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
        //��ȡExcel�ļ���Ϣ
        FileInfo fileInfo = new FileInfo(filePath);
        //ͨ��Excel�����ļ���Ϣ��Excel���
        using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))//��Excel���
        {
            //ȡ��Excel�ļ��еĵ�һ�ű�
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[1];

            //ȡ�ñ��е�һ�е�һ���е�����
            worksheet.Cells[4, 1].Value = "Ŷ��";

            //Debug.Log(s);
            excelPackage.Save();

        }//�ر�Excel���

        
    }


}
