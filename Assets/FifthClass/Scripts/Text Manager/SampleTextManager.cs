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
        // 적은 내용의 0-0을 가져온다.
        // 앞은 sampleTexts 의 분류
        // foreach(string sentecne in sampleTexts.sentecne) {}
        SampleText sampleText = sampleTexts[0];

        foreach (string sentence in sampleText.sentences) 
        { 
          stringQueue.Enqueue(sentence);
        }
    }
     public void DisplayNextSentences()
    {
        Debug.Log("다음 StringQueue 내용 넣기");

        if (stringQueue.Count == 0) 
        {
            TextPerent.SetActive(false);
            return;
        }

       string sentence = stringQueue.Dequeue();

        StopAllCoroutines();                       // 코루틴이 문장을 중복해서 호출하는 현상을 해결한다.
        StartCoroutine(TypeSantence(sentence));    // 우리가 적은 문장을 하나하나 호출하는 효과를 주는 코루틴
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

