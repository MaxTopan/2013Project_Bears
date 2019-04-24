using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScreenController : MonoBehaviour
{
    [Header("Header")]
    public Text header;
    [Header("Body")]
    public Text scoreText;
    public Text improveScore;
    public Text goldScore;
    public Text silverScore;
    public Text bronzeScore;
    [Header("Values")]
    private float goldScoreInt = 0;
    private float silverScoreInt = 0;
    private float bronzeScoreInt = 0;
    private float stepsToImprove = 0;
    [Header("Level")]
    public string levelToLoad = "";

    // Use this for initialization
    void Start()
    {
        ScoreModifier(levelToLoad);
    }

    // Update is called once per frame
    void Update()
    {
        float steps = PlayerController.moveCount / 2;
        // displays player's move count and steps to next rank
        scoreText.text = (steps).ToString();
        if (stepsToImprove <= 0)
        {
            improveScore.text = "Best";
            improveScore.color = new Color(1f, 0.84f, 0f);
        }
        else
        {
            improveScore.text = stepsToImprove.ToString();
            improveScore.color = new Color(1f, 1f, 1f);
        }

        #region Rename Header, Recolour Header and Steps
        if (steps <= goldScoreInt)
        {
            scoreText.color = new Color(1f, 0.84f, 0f);
            header.color = new Color(1f, 0.84f, 0f);
            header.text = "Rank: Gold";
            stepsToImprove = steps - goldScoreInt;
        }
        else if (steps <= silverScoreInt)
        {
            scoreText.color = new Color(0.75f, 0.75f, .75f);
            header.color = new Color(0.75f, 0.75f, .75f);
            header.text = "Rank: Silver";
            stepsToImprove = steps - goldScoreInt;
        }
        else if (steps <= bronzeScoreInt)
        {
            scoreText.color = new Color(0.78f, 0.43f, 0f);
            header.color = new Color(0.78f, 0.43f, 0f);
            header.text = "Rank: Bronze";
            stepsToImprove = steps - silverScoreInt;
        }
        else
        {
            scoreText.color = new Color(1f, 1f, 1f);
            header.color = new Color(1f, 1f, 1f);
            header.text = "Rank: Wooden";
            stepsToImprove = steps - bronzeScoreInt;
        }
        #endregion

        if (gameObject.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Application.LoadLevel(Application.loadedLevel + 1);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.LoadLevel(0);
            }
        }
    }

    public void ScoreModifier(string currentLevel)
    {
        switch (currentLevel)
        {
            case "level1":
                goldScoreInt = 6.5f;
                silverScoreInt = 8.5f;
                bronzeScoreInt = 10f;
                break;

            case "level2":
                goldScoreInt = 15f;
                silverScoreInt = 19f;
                bronzeScoreInt = 21.5f;
                break;

            case "level3":
                goldScoreInt = 16f;
                silverScoreInt = 20f;
                bronzeScoreInt = 22f;
                break;

            case "level4":
                goldScoreInt = 29f;
                silverScoreInt = 30.5f;
                bronzeScoreInt = 33f;
                break;

            case "level5":
                goldScoreInt = 22.5f;
                silverScoreInt = 25.5f;
                bronzeScoreInt = 26.6f;
                break;

            case "level6":
                goldScoreInt = 23.5f;
                silverScoreInt = 24.5f;
                bronzeScoreInt = 27f;
                break;

            case "level7":
                goldScoreInt = 19;
                silverScoreInt = 22;
                bronzeScoreInt = 25;
                break;

            case "level8":
                goldScoreInt = 20;
                silverScoreInt = 22;
                bronzeScoreInt = 25;
                break;

            case "level9":
                goldScoreInt = 28;
                silverScoreInt = 32;
                bronzeScoreInt = 36;
                break;

            case "level10":
                goldScoreInt = 6.5f;
                silverScoreInt = 7.5f;
                bronzeScoreInt = 10;
                break;

            default:
                goldScoreInt = 999;
                silverScoreInt = 999;
                bronzeScoreInt = 999;
                break;
        }
        goldScore.text = goldScoreInt.ToString();
        silverScore.text = silverScoreInt.ToString();
        bronzeScore.text = bronzeScoreInt.ToString();
    }
}
