using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;

namespace GameJam.UI.Weather
{
    public class SystemWeather : MonoBehaviour
    {
        public enum WeatherIconDescription
        {
            None,
            ClearSky,
            FewCloud,
            ScatteredCoulds,
            BrokenClouds,
            ShowerRain,
            Rain,
            Thunderstorm,
            Snow,
            Mist

        }


        string weatherIconUrl = "http://openweathermap.org/img/wn/{0}@2x.png";
        string url = "api.openweathermap.org/data/2.5/weather?id=1733046&appid=9c78607042d0ed7905dcdc5e26802a81&units=metric";

        public WeatherResponse response;

        [Space]
        public WeatherIconDescription iconDescription;

        IEnumerator Start()
        {
            using(UnityWebRequest wr = UnityWebRequest.Get(url))
            {
                yield return wr.SendWebRequest();

                if(wr.error == null)
                {
                    Debug.Log(wr.downloadHandler.text);
                    response = new WeatherResponse();

                    response = JsonUtility.FromJson<WeatherResponse>(wr.downloadHandler.text);
                }
                else
                {
                    Debug.Log("error : " + wr.error);
                }
            }
        }
    }

    [Serializable]
    public class WeatherResponse
    {
        public WeatherDetails[] weather;
        [Space]
        public MainDetails main;
    }

    [Serializable]
    public class WeatherDetails
    {
        public int id;
        public string main;
        public string description;
        public string icon;

        /*

        */
    }

    [Serializable]
    public class MainDetails
    {
        public float temp;
        public float temp_min;
        public float temp_max;
        public int humidity;
    }
}