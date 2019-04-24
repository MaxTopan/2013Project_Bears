using UnityEngine;
using System.Collections;

public class ControlSupervisor : MonoBehaviour
{
    public static bool canMove;

    void Start()
    {
        canMove = true;
    }

    void Update()
    {
        if (PlayerController.isMoving == true)
            canMove = false;
        else
            canMove = true;
    }
}
