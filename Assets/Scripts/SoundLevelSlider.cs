using UnityEngine;
using UnityEngine.UI;

public class SoundLevelSlider : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        slider.value = Settings.soundLevel;
    }
    void Update()
    {
        Settings.soundLevel = slider.value;
    }
}
