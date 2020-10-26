using UnityEngine;
using UnityEngine.UI;

public class GarageScreenHandler : MonoBehaviour
{
    [Header("Garage Screen")]
    private string vehicleNumber;
    public Animator vehicle1SpecsAnimator;
    public Animator vehicle2SpecsAnimator;
    public Animator vehicle3SpecsAnimator;
    public Animator vehicle4SpecsAnimator;
    public GameObject vehicleLocked;
    public Button nextButton;
    public Button previousButton;

    [Header("Message")]
    public GameObject messagePanel;
    public Image messageIcon;
    public Sprite errorSprite;
    public Sprite successSprite;
    public Text messageText;

    private void OnEnable()
    {
        vehicleNumber = PreferenceManager.VehicleSelected;
        DisplayVehicle(null);
    }

    #region Garage Screen

    public void OnBackButtonClick()
    {
        UIManager.Instance.ActivateSpecificScreen(GameScreens.MainScreen);
        AudioManager.Instance.PlayButtonSound();
    }

    public void OnBuyButtonClick()
    {
        if (vehicleNumber == Vehicle.Vehicle2.ToString() && PreferenceManager.Coins >= 4500)
        {
            PreferenceManager.Coins -= 4500;
            FirebaseManager.Instance.UpdateCoins(PreferenceManager.Coins, OnUpdateCoinsComplete);

            PreferenceManager.Vehicle2 = State.Unlocked.ToString();
            FirebaseManager.Instance.UpdateVehicleState("vehicle2", OnUpdateVehicleStateComplete);

            vehicleLocked.SetActive(false);
            DisplaySuccessMessage("Congratulations! You have bought Civic");
        }
        else if (vehicleNumber == Vehicle.Vehicle3.ToString() && PreferenceManager.Coins >= 5500)
        {
            vehicleLocked.SetActive(false);

            PreferenceManager.Coins -= 5500;
            FirebaseManager.Instance.UpdateCoins(PreferenceManager.Coins, OnUpdateCoinsComplete);

            PreferenceManager.Vehicle3 = State.Unlocked.ToString();
            FirebaseManager.Instance.UpdateVehicleState("vehicle3", OnUpdateVehicleStateComplete);

            vehicleLocked.SetActive(false);
            DisplaySuccessMessage("Congratulations! You have bought Lancer");
        }
        else if (vehicleNumber == Vehicle.Vehicle4.ToString() && PreferenceManager.Coins >= 8000)
        {
            vehicleLocked.SetActive(false);

            PreferenceManager.Coins -= 8000;
            FirebaseManager.Instance.UpdateCoins(PreferenceManager.Coins, OnUpdateCoinsComplete);

            PreferenceManager.Vehicle4 = State.Unlocked.ToString();
            FirebaseManager.Instance.UpdateVehicleState("vehicle4", OnUpdateVehicleStateComplete);

            vehicleLocked.SetActive(false);
            DisplaySuccessMessage("Congratulations! You have bought Lamborghini");
        }
        else
        {
            DisplayErrorMessage("You don't have enough coins");
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

    private void OnUpdateVehicleStateComplete(UpdateData result, string vehicleName)
    {
        if (result == UpdateData.Successfull)
        {
            Debug.Log(vehicleName + " is updated");
        }
        else if (result == UpdateData.Error)
        {
            Debug.Log(vehicleName + " is not updated");
            FirebaseManager.Instance.UpdateVehicleState(vehicleName, OnUpdateVehicleStateComplete);
        }
    }

    public void OnNextButtonClick()
    {
        if (vehicleNumber == Vehicle.Vehicle1.ToString())
        {
            if (PreferenceManager.Vehicle2 == State.Unlocked.ToString())
            {
                vehicleLocked.SetActive(false);
                PreferenceManager.VehicleSelected = Vehicle.Vehicle2.ToString();
            }
            else
            {
                vehicleLocked.SetActive(true);
            }

            vehicleNumber = Vehicle.Vehicle2.ToString();
            DisplayVehicle(Vehicle.Vehicle1.ToString());
        }
        else if (vehicleNumber == Vehicle.Vehicle2.ToString())
        {
            if (PreferenceManager.Vehicle3 == State.Unlocked.ToString())
            {
                vehicleLocked.SetActive(false);
                PreferenceManager.VehicleSelected = Vehicle.Vehicle3.ToString();
            }
            else
            {
                vehicleLocked.SetActive(true);
            }

            vehicleNumber = Vehicle.Vehicle3.ToString();
            DisplayVehicle(Vehicle.Vehicle2.ToString());
        }
        else if (vehicleNumber == Vehicle.Vehicle3.ToString())
        {
            if (PreferenceManager.Vehicle4 == State.Unlocked.ToString())
            {
                vehicleLocked.SetActive(false);
                PreferenceManager.VehicleSelected = Vehicle.Vehicle4.ToString();
            }
            else
            {
                vehicleLocked.SetActive(true);
            }

            vehicleNumber = Vehicle.Vehicle4.ToString();
            DisplayVehicle(Vehicle.Vehicle3.ToString());
        }
    }

    public void OnPreviousButtonClick()
    {
        if (vehicleNumber == Vehicle.Vehicle4.ToString())
        {
            if (PreferenceManager.Vehicle3 == State.Unlocked.ToString())
            {
                vehicleLocked.SetActive(false);
                PreferenceManager.VehicleSelected = Vehicle.Vehicle3.ToString();
            }
            else
            {
                vehicleLocked.SetActive(true);
            }

            vehicleNumber = Vehicle.Vehicle3.ToString();
            DisplayVehicle(Vehicle.Vehicle4.ToString());
        }
        else if (vehicleNumber == Vehicle.Vehicle3.ToString())
        {
            if (PreferenceManager.Vehicle2 == State.Unlocked.ToString())
            {
                vehicleLocked.SetActive(false);
                PreferenceManager.VehicleSelected = Vehicle.Vehicle2.ToString();
            }
            else
            {
                vehicleLocked.SetActive(true);
            }

            vehicleNumber = Vehicle.Vehicle2.ToString();
            DisplayVehicle(Vehicle.Vehicle3.ToString());
        }
        else if (vehicleNumber == Vehicle.Vehicle2.ToString())
        {
            vehicleLocked.SetActive(false);
            PreferenceManager.VehicleSelected = Vehicle.Vehicle1.ToString();

            vehicleNumber = Vehicle.Vehicle1.ToString();
            DisplayVehicle(Vehicle.Vehicle2.ToString());
        }
    }

    private void DisplayVehicle(string lastVehicle)
    {
        if (vehicleNumber == Vehicle.Vehicle1.ToString())
        {
            if (lastVehicle == Vehicle.Vehicle2.ToString())
                vehicle2SpecsAnimator.SetTrigger("moveOut");

            Invoke(nameof(MoveSpecsPanelIn), 0.5f);

            previousButton.interactable = false;
            nextButton.interactable = true;

            GarageManager.Instance.DisplayVehicle(Vehicle.Vehicle1.ToString());
        }
        else if (vehicleNumber == Vehicle.Vehicle2.ToString())
        {
            if(lastVehicle == Vehicle.Vehicle1.ToString())
                vehicle1SpecsAnimator.SetTrigger("moveOut");
            else if (lastVehicle == Vehicle.Vehicle3.ToString())
                vehicle3SpecsAnimator.SetTrigger("moveOut");

            Invoke(nameof(MoveSpecsPanelIn), 0.5f);

            previousButton.interactable = true;
            nextButton.interactable = true;

            GarageManager.Instance.DisplayVehicle(Vehicle.Vehicle2.ToString());
        }
        else if (vehicleNumber == Vehicle.Vehicle3.ToString())
        {
            if (lastVehicle == Vehicle.Vehicle2.ToString())
                vehicle2SpecsAnimator.SetTrigger("moveOut");
            else if (lastVehicle == Vehicle.Vehicle4.ToString())
                vehicle4SpecsAnimator.SetTrigger("moveOut");

            Invoke(nameof(MoveSpecsPanelIn), 0.5f);

            previousButton.interactable = true;
            nextButton.interactable = true;

            GarageManager.Instance.DisplayVehicle(Vehicle.Vehicle3.ToString());
        }
        else if (vehicleNumber == Vehicle.Vehicle4.ToString())
        {
            if (lastVehicle == Vehicle.Vehicle3.ToString())
                vehicle3SpecsAnimator.SetTrigger("moveOut");

            Invoke(nameof(MoveSpecsPanelIn), 0.5f);

            previousButton.interactable = true;
            nextButton.interactable = false;

            GarageManager.Instance.DisplayVehicle(Vehicle.Vehicle4.ToString());
        }
    }

    private void MoveSpecsPanelIn()
    {
        if (vehicleNumber == Vehicle.Vehicle1.ToString())
            vehicle1SpecsAnimator.SetTrigger("moveIn");
        else if (vehicleNumber == Vehicle.Vehicle2.ToString())
            vehicle2SpecsAnimator.SetTrigger("moveIn");
        else if (vehicleNumber == Vehicle.Vehicle3.ToString())
            vehicle3SpecsAnimator.SetTrigger("moveIn");
        else if (vehicleNumber == Vehicle.Vehicle4.ToString())
            vehicle4SpecsAnimator.SetTrigger("moveIn");
    }

    #endregion





    #region Message

    public void DisplayErrorMessage(string message)
    {
        messagePanel.SetActive(true);
        messageIcon.GetComponent<Image>().sprite = errorSprite;
        messageText.text = message;
        Invoke(nameof(HideMessage), 4f);
    }

    public void DisplaySuccessMessage(string message)
    {
        messagePanel.SetActive(true);
        messageIcon.GetComponent<Image>().sprite = successSprite;
        messageText.text = message;
        Invoke(nameof(HideMessage), 4f);
    }

    public void HideMessage()
    {
        messagePanel.SetActive(false);
    }

    #endregion
}
