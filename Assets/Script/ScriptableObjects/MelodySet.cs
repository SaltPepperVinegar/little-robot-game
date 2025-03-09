using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MelodySet", menuName = "Melody Puzzle/MelodySetData")]
public class MelodySet : ScriptableObject
{
    public List<Note> Melody;


    public List<float> quartersAfterEachNote;
    public float BPM = 120f;

}