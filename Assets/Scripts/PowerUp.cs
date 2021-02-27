using System;
using Enums;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private PowerUpEnum type = PowerUpEnum.TripleShot;

    private void Update()
    {
        transform.Translate(Vector3.down * (speed * Time.deltaTime));

        if (transform.position.y < -6)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.transform.GetComponent<Player>();
            
            if(player)
            {
                switch (type)
                {
                    case PowerUpEnum.TripleShot:
                        player.TripleShotActive();
                        break;
                    case PowerUpEnum.Speed:
                        player.SpeedActive();
                        break;
                    case  PowerUpEnum.Shield:
                        player.ShieldActive();
                        break;
                }
            }
            
            Destroy(gameObject);
        }
    }
}