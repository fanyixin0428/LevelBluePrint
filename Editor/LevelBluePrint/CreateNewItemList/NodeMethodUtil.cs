using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using PhotonfoxUtil;
using UnityEngine;

/// <summary>
/// 存放 node 公用方法
/// </summary>
public static class NodeMethodUtil
{



    public static string StringOnly(string s)
    {
        if (string.IsNullOrEmpty(s) || !Regex.IsMatch(s, @"^([a-zA-Z_]+)([a-zA-Z0-9])$"))
        {
            return "";
        }

        return s;
    }

    public static string ClassNameOnly(string s)
    {
        if (string.IsNullOrEmpty(s) || !Regex.IsMatch(s, @"^([A-Z])([A-Za-z]+)([a-zA-Z0-9])$"))
        {
            return "";
        }

        return s;
    }
    
    /// <summary>
    /// 创建文件 fileName + extend, 强制重新生成
    /// </summary>
    /// <param name="folderPath"></param>
    /// <param name="fileName"></param>
    public static string Delete(string folderPath, string fileName)
    {
        if (string.IsNullOrEmpty(folderPath) || string.IsNullOrEmpty(fileName))
        {
            Debug.LogError("[NodeMethodUtil] 参数丢失");
            return "";
        }

        var filePath = Application.dataPath.Replace("Assets", folderPath);
        filePath = string.Format("{0}{1}", filePath, fileName);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        return filePath;
    }
}
