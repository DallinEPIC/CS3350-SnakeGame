using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SnakeMovementBehaviour : MonoBehaviour
{
    public Vector3 _movementDirection;
    [SerializeField, Range(0,15)] public float movementSpeed;
    [SerializeField, Range(0,20)] public float maxMovementSpeed;
    [SerializeField, Range(1, 1.2f)] public float movementSpeedMultiplier;
    public static SnakeMovementBehaviour instance;

    void Start()
    {
        _movementDirection = Vector3.right;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.instance.gameRunning) return;

        if (Input.GetKeyDown(KeyCode.W) && _movementDirection != Vector3.back && _movementDirection != Vector3.forward) 
        {
            _movementDirection = Vector3.forward;
            foreach (TailBehaviour tail in SnakeBehaviour.instance.tailPieces) tail.AddTurnPos(transform.position);
        }
        if (Input.GetKeyDown(KeyCode.S) && _movementDirection != Vector3.forward && _movementDirection != Vector3.back) 
        {
            _movementDirection = Vector3.back;
            foreach (TailBehaviour tail in SnakeBehaviour.instance.tailPieces) tail.AddTurnPos(transform.position);
        }
        if (Input.GetKeyDown(KeyCode.A) && _movementDirection != Vector3.right && _movementDirection != Vector3.left) 
        {
            _movementDirection = Vector3.left;
            foreach (TailBehaviour tail in SnakeBehaviour.instance.tailPieces) tail.AddTurnPos(transform.position);
        }
        if (Input.GetKeyDown(KeyCode.D) && _movementDirection != Vector3.left && _movementDirection != Vector3.right) 
        {
            _movementDirection = Vector3.right;
            foreach (TailBehaviour tail in SnakeBehaviour.instance.tailPieces) tail.AddTurnPos(transform.position);
        }

        transform.position += _movementDirection * movementSpeed * Time.deltaTime;
        transform.forward = _movementDirection;
    }
    public void OnEatFruit()
    {
        movementSpeed *= movementSpeedMultiplier;
        if (movementSpeed > maxMovementSpeed) movementSpeed=maxMovementSpeed;
    }
}
