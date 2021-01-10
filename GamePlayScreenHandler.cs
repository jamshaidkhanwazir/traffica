using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScreenHandler : MonoBehaviour
{
    public Text LevelNumberText;
    public Text speedText;
    public Text timerText;
    public GameObject LevelInstructionPanel;
    public GameObject[] levelInstruction;

    private void OnEnable()
    {
        speedText.text = "0";
        SetUpLevel();
        UIManager.Instance.UIScreensReferences[GameScreens.SettingsScreen].GetComponent<SettingsScreenHandler>().SetVehicleControls();
    }

    private void Update()
    {
        if (PreferenceManager.VehicleSelected == Vehicle.Vehicle1.ToString())
        {
            speedText.text = Convert.ToInt32(LevelsManager.Instance.vehicle1.GetComponent<RCCCarControllerV2>().speed).ToString();

            if (PreferenceManager.LevelSelected == 7 && LevelsManager.Instance.vehicle1.GetComponent<RCCCarControllerV2>().speed > 40f)
                LevelFailed("Over Speeding. Speed Limit: 40 km/h");
            else if (PreferenceManager.LevelSelected == 8 && LevelsManager.Instance.vehicle1.GetComponent<RCCCarControllerV2>().speed > 50f)
                LevelFailed("Over Speeding. Speed Limit: 50 km/h");
            else if (PreferenceManager.LevelSelected == 9 && LevelsManager.Instance.vehicle1.GetComponent<RCCCarControllerV2>().speed > 30f)
                LevelFailed("Over Speeding. Speed Limit: 30 km/h");
            else if (PreferenceManager.LevelSelected == 10 && LevelsManager.Instance.vehicle1.GetComponent<RCCCarControllerV2>().speed > 45f)
                LevelFailed("Over Speeding. Speed Limit: 45 km/h");
            else if (PreferenceManager.LevelSelected == 11 && LevelsManager.Instance.vehicle1.GetComponent<RCCCarControllerV2>().speed > 25f)
                LevelFailed("Over Speeding. Speed Limit: 25 km/h");
            else if (PreferenceManager.LevelSelected == 12 && LevelsManager.Instance.vehicle1.GetComponent<RCCCarControllerV2>().speed > 40f)
                LevelFailed("Over Speeding. Speed Limit: 40 km/h");
        }
        else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle2.ToString())
        {
            speedText.text = Convert.ToInt32(LevelsManager.Instance.vehicle2.GetComponent<RCCCarControllerV2>().speed).ToString();

            if (PreferenceManager.LevelSelected == 7 && LevelsManager.Instance.vehicle2.GetComponent<RCCCarControllerV2>().speed > 40f)
                LevelFailed("Over Speeding. Speed Limit: 40 km/h");
            else if (PreferenceManager.LevelSelected == 8 && LevelsManager.Instance.vehicle2.GetComponent<RCCCarControllerV2>().speed > 50f)
                LevelFailed("Over Speeding. Speed Limit: 50 km/h");
            else if (PreferenceManager.LevelSelected == 9 && LevelsManager.Instance.vehicle2.GetComponent<RCCCarControllerV2>().speed > 30f)
                LevelFailed("Over Speeding. Speed Limit: 30 km/h");
            else if (PreferenceManager.LevelSelected == 10 && LevelsManager.Instance.vehicle2.GetComponent<RCCCarControllerV2>().speed > 45f)
                LevelFailed("Over Speeding. Speed Limit: 45 km/h");
            else if (PreferenceManager.LevelSelected == 11 && LevelsManager.Instance.vehicle2.GetComponent<RCCCarControllerV2>().speed > 25f)
                LevelFailed("Over Speeding. Speed Limit: 25 km/h");
            else if (PreferenceManager.LevelSelected == 12 && LevelsManager.Instance.vehicle2.GetComponent<RCCCarControllerV2>().speed > 40f)
                LevelFailed("Over Speeding. Speed Limit: 40 km/h");
        }
        else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle3.ToString())
        {
            speedText.text = Convert.ToInt32(LevelsManager.Instance.vehicle3.GetComponent<RCCCarControllerV2>().speed).ToString();

            if (PreferenceManager.LevelSelected == 7 && LevelsManager.Instance.vehicle3.GetComponent<RCCCarControllerV2>().speed > 40f)
                LevelFailed("Over Speeding. Speed Limit: 40 km/h");
            else if (PreferenceManager.LevelSelected == 8 && LevelsManager.Instance.vehicle3.GetComponent<RCCCarControllerV2>().speed > 50f)
                LevelFailed("Over Speeding. Speed Limit: 50 km/h");
            else if (PreferenceManager.LevelSelected == 9 && LevelsManager.Instance.vehicle3.GetComponent<RCCCarControllerV2>().speed > 30f)
                LevelFailed("Over Speeding. Speed Limit: 30 km/h");
            else if (PreferenceManager.LevelSelected == 10 && LevelsManager.Instance.vehicle3.GetComponent<RCCCarControllerV2>().speed > 45f)
                LevelFailed("Over Speeding. Speed Limit: 45 km/h");
            else if (PreferenceManager.LevelSelected == 11 && LevelsManager.Instance.vehicle3.GetComponent<RCCCarControllerV2>().speed > 25f)
                LevelFailed("Over Speeding. Speed Limit: 25 km/h");
            else if (PreferenceManager.LevelSelected == 12 && LevelsManager.Instance.vehicle3.GetComponent<RCCCarControllerV2>().speed > 40f)
                LevelFailed("Over Speeding. Speed Limit: 40 km/h");
        }
        else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle4.ToString())
        {
            speedText.text = Convert.ToInt32(LevelsManager.Instance.vehicle4.GetComponent<RCCCarControllerV2>().speed).ToString();

            if (PreferenceManager.LevelSelected == 7 && LevelsManager.Instance.vehicle4.GetComponent<RCCCarControllerV2>().speed > 40f)
                LevelFailed("Over Speeding. Speed Limit: 40 km/h");
            else if (PreferenceManager.LevelSelected == 8 && LevelsManager.Instance.vehicle4.GetComponent<RCCCarControllerV2>().speed > 50f)
                LevelFailed("Over Speeding. Speed Limit: 50 km/h");
            else if (PreferenceManager.LevelSelected == 9 && LevelsManager.Instance.vehicle4.GetComponent<RCCCarControllerV2>().speed > 30f)
                LevelFailed("Over Speeding. Speed Limit: 30 km/h");
            else if (PreferenceManager.LevelSelected == 10 && LevelsManager.Instance.vehicle4.GetComponent<RCCCarControllerV2>().speed > 45f)
                LevelFailed("Over Speeding. Speed Limit: 45 km/h");
            else if (PreferenceManager.LevelSelected == 11 && LevelsManager.Instance.vehicle4.GetComponent<RCCCarControllerV2>().speed > 25f)
                LevelFailed("Over Speeding. Speed Limit: 25 km/h");
            else if (PreferenceManager.LevelSelected == 12 && LevelsManager.Instance.vehicle4.GetComponent<RCCCarControllerV2>().speed > 40f)
                LevelFailed("Over Speeding. Speed Limit: 40 km/h");
        }
    }

    public void SetUpLevel()
    {
        Time.timeScale = 1;
        if(PreferenceManager.LevelSelected == 0)
            LevelNumberText.text = "Free Mode";
        else 
            LevelNumberText.text = "Level : " + PreferenceManager.LevelSelected.ToString();
        LevelsManager.Instance.SetupLevelEnvironment();
        DisplayLevelInstruction();
    }

    public void OnStartButtonClick()
    {
        LevelsManager.Instance.rccCanvas.SetActive(true);
        LevelsManager.Instance.ReadyVehicle();
        LevelInstructionPanel.SetActive(false);
        StartCoroutine(LevelTimerCoroutine(LevelsManager.Instance.levels[PreferenceManager.LevelSelected - 1].levelTime));
    }

    public void OnPauseButtonClick()
    {
        LevelsManager.Instance.rccCanvas.SetActive(false);
        UIManager.Instance.ActivateScreen(GameScreens.GamePausedScreen);
        Invoke(nameof(PauseGame), 1f);
        AudioManager.Instance.PlayButtonSound();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void OnSettingsButtonClick()
    {
        LevelsManager.Instance.rccCanvas.SetActive(false);
        UIManager.Instance.ActivateScreen(GameScreens.SettingsScreen);
        AudioManager.Instance.PlayButtonSound();
    }

    public void DisplayLevelInstruction()
    {
        if (PreferenceManager.LevelSelected == 0)
        {
            LevelsManager.Instance.rccCanvas.SetActive(true);
            LevelsManager.Instance.ReadyVehicle();
            LevelInstructionPanel.SetActive(false);
        }
        else
        {
            LevelInstructionPanel.SetActive(true);
            LevelsManager.Instance.rccCanvas.SetActive(false);
            timerText.text = "00:00";

            for (int i = 0; i < levelInstruction.Length; i++)
                levelInstruction[i].SetActive(false);

            levelInstruction[PreferenceManager.LevelSelected - 1].SetActive(true);
        }       
    }

    private IEnumerator LevelTimerCoroutine(int time)
    {
        if (time == 0)
        {
            yield return null;
        }
        else
        {
            while (time != -1)
            {
                if (time >= 60)
                {
                    int seconds = time - 60;
                    timerText.text = "01:" + seconds;
                }
                else
                {
                    if (time < 10)
                        timerText.text = "00:0" + time;
                    else
                        timerText.text = "00:" + time;
                }

                time--;
                yield return new WaitForSeconds(1);
            }

            LevelFailed("Time out");
        }
    }

    public void LevelFailed(string reason)
    {
        if (!UIManager.Instance.UIScreensReferences[GameScreens.LevelFailedScreen].gameObject.activeInHierarchy && !UIManager.Instance.UIScreensReferences[GameScreens.LevelPassedScreen].gameObject.activeInHierarchy)
        {
            LevelsManager.Instance.rccCanvas.SetActive(false);
            StopAllCoroutines();
            UIManager.Instance.UIScreensReferences[GameScreens.LevelFailedScreen].GetComponent<LevelFailedScreenHandler>().levelFailedReasonText.text = reason;
            UIManager.Instance.ActivateScreen(GameScreens.LevelFailedScreen);
        }
    }

    public void LevelPassed()
    {
        if (!UIManager.Instance.UIScreensReferences[GameScreens.LevelFailedScreen].gameObject.activeInHierarchy && !UIManager.Instance.UIScreensReferences[GameScreens.LevelPassedScreen].gameObject.activeInHierarchy)
        {
            LevelsManager.Instance.rccCanvas.SetActive(false);
            StopAllCoroutines();
            bool flag = false;
            if (PreferenceManager.LevelSelected == PreferenceManager.LevelNumber && PreferenceManager.LevelSelected != 12)
            {
                flag = true;
                PreferenceManager.LevelNumber++;
                if (!string.IsNullOrEmpty(PreferenceManager.Username))
                    FirebaseManager.Instance.UpdateLevelNumber(PreferenceManager.LevelNumber, OnUpdateLevelNumberComplete);

                PreferenceManager.Coins += LevelsManager.Instance.levels[PreferenceManager.LevelSelected - 1].levelWinningAmount;

                if (!string.IsNullOrEmpty(PreferenceManager.Username))
                    FirebaseManager.Instance.UpdateCoins(PreferenceManager.Coins, OnUpdateCoinsComplete);
            }

            UIManager.Instance.ActivateScreen(GameScreens.LevelPassedScreen);
            if(flag)
                UIManager.Instance.UIScreensReferences[GameScreens.LevelPassedScreen].GetComponent<LevelPassedScreenHandler>().DisplaySuccessMessage("You have won " + LevelsManager.Instance.levels[PreferenceManager.LevelSelected - 1].levelWinningAmount + " coins");
        }
    }

    private void OnUpdateLevelNumberComplete(UpdateData result)
    {
        if (result == UpdateData.Successfull)
        {
            Debug.Log("Level number is updated");
        }
        else if (result == UpdateData.Error)
        {
            Debug.Log("Level number is not updated");
            FirebaseManager.Instance.UpdateLevelNumber(PreferenceManager.LevelNumber, OnUpdateLevelNumberComplete);
        }
    }

    private void OnUpdateCoinsComplete(UpdateData result)
    {
        if (result == UpdateData.Successfull)
        {
            Debug.Log("Coins are updated");
        }
        else if (result == UpdateData.Error)
        {
            Debug.Log("Coins are not updated");
            FirebaseManager.Instance.UpdateCoins(PreferenceManager.Coins, OnUpdateCoinsComplete);
        }
    }
}
