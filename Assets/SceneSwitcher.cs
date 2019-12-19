using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("main menu");
    }

    public void GotoLocation1()
    {
        SceneManager.LoadScene("compass");
    }

    public void GotoLocation2()
    {
        SceneManager.LoadScene("paris");
    }
}