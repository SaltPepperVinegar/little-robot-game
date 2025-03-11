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
        
        if (notesPlayed.Count == melodyData.correctSequence.Count)
        {
            if (notesPlayed.SequenceEqual(melodyData.correctSequence))
            {
                
                notesPlayed.Clear();
            }

            
        }
        
    }
}

    