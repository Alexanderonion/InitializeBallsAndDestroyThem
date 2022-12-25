using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float _timer;
    void Start()
    {
        _timer = 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }
}
