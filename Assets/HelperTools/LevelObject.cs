
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewExampleData", menuName = "Example Data", order = 51)]
public class LevelObject : ScriptableObject
{
    public List<float> hitTimes;
    public AudioClip song;
}
