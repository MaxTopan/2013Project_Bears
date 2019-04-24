using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class LevelReader : MonoBehaviour
{
    #region declared variables and objects
    public static int playerExit = 0;
    public static bool buttonExist = false;
    [Header("Prefabs")]
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject leftPlayer, rightPlayer;
    public GameObject leftExit, rightExit;
    public GameObject target1, target2;
    public GameObject box, targetBox, button;
    public GameObject bear;
    public GameObject pit, water;
    [Header("Level")]
    public string levelToLoad;
    [Header("UI")]
    public GameObject pauseScreen;
    public GameObject winScreen, failScreen;
    private bool paused;
    public static bool dead = false;
    #endregion

    List<string> lines = new List<string>();
    string currentLevel;

    void Start()
    {
        if (Application.loadedLevel == 12)
        { levelToLoad = CustomLevelLoad.customLevelToLoad; }
        paused = false;
        buttonExist = false;
        TextReader();
        LevelGenerator();
        playerExit = 0;
        dead = false;
        Time.timeScale = 1;
        //levelEnd = false;
    }

    void Update()
    {
        #region InGameCommands

        // restart the current level
        if (Input.GetKeyUp(KeyCode.Backspace) || Input.GetKeyUp(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        // pause/unpause game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == false && dead == false)
            {
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
                paused = true;
            }
            else if (paused == true)
            {
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
                paused = false;
            }
        }
        if ((paused == true || dead == true) && Input.GetKeyDown(KeyCode.Q))
        {
            Application.LoadLevel(0);
        }
        #endregion

        if (dead == true)
        {
            failScreen.SetActive(true);
            Time.timeScale = 0;
        }

        #region Commands to be taken out of builds
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.LoadLevel(Application.loadedLevel - 1);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }*/
        #endregion

        // Ends the level if both players are in their exits
        if (playerExit == 2)
            LevelEnd();
    }

    /// <summary>
    /// Reads textfile named whatever is written in the levelToLoad string. Converts text to list of the lines.
    /// </summary>
    public void TextReader()
    {
        currentLevel = (Resources.Load(levelToLoad).ToString());
        //currentLevel = File.ReadAllText(@"Assets/Levels/Resources/" + levelToLoad + @".txt");
        string line;

        //create stringreader for level textfile
        StringReader reader = new StringReader(currentLevel);

        //adds each line to string until there are no lines
        using (reader)
        {
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
            //Debug.Log(lines.Count);
        }
    }

    /// <summary>
    /// Spawns particular gameobject for each character in the lines. Works like a dot matrix printer.
    /// </summary>
    void LevelGenerator()
    {
        //Debug.Log(lines.Count);
        int width = 0, height = lines.Count;

        LevelSpawner(ref width, ref height);
    }

    /// <summary>
    /// Works with LevelGenerator to spawn the gameobjects for the levels
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    private void LevelSpawner(ref int width, ref int height)
    {
        //for the number of rows
        for (int i = 0; i < lines.Count; i++)
        {
            //if it's a new line, reset to the beginning of the line
            width = 0;
            //go through each character in the line
            foreach (char c in lines[i])
            {
                switch (c)
                {
                    case 'Q': // left wall
                        Instantiate(leftWall, new Vector3(width, 0, height), Quaternion.identity);
                        break;

                    case 'W': // right wall
                        Instantiate(rightWall, new Vector3(width, 0, height), Quaternion.identity);
                        break;

                    case 'O': // left player with target
                        Instantiate(leftPlayer, new Vector3(width, -0.25f, height), Quaternion.Euler(0,180,0));
                        Instantiate(target1, new Vector3(width, 0, height), Quaternion.identity);
                        break;

                    case 'P': // right player with target
                        Instantiate(rightPlayer, new Vector3(width, -0.25f, height), Quaternion.Euler(0,180,0));
                        Instantiate(target2, new Vector3(width, 0.25f, height), Quaternion.identity);
                        break;

                    case 'Z': // left open exit
                        Instantiate(leftExit, new Vector3(width, -0.5f, height), Quaternion.identity);
                        break;

                    case 'X': // right open exit
                        Instantiate(rightExit, new Vector3(width, -0.5f, height), Quaternion.identity);
                        break;

                    case 'A': //box
                        Instantiate(box, new Vector3(width, -0.25f, height), Quaternion.identity);
                        Instantiate(targetBox, new Vector3(width, -0.25f, height), Quaternion.identity);
                        break;

                    case 'S': //button
                        buttonExist = true;
                        Instantiate(button, new Vector3(width, -0.6f, height), Quaternion.identity);
                        break;

                    case 'C': //bear
                        Instantiate(bear, new Vector3(width, -0.15f, height), Quaternion.identity);
                        break;

                    case 'E': //pit
                        Instantiate(pit, new Vector3(width, -0.5f, height), Quaternion.identity);
                        break;

                    case 'R': //water
                        Instantiate(water, new Vector3(width, -0.5f, height), Quaternion.identity);
                        break;

                    default:
                        break;
                }
                width++;
            }
            height--;
        }
    }

    public void LevelEnd()
    {
        //levelEnd = true;
        Time.timeScale = 0;
        winScreen.SetActive(true);
    }
}