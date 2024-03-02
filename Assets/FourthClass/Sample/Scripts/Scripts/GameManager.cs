using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region �̱��� ����
    // single: Ŭ������ �Ѱ��� �����ϵ��� �����ϰ�, �̸� �����ؼ�
    // �ٸ� Ŭ�������� �� Ŭ������ �ҷ��ͼ� ����� �� �ְ� �Ѵ�.

    // �̱��� ������ ����: �̱����� �ʹ� ���� ������� ����
    // �ϳ��� Ŭ������ �ʹ� ���� �����͸� ��� �Ǵ� ������ ������
    // static ��Ŭ���� ������ �ϴµ�, ������ ����� �� �޸𸮰�
    // �Լ� ���� �ִ� �������� �ֽ��ϴ�.

    // [������ ����] Ŭ���� ���� ���� ���踦 �� �� �ִ� ���質 Ŭ���� ����(��� ����)��
    // ���� ���� �� ����� ���� ���鵵�� �ϰ� �� ��
    private static GameManager instance;

    public static GameManager Instance 
    {
    get 
        {
            if (null == instance) 
            {
            instance = new GameManager();
            }

            return instance; 
        }
    }

    // void Awake() �Լ��� ��� Ŭ������ void start()���� ���� ����˴ϴ�.
    private void Awake()
    {
        if(null == instance) 
        { 
        instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        { 
        Destroy(this.gameObject);
        }
    }
    
    // static���� ������ ������ Ŭ���� �̸����� �ٷ� ������ �� �ִ� ������ �ֽ��ϴ�.
    // �� ��� ������ static���� �������� ������?
    // GameManager �ȿ� �ִ� ��� static���� ����� ������ �������� �˰� �־���մϴ�.
    // static���� ������ ������ ���α׷��� ����� �� ���� ���� �ֽ��ϴ�.

    public bool IsPlayerDeath;

    // static Ŭ���� ȣ��. �ν��Ͻ� ȣ��

    #endregion

    public GameObject[] gameoverObject;

    private void SetGameSetting() 
    {
        IsPlayerDeath = false;

        //gameObject[0] = GameObject.Find("BackGround");
        //gameObject[1] = GameObject.Find("GameOver");

        // �ð� ���� ������ 0���� �� �ϴ� ����
    }
    public void GameOver()
    {
        foreach (GameObject obj in gameoverObject) 
        { 
        obj.SetActive(true);
        }
    }

    public void GameQuit() 
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void GameRestart() 
    {
        // �̸��� ��Ȯ���� ������ ������ �߻��մϴ�.
        // 
        SetGameSetting();
        SceneManager.LoadScene("GameScenes");
       
    }

}
