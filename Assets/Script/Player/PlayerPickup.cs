using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private GameObject item = null;
    float distance = float.PositiveInfinity;
    public bool pickedUp = false;
    public GameObject playerObject;
    public GameObject holdPoint;

    /*
    private void OnTriggerStay(Collider collision)
    {   
        if (!pickedUp){
            if (collision.gameObject.tag == "Item"){
                Vector3 directionToTarget = collision.gameObject.transform.position - transform.position;
                float dSqrToTarget = directionToTarget.sqrMagnitude;

                if (dSqrToTarget < distance){
                    instrument = collision.gameObject;
                    distance = dSqrToTarget;
                }
            }

        }
    }
*/
    
    private void Update()
    {
        if (!pickedUp){
            item = FindClosestWithTag("Item");
            //Debug.Log(item);
        } else{
        }


        if (Input.GetButtonDown("Use Item")){
            pickup();
        }
        if (Input.GetButtonDown("Shake")){
            if (pickedUp ){
                ItemOscillation itemscript = item.GetComponentInChildren<ItemOscillation>();
                itemscript.shakeBell();
            }
        }
    }

    private void pickup(){
        if (item == null)
        {
            return;
        }
        Item itemscript = item.GetComponent<Item>();
        if (!pickedUp){
            if (itemscript.inContact){
                if( itemscript.attached){
                    itemscript.DetachBase();
                }
                item.transform.SetParent(playerObject.transform);

                item.transform.localRotation = holdPoint.transform.localRotation;
                item.transform.position = holdPoint.transform.position;

                pickedUp = true;
                Rigidbody rigidbody = item.GetComponent<Rigidbody>();
                rigidbody.isKinematic = true;
                Debug.Log("pick up ");
            }
        } else{
            pickedUp = false;
            Rigidbody rigidbody = item.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            item.transform.SetParent(null);
            itemscript.AttachBase();
            Debug.Log("Drop Down");
        }

    }

    GameObject FindClosestWithTag(string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        GameObject closestObject = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject obj in objects)
        {
            float distance = Vector3.Distance(currentPosition, obj.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = obj;
            }
        }
        return closestObject;
    }

}
