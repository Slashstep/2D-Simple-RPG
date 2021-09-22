using UnityEngine;

public class Weapons : MonoBehaviour
{
    public int damage;

    public virtual void MoveForward()
    {
        transform.Translate(Vector2.up * 20 * Time.deltaTime);
    }

    public virtual void SetRotation(Vector2 target)
    {
        transform.up = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
    }
}
