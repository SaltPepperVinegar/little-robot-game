using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MelodySet", menuName = "Melody Puzzle/MelodySetData")]
public class MelodySet : ScriptableObject
{
    public Note[] Melody;


    public float[] quartersAfterEachNote;
    public float BPM = 120f;

}