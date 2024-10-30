using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

//neext Tail piece is a reference to the next body piece's class
//next Tail piece always points towards head
// queue of turn positions, that is  a deep copy of the next tail piece's queue
// same speed as head but different movement direction



public class TailBehaviour : MonoBehaviour
{
    
    public GameObject nextTailPiece;
    public Queue<Vector3> turnPositions = new Queue<Vector3>();
    private Vector3 _movementDirection = Vector3.right;
    

    private void Start()
    {
        transform.LookAt(nextTailPiece.transform);
    }


    void Update()
    {
        if (!GameController.instance.gameRunning) return;

        transform.position += transform.forward * SnakeMovementBehaviour.instance.movementSpeed * Time.deltaTime;
        //checking if turn pos queue is empty
        if (turnPositions.Count == 0) return;

        Vector3 turnPos = turnPositions.Peek();
        //Debug.Log($"turnpos: {turnPos}" );
        //Debug.Log($"transform.position: {transform.position}");

        //TODO
        //check if moving horizontally or vertically
        if (_movementDirection == Vector3.forward) //moving up
        {
            if (transform.position.z < turnPos.z) return; //Not reached the turn position

            //If passed turn position, lock to z and change movement direction
            transform.position = new Vector3(transform.position.x, transform.position.y, turnPos.z);

            //Check if the move was a left or right move and update movement direction
            if (nextTailPiece.transform.position.x > turnPos.x) { _movementDirection = Vector3.right; }
            else { _movementDirection = Vector3.left; }
            transform.forward = _movementDirection;
            turnPositions.Dequeue();
        }
        else if (_movementDirection == Vector3.back) //moving down 
        {
            if (transform.position.z > turnPos.z) return; //Not reached the turn position

            //If passed turn position, lock to z and change movement direction
            transform.position = new Vector3(transform.position.x, transform.position.y, turnPos.z);

            //Check if the move was a left or right move and update movement direction
            if (nextTailPiece.transform.position.x > turnPos.x) { _movementDirection = Vector3.right; }
            else { _movementDirection = Vector3.left; }
            transform.forward = _movementDirection;
            turnPositions.Dequeue();
        }
        else if (_movementDirection == Vector3.left)//moving left
        {
            if (transform.position.x > turnPos.x) return; //Not reached the turn position

            //If passed turn position, lock to x and change movement direction
            transform.position = new Vector3(turnPos.x, transform.position.y, transform.position.z);

            //Check if the move was a left or right move and update movement direction
            if (nextTailPiece.transform.position.z > turnPos.z) { _movementDirection = Vector3.forward; }
            else { _movementDirection = Vector3.back; }
            transform.forward = _movementDirection;
            turnPositions.Dequeue();
        }
        else //moving right
        {
            if (transform.position.x < turnPos.x) return; //Not reached the turn position

            //If passed turn position, lock to x and change movement direction
            transform.position = new Vector3(turnPos.x, transform.position.y, transform.position.z);

            //Check if the move was a left or right move and update movement direction
            if (nextTailPiece.transform.position.z > turnPos.z) { _movementDirection = Vector3.forward; }
            else { _movementDirection = Vector3.back; }
            transform.forward = _movementDirection;
            turnPositions.Dequeue();
        }
    }
    public void AddTurnPos(Vector3 turnPos)
    {
        turnPositions.Enqueue(turnPos);
    }
    
    public void SpawnNextTailPiece(GameObject tailInstance)
    {
        tailInstance.transform.position = transform.position - _movementDirection;
        TailBehaviour tailBehaviour = tailInstance.GetComponent<TailBehaviour>();
        tailBehaviour.nextTailPiece = gameObject;
        tailBehaviour.turnPositions = new Queue<Vector3>(turnPositions);
        tailBehaviour._movementDirection = new Vector3(_movementDirection.x, _movementDirection.y, _movementDirection.z);
    }
}
