using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicSwitcher : MonoBehaviour
{
    public AudioSource music;
    public AudioClip jazz;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            music.clip = jazz;
            music.Play();
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
