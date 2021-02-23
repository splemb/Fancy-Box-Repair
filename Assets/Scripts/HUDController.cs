using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI emotionCountText;
    public GameController game;

    private void Start()
    {
        GetComponent<CanvasGroup>().alpha = 0;
    }

    private void Update()
    {
        if (game.emotionCount > 0 && GetComponent<CanvasGroup>().alpha < 1) GetComponent<CanvasGroup>().alpha += Time.deltaTime;
        emotionCountText.text = game.emotionCount.ToString();
    }
}
