using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{   
    public GameObject floatPoint;
    public bool attached=false;

    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool AttachItem(GameObject item){
        if (!attached){
            gameObject = item; 
            item.transform.SetParent(floatPoint.transform);
            item.transform.position = floatPoint.transform.position;
            item.transform.localRotation = Quaternion.Euler(0, 0, 0);
            attached = true;
            Rigidbody rigidbody = item.GetComponent<Rigidbody>();
            rigidbody.isKinematic = true;
            return true;
        }
        return false;

    }
    public bool DetachItem(GameObject item){
        if (attached){
            gameObject = null;
            item.transform.SetParent(null);
            attached = false;
            Rigidbody rigidbody = item.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            return false;
        }
        return true;

    }

}
