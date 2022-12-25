using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    public float _speed { get; private set; }
    public static int _points { get; private set; }
    public static int _damage { get; private set; }
    public static GameManager _gameManager;
    public ParticleSystem boomParticle;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        m_Rigidbody = GetComponent<Rigidbody>();
        float rndSpeed = UnityEngine.Random.Range(1f, 10);
        int rndColor = UnityEngine.Random.Range(0, 8);
        _speed = rndSpeed;
        _points = (int)_speed;
        _damage = Damage((int)_speed); 
        GetComponent<MeshRenderer>().material.color = Colors._colorArray[rndColor];
    }

    private void FixedUpdate()
    {
        m_Rigidbody.MovePosition(transform.position + Vector3.down * Time.deltaTime * (_speed + Timer._timer));
    }

    private void OnMouseDown()
    {
        if (!GameManager.paused && !GameManager.endGame)
        {
            GameManager._score += _points;// combine in method
            _gameManager._scoreTextTMP.text = string.Format("{0:d3}", GameManager._score);// combine in method
            ParticleSystem.MainModule mainModule = boomParticle.main;
            mainModule.startColor = GetComponent<MeshRenderer>().material.color;
            Instantiate(boomParticle, transform.position, boomParticle.transform.rotation);
            Destroy(gameObject);
        }
    }

    int Damage(int speed)
    {
        int result = speed switch
        {
            1 => 5,
            2 => 5,
            3 => 4,
            4 => 4,
            5 => 3,
            6 => 3,
            7 => 2,
            8 => 2,
            9 => 1,
            _ => 1
        };

        return result;
    }
}