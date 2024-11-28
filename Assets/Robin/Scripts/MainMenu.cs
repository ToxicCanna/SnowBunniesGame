using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync("RobinGym");
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
