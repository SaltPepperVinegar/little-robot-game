using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Ambience : MonoBehaviour
{
    public AudioClip loopAudioClip; // Assign in Inspector
    public AudioClip oneShotAudioClip; // Assign in Inspector
    private AudioSource audioSource;
    private AudioSource oneShotAudioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = loopAudioClip;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.volume = 0f; // Start with volume at 0
        audioSource.Play();
        StartCoroutine(FadeIn(audioSource, 2f)); // Fade in over 2 seconds

        oneShotAudioSource = gameObject.AddComponent<AudioSource>();
        oneShotAudioSource.clip = oneShotAudioClip;

        Invoke("PlayOneShot", loopAudioClip.length);
    }

    IEnumerator FadeIn(AudioSource source, float duration)
    {
        float startVolume = 0f;
        float targetVolume = 1f;
        float time = 0;

        while (time < duration)
        {
            source.volume = Mathf.Lerp(startVolume, targetVolume, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        source.volume = targetVolume;
    }

    void PlayOneShot()
    {
        oneShotAudioSource.PlayOneShot(oneShotAudioClip);
        Invoke("PlayOneShot", loopAudioClip.length);
    }
}
