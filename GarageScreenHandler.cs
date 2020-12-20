using UnityEngine;
using UnityEngine.UI;

public class GarageScreenHandler : MonoBehaviour
{
    [Header("HUD")]
    public Text coinsText;

    [Header("Garage Screen")]
    public Animator vehicle1SpecsAnimator;
    public Animator vehicle2SpecsAnimator;
    public Animator vehicle3SpecsAnimator;
    public Animator vehicle4SpecsAnimator;
    public GameObject vehicleLocked;
    public Button nextButton;
    public Button previousButton;
    private string vehicleNumber;

    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;

    [Header("Message")]
    public GameObject messagePanel;
    public Image messageIcon;
    public Sprite errorSprite;
    public Sprite successSprite;
    public Text messageText;

    private void OnEnable()
    {
        SetHUD();
        vehicleNumber = PreferenceManager.VehicleSelected;
        DisplayVehicle(null);
    }

    public void SetHUD()
    {
        coinsText.text = PreferenceManager.Coins.ToString();
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
            if (!string.IsNullOrEmpty(PreferenceManager.Username))
                FirebaseManager.Instance.UpdateCoins(PreferenceManager.Coins, OnUpdateCoinsComplete);
            SetHUD();

            PreferenceManager.Vehicle2 = State.Unlocked.ToString();
            if (!string.IsNullOrEmpty(PreferenceManager.Username))
                FirebaseManager.Instance.UpdateVehicleState("vehicle2", OnUpdateVehicleStateComplete);

            vehicleLocked.SetActive(false);
            DisplaySuccessMessage("Congratulations! You have bought Civic");

            GameObject[] allGameObjects = Resources.FindObjectsOfTypeAll<GameObject>();
            Debug.Log(allGameObjects.Length);
            foreach (GameObject gameObject in allGameObjects)
            {
                if (gameObject.tag == "IncrementButton")
                {
                    Debug.Log(gameObject.name);
                    gameObject.GetComponent<UpgradationHandler>().enabled = true;
                }
            }
                
        }
        else if (vehicleNumber == Vehicle.Vehicle3.ToString() && PreferenceManager.Coins >= 5500)
        {
            vehicleLocked.SetActive(false);

            PreferenceManager.Coins -= 5500;
            if (!string.IsNullOrEmpty(PreferenceManager.Username))
                FirebaseManager.Instance.UpdateCoins(PreferenceManager.Coins, OnUpdateCoinsComplete);
            SetHUD();

            PreferenceManager.Vehicle3 = State.Unlocked.ToString();
            if (!string.IsNullOrEmpty(PreferenceManager.Username))
                FirebaseManager.Instance.UpdateVehicleState("vehicle3", OnUpdateVehicleStateComplete);

            vehicleLocked.SetActive(false);
            DisplaySuccessMessage("Congratulations! You have bought Lancer");

            GameObject[] incrementsButtons = GameObject.FindGameObjectsWithTag("IncrementButton");
            foreach (GameObject incremenButton in incrementsButtons)
                incremenButton.GetComponent<UpgradationHandler>().enabled = true;
        }
        else if (vehicleNumber == Vehicle.Vehicle4.ToString() && PreferenceManager.Coins >= 8000)
        {
            vehicleLocked.SetActive(false);

            PreferenceManager.Coins -= 8000;
            if (!string.IsNullOrEmpty(PreferenceManager.Username))
                FirebaseManager.Instance.UpdateCoins(PreferenceManager.Coins, OnUpdateCoinsComplete);
            SetHUD();

            PreferenceManager.Vehicle4 = State.Unlocked.ToString();
            if (!string.IsNullOrEmpty(PreferenceManager.Username))
                FirebaseManager.Instance.UpdateVehicleState("vehicle4", OnUpdateVehicleStateComplete);

            vehicleLocked.SetActive(false);
            DisplaySuccessMessage("Congratulations! You have bought Lamborghini");

            GameObject[] incrementsButtons = GameObject.FindGameObjectsWithTag("IncrementButton");
            foreach (GameObject incremenButton in incrementsButtons)
                incremenButton.GetComponent<UpgradationHandler>().enabled = true;
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

            DisplayColor(PreferenceManager.Vehicle1Color);
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

            DisplayColor(PreferenceManager.Vehicle2Color);
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

            DisplayColor(PreferenceManager.Vehicle3Color);
            GarageManager.Instance.DisplayVehicle(Vehicle.Vehicle3.ToString());
        }
        else if (vehicleNumber == Vehicle.Vehicle4.ToString())
        {
            if (lastVehicle == Vehicle.Vehicle3.ToString())
                vehicle3SpecsAnimator.SetTrigger("moveOut");

            Invoke(nameof(MoveSpecsPanelIn), 0.5f);

            previousButton.interactable = true;
            nextButton.interactable = false;

            DisplayColor(PreferenceManager.Vehicle4Color);
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

    public void OnColorButtonClick(int colorNumber)
    {
        DisplayColor(colorNumber);
    }

    private void DisplayColor(int colorNumber)
    {
        if (vehicleNumber == Vehicle.Vehicle1.ToString())
        {
            PreferenceManager.Vehicle1Color = colorNumber;

            if (colorNumber == 1)
                GarageManager.Instance.vehicle1.transform.GetChild(0).GetComponent<Renderer>().material.color = color1;
            else if (colorNumber == 2)
                GarageManager.Instance.vehicle1.transform.GetChild(0).GetComponent<Renderer>().material.color = color2;
            else if (colorNumber == 3)
                GarageManager.Instance.vehicle1.transform.GetChild(0).GetComponent<Renderer>().material.color = color3;
            else if (colorNumber == 4)
                GarageManager.Instance.vehicle1.transform.GetChild(0).GetComponent<Renderer>().material.color = color4;
            else if (colorNumber == 5)
                GarageManager.Instance.vehicle1.transform.GetChild(0).GetComponent<Renderer>().material.color = color5;
        }
        else if (vehicleNumber == Vehicle.Vehicle2.ToString())
        {
            PreferenceManager.Vehicle2Color = colorNumber;

            if (colorNumber == 1)
                GarageManager.Instance.vehicle2.transform.GetChild(0).GetComponent<Renderer>().material.color = color1;
            else if (colorNumber == 2)
                GarageManager.Instance.vehicle2.transform.GetChild(0).GetComponent<Renderer>().material.color = color2;
            else if (colorNumber == 3)
                GarageManager.Instance.vehicle2.transform.GetChild(0).GetComponent<Renderer>().material.color = color3;
            else if (colorNumber == 4)
                GarageManager.Instance.vehicle2.transform.GetChild(0).GetComponent<Renderer>().material.color = color4;
            else if (colorNumber == 5)
                GarageManager.Instance.vehicle2.transform.GetChild(0).GetComponent<Renderer>().material.color = color5;
        }
        else if (vehicleNumber == Vehicle.Vehicle3.ToString())
        {
            PreferenceManager.Vehicle3Color = colorNumber;

            if (colorNumber == 1)
                GarageManager.Instance.vehicle3.transform.GetChild(0).GetComponent<Renderer>().material.color = color1;
            else if (colorNumber == 2)
                GarageManager.Instance.vehicle3.transform.GetChild(0).GetComponent<Renderer>().material.color = color2;
            else if (colorNumber == 3)
                GarageManager.Instance.vehicle3.transform.GetChild(0).GetComponent<Renderer>().material.color = color3;
            else if (colorNumber == 4)
                GarageManager.Instance.vehicle3.transform.GetChild(0).GetComponent<Renderer>().material.color = color4;
            else if (colorNumber == 5)
                GarageManager.Instance.vehicle3.transform.GetChild(0).GetComponent<Renderer>().material.color = color5;
        }
        else if (vehicleNumber == Vehicle.Vehicle4.ToString())
        {
            PreferenceManager.Vehicle4Color = colorNumber;

            if (colorNumber == 1)
                GarageManager.Instance.vehicle4.transform.GetChild(0).GetComponent<Renderer>().material.color = color1;
            else if (colorNumber == 2)
                GarageManager.Instance.vehicle4.transform.GetChild(0).GetComponent<Renderer>().material.color = color2;
            else if (colorNumber == 3)
                GarageManager.Instance.vehicle4.transform.GetChild(0).GetComponent<Renderer>().material.color = color3;
            else if (colorNumber == 4)
                GarageManager.Instance.vehicle4.transform.GetChild(0).GetComponent<Renderer>().material.color = color4;
            else if (colorNumber == 5)
                GarageManager.Instance.vehicle4.transform.GetChild(0).GetComponent<Renderer>().material.color = color5;
        }
    }

    #endregion





    #region Message

    public void DisplayErrorMessage(string message)
    {
        CancelInvoke();
        messagePanel.SetActive(false);
        messagePanel.SetActive(true);
        messageIcon.GetComponent<Image>().sprite = errorSprite;
        messageText.text = message;
        Invoke(nameof(HideMessage), 4f);
    }

    public void DisplaySuccessMessage(string message)
    {
        CancelInvoke();
        messagePanel.SetActive(false);
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
