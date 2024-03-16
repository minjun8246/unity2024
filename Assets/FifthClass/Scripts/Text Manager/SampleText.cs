using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SampleText
{
    // NPC이름
    public string npcName;
    // NPC 아이콘 이미지의 이름
    public string ImageName;
    // NPC가 대화할 문장
    public string[] sentences;
}

public class SampleTaxeList 
{
    public SampleText[] sampleTexts;
}