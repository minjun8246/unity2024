using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    static string nextScene;

    public Image ProgressBar;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.A)) 
        //{
            //ProgressBar.fillAmount += 0.1f;
        //}
    }

    public static void LoadScens(string SceneName) 
    {
        nextScene = SceneName;
        SceneManager.LoadScene("Loading");
    }

    IEnumerator LoadSceneProcess() 
    {
        //
        yield return new WaitForSeconds(0.3f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
        operation.allowSceneActivation = false;

        float timer = 0;
        while (!operation.isDone) 
        { 
        yield return null;

            if (operation.progress < 0.9f)
            {
                ProgressBar.fillAmount = operation.progress;
            }
            else 
            {
                timer += Time.unscaledDeltaTime;
                ProgressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if (ProgressBar.fillAmount >= 1f) 
                {
                    yield return new WaitForSeconds(1.7f);
                    operation.allowSceneActivation = true;
                }
                yield return null;
            }
        }
    }
}
