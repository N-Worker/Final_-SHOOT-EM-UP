using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        StartGG();
    }
    public int score = 0;
    public int life = 3;

    public TMP_Text sorceText, lifeText, level;

    public GameObject winPop, losePop, startPop;

    private void Start()
    {
        sorceText.text = "0";
        lifeText.text = life.ToString();
        level.text = "0";
        winPop.SetActive(false);
        losePop.SetActive(false);
        startPop.SetActive(true);
    }

    public void AddScore(int nScore)
    {
        score += nScore;
        sorceText.text = score.ToString();
    }
    public void DecLife()
    {
        life--;
        lifeText.text = life.ToString();
        if (life <= 0)
        {
            LoseGG();
        }
    }

    public void WinGG()
    {
        winPop.SetActive(true);
    }
    public void LoseGG()
    {
        losePop.SetActive(true);
    }
    public void StartGG()
    {
        startPop.SetActive(true);
        Time.timeScale = 0; //Stop game till play game
    }
    public void StartGame()
    {
        startPop.SetActive(false);
        Time.timeScale = 1; // Play game
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}