using UnityEngine;
using System.Collections;

public class PitController : MonoBehaviour
{
    private bool open = false;
    [Header("Textures")]
    public Texture openPit;
    public Texture closedPit;
    [Header("Sound")]
    public AudioSource fallingSound;
    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    void Start()
    {
        open = false;
        rend.material.mainTexture = closedPit;
    }

    void OnTriggerStay(Collider other)
    {
        if (open == true)
        {
            Destroy(other.gameObject);
            if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
            {
                LevelReader.dead = true;
            }
            fallingSound.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (open == false)
        {
            rend.material.mainTexture = openPit;
            open = true;
        }
    }
}