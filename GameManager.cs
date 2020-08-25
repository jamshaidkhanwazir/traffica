using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}

public enum GameScreens
{
    MainScreen,
    LoginScreen,
    RulesScreen,
    LeaderBoardScreen,
    LevelsScreen,
    GamePlayScreen,
    GamePausedScreen,
    LevelPassedScreen,
    LevelFailedScreen,
    SettingsScreen,
    QuitGameScreen,
    ProfileScreen,
    LoadingScreen
}