using UnityEngine;
using System.Collections;

public class RadioSound : MonoBehaviour {

    public AudioSource source;
    public AudioClip sound;
    public int wait = 10;
    bool keepPlaying=true;

    void Start () {
        StartCoroutine(SoundOut());
    }

    IEnumerator SoundOut()
    {
        while (keepPlaying) {
            source.PlayOneShot(sound);  
            yield return new WaitForSeconds(wait);
        }
    }
}
