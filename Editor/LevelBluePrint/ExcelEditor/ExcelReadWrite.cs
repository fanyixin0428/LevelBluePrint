using UnityEngine;
using ExcelDataReader;
using System.IO;
using System.Data;
using System;
using System.Collections.Generic;

namespace LevelBluePrintUtil
{ 
    
    public class ExcelReadWrite
    {
        public ItemList itemList = new ItemList();
        
        
        public void testExcelReadWrite()
        {
            string excelPath = Path.Combine(Application.dataPath, "ExcelTest.xlsx");
            string excelSheetName = "Sheet1";

            var excelRowData = ReadExcel(excelPath, excelSheetName);
            itemList.itemList = ParseDataToScriptableObject(excelRowData);

        }

        List<Item> ParseDataToScriptableObject(DataRowCollection excelData)
        {
            List<Item> itemList = new List<Item>();
            Item item;

            for (int i = 1; i < excelData.Count; i++)
            {
                item = new Item();
                item.itemID = Int32.Parse(excelData[i][0].ToString());
                item.comment = excelData[i][2].ToString();
                item.itmeName = excelData[i][4].ToString();
                //输出第一行

                itemList.Add(item);
            }

            return itemList;
        }

        DataRowCollection ReadExcel(string excelPath,string excelSheet)
        {
            using (FileStream fileStream = File.Open(excelPath, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);

                var result = excelReader.AsDataSet();

                return result.Tables[excelSheet].Rows;
            }

        }
    }

    [Serializable]
    public class ItemList 
    {
        public List<Item> itemList = new List<Item>();
    }

    [Serializable]
    public class Item
    {
        public int itemID;
        public string comment;
        public string itmeName;

    }
}