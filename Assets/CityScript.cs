using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class CityScript : MonoBehaviour
{
    public bool knowsWeather;
    private WeatherAPI weather;
    Text cityText;
    Text tempText;
    Text weatherText;
    // Use this for initialization

    void Start()
    {
        knowsWeather = false;
        cityText = GameObject.Find("City").GetComponent<Text>();
        tempText = GameObject.Find("Temp").GetComponent<Text>();
        weatherText = GameObject.Find("Weather").GetComponent<Text>();
        weather = WeatherAPI.FindObjectOfType<WeatherAPI>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!knowsWeather && weather.temp != 0)
        {
            cityText.text = weather.city + ", " + weather.country;
            tempText.text = (weather.temp * (9.0 / 5.0) - 459.67).ToString("0") + " F";
            weatherText.text = weather.weatherDescription;
            knowsWeather = true;
        }
    }
}