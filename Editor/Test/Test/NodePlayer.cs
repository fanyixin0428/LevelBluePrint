using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodePlayer : MonoBehaviour
{
    public DialogGragh gragh;

    public DialogNode StartNode;

    public DialogNode currentNode;

    public Text ID;
    
    public Text username;

    public Text content;

    public 

    void Start()
    {
        for (int i = 0; i < gragh.nodes.Count; i++)
        {
            if (gragh.nodes[i] is DialogNode)
            {
                DialogNode node = gragh.nodes[i] as DialogNode;
                if (node.ID ==1)
                {
                    StartNode = node;
                }
            }
        }
        currentNode = StartNode;
    }

    private bool isShow;
    public void ButtonClick()
    {
        if (currentNode == StartNode && !isShow)
        {
            ShowContent();
        }
        if (currentNode.GetPort(fieldName: "exit").Connection == null)
        {
            Debug.Log(message: "¶Ô»°½áÊø");
                return;
        }

        currentNode = currentNode.GetPort(fieldName: "exit").Connection.node as DialogNode;

        ShowContent();

    }

    private void ShowContent()
    {
        ID.text = "ID: " + currentNode.ID;
        username.text = "Name: " + currentNode.username;
        content.text = "Content: " + currentNode.content;
    }
}
