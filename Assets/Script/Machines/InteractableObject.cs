using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public TextMeshProUGUI text;
    private bool inRange;
    private GameObject player;  
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        if (player != null)
        {
            Vector3 playerPos = player.transform.position + new Vector3(0, 3, 0);
            text.transform.LookAt(playerPos);
            text.transform.Rotate(0, 180, 0);
        }
        
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            text.text = "Interacted!";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.tag == "Player")
        {
            text.text = "Press E to Interact!";
            
            inRange = true;
        }
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            text.text = "";
            inRange = false;
        }
        
    }
}
