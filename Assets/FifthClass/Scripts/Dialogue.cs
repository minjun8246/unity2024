using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Dialogue
{
    public int sceneID;
    public string name;
    public string ImageName;

    [TextArea(3, 10)]
    public string[] sentences;
}

[System.Serializable]
public class DialogueList
{
    public Dialogue[] dialogues;
}
