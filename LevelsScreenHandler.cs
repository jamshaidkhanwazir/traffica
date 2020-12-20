using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsScreenHandler : MonoBehaviour
{
    [Header("HUD")]
    public Text coinsText;
    public Text levelNumberText;

    [Header("Levels Screen")]
    public List<GameObject> levelLockImages = new List<GameObject>(12);

    private void OnEnable()
    {
        SetHUD();

        for (int i = 0; i < levelLockImages.Count; i++)
        {
            levelLockImages[i].SetActive(false);
        }

        for (int i = PreferenceManager.LevelNumber; i < levelLockImages.Count; i++)
        {
            levelLockImages[i].SetActive(true);
        }
    }

    public void SetHUD()
    {
        coinsText.text = PreferenceManager.Coins.ToString();
        levelNumberText.text = "Level : " + PreferenceManager.LevelNumber.ToString();
    }

    public void OnBackButtonClick()
    {
        UIManager.Instance.ActivateSpecificScreen(GameScreens.MainScreen);
        AudioManager.Instance.PlayButtonSound();
    }

    public void OnPlayButtonClick(int levelNumber)
    {
        if (levelNumber <= PreferenceManager.LevelNumber)
        {
            GameManager.Instance.playingGame = true;
            PreferenceManager.LevelSelected = levelNumber;
            StartCoroutine(LoadLevelCoroutine());
        }
        AudioManager.Instance.PlayButtonSound();
    }

    private IEnumerator LoadLevelCoroutine()
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
