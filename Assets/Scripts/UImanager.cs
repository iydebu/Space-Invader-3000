using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public static UImanager instance;

    private void Awake()
    { 
        instance = GetComponent<UImanager>();
    }

    public TMP_Text Score;
    public TMP_Text GOScore;
    public GameObject[] life;
    public GameObject GameOverPanel;
    public GameObject GamePanel;
    public GameObject StartPanel;
    public GameObject spawn;
    public GameObject player;
    public bool isPlaying = false;

    public void UpdateScore(int score)
    {
        Score.text = score.ToString();
    }

    public void UpdateLife()
    {
        for(int i = 0; i < life.Length; i++)
        {
            if (i < PlayerController.instance.life)
            {
                life[i].SetActive(true);
            }
            else
            {
                life[i].SetActive(false);
            }
        }
    }
    public void Play()
    {
        StartPanel.SetActive(false);
        GamePanel.SetActive(true);
        spawn.SetActive(true);
        player.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        GOScore.text = "Score: "+Score.text;
        GamePanel.SetActive(false);
        spawn.SetActive(false);
        player.SetActive(false);
    }
}
