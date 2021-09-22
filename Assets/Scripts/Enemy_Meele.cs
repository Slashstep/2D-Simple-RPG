using UnityEngine;

public class Enemy_Meele : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        minDistance = 1.5f;
        SetUpHealthSlider();
        EnterActiveUnits();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckHealth();
        SetHealthBar();
    }
}
