using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour
{
    public static bool buttonActive;
    public AudioSource unlockSound;
    //public static bool buttonExist;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.up, 1))
        {
            if (buttonActive == false)
            {
                unlockSound.Play();
                buttonActive = true;
            }
            //Debug.Log("Button active");
        }
        else
        {
            buttonActive = false;
            //Debug.Log("Button off");
        }
    }
}
