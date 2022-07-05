using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

/// <summary>
/// 自定义设置，目前仅用于提供 toolbar 的两个按钮设置
/// </summary>
public interface ICustomSetting
{
    string AddName
    {
        get;
        set;
    }

    string RemoveName
    {
        get;
        set;
    }

    // toolbar add button method
    void Add(OdinMenuEditorWindow window);

    // toolbar remove button method
    void Remove(OdinMenuItem selected);
}
