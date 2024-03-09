using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SampleTextManager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI npcName;
    public Image npcIcon;

    public string iconID;
    private void Start()
    {
        npcIcon.sprite = Resources.Load<Sprite>($"Album/{iconID}");
    }

    public Queue<string> stringQueue;

    public void StartText(SampleText[] sampleTexts) 
    {
        //npcNameText.text = sampleTexts[0].npcName;
    textComponent.text = sampleTexts[0].sentenences[0];
                      // ���� ������ 0-0�� �����´�.
                      // ���� sampleTexts �� �з�
       // foreach(string sentecne in sampleTexts.sentecne) {}
    }

}

