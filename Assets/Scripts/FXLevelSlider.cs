using UnityEngine;
using UnityEngine.UI;

public class FXLevelSlider : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>(); 
    }

    void Start()
    {
        slider.value = Settings.fxLevel;
    }
    void Update()
    {
        Settings.fxLevel = slider.value;
    }
}
