using UnityEngine;

public static class PreferenceManager
{
    public static string Username
    {
        get { return PlayerPrefs.GetString("USER_NAME", null);}

        set { PlayerPrefs.SetString("USER_NAME", value);}
    }

    public static string Email
    {
        get { return PlayerPrefs.GetString("EMAIL", null); }

        set { PlayerPrefs.SetString("EMAIL", value); }
    }

    public static int LevelNumber
    {
        get { return PlayerPrefs.GetInt("LEVEL_NUMBER", 1);}

        set { PlayerPrefs.SetInt("LEVEL_NUMBER", value);}
    }

    public static int Coins
    {
        get { return PlayerPrefs.GetInt("COINS", 500); }

        set { PlayerPrefs.SetInt("COINS", value); }
    }

    public static string VehicleSelected
    {
        get { return PlayerPrefs.GetString("VEHICLE_SELECTED", Vehicle.Vehicle1.ToString()); }

        set { PlayerPrefs.SetString("VEHICLE_SELECTED", value); }
    }

    public static string Vehicle2
    {
        get { return PlayerPrefs.GetString("VEHICLE_2", State.Locked.ToString()); }

        set { PlayerPrefs.SetString("VEHICLE_2", value); }
    }

    public static string Vehicle3
    {
        get { return PlayerPrefs.GetString("VEHICLE_3", State.Locked.ToString()); }

        set { PlayerPrefs.SetString("VEHICLE_2", value); }
    }

    public static string Vehicle4
    {
        get { return PlayerPrefs.GetString("VEHICLE_4", State.Locked.ToString()); }

        set { PlayerPrefs.SetString("VEHICLE_2", value); }
    }

    public static float Music
    {
        get { return PlayerPrefs.GetFloat("MUSIC", 0.8f); }

        set { PlayerPrefs.SetFloat("MUSIC", value); }
    }

    public static float SFX
    {
        get { return PlayerPrefs.GetFloat("SFX", 0.8f); }

        set { PlayerPrefs.SetFloat("SFX", value); }
    }

    public static string Controls
    {
        get { return PlayerPrefs.GetString("CONTROLS",ControlType.Buttons.ToString()); }

        set { PlayerPrefs.SetString("CONTROLS", value); }
    }
}

public enum State
{
    Locked,
    Unlocked
}
