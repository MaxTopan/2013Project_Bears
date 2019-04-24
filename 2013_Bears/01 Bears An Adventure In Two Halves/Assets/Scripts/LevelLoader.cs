using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    public void GetLevel(int levels)
    {
        if (levels == -1)
        {
            Application.Quit();
        }
        else
        {
            Application.LoadLevel(levels);
        }
    }

    public void ResetLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}