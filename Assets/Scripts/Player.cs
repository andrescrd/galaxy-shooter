﻿using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 initialPosition = new Vector3(0, 0, 0);
    [SerializeField] private float speed = 5;
    [SerializeField] private float speedMiltiplier = 3;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject tripleShotPrefab;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private Vector3 laserOffset = new Vector3(0, 0.8f, 0);
    [SerializeField] private int lives = 3;

    private float _nextFire;
    private bool _isTripleShotActive = false;
    private SpawnManager _spawnManager;

    void Start()
    {
        transform.position = initialPosition;
        _spawnManager = GameObject.FindObjectOfType<SpawnManager>();

        if (_spawnManager == null)
            Debug.LogError("Spawn Manager not found");
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

        if (_isTripleShotActive)
        {
            Instantiate(tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(laserPrefab, transform.position + laserOffset, Quaternion.identity);
        }
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
        {
            _spawnManager.StopSpawn();
            Destroy(gameObject);
        }
    }

    public void TripleShotActive()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutinte());
    }

    private IEnumerator TripleShotPowerDownRoutinte()
    {
        yield return new WaitForSeconds(5.0f);
        _isTripleShotActive = false;
    }

    public void SpeedActive()
    {
        speed *= speedMiltiplier;
        StartCoroutine(SpeedActiveRoutine());
    }

    private IEnumerator SpeedActiveRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        speed /= speedMiltiplier;
    }

    public void ShieldActive()
    {
        throw new System.NotImplementedException();
    }
}