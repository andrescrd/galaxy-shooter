using System;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed = 8;

    private bool _isEnemyLaser;

    private void Update()
    {
        if (_isEnemyLaser)
        {
            MoveDown();
        }
        else
        {
            MoveUp();
        }
    }

    private void MoveUp()
    {
        transform.Translate(Vector3.up * (Time.deltaTime * speed));

        if (transform.position.y > 10)
        {
            if (transform.parent)
                Destroy(transform.parent.gameObject);

            Destroy(gameObject);
        }
    }

    private void MoveDown()
    {
        transform.Translate(Vector3.down * (Time.deltaTime * speed));

        if (transform.position.y < -10)
        {
            if (transform.parent)
                Destroy(transform.parent.gameObject);

            Destroy(gameObject);
        }
    }

    public void IsEnemyLaser()
    {
        _isEnemyLaser = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _isEnemyLaser)
        {
            var player = other.GetComponent<Player>();
            if (player)
                player.TakeDamage();
        }
        else if (other.CompareTag("Enemy") && !_isEnemyLaser)
        {
            var player = other.GetComponent<Enemy>();
            if (player)
                player.TakeDamage(gameObject);
        }
    }
}