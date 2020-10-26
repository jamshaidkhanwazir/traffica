using UnityEngine;
using UnityEngine.UI;

public class MainScreenHandler : MonoBehaviour
{
    [Header("HUD")]
    public GameObject profileButton;
    public GameObject loginButton;

    private void OnEnable()
    {
        SetHUD();
    }

    public void SetHUD()
    {
        if (string.IsNullOrEmpty(PreferenceManager.Username))
        {
            profileButton.SetActive(false);
            loginButton.SetActive(true);
        }
        else
        {
            UIManager.Instance.UIScreensReferences[GameScreens.ProfileScreen].GetComponent<ProfileScreenHandler>().SetProfileFromCache();
            profileButton.transform.GetChild(0).GetComponent<Text>().text = PreferenceManager.Username.ToUpper();
            profileButton.SetActive(true);
            loginButton.SetActive(false);
        }
    }

    public void OnLoginButtonClick()
    {
        UIManager.Instance.ActivateScreen(GameScreens.LoginScreen);
        AudioManager.Instance.PlayButtonSound();
    }

    public void OnProfileButtonClick()
    {
        UIManager.Instance.ActivateScreen(GameScreens.ProfileScreen);
        AudioManager.Instance.PlayButtonSound();
    }

    public void OnRulesButtonClick()
    {
        UIManager.Instance.ActivateScreen(GameScreens.RulesScreen);
        AudioManager.Instance.PlayButtonSound();
    }

    public void OnPlayButtonClick()
    {
        UIManager.Instance.ActivateSpecificScreen(GameScreens.LevelsScreen);
        AudioManager.Instance.PlayButtonSound();
    }

    public void OnGarageButtonClick()
    {
        UIManager.Instance.ActivateSpecificScreen(GameScreens.GarageScreen);
        AudioManager.Instance.PlayButtonSound();
    }

    public void OnSettingsButtonClick()
    {
        UIManager.Instance.ActivateScreen(GameScreens.SettingsScreen);
        AudioManager.Instance.PlayButtonSound();
    }

    public void OnLeaderBoardButtonClick()
    {
        UIManager.Instance.ActivateSpecificScreen(GameScreens.LeaderBoardScreen);
        AudioManager.Instance.PlayButtonSound();
    }

    public void OnExitButtonClick()
    {
        UIManager.Instance.ActivateScreen(GameScreens.QuitGameScreen);
        AudioManager.Instance.PlayButtonSound();
    }
}
