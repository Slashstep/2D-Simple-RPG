using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Weapons
{

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Edge"))
            Destroy(gameObject);
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
            enemyScript.DamageManagement(damage);
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerScript = collision.gameObject.GetComponent<PlayerController>();
            playerScript.DamageManagement(damage);
        } 
    }
}
