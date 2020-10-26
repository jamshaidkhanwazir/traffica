using UnityEngine;

public class QuitGameScreenHandler : MonoBehaviour
{
    public void OnYesButtoncClick()
    {
        Application.Quit();
        AudioManager.Instance.PlayButtonSound();
    }

    public void OnNoButtoncClick()
    {
        UIManager.Instance.DeActivateScreen(GameScreens.QuitGameScreen);
        AudioManager.Instance.PlayButtonSound();
    }
}
