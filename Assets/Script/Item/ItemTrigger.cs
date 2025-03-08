using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{   
    public GameObject parent;
    private Item item;
    void Start()
    {
        item = parent.GetComponent<Item>();
    }
    void OnTriggerEnter(Collider collision)
    {

        if(collision.gameObject.tag == "Pickup" ){
            item.inContact = true;
        } 
        if(collision.gameObject.tag == "Base"){
            item.Base = collision.gameObject;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "Pickup" ){
            item.inContact = false;
        }
        if(collision.gameObject.tag == "Base"){
            item.Base = null;
        }

    }
}
