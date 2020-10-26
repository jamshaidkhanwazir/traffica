using UnityEngine;

public class RulesScreenHandler : MonoBehaviour
{
    public void OnCloseButtonClick()
    {
        UIManager.Instance.DeActivateScreen(GameScreens.RulesScreen);
        AudioManager.Instance.PlayButtonSound();
    }
}
