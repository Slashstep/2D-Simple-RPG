using UnityEngine;

public class Melee : Weapons
{
    Vector2 startPosition;
    float dist;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }

    public override void MoveForward()
    {
        dist = Mathf.Abs(Vector2.Distance(startPosition, transform.position));

        if (dist <= 1)
            base.MoveForward();
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Edge"))
            Destroy(gameObject);
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
            enemyScript.DamageManagement(damage);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerScript = collision.gameObject.GetComponent<PlayerController>();
            playerScript.DamageManagement(damage);
        }
    }
}
