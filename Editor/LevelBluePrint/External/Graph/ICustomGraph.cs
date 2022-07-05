using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Graph 自定义接口
/// </summary>
public interface ICustomGraph
{
    /// <summary>
    /// 当设置属性更改时，同步到下属的 node 中
    /// </summary>
    void UpdateData();
}