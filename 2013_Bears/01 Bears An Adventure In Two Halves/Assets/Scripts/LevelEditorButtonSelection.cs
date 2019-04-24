using UnityEngine;
using System.Collections;

public class LevelEditorButtonSelection : MonoBehaviour
{
    public static string selection;
    public static bool player1Exist = false;
    public static bool player2Exist = false;
    public static bool buttonExist = false;
    public static bool boxExist = false;

    public void ChooseTile(string tileSelection)
    {
        selection = tileSelection;
    }

    public void DisableSelect()
    {
        LevelEditor.selectable = false;
    }

    public void EnableSelect()
    {
        LevelEditor.selectable = true;
    }

    public void ResetValues()
    {
        player1Exist = false;
        player2Exist = false;
        buttonExist = false;
        boxExist = false;
        EnableSelect();
    }
}