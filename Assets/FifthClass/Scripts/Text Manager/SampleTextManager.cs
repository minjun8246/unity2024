using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SampleTextManager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI npcName;
    public Image npcIcon;

    public string iconID;

    public Queue<string> stringQueue;

    public float typeSpeed;
    private void Start()
    {
        //npcIcon.sprite = Resources.Load<Sprite>($"Album/{iconID}");
    }

    public GameObject TextPerent;

    private void Awake()
    {
        stringQueue = new Queue<string>();
    } 

    public void StartText(SampleText[] sampleTexts) 
    {
        TextPerent.SetActive(true);

        npcName.text = sampleTexts[0].npcName;
        textComponent.text = sampleTexts[0].sentences[0];
        npcIcon.sprite = Resources.Load<Sprite>($"Album/{sampleTexts[0].ImageName}");
        // ���� ������ 0-0�� �����´�.
        // ���� sampleTexts �� �з�
        // foreach(string sentecne in sampleTexts.sentecne) {}
        SampleText sampleText = sampleTexts[0];

        foreach (string sentence in sampleText.sentences) 
        { 
          stringQueue.Enqueue(sentence);
        }
    }
     public void DisplayNextSentences()
    {
        Debug.Log("���� StringQueue ���� �ֱ�");

        if (stringQueue.Count == 0) 
        {
            TextPerent.SetActive(false);
            return;
        }

       string sentence = stringQueue.Dequeue();

        StopAllCoroutines();                       // �ڷ�ƾ�� ������ �ߺ��ؼ� ȣ���ϴ� ������ �ذ��Ѵ�.
        StartCoroutine(TypeSantence(sentence));    // �츮�� ���� ������ �ϳ��ϳ� ȣ���ϴ� ȿ���� �ִ� �ڷ�ƾ
    }

    IEnumerator TypeSantence(string sentence) 
    {
        textComponent.text = "";
        foreach (char letter in sentence.ToCharArray()) 
        { 
        textComponent.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
}

