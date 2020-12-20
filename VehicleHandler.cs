using UnityEngine;

public class VehicleHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (!UIManager.Instance.UIScreensReferences[GameScreens.LevelPassedScreen].gameObject.activeInHierarchy && !UIManager.Instance.UIScreensReferences[GameScreens.LevelFailedScreen].gameObject.activeInHierarchy)
        {
            if (collision.gameObject.tag == "OffRoadCheck")
            {
                UIManager.Instance.UIScreensReferences[GameScreens.GamePlayScreen].GetComponent<GamePlayScreenHandler>().LevelFailed("Stay on the Road");
            }

            if (collision.gameObject.tag == "WrongWayCheck")
            {
                UIManager.Instance.UIScreensReferences[GameScreens.GamePlayScreen].GetComponent<GamePlayScreenHandler>().LevelFailed("Wrong Way");
            }

            if (collision.gameObject.tag == "TrafficSignalCheck")
            {
                if (PreferenceManager.LevelSelected == 1 && PreferenceManager.LevelSelected == 7 && PreferenceManager.LevelSelected == 10 && !LevelsManager.Instance.levels[PreferenceManager.LevelSelected - 1].trafficLightHandler.GreenLightTrafficPole3.activeInHierarchy)
                {
                    UIManager.Instance.UIScreensReferences[GameScreens.GamePlayScreen].GetComponent<GamePlayScreenHandler>().LevelFailed("Stop vehicle before zebra crossing on red traffic signal");
                }
                else if (PreferenceManager.LevelSelected == 2 && PreferenceManager.LevelSelected == 8 && PreferenceManager.LevelSelected == 11 && !LevelsManager.Instance.levels[PreferenceManager.LevelSelected - 1].trafficLightHandler.GreenLightTrafficPole2.activeInHierarchy)
                {
                    UIManager.Instance.UIScreensReferences[GameScreens.GamePlayScreen].GetComponent<GamePlayScreenHandler>().LevelFailed("Stop vehicle before zebra crossing on red traffic signal");
                }
                else if (PreferenceManager.LevelSelected == 3 && PreferenceManager.LevelSelected == 9 && PreferenceManager.LevelSelected == 12 && !LevelsManager.Instance.levels[PreferenceManager.LevelSelected - 1].trafficLightHandler.GreenLightTrafficPole3.activeInHierarchy)
                {
                    UIManager.Instance.UIScreensReferences[GameScreens.GamePlayScreen].GetComponent<GamePlayScreenHandler>().LevelFailed("Stop vehicle before zebra crossing on red traffic signal");
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destination")
        {
            UIManager.Instance.UIScreensReferences[GameScreens.GamePlayScreen].GetComponent<GamePlayScreenHandler>().LevelPassed();
        }

        if (collision.gameObject.tag == "Object")
        {
            UIManager.Instance.UIScreensReferences[GameScreens.GamePlayScreen].GetComponent<GamePlayScreenHandler>().LevelFailed("You hit the vehicle");
        }
    }
}
