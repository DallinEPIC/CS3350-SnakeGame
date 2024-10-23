using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovementBehaviour : MonoBehaviour
{
    private Vector3 _movementDirection;
    [SerializeField, Range(1,50)] public float _movementSpeed;
    public static SnakeMovementBehaviour instance;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) 
        { 
            _movementDirection = Vector3.forward;
            foreach (GameObject tail in SnakeBehaviour.instance.tailPieces)
            {
                TailBehaviour tailBehaviour;
                tailBehaviour = tail.GetComponent<TailBehaviour>();
                tailBehaviour.AddTurnPos(transform.position);
            }
        }
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            _movementDirection = Vector3.back;
            foreach (GameObject tail in SnakeBehaviour.instance.tailPieces)
            {
                TailBehaviour tailBehaviour;
                tailBehaviour = tail.GetComponent<TailBehaviour>();
                tailBehaviour.AddTurnPos(transform.position);
            }
        }
    
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            _movementDirection = Vector3.left;
            foreach (GameObject tail in SnakeBehaviour.instance.tailPieces)
            {
                TailBehaviour tailBehaviour;
                tailBehaviour = tail.GetComponent<TailBehaviour>();
                tailBehaviour.AddTurnPos(transform.position);
            }
        }
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            _movementDirection = Vector3.right;
            foreach (GameObject tail in SnakeBehaviour.instance.tailPieces)
            {
                TailBehaviour tailBehaviour;
                tailBehaviour = tail.GetComponent<TailBehaviour>();
                tailBehaviour.AddTurnPos(transform.position);
            }
        }

        transform.position += _movementDirection * _movementSpeed * Time.deltaTime;
    }
}
