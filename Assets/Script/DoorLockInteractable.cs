using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorLockInteractable : BaseInteractable
{
    private AudioSource melody;
    protected override void Start()
    {
        base.Start();
        melody = GetComponent<AudioSource>();
    }
    protected override void Interact()
    {
        text.text = "Play this sound to gain access!";
        melody.Play();
    }
}
