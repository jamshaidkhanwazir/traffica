using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelFailedScreenHandler : MonoBehaviour
{
    public Text levelFailedReasonText;

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
