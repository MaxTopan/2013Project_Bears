using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class LevelNameInput : MonoBehaviour
{
    public static string levelName;
    public string metaContents;
    public UnityEngine.UI.InputField inputName;
    string path = "Assets/Levels/Resources/" + levelName + ".txt";
    string metaPath = "Assets/Levels/Resources/" + levelName + ".txt.meta";

    // Use this for initialization
    void Start()
    {

    }

    /// <summary>
    /// reads inputfield and creates a path for level and meta file
    /// </summary>
    public void NameChange()
    {
        levelName = inputName.text;
        //Debug.Log(levelName);
        //path = @"E:\Games\01TestGame\Assets\Levels\Resources\" + levelName + ".txt";
        path = "Assets/Levels/Resources/" + levelName + ".txt";
        MetaCreator();
        metaPath = "Assets/Levels/Resources/" + levelName + ".txt.meta";
    }

    /// <summary>
    /// creates the text to be written into the meta file, including guid
    /// </summary>
    public void MetaCreator()
    {
        Guid g; 
        g = Guid.NewGuid();
        metaContents =
@"fileFormatVersion: 2
guid: " + g + @"
TextScriptImporter:
  userData: ";
    }

    /// <summary>
    /// creates the files and writes the strings into them
    /// </summary>
    public void SaveLevel()
    {
        // create textfile with all text being what saveBlock picked up in LevelSaver
        File.Create(levelName);
        File.WriteAllText(path, LevelSaver.levelContents);

        // create meta file as object reference for above textfile
        File.Create(levelName + ".txt.meta");
        File.WriteAllText(metaPath, metaContents);
    }
}
