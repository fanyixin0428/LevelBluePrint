using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 辅助功能类
/// </summary>
public static class LevelBluePrintUtils
{
    /// <summary>
    ///  删除 ScriptableObject 对象
    /// </summary>
    /// <param name="obj"></param>
    public static void DeleteSelf(this ScriptableObject obj)
    {
        string name = obj.name;
        AssetDatabase.TryGetGUIDAndLocalFileIdentifier(obj, out string guid, out long localId);
        if (guid == null)
        {
            Debug.LogWarning("未找到删除对象 guid");
            return;
        }

        string path = AssetDatabase.GUIDToAssetPath(guid);
        AssetDatabase.DeleteAsset(path);
        Debug.Log("删除成功: " + name);
    }
    
    /// <summary>
    /// 浅层数据拷贝
    /// </summary>
    /// <param name="self"></param>
    /// <param name="other"></param>
    public static void Clone(this BasicProperty self, ref BasicProperty other)
    {
        other = new BasicProperty();
    }

    /// <summary>
    /// 是否存在对应文件
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static bool HasFile(this string path)
    {
        return File.Exists(Path.GetFullPath(path));
    }
    
    // 获取全局路径
    public static string GetFullPath(this string path)
    {
        String[] relPath = path.Split('/');
        String[] absPath = Application.dataPath.Split('/');

        var filePath = new StringBuilder();
        int count = 1;
        for (int i = 0; i < relPath.Length; i++)
        {
            if (relPath[i].Equals(".."))
            {
                count++;
            }
            else
                break;
        }

        for (int i = 0; i < absPath.Length - count; i++)
        {
            filePath.Append(absPath[i]);
            filePath.Append("/");
        }

        for (int i = count - 1; i < relPath.Length; i++)
        {
            filePath.Append(relPath[i]);
            if ((i + 1) < relPath.Length)
                filePath.Append("/");
        }

        return filePath.ToString();
    }

    /// <summary>
    /// 创建 ScriptObject asset
    /// </summary>
    /// <param name="foldPath"></param>
    /// <typeparam name="T"></typeparam>
    public static T CreateScriptObject<T>(string foldPath, string fileName = "") where T : ScriptableObject
    {
        CheckFold(foldPath);
        Type type = typeof(T);
        string path = foldPath + (fileName.Equals("") ? type.Name : fileName) + ".asset";
        var asset = AssetDatabase.LoadAssetAtPath(path, type);
        if (asset != null)
            AssetDatabase.DeleteAsset(path);
            
        var instance = ScriptableObject.CreateInstance<T>();
        AssetDatabase.CreateAsset(instance, path);
        AssetDatabase.Refresh();

        return instance;
    }

    /// <summary>
    /// 传入数据创建对象
    /// </summary>
    /// <param name="data"></param>
    /// <param name="foldPath"></param>
    /// <param name="fileName"></param>
    /// <typeparam name="T"></typeparam>
    public static void CreateScriptableObject<T>(T data, string foldPath, string fileName) where T : ScriptableObject
    {
        CheckFold(foldPath);
        string path = foldPath + "/" + fileName + ".asset";
        var asset = AssetDatabase.LoadAssetAtPath(path, typeof(T));
        if (asset != null)
            AssetDatabase.DeleteAsset(path);
        
        AssetDatabase.CreateAsset(data, path);
        AssetDatabase.Refresh();
    }

    /// <summary>
    /// 创建路径
    /// </summary>
    /// <param name="foldPath"></param>
    public static void CheckFold(string foldPath)
    {
        if (Directory.Exists(foldPath))
            return;
        
        Directory.CreateDirectory(foldPath);
    }

}
