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
    [HideInInspector] public Vector3 movementDirection = Vector3.right;
    

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

        //check if moving horizontally or vertically
        if (movementDirection == Vector3.forward) //moving up
        {
            if (transform.position.z < turnPos.z) return; //Not reached the turn position

            //If passed turn position, lock to z and change movement direction
            transform.position = new Vector3(transform.position.x, transform.position.y, turnPos.z);

            //Check if the move was a left or right move and update movement direction
            if (nextTailPiece.transform.position.x > turnPos.x) { movementDirection = Vector3.right; }
            else { movementDirection = Vector3.left; }
            transform.forward = movementDirection;
            turnPositions.Dequeue();
        }
        else if (movementDirection == Vector3.back) //moving down 
        {
            if (transform.position.z > turnPos.z) return; //Not reached the turn position

            //If passed turn position, lock to z and change movement direction
            transform.position = new Vector3(transform.position.x, transform.position.y, turnPos.z);

            //Check if the move was a left or right move and update movement direction
            if (nextTailPiece.transform.position.x > turnPos.x) { movementDirection = Vector3.right; }
            else { movementDirection = Vector3.left; }
            transform.forward = movementDirection;
            turnPositions.Dequeue();
        }
        else if (movementDirection == Vector3.left)//moving left
        {
            if (transform.position.x > turnPos.x) return; //Not reached the turn position

            //If passed turn position, lock to x and change movement direction
            transform.position = new Vector3(turnPos.x, transform.position.y, transform.position.z);

            //Check if the move was a left or right move and update movement direction
            if (nextTailPiece.transform.position.z > turnPos.z) { movementDirection = Vector3.forward; }
            else { movementDirection = Vector3.back; }
            transform.forward = movementDirection;
            turnPositions.Dequeue();
        }
        else //moving right
        {
            if (transform.position.x < turnPos.x) return; //Not reached the turn position

            //If passed turn position, lock to x and change movement direction
            transform.position = new Vector3(turnPos.x, transform.position.y, transform.position.z);

            //Check if the move was a left or right move and update movement direction
            if (nextTailPiece.transform.position.z > turnPos.z) { movementDirection = Vector3.forward; }
            else { movementDirection = Vector3.back; }
            transform.forward = movementDirection;
            turnPositions.Dequeue();
        }
        if(nextTailPiece.tag == "Player" ) { if (turnPositions.Count == 0) transform.position = nextTailPiece.transform.position - new Vector3(movementDirection.x * 1.5f, movementDirection.y, movementDirection.z * 1.5f); }
        else
        {
            TailBehaviour tailBehaviour = nextTailPiece.GetComponent<TailBehaviour>();
            if (turnPositions.Count == tailBehaviour.turnPositions.Count) transform.position = nextTailPiece.transform.position - movementDirection;
        }
    }
    public void AddTurnPos(Vector3 turnPos)
    {
        turnPositions.Enqueue(turnPos);
    }
    
    public void SpawnNextTailPiece(GameObject tailInstance)
    {
        tailInstance.transform.position = transform.position - movementDirection;
        TailBehaviour tailBehaviour = tailInstance.GetComponent<TailBehaviour>();
        tailBehaviour.nextTailPiece = gameObject;
        tailBehaviour.turnPositions = new Queue<Vector3>(turnPositions);
        tailBehaviour.movementDirection = new Vector3(movementDirection.x, movementDirection.y, movementDirection.z);
    }
}
