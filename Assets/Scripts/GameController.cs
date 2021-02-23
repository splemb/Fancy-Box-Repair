using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject playerBox;
    public GameObject controlsSign;

    public CanvasGroup title;
    public CanvasGroup start;

    public int emotionCount;

    private void Start()
    {
        title.alpha = 0f;
        start.alpha = -1f;
    }

    void Update()
    {
        if (playerBox.activeInHierarchy == false)
        {
            if (title.alpha < 1f) title.alpha += Time.deltaTime / 2;
            if (start.alpha < 1f) start.alpha += Time.deltaTime / 2;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerBox.SetActive(true);
                playerBox.GetComponent<Rigidbody>().AddForce(0, -1000, 0);
                controlsSign.SetActive(true);
            }
        }
        else
        {
            title.alpha = 1f;
            start.alpha = 1f;
        }
    }
}
