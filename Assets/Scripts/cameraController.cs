using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform following;
    public Rigidbody followingRB;

    public Queue<Vector3> followingPosQueue = new Queue<Vector3>();
    float averageYPos;

    private void Start()
    {
        transform.position = new Vector3(-28, transform.position.y, transform.position.z);
        for (int i = 0; i < 120; i++) followingPosQueue.Enqueue(following.position);
    }

    private void Update()
    {
        followingPosQueue.Dequeue();
        followingPosQueue.Enqueue(following.position);
        averageYPos = 0;

        foreach (Vector3 pos in followingPosQueue) averageYPos += pos.y;
        averageYPos /= followingPosQueue.Count;

        if (following.position.x > -28)
        {
            transform.position = new Vector3(following.transform.position.x, transform.position.y, transform.position.z);
            if (Mathf.Abs(followingRB.velocity.y) > 0.1f) transform.position = new Vector3(transform.position.x, averageYPos + 2, transform.position.z);
            else transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, following.transform.position.y + 2, transform.position.z), 0.9f * Time.deltaTime);
        }

        if (following.position.z > 16)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, following.transform.position.z - 35);
        }
    }
}
