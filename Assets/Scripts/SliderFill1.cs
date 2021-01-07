using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderFill : MonoBehaviour
{
    [Tooltip("How long does it take for this slider to fill, in seconds")]
    private float FillTime;
    private Slider _slider;
    void Start()
    {
        FillTime = GameManager.Instance.nextLeveltime;        
        _slider = GetComponent<Slider>();
        Reset();
    }

    public void Reset()
    {
        _slider.minValue = Time.time;
        _slider.maxValue = Time.time + FillTime;
    }
    void Update()
    {
        _slider.value = Time.time;
    }
}