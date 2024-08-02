using UnityEngine;

public class Sound : MonoBehaviour
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
