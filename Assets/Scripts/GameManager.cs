using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static int _score = 0;
    public static int _lifePoint = 10;
    public TextMeshProUGUI _scoreTextTMP;
    public TextMeshProUGUI _lifePointTextTMP;
    public GameObject gameOver;
    public static bool endGame;
    public GameObject pauseScreen;
    public static bool paused;
    public GameObject Menu;
    public bool _menuON;

   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !endGame && !_menuON)
        {
            ChangePause();
        }

        if (Input.GetKeyDown(KeyCode.R) && !_menuON)
        {
            Restart();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!_menuON)
            {
                _menuON = true;
                Menu.SetActive(true);
                if (!paused)
                {
                    ChangePause();
                }
            }
            else if(!endGame)
            {
                _menuON = false;
                Menu.SetActive(false);
                if (!paused)
                {
                    ChangePause();
                }                
            }
        }
    }

    public void ChangePause()
    {
        if (!paused)
        {
            paused = true;
            if (!endGame)
            {
                pauseScreen.SetActive(true);
            }
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);// dublicate code
        Time.timeScale = 1;// dublicate code
        _menuON = false;// dublicate code
        endGame = false;// dublicate code
        paused = false;// dublicate code
        _score = 0;// dublicate code
        _scoreTextTMP.text = string.Format("{ 0:d3}", GameManager._score);// dublicate code
        _lifePoint = 10;// dublicate code
        _lifePointTextTMP.text = string.Format("{0:d2}", GameManager._lifePoint);// dublicate code
    }
}
