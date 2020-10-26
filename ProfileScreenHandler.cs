using UnityEngine;
using UnityEngine.UI;

public class ProfileScreenHandler : MonoBehaviour
{
    public Text usernameText;
    public Text levelNumberText;
    public Text emailText;

    public void SetProfileFromCache()
    {
        usernameText.text = PreferenceManager.Username.ToUpper();
        levelNumberText.text = PreferenceManager.LevelNumber.ToString();
        emailText.text = PreferenceManager.Email.ToString();
    }

    public void SetUserProfileFromFirebase(User user)
    {
        usernameText.text = user.username.ToUpper();
        levelNumberText.text = user.levelNumber.ToString();
        emailText.text = user.email.ToString();

        PreferenceManager.Username = user.username;
        PreferenceManager.LevelNumber = user.levelNumber;
        PreferenceManager.Coins = user.coins;
        PreferenceManager.Email = user.email;
        PreferenceManager.Vehicle2 = user.vehicle2;
        PreferenceManager.Vehicle3 = user.vehicle3;
        PreferenceManager.Vehicle4 = user.vehicle4;
    }

    public void OnCloseButtonClick()
    {
        UIManager.Instance.DeActivateScreen(GameScreens.ProfileScreen);
        AudioManager.Instance.PlayButtonSound();
    }

    public void OnLogoutButtonClick()
    {
        PreferenceManager.Username = null;
        PreferenceManager.LevelNumber = 1;
        PreferenceManager.Coins = 500;
        PreferenceManager.Email = null;
        PreferenceManager.VehicleSelected = Vehicle.Vehicle1.ToString();
        PreferenceManager.Vehicle2 = State.Locked.ToString();
        PreferenceManager.Vehicle3 = State.Locked.ToString();
        PreferenceManager.Vehicle4 = State.Locked.ToString();

        UIManager.Instance.DeActivateScreen(GameScreens.ProfileScreen);
        UIManager.Instance.ActivateScreen(GameScreens.LoginScreen);
        UIManager.Instance.UIScreensReferences[GameScreens.MainScreen].GetComponent<MainScreenHandler>().SetHUD();
        AudioManager.Instance.PlayButtonSound();
    }
}
