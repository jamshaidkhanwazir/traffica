using UnityEngine;
using UnityEngine.UI;

public class UpgradationHandler : MonoBehaviour
{
    [Header("Vehicle")]
    public bool Vehicle1;
    public bool Vehicle2;
    public bool Vehicle3;
    public bool Vehicle4;

    [Header("Specification")]
    public bool Speed;
    public bool Acceleration;
    public bool Braking;
    public bool Engine;

    public Slider slider;

    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey(GenerateName()))
            PlayerPrefs.SetFloat(GenerateName(), slider.value);

        slider.value = PlayerPrefs.GetFloat(GenerateName());

        if (Vehicle1)
        {
            if (slider.value == 1)
                gameObject.SetActive(false);
            else
                gameObject.SetActive(true);
        }
        else if (Vehicle2)
        {
            if (PreferenceManager.Vehicle2 == State.Locked.ToString())
            {
                gameObject.SetActive(false);
            } 
            else
            {
                if (slider.value == 1)
                    gameObject.SetActive(false);
                else
                    gameObject.SetActive(true);
            }
        }
        else if (Vehicle3)
        {
            if (PreferenceManager.Vehicle3 == State.Locked.ToString())
            {
                gameObject.SetActive(false);
            }
            else
            {
                if (slider.value == 1)
                    gameObject.SetActive(false);
                else
                    gameObject.SetActive(true);
            }
        }
        else if (Vehicle4)
        {
            if (PreferenceManager.Vehicle4 == State.Locked.ToString())
            {
                gameObject.SetActive(false);
            }
            else
            {
                if (slider.value == 1)
                    gameObject.SetActive(false);
                else
                    gameObject.SetActive(true);
            }
        }
    }

    public void OnUpgradeButtonClick()
    {
        if (PreferenceManager.Coins >= 100)
        {
            slider.value += 0.1f;
            PlayerPrefs.SetFloat(GenerateName(), slider.value);

            if (slider.value == 1)
                gameObject.SetActive(false);
            else
                gameObject.SetActive(true);

            PreferenceManager.Coins -= 100;
            if (!string.IsNullOrEmpty(PreferenceManager.Username))
                FirebaseManager.Instance.UpdateCoins(PreferenceManager.Coins, OnUpdateCoinsComplete);
            UIManager.Instance.UIScreensReferences[GameScreens.GarageScreen].GetComponent<GarageScreenHandler>().SetHUD();
            UIManager.Instance.UIScreensReferences[GameScreens.GarageScreen].GetComponent<GarageScreenHandler>().DisplaySuccessMessage("You have upgraded your vehicle");
        }
        else
        {
            UIManager.Instance.UIScreensReferences[GameScreens.GarageScreen].GetComponent<GarageScreenHandler>().DisplayErrorMessage("You don't have enough coins");
        }
    }

    private string GenerateName()
    {
        string name = null;

        if (Vehicle1)
            name = "VEHICLE1";
        else if (Vehicle2)
            name = "VEHICLE2";
        else if (Vehicle3)
            name = "VEHICLE3";
        else if (Vehicle4)
            name = "VEHICLE4";

        if (Speed)
            name += "_SPEED";
        else if (Acceleration)
            name += "_ACCELERATION";
        else if (Braking)
            name += "_BRAKING";
        else if (Engine)
            name += "_ENGINE";

        return name;
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
