using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Enter our level scene name here:")]
    [SerializeField] private string levelName;
    public void Play()
    {
        SceneManager.LoadSceneAsync(levelName);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
