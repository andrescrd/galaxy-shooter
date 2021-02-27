using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 initialPosition = new Vector3(0, 0, 0);
    [SerializeField] private float speed = 5;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private Vector3 laserOffset = new Vector3(0, 0.8f, 0);
    [SerializeField] private int lives = 3;

    private float _nextFire;

    void Start()
    {
        transform.position = initialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
            FireLaser();
    }

    private void FireLaser()
    {
        _nextFire = Time.time + fireRate;
        Instantiate(laserPrefab, transform.position + laserOffset, Quaternion.identity);
    }

    private void CalculateMovement()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        var direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * (Time.deltaTime * speed));

        var newPosition = new Vector3
        {
            y = Mathf.Clamp(transform.position.y, -3, 0),
            x = Mathf.Clamp(transform.position.x, -9, 9)
        };

        transform.position = newPosition;
    }

    public void TakeDamage()
    {
        lives--;

        if (lives <= 0)
            Destroy(gameObject);
    }
}