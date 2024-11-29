using UnityEngine;
using UnityEngine.UI;

public class WarmthBar : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Gradient _gradient;

    private float _target;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        CheckWarmthBarGradientAmount();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the target based on the player's warmth value
        _target = PlayerStatsManager.Instance.GetWarmthValue() / PlayerStatsManager.Instance.GetMaxWarmthValue();

        // Update the fill amount of the warmth bar
        _image.fillAmount = Mathf.Lerp(_image.fillAmount, _target, Time.deltaTime); // Lerp the value smoothly over time

        // Update the color based on the fill amount
        CheckWarmthBarGradientAmount();
    }

    private void CheckWarmthBarGradientAmount()
    {
        _image.color = _gradient.Evaluate(_image.fillAmount);
    }
}
