using UnityEngine;

public class GarageManager : MonoBehaviour
{
    public GameObject vehicle1;
    public GameObject vehicle2;
    public GameObject vehicle3;
    public GameObject vehicle4;

    public static GarageManager _instance;
    public static GarageManager Instance
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

    public void DisplayVehicle(string vehicle)
    {
        vehicle1.SetActive(false);
        vehicle2.SetActive(false);
        vehicle3.SetActive(false);
        vehicle4.SetActive(false);

        if (vehicle == Vehicle.Vehicle1.ToString())
            vehicle1.SetActive(true);
        else if (vehicle == Vehicle.Vehicle2.ToString())
            vehicle2.SetActive(true);
        else if (vehicle == Vehicle.Vehicle3.ToString())
            vehicle3.SetActive(true);
        else if (vehicle == Vehicle.Vehicle4.ToString())
            vehicle4.SetActive(true);
    }
}

public enum Vehicle
{
    Vehicle1,
    Vehicle2,
    Vehicle3,
    Vehicle4
}
