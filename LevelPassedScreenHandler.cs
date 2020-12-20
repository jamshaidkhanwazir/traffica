using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPassedScreenHandler : MonoBehaviour
{
    public void OnHomeButtonClick()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadMainSceneCoroutine());
        AudioManager.Instance.PlayButtonSound();
    }

    public void OnPlayAgainButtonClick()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadGamePlaySceneCoroutine()); 
        AudioManager.Instance.PlayButtonSound();
    }

    public void OnNextButtonClick()
    {
        Time.timeScale = 1;
        PreferenceManager.LevelSelected++;
        StartCoroutine(LoadGamePlaySceneCoroutine());
        AudioManager.Instance.PlayButtonSound();
    }

    private IEnumerator LoadMainSceneCoroutine()
    {
        UIManager.Instance.ActivateScreen(GameScreens.LoadingScreen);
        AsyncOperation operation = SceneManager.LoadSceneAsync(0);
        while (!operation.isDone)
        {
            yield return null;
        }

        UIManager.Instance.DeActivateScreen(GameScreens.LoadingScreen);
        UIManager.Instance.ActivateSpecificScreen(GameScreens.MainScreen);
    }

    private IEnumerator LoadGamePlaySceneCoroutine()
    {
        UIManager.Instance.ActivateScreen(GameScreens.LoadingScreen);
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        while (!operation.isDone)
        {
            yield return null;
        }

        UIManager.Instance.DeActivateScreen(GameScreens.LoadingScreen);
        UIManager.Instance.ActivateSpecificScreen(GameScreens.GamePlayScreen);
    }
}
