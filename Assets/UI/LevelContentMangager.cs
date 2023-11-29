using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelContentMangager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject content;
    public GameObject buttonGameObjPrefab;
    void Start()
    {
        List<FileInfo> listOfFiles = new List<FileInfo>(new DirectoryInfo(@"C:\dev\Unity\LetsLearnUnity\Assets\Resources\LevelData\").GetFiles());
        listOfFiles.Sort((item1, item2) => item1.Name.CompareTo(item2.Name));

        List<string> listOfLevelNames = new List<string>();

        foreach (FileInfo file in listOfFiles)
        {
            string extension = file.Name.Substring(file.Name.LastIndexOf('.'));

            if (extension == ".asset")
            {
                listOfLevelNames.Add(file.Name.Substring(0, file.Name.LastIndexOf('.')));
            }
            else if (extension != ".meta")
            {
                throw new System.Exception($"filename: {file.Name}\nextension: {extension}");
            }
        }

        foreach (string levelName in listOfLevelNames)
        {
            GameObject buttonGameObj = Instantiate(buttonGameObjPrefab);
            buttonGameObj.transform.SetParent(content.transform, false);
            buttonGameObj.name = levelName;

            TextMeshProUGUI buttonText = buttonGameObj.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = levelName;
            buttonText.fontSize = 10;

            Button button = buttonGameObj.GetComponent<Button>();
            button.onClick.AddListener(SetUpLevel);

            //Transform buttonText = buttonGameObj.transform.Find("Text (TMP)");
            //gameObject
        }
    }

    void SetUpLevel()
    {
        GameObject selButton = EventSystem.current.currentSelectedGameObject;
        string levelName = selButton.name;

        Debug.Log($"LevelData/{levelName}");
        LevelObject currentLevel = Resources.Load<LevelObject>($"LevelData/{levelName}");
        GameData.currLevel = currentLevel;
        SceneManager.LoadScene("GameLoop");
    }

    // Update is called once per frame
}
