using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emotionDoor : MonoBehaviour
{
    private GameController game;
    public int requiredEmotion;
    public TMPro.TextMeshProUGUI emotionText;

    private void Start()
    {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        emotionText.text = requiredEmotion.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && game.emotionCount >= requiredEmotion)
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().Play("open");
        }
    }
}
