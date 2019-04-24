using UnityEngine;
using System.Collections;

public class ExitController : MonoBehaviour
{
    private bool open;
    public GameObject door;
    Object objDoor;

    void Start()
    {
        if (LevelReader.buttonExist == true)
        {
            objDoor = Instantiate(door, transform.position, transform.rotation);
            open = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonController.buttonActive == true && open == false)
        {
            Destroy(objDoor);
            open = true;
            //Debug.Log("open");
        }
        
        if (ButtonController.buttonActive == false && open == true)
        {
            objDoor = Instantiate(door, transform.position, transform.rotation);
            open = false;
            //Debug.Log("closed");
        }
    }
}