using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using Unity.Collections;
using UnityEditor;
using UnityEngine;


[Serializable]
public class CreateNewProperty : GlobalConfig<CreateNewProperty>
{
    [Sirenix.OdinInspector.FilePath]
    public string enumPath = "";
    
    // 兼容
    [HideInInspector]
    public string[] DefaultEnums = new[]
    {
        "Int",
        "String",
        "Float",
        "ActorID",
        "ArrayInt",
        "Boolean",
        "ArrayString",
        "AudioPlayData",
        "Vector2",
        "Node",
        "Direction"
    };
    
    [TableList]
    public List<DynamicProperty> NewEnums = new List<DynamicProperty>();
    
    [InfoBox("更新属性后，需要更新对应节点数据，请到 “创建新节点->查看” 更新对应节点")]
    [Button("更新可选属性", ButtonSizes.Large)]
    public void UpdateEnum()
    {
        if (string.IsNullOrEmpty(enumPath) || !enumPath.Contains("NodePropertyType"))
        {
            Debug.LogWarning("[CreateNewProperty] update failed");
            return;
        }

        var rawData = AssetDatabase.LoadAssetAtPath<TextAsset>(enumPath);
        if (rawData != null)
            AssetDatabase.DeleteAsset(enumPath);

        StringBuilder sb = new StringBuilder();
        sb.Append("/// <summary>\n");
        sb.Append("/// 节点属性类型\n");
        sb.Append("/// <summary>\n");

        sb.Append("public enum NodePropertyType\n");
        sb.Append("{\n");

        // default
        for (int i = 0; i < DefaultEnums.Length; i++)
        {
            sb.Append($"\t{DefaultEnums[i]},\n");
        }

        // new
        for (int i = 0; i < NewEnums.Count; i++)
        {
            sb.Append($"\t{NewEnums[i].Name},\n");
        }

        
        sb.Append("}");

        using (var sw = new StreamWriter(enumPath.Replace("Assets", Application.dataPath), false, Encoding.UTF8))
        {
            sw.Write(sb.ToString());
            sw.Close();
        }
        
        AssetDatabase.Refresh();
    }

    public DynamicProperty GetProperty(string propName)
    {
        var property = NewEnums.Find(e =>
        {
            return e.Name.Equals(propName);
        });

        return property;
    }

    public List<PropertyContent> GetPropertyContent(string propName)
    {
        var property = GetProperty(propName);
        return property?.contents;
    }

    public List<string> GetPropertyContentDesc(string propName)
    {
       var contents = GetPropertyContent(propName);
       var descs = new List<string>();
        
       contents?.ForEach(c =>
       {
           descs.Add(c.TypeDesc);
       });

       return descs;
    }

    public PropertyContent GetPropertyContent(string propName, string propDesc)
    {
        var contents = GetPropertyContent(propName);
        var prop = contents?.Find(c =>
        {
            return c.TypeDesc.Equals(propDesc);
        });

        if (prop == null)
            return new PropertyContent();

        return prop;
    }
    
}

// 属性参数类型
public enum PropertyParamType
{
    Int,
    String
}

[Serializable]
public class DynamicProperty
{
    [BoxGroup("Basic"), OnValueChanged("valueCheck")]
    public string Name;
    [BoxGroup("Basic"), OnValueChanged("onTypeChange")]
    public PropertyParamType PType;
    public List<PropertyContent> contents;

    private void onTypeChange()
    {
        contents.ForEach(f =>
        {
            f.isInt = PType == PropertyParamType.Int;
        });
    }

    private void valueCheck(string value)
    {
        Name = NodeMethodUtil.StringOnly(value);
    }
}

[Serializable]
public class PropertyContent
{
    public string TypeDesc;
    [ShowIf("isInt")]
    public int IntParam;
    [HideIf("isInt")]
    public string StringParam;
    [SerializeField, HideInInspector]
    public bool isInt = true;
}