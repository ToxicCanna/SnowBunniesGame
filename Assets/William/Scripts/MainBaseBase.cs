using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainBaseBase : MonoBehaviour
{
    [SerializeField] private int _stickRequired;
    [SerializeField] private int _currentSticks;
    [SerializeField] private int _logRequired;
    [SerializeField] private int _currentLogs;

    [SerializeField] private GameObject mainBaseModel;
    [SerializeField] private TMP_Text textUI;
    [SerializeField] private GameObject stickModelForUI;
    [SerializeField] private GameObject logModelForUI;


    private void Start()
    {
        _currentSticks = 0;
        _currentLogs = 0;
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Stick"))
        {
            if (_currentSticks < _stickRequired)
            {
                _currentSticks++;
                Destroy(other.gameObject);
                textUI.text = ": " + _currentSticks + "/" + _stickRequired + "       : " + _currentLogs + "/" + _logRequired;
                if (_currentSticks >= _stickRequired && _currentLogs >= _logRequired)
                {
                    mainBaseModel.SetActive(true);
                    textUI.gameObject.SetActive(false);
                    stickModelForUI.SetActive(false);
                    logModelForUI.SetActive(false);

                    StartCoroutine(WinTimer());
                }
            }
        }
        else if (other.gameObject.CompareTag("Log"))
        {
            if (_currentLogs < _logRequired)
            {
                _currentLogs++;
                Destroy(other.gameObject);
                textUI.text = ": " + _currentSticks + "/" + _stickRequired + "       : " + _currentLogs + "/" + _logRequired;
                if (_currentSticks >= _stickRequired && _currentLogs >= _logRequired)
                {
                    mainBaseModel.SetActive(true);
                    textUI.gameObject.SetActive(false);
                    stickModelForUI.SetActive(false);
                    logModelForUI.SetActive(false);

                    StartCoroutine(WinTimer());
                }
            }
        }
    }

    private IEnumerator WinTimer()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("YouWin");
    }
}
