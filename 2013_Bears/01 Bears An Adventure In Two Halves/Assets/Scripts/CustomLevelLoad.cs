using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;

public class CustomLevelLoad : MonoBehaviour
{
    [Header("Custom Levels")]
    public Text custom1;
    public Text custom2, custom3, custom4;
    public Text custom5;
    private string path = "Assets/Levels/Resources/_CustomLevels.txt";
    private char delimiterChar = ',';
    private string[] levels = new string[5];
    public static string customLevelToLoad = "";

    public void CreateLevelList()
    {
        string namesString = File.ReadAllText(path);
        List<string> customNames = namesString.Split(delimiterChar).ToList();
        for (int i = 0; i < customNames.Count; i++)
        {
            switch (i)
            {
                case 0:
                    break;

                case 1:
                    custom1.text = customNames[i];
                    levels[0] = customNames[i];
                    break;

                case 2:
                    custom2.text = customNames[i];
                    levels[1] = customNames[i];
                    break;

                case 3:
                    custom3.text = customNames[i];
                    levels[2] = customNames[i];
                    break;

                case 4:
                    custom4.text = customNames[i];
                    levels[3] = customNames[i];
                    break;

                case 5:
                    custom5.text = customNames[i];
                    levels[4] = customNames[i];
                    break;
            }
        }
    }

    public void LoadLevels(int i)
    {
        customLevelToLoad = levels[i];
    }
}