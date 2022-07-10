//�ű�������
using System.IO;
using System.Text;
using UnityEngine;


class ScriptGenerator
{
    public static string _codePath = Application.dataPath + "/Worksheets/Manager/";
    public string[] Fileds;
    public string[] Types;
    public string ClassName;

    public ScriptGenerator(string className, string[] fileds, string[] types)
    {
        ClassName = className;
        Fileds = fileds;
        Types = types;
    }

    public string Generate()
    {
        if (Types == null || Fileds == null || ClassName == null)
            return null;
        string arg = CreateCode(ClassName, Types, Fileds);
        // EditorGenerate(arg);
        return arg;
    }

    //��������
    private string CreateCode(string tableName, string[] types, string[] fields)
    {
        //������
        StringBuilder classSource = new StringBuilder();
        classSource.Append("/*Auto create\n");
        classSource.Append("Don't Edit it*/\n");
        classSource.Append("\n");
        classSource.Append("using System;\n");
        classSource.Append("using System.Reflection;\n");
        classSource.Append("using System.Collections.Generic;\n");
        classSource.Append("[Serializable]\n");
        classSource.Append("public class " + tableName + "\n");
        classSource.Append("{\n");
        //���ó�Ա
        for (int i = 0; i < fields.Length; ++i)
        {
            classSource.Append(PropertyString(types[i], fields[i]));
        }

        classSource.Append("}\n");

        //����Container
        classSource.Append("\n");
        classSource.Append("[Serializable]\n");
        classSource.Append("public class " + tableName + "Container\n");
        classSource.Append("{\n");
        classSource.Append("\tpublic " + "Dictionary<int, " + tableName + ">" + " Dict" + " = new Dictionary<int, " +
                           tableName + ">();\n");
        classSource.Append("}\n");
        return classSource.ToString();
    }

    private string PropertyString(string type, string propertyName)
    {
        if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(propertyName))
            return null;
        StringBuilder sbProperty = new StringBuilder();
        sbProperty.Append("\tpublic " + type + " " + propertyName + ";\n");
        return sbProperty.ToString();
    }

    public void EditorGenerate(string scripts)
    {
        string csPath = _codePath + $"{ClassName}.cs";
        string dstDir = Path.GetDirectoryName(csPath);
        if (!Directory.Exists(dstDir))
        {
            Directory.CreateDirectory(dstDir);
        }

        File.WriteAllText(csPath, scripts);
    }
}