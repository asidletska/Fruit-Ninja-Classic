using UnityEngine;

public class SoundEffectButton : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip clickFx;

    public void ClickSound()
    {
        myFx.PlayOneShot(clickFx);
    }
}
