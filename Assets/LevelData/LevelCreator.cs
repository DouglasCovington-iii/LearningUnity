using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class LevelCreator
{

    [UnityEditor.MenuItem("Assets/Create/Level Asset from Musician mode")]
    public static void DoesStuff()
    {
        LevelObject assetente = ScriptableObject.CreateInstance<LevelObject>();
        assetente.hitList = new List<float> { 1, 2, 4 };

        AssetDatabase.CreateAsset(assetente, "Assets/LevelData/Level1.asset");
        AssetDatabase.SaveAssets();
    }
}
