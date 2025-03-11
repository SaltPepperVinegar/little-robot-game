using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorLockInteractable : BaseInteractable
{
    private AudioSource melody;
    public MelodyCheck melodyCheck;
    public AudioClip failSound;
    public AudioClip correctSound;

    protected override void Start()
    {
        base.Start();
        melody = GetComponent<AudioSource>();
    }

    protected override void Interact()
    {
        text.text = "Play this sound to gain access!";
        melody.clip = melodyCheck.melodyData.audioClip;
        melody.Stop();
        melody.Play();
    }

    public void FailSound()
    {
        melody.clip = failSound;
        melody.Play();
    }

    public void CorrectSound()
    {
        melody.clip = correctSound;
        melody.Play();
    }
}