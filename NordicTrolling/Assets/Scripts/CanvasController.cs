using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    //public GameObject IntroCanvas;
    public GameObject GameCanvas;
    public GameObject OverCanvas;
    public Text gameOverText;

    void Awake()
    {
        EventManager.Instance.AddListener<GameOverEvent>(GameOver);
    }

    private void GameOver(GameOverEvent e)
    {
        GameCanvas.SetActive(false);
        OverCanvas.SetActive(true);
        if (e.IsGameWon)
        {
            gameOverText.text = "You win";
        }
        else
        {
            gameOverText.text = "Your viking died!";
        }
    }

    void OnDestroy()
    {
        try
        {
            EventManager.Instance.RemoveListener<GameOverEvent>(GameOver);
        }
        catch (Exception)
        {
            Debug.Log("Tried to destroy null object");
        }
    }
}
