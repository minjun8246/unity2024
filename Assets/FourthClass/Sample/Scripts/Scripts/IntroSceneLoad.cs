using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneLoad : MonoBehaviour
{
    public void LoadGameScene() 
    {
        //SceneManager.LoadScene("GameScenes");
        Loading.LoadScens("GameScenes");
    }

}
