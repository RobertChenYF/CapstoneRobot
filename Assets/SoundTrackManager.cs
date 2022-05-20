using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrackManager : MonoBehaviour
{
    public AudioClip[] gameSoundTrack;
    private AudioSource soundTrackPlayer;
    // Start is called before the first frame update
    void Start()
    {
        soundTrackPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            fadeOut();
        }
    }


    public void startPlay(int audioCode)
    {
        soundTrackPlayer.Stop();
        soundTrackPlayer.volume = 1;
        soundTrackPlayer.PlayOneShot(gameSoundTrack[audioCode]);
    }

    public void fadeOut()
    {
        StartCoroutine(FadeOutMusic(soundTrackPlayer));
    }

    public void fadeIn(int audioCode)
    {
        soundTrackPlayer.PlayOneShot(gameSoundTrack[audioCode]);
        StartCoroutine(FadeInMusic(soundTrackPlayer));
    }

    IEnumerator FadeOutMusic(AudioSource audio)
    {
        
        for (float a = 1f; a >= 0; a -= 0.5f * Time.deltaTime)
        {
            audio.volume = a;
            yield return null;
        }

        audio.Stop();
    }

    IEnumerator FadeInMusic(AudioSource audio)
    {

        for (float a = 0f; a <=1; a += 0.5f * Time.deltaTime)
        {
            audio.volume = a;
            yield return null;
        }
    }
}
