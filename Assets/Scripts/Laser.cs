using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed = 8;

    void Update()
    {
        transform.Translate(Vector3.up * (Time.deltaTime * speed));

        if (transform.position.y > 10)
        {
            if (transform.parent)
                Destroy(transform.parent.gameObject);

            Destroy(gameObject);
        }
    }
}