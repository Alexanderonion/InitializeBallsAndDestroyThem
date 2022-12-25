using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    public GameObject Menu;
    public GameManager GameManager;
    
    public void StartNew()
    {
        Time.timeScale = 1;// dublicate code
        SceneManager.LoadScene(0);// dublicate code
        GameManager.endGame = false;// dublicate code
        GameManager.paused = false;// dublicate code
        GameManager._menuON = false;// dublicate code
        GameManager._score = 0; // dublicate code
        GameManager._scoreTextTMP.text = string.Format("{ 0:d3}", GameManager._score);// dublicate code
        GameManager._lifePoint = 10;// dublicate code
        GameManager._lifePointTextTMP.text = string.Format("{0:d2}", GameManager._lifePoint);// dublicate code
    }

    public void Pause()
    {
        if (!GameManager.endGame)
        {
            Menu.SetActive(false);
            GameManager._menuON = false;
        }
    }

    public void ResumeGame()
    {
        if (!GameManager.endGame)
        {
            Menu.SetActive(false);
            GameManager._menuON = false;
            GameManager.ChangePause();
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
