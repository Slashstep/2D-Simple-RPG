using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;

    public int enemyHealth;

    public GameObject player;
    public Vector2 playerPos;
    public GameObject weapon;
    public Slider healthSlider;

    public float minDistance;
    public float attackSpeed;

    public bool hasAttacked;

    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterActiveUnits()
    {
        gameManager.activeUnits.Add(gameObject);
    }

    public void SetUpHealthSlider()
    {
        healthSlider.maxValue = enemyHealth;
        healthSlider.value = enemyHealth;
    }

    public void SetHealthBar()
    {
        healthSlider.value = enemyHealth;
    }
    public virtual void Movement()
    {
        playerPos = player.transform.position;

        if(!gameManager.hasWaveStarted)
        {
            if (Vector2.Distance(transform.position, playerPos) >= minDistance)
                transform.position = Vector2.MoveTowards(transform.position, playerPos, enemySpeed * Time.deltaTime);
            else
                Attack();
        }
    }

    public virtual void Attack()
    {
        if(!hasAttacked && !gameManager.hasWaveStarted)
        {
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y);
            var weap = Instantiate(weapon, spawnPosition, weapon.transform.rotation);
            Physics2D.IgnoreCollision(weap.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Weapons weaponScript = weap.GetComponent<Weapons>();
            weaponScript.SetRotation(playerPos);
            hasAttacked = true;
            StartCoroutine(AttackCooldown());
        }
    }

    public virtual IEnumerator AttackCooldown()
    {
        yield return new WaitForSecondsRealtime(attackSpeed);
        hasAttacked = false;
    }

    public void DamageManagement(int damage)
    {
        enemyHealth -= damage;
    }

    public void CheckHealth()
    {
        if (enemyHealth < 1)
        {
            Destroy(gameObject);
            gameManager.activeUnits.Remove(gameObject);
        }
    }
}
