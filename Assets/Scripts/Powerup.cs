using Enums;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private PowerupEnum type = PowerupEnum.TripleShot;
    
    void Update()
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
                    case PowerupEnum.TripleShot:
                        player.TripleShotActive();
                        break;
                    case PowerupEnum.Speed:
                        player.SpeedActive();
                        break;
                    case  PowerupEnum.Shield:
                        player.ShieldActive();
                        break;
                }
            }
            
            Destroy(gameObject);
        }
    }
}