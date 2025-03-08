using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour
{   
    public Note note = new Note();
    public bool inContact = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
    void OnTriggerEnter(Collider collision)
    {

        if(collision.gameObject.tag == "Pickup" ){
            inContact = true;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "Pickup" ){
            inContact = false;
        }

    }
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
}
