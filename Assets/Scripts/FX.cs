using UnityEngine;

public class FX : MonoBehaviour
{
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        source.volume = Settings.soundLevel;
    }
}
