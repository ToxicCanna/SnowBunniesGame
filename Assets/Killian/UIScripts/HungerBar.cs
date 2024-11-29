using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Gradient _gradient;
    private float _target;
    

    // Start is called before the first frame update
    private Coroutine drainHungerBarCoroutine;
    void Start()
    {
        _image = GetComponent<Image>();

        CheckHungerBarGradientAmount();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the target based on the player's hunger value
        _target = PlayerStatsManager.Instance.GetHungerValue() / PlayerStatsManager.Instance.GetMaxHungerValue();

        // Update the fill amount of the hunger bar
        _image.fillAmount = Mathf.Lerp(_image.fillAmount, _target, Time.deltaTime * 2f); // Lerp the value smoothly over time

        // Update the color based on the fill amount
        CheckHungerBarGradientAmount();
    }

    private void CheckHungerBarGradientAmount()
    {
        _image.color = _gradient.Evaluate(_image.fillAmount);
    }
}
