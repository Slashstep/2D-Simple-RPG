using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;

    public int enemyHealth;

    public GameObject player;
    public Vector2 playerPos;
    public GameObject weapon;

    public float minDistance;
    public float attackSpeed;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Movement()
    {
        playerPos = player.transform.position;

        if (Vector2.Distance(transform.position, playerPos) >= minDistance)
            transform.position = Vector2.MoveTowards(transform.position, playerPos, enemySpeed * Time.deltaTime);
        else
            StartCoroutine(Attack());
    }

    public virtual IEnumerator Attack()
    {
        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y);
        var weap = Instantiate(weapon, spawnPosition, weapon.transform.rotation);
        Physics2D.IgnoreCollision(weap.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Weapons weaponScript = weap.GetComponent<Weapons>();
        weaponScript.SetRotation(playerPos);
        yield return new WaitForSeconds(attackSpeed);
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
        }
    }
}
