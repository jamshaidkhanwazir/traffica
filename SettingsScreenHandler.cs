using UnityEngine;
using UnityEngine.UI;

public class SettingsScreenHandler : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    [Space(20)]
    public Image steeringImage;
    public Sprite steeringEnableSprite;
    public Sprite steeringDisableSprite;
    public Image tiltImage;
    public Sprite tiltEnableSprite;
    public Sprite tiltDisableSprite;
    public Image buttonsImage;
    public Sprite buttonsEnableSprite;
    public Sprite buttonsDisableSprite;

    private void OnEnable()
    {
        musicSlider.GetComponent<Slider>().value = PreferenceManager.Music;
        sfxSlider.GetComponent<Slider>().value = PreferenceManager.SFX;
        DisplayControlsImage(PreferenceManager.Controls);
    }

    public void OnCloseButtonClick()
    {
        if(GameManager.Instance.playingGame)
            LevelsManager.Instance.rccCanvas.SetActive(true);
        UIManager.Instance.DeActivateScreen(GameScreens.SettingsScreen);
        AudioManager.Instance.PlayButtonSound();
    }

    public void OnMusicSliderValueChange()
    {
        SetMusicVolume(musicSlider.GetComponent<Slider>().value);
    }

    private void SetMusicVolume(float _volume)
    {
        PreferenceManager.Music = _volume;
        AudioManager.Instance.SetMusicVolume(PreferenceManager.Music);
    }

    public void OnSFXSliderValueChange()
    {
        SetSFXVolume(sfxSlider.GetComponent<Slider>().value);
    }

    private void SetSFXVolume(float _volume)
    {
        PreferenceManager.SFX = _volume;
        AudioManager.Instance.SetSFXVolume(PreferenceManager.SFX);
    }

    public void OnControlButtonClick(string controlType)
    {
        PreferenceManager.Controls = controlType;
        DisplayControlsImage(controlType);
        AudioManager.Instance.PlayButtonSound();
    }

    private void DisplayControlsImage(string _controlType)
    {
        steeringImage.sprite = steeringDisableSprite;
        tiltImage.sprite = tiltDisableSprite;
        buttonsImage.sprite = buttonsDisableSprite;

        if (_controlType == ControlType.Steering.ToString())
            steeringImage.sprite = steeringEnableSprite;
        else if (_controlType == ControlType.Tilt.ToString())
            tiltImage.sprite = tiltEnableSprite;
        else if (_controlType == ControlType.Buttons.ToString())
            buttonsImage.sprite = buttonsEnableSprite;

        if (GameManager.Instance.playingGame)
            SetVehicleControls();
    }

    public void SetVehicleControls()
    {
        if (PreferenceManager.Controls == ControlType.Steering.ToString())
        {
            if (PreferenceManager.VehicleSelected == Vehicle.Vehicle1.ToString())
            {
                LevelsManager.Instance.vehicle1.GetComponent<RCCCarControllerV2>().mobileController = true;
                LevelsManager.Instance.vehicle1.GetComponent<RCCCarControllerV2>().steeringWheelControl = true;
                LevelsManager.Instance.vehicle1.GetComponent<RCCCarControllerV2>().useAccelerometerForSteer = false;
            }
            else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle2.ToString())
            {
                LevelsManager.Instance.vehicle2.GetComponent<RCCCarControllerV2>().mobileController = true;
                LevelsManager.Instance.vehicle2.GetComponent<RCCCarControllerV2>().steeringWheelControl = true;
                LevelsManager.Instance.vehicle2.GetComponent<RCCCarControllerV2>().useAccelerometerForSteer = false;
            }
            else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle3.ToString())
            {
                LevelsManager.Instance.vehicle3.GetComponent<RCCCarControllerV2>().mobileController = true;
                LevelsManager.Instance.vehicle3.GetComponent<RCCCarControllerV2>().steeringWheelControl = true;
                LevelsManager.Instance.vehicle3.GetComponent<RCCCarControllerV2>().useAccelerometerForSteer = false;
            }
            else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle4.ToString())
            {
                LevelsManager.Instance.vehicle4.GetComponent<RCCCarControllerV2>().mobileController = true;
                LevelsManager.Instance.vehicle4.GetComponent<RCCCarControllerV2>().steeringWheelControl = true;
                LevelsManager.Instance.vehicle4.GetComponent<RCCCarControllerV2>().useAccelerometerForSteer = false;
            }
        }
        else if (PreferenceManager.Controls == ControlType.Buttons.ToString())
        {
            if (PreferenceManager.VehicleSelected == Vehicle.Vehicle1.ToString())
            {
                LevelsManager.Instance.vehicle1.GetComponent<RCCCarControllerV2>().mobileController = true;
                LevelsManager.Instance.vehicle1.GetComponent<RCCCarControllerV2>().steeringWheelControl = false;
                LevelsManager.Instance.vehicle1.GetComponent<RCCCarControllerV2>().useAccelerometerForSteer = false;
            }
            else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle2.ToString())
            {
                LevelsManager.Instance.vehicle2.GetComponent<RCCCarControllerV2>().mobileController = true;
                LevelsManager.Instance.vehicle2.GetComponent<RCCCarControllerV2>().steeringWheelControl = false;
                LevelsManager.Instance.vehicle2.GetComponent<RCCCarControllerV2>().useAccelerometerForSteer = false;
            }
            else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle3.ToString())
            {
                LevelsManager.Instance.vehicle3.GetComponent<RCCCarControllerV2>().mobileController = true;
                LevelsManager.Instance.vehicle3.GetComponent<RCCCarControllerV2>().steeringWheelControl = false;
                LevelsManager.Instance.vehicle3.GetComponent<RCCCarControllerV2>().useAccelerometerForSteer = false;
            }
            else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle4.ToString())
            {
                LevelsManager.Instance.vehicle4.GetComponent<RCCCarControllerV2>().mobileController = true;
                LevelsManager.Instance.vehicle4.GetComponent<RCCCarControllerV2>().steeringWheelControl = false;
                LevelsManager.Instance.vehicle4.GetComponent<RCCCarControllerV2>().useAccelerometerForSteer = false;
            }
        }
        else if (PreferenceManager.Controls == ControlType.Tilt.ToString())
        {
            if (PreferenceManager.VehicleSelected == Vehicle.Vehicle1.ToString())
            {
                LevelsManager.Instance.vehicle1.GetComponent<RCCCarControllerV2>().mobileController = true;
                LevelsManager.Instance.vehicle1.GetComponent<RCCCarControllerV2>().steeringWheelControl = false;
                LevelsManager.Instance.vehicle1.GetComponent<RCCCarControllerV2>().useAccelerometerForSteer = true;
            }
            else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle2.ToString())
            {
                LevelsManager.Instance.vehicle2.GetComponent<RCCCarControllerV2>().mobileController = true;
                LevelsManager.Instance.vehicle2.GetComponent<RCCCarControllerV2>().steeringWheelControl = false;
                LevelsManager.Instance.vehicle2.GetComponent<RCCCarControllerV2>().useAccelerometerForSteer = true;
            }
            else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle3.ToString())
            {
                LevelsManager.Instance.vehicle3.GetComponent<RCCCarControllerV2>().mobileController = true;
                LevelsManager.Instance.vehicle3.GetComponent<RCCCarControllerV2>().steeringWheelControl = false;
                LevelsManager.Instance.vehicle3.GetComponent<RCCCarControllerV2>().useAccelerometerForSteer = true;
            }
            else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle4.ToString())
            {
                LevelsManager.Instance.vehicle4.GetComponent<RCCCarControllerV2>().mobileController = true;
                LevelsManager.Instance.vehicle4.GetComponent<RCCCarControllerV2>().steeringWheelControl = false;
                LevelsManager.Instance.vehicle4.GetComponent<RCCCarControllerV2>().useAccelerometerForSteer = true;
            }
        }
    }
}

public enum ControlType
{
    Steering,
    Tilt,
    Buttons
}
