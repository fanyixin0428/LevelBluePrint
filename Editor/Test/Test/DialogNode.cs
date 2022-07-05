using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DialogNode : Node {

    [Input] public int enter;
    [Output] public int exit;

    public int ID;

    public string username;

    [TextArea]
    public string content;

    public override object GetValue(NodePort port)
    {
        return null;
    }
}