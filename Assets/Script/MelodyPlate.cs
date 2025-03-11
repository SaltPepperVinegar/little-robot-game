using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MelodyPlate : MonoBehaviour
{
    public NoteData note;
    public MelodyCheck melodyCheck;
    private AudioSource audioSource;
    private float cooldownTime = 1.5f;
    private bool canTrigger = true;
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = note.audioClip;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (canTrigger)
        {
            melodyCheck.SaveNoteToList(note.note);
            audioSource.Play();

            StartCoroutine(CooldownTimer());
        }
        
    }

    IEnumerator CooldownTimer()
    {
        canTrigger = false;
        

        yield return new WaitForSeconds(cooldownTime);

        canTrigger = true;
    }
}
