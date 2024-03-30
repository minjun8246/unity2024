using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStage : MonoBehaviour
{
    public static GameStage Instance;

    public int spawnMonsterCount;
    public int waveCount = 1;
    public int maxWave;
    public bool stageClear;
    public GameObject MonsterPrefab;
    public Transform[] spawnPositions;

    [Header("게임 클리어 UI")]
    public GameObject clearGameUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CreateMonster(waveCount);
    }

    private void Update()
    {
        if (spawnMonsterCount <= 0 && !stageClear)
        {
            waveCount++;
            waveProcess();
        }
        if (stageClear)
        {
            clearGameUI.SetActive(true);
        }
    }

    private void waveProcess()
    {
        if (waveCount > maxWave)
        {
            stageClear = true;
            return;
        }
        else
        {
            CreateMonster(waveCount);
        }
    }

    private void CreateMonster(int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(MonsterPrefab, SetCharacterPosition().position, Quaternion.identity);
            spawnMonsterCount++;
        }
    }

    private Transform SetCharacterPosition()
    {
        int selectPos = UnityEngine.Random.RandomRange(0, spawnPositions.Length);

        return spawnPositions[selectPos];
    }

    // 스테이지 클리어 UI 버튼
    public void ReturnToTitle() 
    {
        SceneManager.LoadScene("Intro");
    }

    public void GameQuit() 
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
