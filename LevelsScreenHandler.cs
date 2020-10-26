using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsScreenHandler : MonoBehaviour
{
    public List<GameObject> levelLockImages = new List<GameObject>(12);
    public List<Button> levelPlayButtons = new List<Button>(12);

    private void OnEnable()
    {
        for (int i = PreferenceManager.LevelNumber; i < levelPlayButtons.Count; i++)
        {
            levelLockImages[i].SetActive(true);
            levelPlayButtons[i].interactable = false;
        }
    }

    public void OnBackButtonClick()
    {
        UIManager.Instance.ActivateSpecificScreen(GameScreens.MainScreen);
        AudioManager.Instance.PlayButtonSound();
    }
}
