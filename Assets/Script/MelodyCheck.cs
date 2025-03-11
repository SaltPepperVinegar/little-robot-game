using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MelodyCheck : MonoBehaviour
{
    private List<Note> notesPlayed = new List<Note>();
    public MelodyData melodyData;
    public Transform hinge;
    private bool DoorOpen;
    private bool isRotating = false;
    private float rotationSpeed = 60f;
    private float doorOpenTargetAngle = -110f;
    private float doorCloseTargetAngle = 0f;
    private float currentAngle = 0f;
    public GameObject door;

    public void SaveNoteToList(Note note)
    {
        notesPlayed.Add(note);
        
        if (notesPlayed.Count == melodyData.correctSequence.Count)
        {
            if (notesPlayed.SequenceEqual(melodyData.correctSequence))
            {
                DoorOpen = true;
                isRotating = true;
            }
            else
            {
                Debug.Log("Incorrect Melody");
            }

        }
        else
        {
            //Debug.Log("Notes Played: " + notesPlayed[0] + ", " + notesPlayed[1] + ", " + notesPlayed[2]);
            notesPlayed.Clear();
        }
    }

    void Update()
    {
        if (isRotating)
        {
            RotateDoors();
        }
    }

    private void RotateDoors()
    {
        float rotationStep = rotationSpeed * Time.deltaTime;
        if (DoorOpen)
        {
            if (currentAngle < doorOpenTargetAngle)
            {
                door.transform.RotateAround(hinge.position, Vector3.up, rotationStep);
                currentAngle += rotationStep;
            }
            else
            {
                isRotating = false;
            }

        }
        else
        {
            if (currentAngle > 0)
            {
                door.transform.RotateAround(hinge.position, Vector3.up, -rotationStep);
                currentAngle -= rotationStep;
            }
            else
            {
                isRotating = false;
            }
        }
    }
}

    