using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Shooter shooter = other.gameObject.GetComponent<Bullet>().GetShooter();

            if (shooter == Shooter.Enemy)
            {
                transform.localScale = new Vector3(transform.localScale.x * 0.9f, 0.5f, 1.0f);
            }
        }

        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
