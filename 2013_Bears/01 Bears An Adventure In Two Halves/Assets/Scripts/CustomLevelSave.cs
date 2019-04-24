using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class CustomLevelSave : MonoBehaviour
{
    public InputField inputName;
    char delimiterChar = ',';
    private string path = "Assets/Levels/Resources/_CustomLevels.txt";

    public void SaveNames()
    {
        File.AppendAllText(path, delimiterChar + inputName.text);
    }
}
