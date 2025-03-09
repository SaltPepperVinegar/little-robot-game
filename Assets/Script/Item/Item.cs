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
    public Note note = new Note();
    public bool inContact = false;

    public GameObject Base = null;
    public bool attached = false;
 
    public AudioSource notesAudio;

    public void AttachBase(){
        if(Base != null){
            attached = Base.GetComponentInParent<Base>().AttachItem(gameObject);
            

        }
    }

    public void DetachBase(){
        if(Base != null){
            attached = Base.GetComponentInParent<Base>().DetachItem(gameObject);

        }
    }
}   
