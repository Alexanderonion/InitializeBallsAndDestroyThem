using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyBall : MonoBehaviour
{
    public TextMeshProUGUI _text;

    private void Start()
    {
        ;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        Destroy(other.gameObject);
        GameManager._lifePoint -= Ball._damage;// combine in method

        if (GameManager._lifePoint <= 0)
        {
            Ball._gameManager._lifePointTextTMP.text = "00";// combine in method
            Ball._gameManager.gameOver.SetActive(true);
            GameManager.endGame = true;

            if (GameManager._score > LeaderLine.Instance._topScore)
            {
                LeaderLine.Instance._topScore = GameManager._score;
                LeaderLine.Instance.SaveScore();
                _text.text = $"Best Score: {LeaderLine.Instance._topScore}";
            }
        }
        else
        {
            Ball._gameManager._lifePointTextTMP.text = string.Format("{0:d2}", GameManager._lifePoint);// combine in method
        }
    }
}
