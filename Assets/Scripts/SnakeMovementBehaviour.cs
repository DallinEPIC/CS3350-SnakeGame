using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovementBehaviour : MonoBehaviour
{
    private Vector3 _movementDirection;
    [SerializeField, Range(1,50)] private float _movementSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) { _movementDirection = Vector3.forward; }
        if (Input.GetKeyDown(KeyCode.S)) { _movementDirection = Vector3.back; }
        if (Input.GetKeyDown(KeyCode.A)) { _movementDirection = Vector3.left; }
        if (Input.GetKeyDown(KeyCode.D)) { _movementDirection = Vector3.right; }

        transform.position += _movementDirection * _movementSpeed ;
    }
}
