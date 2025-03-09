using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MelodyCheck : MonoBehaviour
{
    private List<string> notesPlayed = new List<string>();
    public MelodyData melodyData;
    public SlidingDoor door1;
    public SlidingDoor door2;
    private bool DoorOpen;
    public void SaveNoteToList(string note)
    {
        notesPlayed.Add(note);

        if (notesPlayed.Count - 1 != melodyData.correctSequence.Count)
        {
            if (notesPlayed.SequenceEqual(melodyData.correctSequence))
            {
                if (door1 != null && door2 != null)
                {
                    door1.SetAnimation(!DoorOpen);
                    door2.SetAnimation(!DoorOpen);
                }
                
            }

            
        }
        else
        {
            Debug.Log("Notes Played: " + notesPlayed[0] + ", " + notesPlayed[1] + ", " + notesPlayed[2]);
            notesPlayed.Clear();
        }
    }
}

    