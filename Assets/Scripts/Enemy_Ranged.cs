using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ranged : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        minDistance = 8;
        SetUpHealthSlider();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckHealth();
        SetHealthBar();
    }
}
