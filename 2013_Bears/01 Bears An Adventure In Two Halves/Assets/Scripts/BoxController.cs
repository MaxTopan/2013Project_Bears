using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour
{
    private float speed = 3.2f;
    public GameObject box;
    public Transform targetBox;
    public static bool upWall, rightWall, downWall, leftWall;
    public static bool upPlayer, rightPlayer, downPlayer, leftPlayer;
    public static bool detectButton;

    void Start()
    {
        targetBox.position = box.transform.position;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        if (box.transform.position != targetBox.position)
        {
            box.transform.position = Vector3.MoveTowards(box.transform.position, targetBox.position, step);
        }

        PlayerRaycast();
        WallRaycast();
    }

    private void WallRaycast()
    {

        var wallLayer = 1 << 10;

        //UP
        if (Physics.Raycast(transform.position, Vector3.forward, 1, wallLayer)) //UP
            upWall = true;
        else
            upWall = false;
        //RIGHT
        if (Physics.Raycast(transform.position, Vector3.right, 1, wallLayer)) //RIGHT
            rightWall = true;
        else
            rightWall = false;
        //DOWN
        if (Physics.Raycast(transform.position, Vector3.back, 1, wallLayer)) //DOWN
            downWall = true;
        else
            downWall = false;
        //LEFT
        if (Physics.Raycast(transform.position, Vector3.left, 1, wallLayer)) //LEFT
            leftWall = true;
        else
            leftWall = false;
    }

    private void PlayerRaycast()
    {
        var player2Layer = 1 << 8;
        var player1Layer = 1 << 12;

        //UP
        if ((Physics.Raycast(transform.position, Vector3.forward, 1, player2Layer)) || (Physics.Raycast(transform.position, Vector3.forward, 1, player1Layer))) //UP
            upPlayer = true;
        else
            upPlayer = false;
        //RIGHT
        if ((Physics.Raycast(transform.position, Vector3.right, 1, player2Layer)) || (Physics.Raycast(transform.position, Vector3.right, 1, player1Layer))) //RIGHT
            rightPlayer = true;
        else
            rightPlayer = false;
        //DOWN
        if ((Physics.Raycast(transform.position, Vector3.back, 1, player2Layer)) || (Physics.Raycast(transform.position, Vector3.back, 1, player1Layer))) //DOWN
            downPlayer = true;
        else
            downPlayer = false;
        //LEFT
        if ((Physics.Raycast(transform.position, Vector3.left, 1, player2Layer)) || (Physics.Raycast(transform.position, Vector3.left, 1, player1Layer))) //LEFT
            leftPlayer = true;
        else
            leftPlayer = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            if (upPlayer && !downWall)
            {
                targetBox.Translate(0, 0, -1);
            }
            if (rightPlayer && !leftWall)
            {
                targetBox.Translate(-1, 0, 0);
            }
            if (downPlayer && !upWall)
            {
                targetBox.Translate(0, 0, 1);
            }
            if (leftPlayer && !rightWall)
            {
                targetBox.Translate(1, 0, 0);
            }
        }
    }
}