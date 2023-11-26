using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="LevelData", menuName = "Level Asset")]
public class LevelObject : ScriptableObject
{
    public List<float> hitList;
    public AudioClip song;
}

