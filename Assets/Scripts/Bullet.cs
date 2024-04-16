using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Shooter
{
    Player,
    Enemy
}

public class Bullet : MonoBehaviour
{
    [SerializeField] private Shooter shooter;
    [SerializeField] private float speed = 32.0f;
    
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public Shooter GetShooter()
    {
        return shooter;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
