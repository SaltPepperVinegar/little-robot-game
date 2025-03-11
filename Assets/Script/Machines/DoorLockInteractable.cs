using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorLockInteractable : BaseInteractable
{
    private AudioSource melody;
    public MelodyCheck melodyCheck;

    protected override void Start()
    {
        base.Start();
        melody = GetComponent<AudioSource>();
        melody.clip = melodyCheck.melodyData.audioClip;
    }

    protected override void Interact()
    {
        text.text = "Play this sound to gain access!";
        melody.Stop();
        melody.Play();
    }
}