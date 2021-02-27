using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;

    private Player _player;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        transform.Translate(Vector3.down * (speed * Time.deltaTime));

        if (transform.position.y < -7)
            transform.position = new Vector3(Random.Range(-8f, 8f), 7, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.transform.GetComponent<Player>();

            if (player)
                player.TakeDamage();

            Destroy(gameObject);
        }
        
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);

            if (_player)
                _player.AddScore(10);
            
            Destroy(gameObject);
        }
    }
}