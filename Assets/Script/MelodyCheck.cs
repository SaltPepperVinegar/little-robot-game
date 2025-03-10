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
    public void SaveNoteToList(Note note)
    {
        notesPlayed.Add(note);

        if (notesPlayed.Count - 1 != melodyData.correctSequence.Count)
        {
            if (notesPlayed.SequenceEqual(melodyData.correctSequence))
            {
                
            }

            
        }
        else
        {
            Debug.Log("Notes Played: " + notesPlayed[0] + ", " + notesPlayed[1] + ", " + notesPlayed[2]);
            notesPlayed.Clear();
        }
    }
}

    