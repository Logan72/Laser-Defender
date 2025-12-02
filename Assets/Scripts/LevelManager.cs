using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float delayTime = 2f;
    public static void LoadPlayingScene()
    {
        SceneManager.LoadScene(1);
    }
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGameOverScene()
    {
        StartCoroutine(WaitAndLoad(2, delayTime));
    }
    IEnumerator WaitAndLoad(int sceneIndex, float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);

        SceneManager.LoadScene(sceneIndex);
    }
    public static void QuitGame()
    {
        Application.Quit();
    }
}
