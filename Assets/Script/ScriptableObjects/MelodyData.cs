using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melody", menuName = "Melody Puzzle/MelodyData")]
public class MelodyData : ScriptableObject
{
    public List<String> correctSequence;
}