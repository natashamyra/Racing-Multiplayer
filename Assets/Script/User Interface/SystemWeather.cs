using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace GameJam.UI.Weather
{
    public class SystemWeather : MonoBehaviour
    {
        public enum WeatherIconDescription
        {
            None,
            Thunderstorm,
            Drizzle,
            Rain,
            Mist,
            Smoke,
            Haze,
            Dust,
            Fog,
            Sand,
            Clear,
            Clouds
        }

        #region variable
        public Sprite[] weatherIcons;

        [Space(10)]
        public TextMeshProUGUI weatherText;
        public TextMeshProUGUI temperatureText;
        public Image weatherIcon;

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

                    weatherText.SetText($"{response.weather[0].main}");
                    temperatureText.SetText($"{response.main.temp} °C");

                    UpdateIcon(response.weather[0].main);
                }
                else
                {
                    Debug.Log("error : " + wr.error);
                }
            }
        }
        #endregion

        void UpdateIcon(string value)
        {
            switch (value)
            {
                case "Thunderstorm":
                    iconDescription = WeatherIconDescription.Thunderstorm;
                    weatherIcon.sprite = weatherIcons[1];
                    break;
                case "Drizzle":
                    iconDescription = WeatherIconDescription.Drizzle;
                    weatherIcon.sprite = weatherIcons[2];
                    break;
                case "Rain":
                    iconDescription = WeatherIconDescription.Rain;
                    weatherIcon.sprite = weatherIcons[3];
                    break;
                case "Mist":
                    iconDescription = WeatherIconDescription.Mist;
                    weatherIcon.sprite = weatherIcons[0];
                    break;
                case "Smoke":
                    iconDescription = WeatherIconDescription.Smoke;
                    weatherIcon.sprite = weatherIcons[0];
                    break;
                case "Haze":
                    iconDescription = WeatherIconDescription.Haze;
                    weatherIcon.sprite = weatherIcons[0];
                    break;
                case "Dust":
                    iconDescription = WeatherIconDescription.Dust;
                    weatherIcon.sprite = weatherIcons[0];
                    break;
                case "Fog":
                    iconDescription = WeatherIconDescription.Fog;
                    weatherIcon.sprite = weatherIcons[0];
                    break;
                case "Sand":
                    iconDescription = WeatherIconDescription.Sand;
                    weatherIcon.sprite = weatherIcons[0];
                    break;
                case "Clear":
                    iconDescription = WeatherIconDescription.Clear;
                    weatherIcon.sprite = weatherIcons[0];
                    break;
                case "Clouds":
                    iconDescription = WeatherIconDescription.Clouds;
                    weatherIcon.sprite = weatherIcons[4];
                    break;
                default:
                    weatherIcon.sprite = weatherIcons[0];
                    break;
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