using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using SimpleJSON;
public class WeatherAPI : MonoBehaviour
{
    public string url;
    public string city;
    public string country;
    public string weatherDescription;
    public float temp;
    public float temp_min;
    public float temp_max;
    public float rain;
    public float wind;
    public float clouds;
    // Use this for initialization
    IEnumerator Start()
    {
        //might need to move all of this to update()
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "paris")
            url = "http://api.openweathermap.org/data/2.5/weather?q=Paris,FR&APPID=5b988441b41f98a313c4e4926bd5438e";
        else if (scene.name == "compass")
            url = "http://api.openweathermap.org/data/2.5/weather?zip=23220,US&APPID=5b988441b41f98a313c4e4926bd5438e";

        WWW request = new WWW(url);
        yield return request;
        if (request.error == null || request.error == "")
        {
            setWeatherAttributes(request.text);
        }
        else
        {
            Debug.Log("Error: " + request.error);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
    void setWeatherAttributes(string jsonString)
    {
        var weatherJson = JSON.Parse(jsonString);
        city = weatherJson["name"].Value;
        weatherDescription = weatherJson["weather"][0]["description"].Value;
        temp = weatherJson["main"]["temp"].AsFloat;
        temp_min = weatherJson["main"]["temp_min"].AsFloat;
        temp_max = weatherJson["main"]["temp_max"].AsFloat;
        rain = weatherJson["rain"]["3h"].AsFloat;
        clouds = weatherJson["clouds"]["all"].AsInt;
        wind = weatherJson["wind"]["speed"].AsFloat;
        country = weatherJson["sys"]["country"].Value;
    }
}