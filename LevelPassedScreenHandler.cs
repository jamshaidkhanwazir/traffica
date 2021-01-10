using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPassedScreenHandler : MonoBehaviour
{
    [Header("Level Passed Screen")]
    public GameObject nextLevelButton;

    [Header("Message")]
    public GameObject messagePanel;
    public Text messageText;

    private void OnEnable()
    {
        if (PreferenceManager.LevelSelected == 12)
            nextLevelButton.SetActive(false);
        else
            nextLevelButton.SetActive(true);
    }

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




    #region Message

    public void DisplaySuccessMessage(string message)
    {
        messagePanel.SetActive(true);
        messageText.text = message;
        Invoke(nameof(HideMessage), 4f);
    }

    public void HideMessage()
    {
        messagePanel.SetActive(false);
    }

    #endregion
}
