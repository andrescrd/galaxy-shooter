using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;

    private Player _player;
    private Animator _animator;
    private static readonly int OnEnemyDeath = Animator.StringToHash("OnEnemyDeath");

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
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

            _animator.SetTrigger(OnEnemyDeath);
            speed = 0;
            Destroy(gameObject, 2.8f);
        }
        
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);

            if (_player)
                _player.AddScore(10);
            
            _animator.SetTrigger(OnEnemyDeath);
            speed = 0;
            Destroy(gameObject, 2.8f);
        }
    }
}