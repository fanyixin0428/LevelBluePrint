using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
/// 基本属性配置
/// </summary>
[Serializable]
public class BasicProperty
{
    /// <summary>
    /// 标识 id
    /// </summary>

    /// <summary>
    /// 名称
    /// </summary>
    [LabelText("关卡名称")]
    public string name;

    [LabelText("关卡ID")]
    public int mapId;
}

