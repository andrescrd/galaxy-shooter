using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Vector3 InitialPosition = new Vector3(0, 0, 0);
    [SerializeField]
    private float Speed = 5;

    void Start()
    {
        transform.position = InitialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalinput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalinput, 0);
        transform.Translate(direction * Time.deltaTime * Speed);

        Vector3 newPosition = new Vector3();
        newPosition.y = Mathf.Clamp(transform.position.y, -3, 0);
        newPosition.x = Mathf.Clamp(transform.position.x, -9, 9);

        transform.position = newPosition;
    }
}
