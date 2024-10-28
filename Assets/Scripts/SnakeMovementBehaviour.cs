using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovementBehaviour : MonoBehaviour
{
    private Vector3 _movementDirection;
    [SerializeField, Range(1,50)] public float movementSpeed;
    public static SnakeMovementBehaviour instance;

    void Start()
    {
        _movementDirection = Vector3.right;
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) 
        { 
            _movementDirection = Vector3.forward;
            foreach (TailBehaviour tail in SnakeBehaviour.instance.tailPieces)
            {
                tail.AddTurnPos(transform.position);
                
                
            }
        }
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            _movementDirection = Vector3.back;
            foreach (TailBehaviour tail in SnakeBehaviour.instance.tailPieces)
            {
                tail.AddTurnPos(transform.position);
                

            }
        }
    
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            _movementDirection = Vector3.left;
            foreach (TailBehaviour tail in SnakeBehaviour.instance.tailPieces)
            {
                tail.AddTurnPos(transform.position);
                

            }
        }
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            _movementDirection = Vector3.right;
            foreach (TailBehaviour tail in SnakeBehaviour.instance.tailPieces)
            {
                tail.AddTurnPos(transform.position);
                

            }
        }

        transform.position += _movementDirection * movementSpeed * Time.deltaTime;
    }
}
