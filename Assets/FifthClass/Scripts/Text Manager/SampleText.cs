using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SampleText
{
    // NPC�̸�
    public string npcName;
    // NPC ������ �̹����� �̸�
    public string ImageName;
    // NPC�� ��ȭ�� ����
    public string[] sentenences;
}

public class SampleTaxeList 
{
    public SampleText[] sampleTexts;
}