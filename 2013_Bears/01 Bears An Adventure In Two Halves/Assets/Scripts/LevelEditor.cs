using UnityEngine;
using System.Collections;

public class LevelEditor : MonoBehaviour
{
    private bool selected;
    public static bool selectable = false;
    public GameObject leftWall, rightWall;
    public GameObject leftPlayer, rightPlayer;
    public GameObject leftExit, rightExit;
    public GameObject box, button;
    public GameObject bear;
    public GameObject pit, water;
    private GameObject currentSelection;
    private Renderer rend;
    //    public bool player1Exist = false;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    void Start()
    {
        Time.timeScale = 0;
        selectable = false;
    }

    void Update()
    {
        switch (LevelEditorButtonSelection.selection)
        {
            case "player 1":
                currentSelection = leftPlayer;
                break;

            case "player 2":
                currentSelection = rightPlayer;
                break;

            case "left wall":
                currentSelection = leftWall;
                break;

            case "right wall":
                currentSelection = rightWall;
                break;

            case "left exit":
                currentSelection = leftExit;
                break;

            case "right exit":
                currentSelection = rightExit;
                break;

            case "box":
                currentSelection = box;
                break;

            case "button":
                currentSelection = button;
                break;

            case "bear":
                currentSelection = bear;
                break;

            case "pit":
                currentSelection = pit;
                break;

            case "water":
                currentSelection = water;
                break;

            default:
                currentSelection = leftWall;
                break;
        }

        // Checks which tile to spawn something on and spawns current selection
        if (selected == true && Input.GetMouseButton(0))
        {
            if (currentSelection == leftPlayer)
            {
                if (LevelEditorButtonSelection.player1Exist == false)
                {
                    Instantiate(currentSelection, transform.position, Quaternion.Euler(0,180,0));
                    LevelEditorButtonSelection.player1Exist = true;
                    Destroy(gameObject);
                }
                //LimitFunction(LevelEditorButtonSelection.player1Exist);
            }

            if (currentSelection == rightPlayer)
            {
                if (LevelEditorButtonSelection.player2Exist == false)
                {
                    Instantiate(currentSelection, transform.position, Quaternion.Euler(0, 180, 0));
                    LevelEditorButtonSelection.player2Exist = true;
                    Destroy(gameObject);
                }
                //LimitFunction(LevelEditorButtonSelection.player2Exist);
            }

            if (currentSelection == button)
            {
                if (LevelEditorButtonSelection.buttonExist == false)
                {
                    Instantiate(currentSelection, transform.position, transform.rotation);
                    LevelEditorButtonSelection.buttonExist = true;
                    Destroy(gameObject);
                }
                //LimitFunction(LevelEditorButtonSelection.buttonExist);
            }

            if (currentSelection == box)
            {
                if (LevelEditorButtonSelection.boxExist == false)
                {
                    Instantiate(currentSelection, transform.position, transform.rotation);
                    LevelEditorButtonSelection.boxExist = true;
                    Destroy(gameObject);
                }
                //LimitFunction(LevelEditorButtonSelection.boxExist);
            }

            if (currentSelection != leftPlayer && currentSelection != rightPlayer && currentSelection != button && currentSelection != box)
            {
                Instantiate(currentSelection, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    /*void LimitFunction(bool objectToLimit)
    {
        if (objectToLimit == false)
        {
            Debug.Log("YES");
            Instantiate(currentSelection, transform.position, transform.rotation);
            Destroy(gameObject);
            objectToLimit = true;
        }
    }*/

    void OnMouseEnter()
    {
        if (selectable == true)
        {
        rend.material.color = Color.cyan;
        selected = true;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = Color.white;
        selected = false;
    }
}
