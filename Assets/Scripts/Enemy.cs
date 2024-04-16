using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private float speed = 0.5f;
    private float timer = 0.0f;
    private float interval_shot = 2.0f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        CountInterval();

        Shot();
    }

    void CountInterval()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    void Shot()
    {
        if (timer > 0) return;
        Instantiate(bulletPrefab, transform.position, new Quaternion(0, 0, 180, 0));
        timer = interval_shot;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Bullet")
        {
            Shooter shooter = other.gameObject.GetComponent<Bullet>().GetShooter();
            
            if (shooter == Shooter.Player)
            {
                Destroy(gameObject);
            }
        }
    }
}
