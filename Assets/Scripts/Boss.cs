using UnityEngine;

public class Boss : Enemy
{
    public GameObject secondaryWeapon;

    private float maxDistance = 6;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        minDistance = 2;
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

    public override void Movement()
    {
        playerPos = player.transform.position;

        if(!gameManager.hasWaveStarted)
        {
            if (Vector2.Distance(transform.position, playerPos) >= maxDistance)
                transform.position = Vector2.MoveTowards(transform.position, playerPos, enemySpeed * Time.deltaTime);
            else if(Vector2.Distance(transform.position, playerPos) < maxDistance && Vector2.Distance(transform.position, playerPos) >= minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerPos, enemySpeed * Time.deltaTime);
                SecondaryAttack();
            }
            else if (Vector2.Distance(transform.position, playerPos) < minDistance)
                Attack();
        }
    }

    public void SecondaryAttack()
    {
        if (hasAttacked == false)
        {
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y);
            var secWeap = Instantiate(secondaryWeapon, spawnPosition, secondaryWeapon.transform.rotation);
            Physics2D.IgnoreCollision(secWeap.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Weapons weaponScript = secWeap.GetComponent<Weapons>();
            weaponScript.SetRotation(playerPos);
            hasAttacked = true;
            StartCoroutine(AttackCooldown());
        }
    }
}
