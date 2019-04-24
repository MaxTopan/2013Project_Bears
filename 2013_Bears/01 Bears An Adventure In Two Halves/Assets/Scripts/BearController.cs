using UnityEngine;
using System.Collections;

//RENDERER.MATERIAL.SETTEXTURE

public class BearController : MonoBehaviour
{
    public GameObject bear;
    private RaycastHit hit;
    private bool wall = false;
    public int speed = 6;
    private bool moving = false;
    private string direction = "";
    public Texture sleeping, running;
    public AudioSource biteSound;
    private Rigidbody rb;
    private Renderer rend;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the bear is stationary movement is false
        if (rb.velocity == Vector3.zero)
        {
            rend.material.mainTexture = sleeping;
            transform.eulerAngles = new Vector3(0, 0, 0);
            moving = false;
        }
        else
        {
            rend.material.mainTexture = running;
            moving = true;
        }

        // if bear is still search for player, if bear is moving search for wall
        if (moving == false)
        {
            PlayerRaycast();
        }
        else
        {
            WallRaycast();
        }

        // if bear finds a wall, stop on adjacent tile
        if (wall == true)
        {
            rb.velocity = Vector3.zero;
            wall = false;
        }
    }

    void PlayerRaycast()
    {
        //var playerLayer = 1 << 12;
        // OLD METHOD, COULD DETECT THROUGH WALLS
        /*if (Physics.Raycast(transform.position, Vector3.forward, Mathf.Infinity, playerLayer))
        {
            direction = "up";
            rigidbody.velocity = new Vector3(0, 0, speed);
        }*/

        // UP
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, Mathf.Infinity) && hit.collider.tag == "Player1")
        {
            direction = "up";
            rb.velocity = new Vector3(0, 0, speed);
            transform.eulerAngles = new Vector3(0, 90, 0);
        }

        //RIGHT
        if (Physics.Raycast(transform.position, Vector3.right, out hit, Mathf.Infinity) && hit.collider.tag == "Player1")
        {
            direction = "right";
            rb.velocity = new Vector3(speed, 0, 0);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        //DOWN
        if (Physics.Raycast(transform.position, Vector3.back, out hit, Mathf.Infinity) && hit.collider.tag == "Player1")
        {
            direction = "down";
            rb.velocity = new Vector3(0, 0, -speed);
            transform.eulerAngles = new Vector3(0, 270, 0);
        }

        //LEFT
        if (Physics.Raycast(transform.position, Vector3.left, out hit, Mathf.Infinity) && hit.collider.tag == "Player1")
        {
            direction = "left";
            rb.velocity = new Vector3(-speed, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }

    void WallRaycast()
    {
        var wallLayer = 1 << 10;
        float distance = 0.55f;

        //UP
        if ((Physics.Raycast(transform.position, Vector3.forward, distance, wallLayer)) && direction == "up")
            wall = true;
        //RIGHT
        if ((Physics.Raycast(transform.position, Vector3.right, distance, wallLayer)) && direction == "right")
            wall = true;
        //DOWN
        if ((Physics.Raycast(transform.position, Vector3.back, distance, wallLayer)) && direction == "down")
            wall = true;
        //LEFT
        if ((Physics.Raycast(transform.position, Vector3.left, distance, wallLayer)) && direction == "left")
            wall = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 13) // Bear Layer
        {
            Destroy(bear);
        }

        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            rb.velocity = Vector3.zero;
            LevelReader.dead = true;
            //rigidbody.rotation = Quaternion.Euler(Vector3.zero);
        }
        biteSound.Play();
    }
}
