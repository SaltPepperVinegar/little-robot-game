using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CheckNotes : MonoBehaviour
{
    public TextMeshProUGUI text;
    private bool inRange;
    private GameObject player;
    public GameObject BaseManagement;

    private ProgressManagement management;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        management = BaseManagement.GetComponent<ProgressManagement>();
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
            management.CheckForMelody();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.tag == "Player")
        {
            text.text = "Press E to Ring the Bell!";
            
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
