using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private float speed = 8.0f;
    private bool onWall = false;

    void Update()
    {
        bool onRightWall = transform.position.x > 0 && onWall;
        bool onLeftWall  = transform.position.x < 0 && onWall;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (onLeftWall) return;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (onRightWall) return;
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            onWall = true;
        }

        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("GameOver!");
        }

        if (other.gameObject.tag == "Bullet")
        {
            Shooter shooter = other.gameObject.GetComponent<Bullet>().GetShooter();

            if (shooter == Shooter.Enemy)
            {
                Debug.Log("Damage!");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            onWall = false;
        }
    }
}
