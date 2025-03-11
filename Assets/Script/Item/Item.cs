using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Note
    {
        a,
        asharp,
        b,
        c,
        csharp,
        d,
        dsharp,
        e,
        f,
        fsharp,
        g,
        gsharp,
    }


public class Item : MonoBehaviour
{   
    public Note note;
    public bool inContact = false;

    public GameObject Base = null;
    public bool attached = false;
    public bool playing;
    public AudioSource notesAudio;

    public bool hasBeenPickedup = false ;
    public void AttachBase(){
        if(Base != null){
            attached = Base.GetComponentInParent<Base>().AttachItem(gameObject);
            

        }
    }
    public void PlaySound(){
            notesAudio.Stop();
            notesAudio.Play();
    }
    public void DetachBase(){
        if(Base != null){
            attached = Base.GetComponentInParent<Base>().DetachItem(gameObject);

        }
    }
    public void ChangeVoice(AudioClip audioClip){
        notesAudio.clip = audioClip;
    }
    public void PlaySoundWhenNearBy(){
        if (!playing && !hasBeenPickedup){
            StartCoroutine(PlaySoundWithCoolDown());

        }
    }
    IEnumerator PlaySoundWithCoolDown(){
        playing = true;
        PlaySound();
        yield return new WaitForSeconds(3f);
        playing = false;
    }
}   
