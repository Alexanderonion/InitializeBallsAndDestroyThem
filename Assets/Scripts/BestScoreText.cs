using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScoreText : MonoBehaviour
{
    public TextMeshProUGUI _text;
    void Start()
    {
        _text.text = $"Best Score: {LeaderLine.Instance._topScore}";
    }
}
