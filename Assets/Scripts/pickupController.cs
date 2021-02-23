using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupController : MonoBehaviour
{
    bool pickedUp = false;

    private void FixedUpdate()
    {
        if (pickedUp)
        {
            transform.localScale *= 0.9f;
            if (transform.localScale.magnitude <= 0.1f) Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") pickedUp = true;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().emotionCount++;
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<AudioSource>().Play();
    }
}
