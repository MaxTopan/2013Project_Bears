using UnityEngine;
using System.Collections;

public class WaterController : MonoBehaviour
{
    public AudioSource waterSplash;

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            LevelReader.dead = true;
        }
        waterSplash.Play();
    }
}
