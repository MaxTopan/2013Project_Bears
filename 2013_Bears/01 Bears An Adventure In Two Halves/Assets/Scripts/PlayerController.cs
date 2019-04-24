using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int playersExit;
    //bool nextLevel;
    public GameObject player;
    public Transform target;
    public float speed = 3;
    //public static string lastDirection = "";
    //bool canMove = true;
    private bool upWall, rightWall, downWall, leftWall;
    private bool upBox, rightBox, downBox, leftBox;
    public static bool isMoving;
    public static float moveCount = 0;
    public GameObject deathPanel;

    // Use this for initialization
    void Start()
    {
        target.position = player.transform.position;
        ControlSupervisor.canMove = true;
        moveCount = 0;
    }

    // Update is called once per frame
    void Update()
    {        
        player.transform.LookAt(target);

        // if the player character is not on it's target, move towards the target
        float step = speed * Time.deltaTime;
        if (player.transform.position != target.position)
        {
            //isMoving = true;
            //ControlSupervisor.canMove = false;
            player.transform.position = Vector3.MoveTowards(player.transform.position, target.position, step);
        }
        else
        {
            //isMoving = false;
            //ControlSupervisor.canMove = true;
        }

        WallRaycast();
        BoxRaycast();
        PlayerMovement();

        //Debug.Log(moveCount/2);
    }

    /// <summary>
    /// checks for key input and moves the players target accordingly
    /// </summary>
    private void PlayerMovement()
    {
        if (LevelReader.playerExit != 2)
        {
            if (target.position == player.transform.position && ControlSupervisor.canMove == true)
            {
                if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && upWall == false) // up
                {
                    if (!(upBox == true && BoxController.upWall == true))
                    {
                        target.Translate(0, 0, 1);
                        moveCount++;
                        //lastDirection = "up";
                        //StartCoroutine(pausePlayer());
                    }
                }
                else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && rightWall == false) //right
                {
                    if (!(rightBox == true && BoxController.rightWall == true))
                    {
                        target.Translate(1, 0, 0);
                        moveCount++;
                        //lastDirection = "right";
                        //StartCoroutine(pausePlayer());
                    }
                }
                else if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && downWall == false) // down
                {
                    if (!(downBox == true && BoxController.downWall == true))
                    {
                        target.Translate(0, 0, -1);
                        moveCount++;
                        //lastDirection = "down";
                        //StartCoroutine(pausePlayer());
                    }
                }
                else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && leftWall == false) // left
                {
                    if (!(leftBox == true && BoxController.leftWall == true))
                    {
                        target.Translate(-1, 0, 0);
                        moveCount++;
                        //lastDirection = "left";
                        //StartCoroutine(pausePlayer());
                    }
                }
            }
        }
    }

    /// <summary>
    /// checks in each cardinal direction for walls, then prevents movement accordingly
    /// </summary>
    void WallRaycast()
    {
        var wallLayer = 1 << 10;

        //UP
        if (Physics.Raycast(transform.position, Vector3.forward, 1, wallLayer))
            upWall = true;
        else
            upWall = false;
        //RIGHT
        if (Physics.Raycast(transform.position, Vector3.right, 1, wallLayer))
            rightWall = true;
        else
            rightWall = false;
        //DOWN
        if (Physics.Raycast(transform.position, Vector3.back, 1, wallLayer))
            downWall = true;
        else
            downWall = false;
        //LEFT
        if (Physics.Raycast(transform.position, Vector3.left, 1, wallLayer))
            leftWall = true;
        else
            leftWall = false;
    }

    /// <summary>
    /// checks in each direction for boxes, sets bools accordingly
    /// </summary>
    void BoxRaycast()
    {
        var boxLayer = 1 << 9;

        //UP
        if (Physics.Raycast(transform.position, Vector3.forward, 1, boxLayer))
            upBox = true;
        else
            upBox = false;
        //RIGHT
        if (Physics.Raycast(transform.position, Vector3.right, 1, boxLayer))
            rightBox = true;
        else
            rightBox = false;
        //DOWN
        if (Physics.Raycast(transform.position, Vector3.back, 1, boxLayer))
            downBox = true;
        else
            downBox = false;
        //LEFT
        if (Physics.Raycast(transform.position, Vector3.left, 1, boxLayer))
            leftBox = true;
        else
            leftBox = false;
    }

    //bounces player off of walls
    //  void OnCollisionEnter(Collision other)
    // {
    /*if (other.gameObject.tag == "Wall") // (or (tag is box and box is pressed against a wall))
    {
        switch (lastDirection)
        {
            case "up":
                target.Translate(0, 0, -1);
                break;

            case "right":
                target.Translate(-1, 0, 0);
                break;

            case "down":
                target.Translate(0, 0, 1);
                break;

            case "left":
                target.Translate(1, 0, 0);
                break;
        }
        //pause player for appropriate amount of time
        //StartCoroutine(PausePlayer(0.15f));
    }*/

    /*      if (other.gameObject.tag == "Box")
          {
              if (upBox == true && BoxController.upWall == true) { target.Translate(0, 0, -1); }
              if (rightBox == true && BoxController.rightWall == true) { target.Translate(-1, 0, 0); }
              if (downBox == true && BoxController.downWall == true) { target.Translate(0, 0, 1); }
              if (leftBox == true && BoxController.leftWall == true) { target.Translate(1, 0, 0); }
          }
      }*/

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 13) //Bear Layer
        {
            Destroy(player);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LeftExit" || other.gameObject.tag == "RightExit")
        {
            //characterExit = true;
            LevelReader.playerExit++;
            //Debug.Log("exit");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LeftExit" || other.gameObject.tag == "RightExit")
        {
            //characterExit = true;
            LevelReader.playerExit--;
            //Debug.Log("no exit");
            if (LevelReader.playerExit == 2)
            {
                Application.LoadLevel(Application.loadedLevel + 1);
            }
        }
    }

    /* IEnumerator PausePlayer(float waitForSeconds)
     {
         canMove = false;
         yield return new WaitForSeconds(waitForSeconds);
         canMove = true;
     }*/
}