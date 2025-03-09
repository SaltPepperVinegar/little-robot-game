using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Note1", menuName = "Melody Puzzle/NoteData")]
public class NoteData : ScriptableObject
{
    public AudioClip audioClip;
    public Note note;
}