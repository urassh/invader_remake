using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private int direction = 1;
    private float speed = 2.0f;
    private float spawnRate = 0.2f;
    private float timer = 0.0f;
    private float interval_spawn = 4.0f;

    void Update()
    {
        
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        CountInterval();

        SpawnEnemy();
    }

    void CountInterval()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            direction *= -1;
        }
    }

    void SpawnEnemy() {
        if (timer > 0) return;
        if (Random.value < spawnRate)
        {
            Instantiate(enemyPrefab, transform.position, new Quaternion(0, 0, 180, 0));
            timer = interval_spawn;
        }
    }
}
