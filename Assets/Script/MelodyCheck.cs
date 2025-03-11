using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MelodyCheck : MonoBehaviour
{
    private List<Note> notesPlayed = new List<Note>();
    public MelodyData melodyData;
    private bool DoorOpen;
    public DoorController doorLeft;
    public DoorController doorRight;
    
    public void SaveNoteToList(Note note)
    {
        notesPlayed.Add(note);
        Debug.Log(note);
        Debug.Log(melodyData.correctSequence[0]);
        Debug.Log(melodyData.correctSequence[1]);
        Debug.Log(melodyData.correctSequence[2]);
        
        if (notesPlayed.Count == melodyData.correctSequence.Count)
        {
            if (notesPlayed.SequenceEqual(melodyData.correctSequence))
            {
                doorLeft.OpenDoor();
                doorRight.OpenDoor();
                notesPlayed.Clear();
            }
            
        }
        
    }
}

    