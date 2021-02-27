using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private GameObject laserPrefab;

    private Player _player;
    private Animator _animator;
    private AudioSource _audioSource;
    private static readonly int OnEnemyDeath = Animator.StringToHash("OnEnemyDeath");
    private float _canFire = -1;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        CalculateMovement();
        Shoot();
    }

    private void Shoot()
    {
        
        if (Time.time > _canFire)
        {
            _canFire = Time.time + Random.Range(1f, 7f);
            var laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            var allLasers = laser.GetComponentsInChildren<Laser>();

            foreach (var singleLaser in allLasers)
                singleLaser.IsEnemyLaser();
        }
    }

    private void CalculateMovement()
    {
        transform.Translate(Vector3.down * (speed * Time.deltaTime));

        if (transform.position.y < -7)
            transform.position = new Vector3(Random.Range(-8f, 8f), 7, 0);
    }

    public void TakeDamage(GameObject other)
    {
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);

            if (_player)
                _player.AddScore(10);

            _animator.SetTrigger(OnEnemyDeath);
            speed = 0;
            _audioSource.Play();

            Destroy(GetComponent<Collider2D>());
            Destroy(gameObject, 2.8f);
        }
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
            _audioSource.Play();

            Destroy(GetComponent<Collider2D>());
            Destroy(gameObject, 2.8f);
        }
    }
}