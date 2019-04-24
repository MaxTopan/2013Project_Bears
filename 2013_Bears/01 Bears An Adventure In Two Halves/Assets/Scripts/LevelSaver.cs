using UnityEngine;
using System.Collections;

public class LevelSaver : MonoBehaviour
{
    private RaycastHit hit;
    public char currentObject;
    public static string levelContents = "";
    static int row = 10, col = 16;

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Level: " + levelContents);
        }
    }*/

    /// <summary>
    /// writes characters to correct place in string
    /// </summary>
    public void WriteFile()
    {
        levelContents = "";
        // for number of rows
        for (int i = row; i > 0; i--)
        {
            // if not before first line, write a page break
            if (i != 10)
                levelContents = levelContents + "\r\n";
            // for number of columns
            for (int j = 0; j < col; j++)
            {
                // move saveBlock to location
                gameObject.transform.position = new Vector3(j, 1.9f, i);
                ReadObject();
                levelContents = levelContents + currentObject;
            }
        }
    }

    public void ReadObject()
    {
        if (Physics.Raycast(gameObject.transform.position, Vector3.down, out hit, 1))
        {
            //Debug.Log("detected");
            //Debug.Log(hit.collider.tag);

            switch (hit.collider.tag)
            {
                case "Player1":
                    currentObject = 'O';
                    break;

                case "Player2":
                    currentObject = 'P';
                    break;

                case "LeftWall":
                    currentObject = 'Q';
                    break;

                case "RightWall":
                    currentObject = 'W';
                    break;

                case "LeftExit":
                    currentObject = 'Z';
                    break;

                case "RightExit":
                    currentObject = 'X';
                    break;

                case "Box":
                    currentObject = 'A';
                    break;

                case "Button":
                    currentObject = 'S';
                    break;

                case "Bear":
                    currentObject = 'C';
                    break;

                case "Pit":
                    currentObject = 'E';
                    break;

                case "Water":
                    currentObject = 'R';
                    break;

                default:
                    currentObject = '-';
                    break;
            }
        }
    }
}