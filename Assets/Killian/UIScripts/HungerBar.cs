using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    [SerializeField] private float _timeToDrain = 0.75f;
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
    public void UpdateHungerBar()
    {
        _target = (PlayerStatsManager.Instance.GetHungerValue() / PlayerStatsManager.Instance.GetMaxHungerValue());
        _image.color = _gradient.Evaluate(_image.fillAmount);

        drainHungerBarCoroutine = StartCoroutine(DrainHungerBar());
        CheckHungerBarGradientAmount();

    }
    private IEnumerator DrainHungerBar()
    {
        float fillAmount = _image.fillAmount;
        float elapsedTime = 0f;
        while (elapsedTime <= _timeToDrain);
        {
            elapsedTime += Time.deltaTime;

            _image.fillAmount = Mathf.Lerp(fillAmount, _target, (elapsedTime / _timeToDrain));

            yield return null;
        }
    }

    private void CheckHungerBarGradientAmount()
    {
        _image.color = _gradient.Evaluate(_image.fillAmount);
    }
}
