using UnityEngine;

[System.Serializable]
public class Level
{
    public string levelName;
    public int levelTime;
    public int levelWinningAmount;
    public GameObject levelEnvironment;
    public TrafficLightHandler trafficLightHandler;
    public Transform vehicleInitialPosition;
}

public class LevelsManager : MonoBehaviour
{
    public RCCCarCamera rccMainCamera;
    public MiniMapController miniMapController;
    public GameObject rccCanvas;

    [Header("Vehicles")]
    public GameObject vehicle1;
    public GameObject vehicle2;
    public GameObject vehicle3;
    public GameObject vehicle4;

    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;

    [Header("Levels")]
    public GameObject freeModeEnvironment;
    public Level[] levels;

    public static LevelsManager _instance;
    public static LevelsManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    public void SetupLevelEnvironment()
    {
        for (int i = 0; i < levels.Length; i++)
            levels[i].levelEnvironment.SetActive(false);

        if (PreferenceManager.LevelSelected == 0)
        {
            freeModeEnvironment.SetActive(true);
        }
        else 
        {
            freeModeEnvironment.SetActive(false);
            levels[PreferenceManager.LevelSelected - 1].levelEnvironment.SetActive(true);
        }
        

        vehicle1.SetActive(false);
        vehicle2.SetActive(false);
        vehicle3.SetActive(false);
        vehicle4.SetActive(false);

        if (PreferenceManager.VehicleSelected == Vehicle.Vehicle1.ToString())
        {
            rccMainCamera.playerCar = vehicle1.transform;
            miniMapController.target = vehicle1.transform;
            vehicle1.SetActive(true);
            DisplayColor(PreferenceManager.Vehicle1Color);
            vehicle1.GetComponent<RCCCarControllerV2>().enabled = false;

            if (PreferenceManager.LevelSelected == 0)
            {
                vehicle1.transform.position = levels[1].vehicleInitialPosition.position;
                vehicle1.transform.eulerAngles = levels[1].vehicleInitialPosition.eulerAngles;
            }
            else
            {
                vehicle1.transform.position = levels[PreferenceManager.LevelSelected - 1].vehicleInitialPosition.position;
                vehicle1.transform.eulerAngles = levels[PreferenceManager.LevelSelected - 1].vehicleInitialPosition.eulerAngles;
            }
        }
        else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle2.ToString())
        {
            rccMainCamera.playerCar = vehicle2.transform;
            miniMapController.target = vehicle2.transform;
            vehicle2.SetActive(true);
            DisplayColor(PreferenceManager.Vehicle2Color);
            vehicle2.GetComponent<RCCCarControllerV2>().enabled = false;

            if (PreferenceManager.LevelSelected == 0)
            {
                vehicle2.transform.position = levels[1].vehicleInitialPosition.position;
                vehicle2.transform.eulerAngles = levels[1].vehicleInitialPosition.eulerAngles;
            }
            else
            {
                vehicle2.transform.position = levels[PreferenceManager.LevelSelected - 1].vehicleInitialPosition.position;
                vehicle2.transform.eulerAngles = levels[PreferenceManager.LevelSelected - 1].vehicleInitialPosition.eulerAngles;
            }
        }
        else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle3.ToString())
        {
            rccMainCamera.playerCar = vehicle3.transform;
            miniMapController.target = vehicle3.transform;
            vehicle3.SetActive(true);
            DisplayColor(PreferenceManager.Vehicle3Color);
            vehicle3.GetComponent<RCCCarControllerV2>().enabled = false;

            if (PreferenceManager.LevelSelected == 0)
            {
                vehicle3.transform.position = levels[1].vehicleInitialPosition.position;
                vehicle3.transform.eulerAngles = levels[1].vehicleInitialPosition.eulerAngles;
            }
            else
            {
                vehicle3.transform.position = levels[PreferenceManager.LevelSelected - 1].vehicleInitialPosition.position;
                vehicle3.transform.eulerAngles = levels[PreferenceManager.LevelSelected - 1].vehicleInitialPosition.eulerAngles;
            }
        }
        else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle4.ToString())
        {
            rccMainCamera.playerCar = vehicle4.transform;
            miniMapController.target = vehicle4.transform;
            vehicle4.SetActive(true);
            DisplayColor(PreferenceManager.Vehicle4Color);
            vehicle4.GetComponent<RCCCarControllerV2>().enabled = false;

            if (PreferenceManager.LevelSelected == 0)
            {
                vehicle4.transform.position = levels[1].vehicleInitialPosition.position;
                vehicle4.transform.eulerAngles = levels[1].vehicleInitialPosition.eulerAngles;
            }
            else
            {
                vehicle4.transform.position = levels[PreferenceManager.LevelSelected - 1].vehicleInitialPosition.position;
                vehicle4.transform.eulerAngles = levels[PreferenceManager.LevelSelected - 1].vehicleInitialPosition.eulerAngles;
            }
        }
    }

    public void ReadyVehicle()
    {
        if (PreferenceManager.VehicleSelected == Vehicle.Vehicle1.ToString())
        {
            vehicle1.GetComponent<RCCCarControllerV2>().enabled = true;
            if (!vehicle1.GetComponent<RCCCarControllerV2>().engineRunning)
                vehicle1.GetComponent<RCCCarControllerV2>().KillOrStartEngine();
        }
        else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle2.ToString())
        {
            vehicle2.GetComponent<RCCCarControllerV2>().enabled = true;
            if (!vehicle2.GetComponent<RCCCarControllerV2>().engineRunning)
                vehicle2.GetComponent<RCCCarControllerV2>().KillOrStartEngine();
        }
        else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle3.ToString())
        {
            vehicle3.GetComponent<RCCCarControllerV2>().enabled = true;
            if (!vehicle3.GetComponent<RCCCarControllerV2>().engineRunning)
                vehicle3.GetComponent<RCCCarControllerV2>().KillOrStartEngine();
        }
        else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle4.ToString())
        {
            vehicle4.GetComponent<RCCCarControllerV2>().enabled = true;
            if (!vehicle4.GetComponent<RCCCarControllerV2>().engineRunning)
                vehicle4.GetComponent<RCCCarControllerV2>().KillOrStartEngine();
        }
    }

    private void DisplayColor(int colorNumber)
    {
        if (PreferenceManager.VehicleSelected == Vehicle.Vehicle1.ToString())
        {
            PreferenceManager.Vehicle1Color = colorNumber;

            if (colorNumber == 1)
                vehicle1.transform.GetChild(0).GetComponent<Renderer>().material.color = color1;
            else if (colorNumber == 2)
                vehicle1.transform.GetChild(0).GetComponent<Renderer>().material.color = color2;
            else if (colorNumber == 3)
                vehicle1.transform.GetChild(0).GetComponent<Renderer>().material.color = color3;
            else if (colorNumber == 4)
                vehicle1.transform.GetChild(0).GetComponent<Renderer>().material.color = color4;
            else if (colorNumber == 5)
                vehicle1.transform.GetChild(0).GetComponent<Renderer>().material.color = color5;
        }
        else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle2.ToString())
        {
            PreferenceManager.Vehicle2Color = colorNumber;

            if (colorNumber == 1)
                vehicle2.transform.GetChild(0).GetComponent<Renderer>().material.color = color1;
            else if (colorNumber == 2)
                vehicle2.transform.GetChild(0).GetComponent<Renderer>().material.color = color2;
            else if (colorNumber == 3)
                vehicle2.transform.GetChild(0).GetComponent<Renderer>().material.color = color3;
            else if (colorNumber == 4)
                vehicle2.transform.GetChild(0).GetComponent<Renderer>().material.color = color4;
            else if (colorNumber == 5)
                vehicle2.transform.GetChild(0).GetComponent<Renderer>().material.color = color5;
        }
        else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle3.ToString())
        {
            PreferenceManager.Vehicle3Color = colorNumber;

            if (colorNumber == 1)
                vehicle3.transform.GetChild(0).GetComponent<Renderer>().material.color = color1;
            else if (colorNumber == 2)
                vehicle3.transform.GetChild(0).GetComponent<Renderer>().material.color = color2;
            else if (colorNumber == 3)
                vehicle3.transform.GetChild(0).GetComponent<Renderer>().material.color = color3;
            else if (colorNumber == 4)
                vehicle3.transform.GetChild(0).GetComponent<Renderer>().material.color = color4;
            else if (colorNumber == 5)
                vehicle3.transform.GetChild(0).GetComponent<Renderer>().material.color = color5;
        }
        else if (PreferenceManager.VehicleSelected == Vehicle.Vehicle4.ToString())
        {
            PreferenceManager.Vehicle4Color = colorNumber;

            if (colorNumber == 1)
                vehicle4.transform.GetChild(0).GetComponent<Renderer>().material.color = color1;
            else if (colorNumber == 2)
                vehicle4.transform.GetChild(0).GetComponent<Renderer>().material.color = color2;
            else if (colorNumber == 3)
                vehicle4.transform.GetChild(0).GetComponent<Renderer>().material.color = color3;
            else if (colorNumber == 4)
                vehicle4.transform.GetChild(0).GetComponent<Renderer>().material.color = color4;
            else if (colorNumber == 5)
                vehicle4.transform.GetChild(0).GetComponent<Renderer>().material.color = color5;
        }
    }
}
