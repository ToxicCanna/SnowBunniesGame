using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CampfireBase : MonoBehaviour
{
    [SerializeField] private int _stickRequired;
    [SerializeField] private int _currentSticks;
    [SerializeField] private GameObject campfireModel;
    [SerializeField] private TMP_Text textUI;
    [SerializeField] private GameObject stickModelForUI;

    private void Start()
    {
        _currentSticks = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.CompareTag("Stick"))
        {
            _currentSticks++;
            Destroy(other.gameObject);
            textUI.text = ": " + _currentSticks + "/" + _stickRequired;
            if (_currentSticks >= _stickRequired)
            {
                campfireModel.SetActive(true);
                textUI.gameObject.SetActive(false);
                stickModelForUI.SetActive(false);
            }
        }
        
    }
}
