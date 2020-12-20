using System.Collections;
using UnityEngine;

public class TrafficLightHandler : MonoBehaviour
{
    public TrafficLights SelectNumberOfTrafficLights;

    public GameObject RedLightTrafficPole1;
    public GameObject OrangeLightTrafficPole1;
    public GameObject GreenLightTrafficPole1;

    public GameObject RedLightTrafficPole2;
    public GameObject OrangeLightTrafficPole2;
    public GameObject GreenLightTrafficPole2;

    public GameObject RedLightTrafficPole3;
    public GameObject OrangeLightTrafficPole3;
    public GameObject GreenLightTrafficPole3;

    public GameObject RedLightTrafficPole4;
    public GameObject OrangeLightTrafficPole4;
    public GameObject GreenLightTrafficPole4;

    private void OnEnable()
    {
        if (SelectNumberOfTrafficLights == TrafficLights.ThreeTrafficLights)
        {
            RedLightTrafficPole1.SetActive(true);
            RedLightTrafficPole2.SetActive(true);
            RedLightTrafficPole3.SetActive(true);

            OrangeLightTrafficPole1.SetActive(false);
            OrangeLightTrafficPole2.SetActive(false);
            OrangeLightTrafficPole3.SetActive(false);

            GreenLightTrafficPole1.SetActive(false);
            GreenLightTrafficPole2.SetActive(false);
            GreenLightTrafficPole3.SetActive(false);
        }
        else if (SelectNumberOfTrafficLights == TrafficLights.FourTrafficLights)
        {
            RedLightTrafficPole1.SetActive(true);
            RedLightTrafficPole2.SetActive(true);
            RedLightTrafficPole3.SetActive(true);
            RedLightTrafficPole4.SetActive(true);

            OrangeLightTrafficPole1.SetActive(false);
            OrangeLightTrafficPole2.SetActive(false);
            OrangeLightTrafficPole3.SetActive(false);
            OrangeLightTrafficPole4.SetActive(false);

            GreenLightTrafficPole1.SetActive(false);
            GreenLightTrafficPole2.SetActive(false);
            GreenLightTrafficPole3.SetActive(false);
            GreenLightTrafficPole4.SetActive(false);
        }

        StartCoroutine(TrafficPole1Couroutine());
    }

    private IEnumerator TrafficPole1Couroutine()
    {
        RedLightTrafficPole1.SetActive(false);
        OrangeLightTrafficPole1.SetActive(false);
        GreenLightTrafficPole1.SetActive(true);

        int timer = 15;
        while (timer != 0)
        {
            if(timer <= 2)
            {
                RedLightTrafficPole1.SetActive(false);
                OrangeLightTrafficPole1.SetActive(true);
                GreenLightTrafficPole1.SetActive(false);

                RedLightTrafficPole2.SetActive(false);
                OrangeLightTrafficPole2.SetActive(true);
                GreenLightTrafficPole2.SetActive(false);
            }

            yield return new WaitForSeconds(1);
            timer--;
        }

        RedLightTrafficPole1.SetActive(true);
        OrangeLightTrafficPole1.SetActive(false);
        GreenLightTrafficPole1.SetActive(false);

        StartCoroutine(TrafficPole2Couroutine());
    }

    private IEnumerator TrafficPole2Couroutine()
    {
        RedLightTrafficPole2.SetActive(false);
        OrangeLightTrafficPole2.SetActive(false);
        GreenLightTrafficPole2.SetActive(true);

        int timer = 15;
        while (timer != 0)
        {
            if (timer <= 2)
            {
                RedLightTrafficPole2.SetActive(false);
                OrangeLightTrafficPole2.SetActive(true);
                GreenLightTrafficPole2.SetActive(false);

                RedLightTrafficPole3.SetActive(false);
                OrangeLightTrafficPole3.SetActive(true);
                GreenLightTrafficPole3.SetActive(false);
            }

            yield return new WaitForSeconds(1);
            timer--;
        }

        RedLightTrafficPole2.SetActive(true);
        OrangeLightTrafficPole2.SetActive(false);
        GreenLightTrafficPole2.SetActive(false);

        StartCoroutine(TrafficPole3Couroutine());
    }

    private IEnumerator TrafficPole3Couroutine()
    {
        RedLightTrafficPole3.SetActive(false);
        OrangeLightTrafficPole3.SetActive(false);
        GreenLightTrafficPole3.SetActive(true);

        int timer = 15;
        while (timer != 0)
        {
            if (timer <= 2)
            {
                RedLightTrafficPole3.SetActive(false);
                OrangeLightTrafficPole3.SetActive(true);
                GreenLightTrafficPole3.SetActive(false);

                if (SelectNumberOfTrafficLights == TrafficLights.ThreeTrafficLights)
                {
                    RedLightTrafficPole1.SetActive(false);
                    OrangeLightTrafficPole1.SetActive(true);
                    GreenLightTrafficPole1.SetActive(false);
                }
                else if (SelectNumberOfTrafficLights == TrafficLights.FourTrafficLights)
                {
                    RedLightTrafficPole4.SetActive(false);
                    OrangeLightTrafficPole4.SetActive(true);
                    GreenLightTrafficPole4.SetActive(false);
                }
            }

            yield return new WaitForSeconds(1);
            timer--;
        }

        RedLightTrafficPole3.SetActive(true);
        OrangeLightTrafficPole3.SetActive(false);
        GreenLightTrafficPole3.SetActive(false);

        if (SelectNumberOfTrafficLights == TrafficLights.ThreeTrafficLights)
            StartCoroutine(TrafficPole1Couroutine());
        else if (SelectNumberOfTrafficLights == TrafficLights.FourTrafficLights)
            StartCoroutine(TrafficPole4Couroutine());
    }

    private IEnumerator TrafficPole4Couroutine()
    {
        RedLightTrafficPole4.SetActive(false);
        OrangeLightTrafficPole4.SetActive(false);
        GreenLightTrafficPole4.SetActive(true);

        int timer = 15;
        while (timer != 0)
        {
            if (timer <= 2)
            {
                RedLightTrafficPole4.SetActive(false);
                OrangeLightTrafficPole4.SetActive(true);
                GreenLightTrafficPole4.SetActive(false);

                RedLightTrafficPole1.SetActive(false);
                OrangeLightTrafficPole1.SetActive(true);
                GreenLightTrafficPole1.SetActive(false);
            }

            yield return new WaitForSeconds(1);
            timer--;
        }

        RedLightTrafficPole4.SetActive(true);
        OrangeLightTrafficPole4.SetActive(false);
        GreenLightTrafficPole4.SetActive(false);

        StartCoroutine(TrafficPole1Couroutine());
    }
}

public enum TrafficLights
{
    ThreeTrafficLights,
    FourTrafficLights
}

