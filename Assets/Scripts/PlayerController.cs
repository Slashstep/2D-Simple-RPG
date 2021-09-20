using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject meleeAttackPrefab;
    public GameObject rangedAttackPrefab;

    private Rigidbody2D playerRb;
    private float horizontalMovement;
    private float verticalMovement;
    public bool hasAttacked;
    public float attackSpeed;

    private int m_playerHealth;
    public int playerHealth
    {
        get { return m_playerHealth; }
        set
        {
            if (value <= 10)
                m_playerHealth = value;
            else
                m_playerHealth = 15;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckHealth();

        if (Input.GetMouseButtonDown(0))
            MeleeAttack();
        else if (Input.GetMouseButtonDown(1))
            RangedAttack();
    }

    void Move()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        transform.Translate(Vector2.right * horizontalMovement * speed * Time.deltaTime);
        transform.Translate(Vector2.up * verticalMovement * speed * Time.deltaTime);
    }

    void CheckHealth()
    {
        if (playerHealth < 1)
        {
            //GameManager.isGameOver = true
            //Time.timeScale = 0;
        }
    }

    public void DamageManagement(int damage)
    {
        playerHealth -= damage;
    }

    public void HealingManagement(int healing)
    {
        playerHealth += healing;
    }

    private void MeleeAttack()
    {
        if(!hasAttacked)
        {
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y);
            var melee = Instantiate(meleeAttackPrefab, spawnPosition, meleeAttackPrefab.transform.rotation);
            Physics2D.IgnoreCollision(melee.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Weapons meleeScript = melee.GetComponent<Weapons>();
            meleeScript.SetRotation(MousePosition());
            hasAttacked = true;
            StartCoroutine(AttackCooldown());
        }
    }

    private void RangedAttack()
    {
        if(!hasAttacked)
        {
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y);
            var ranged = Instantiate(rangedAttackPrefab, spawnPosition, meleeAttackPrefab.transform.rotation);
            Physics2D.IgnoreCollision(ranged.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Weapons rangedScript = ranged.GetComponent<Weapons>();
            rangedScript.SetRotation(MousePosition());
            hasAttacked = true;
            StartCoroutine(AttackCooldown());
        }
    }

    public virtual IEnumerator AttackCooldown()
    {
        yield return new WaitForSecondsRealtime(attackSpeed);
        hasAttacked = false;
    }

    Vector2 MousePosition()
    {
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        return mousePosition;
    }
}
