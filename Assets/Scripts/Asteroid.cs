using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float speedRotation = 3;
    [SerializeField] private GameObject explosionPrefab;

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.forward * (speedRotation * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject, 0.2f);
        }
    }
}