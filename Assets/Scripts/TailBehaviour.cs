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
    //public Vector3 movementDirection;
    

    private void Start()
    {
        transform.LookAt(nextTailPiece.transform);
    }


    void Update()
    {
        transform.position += transform.forward * SnakeMovementBehaviour.instance.movementSpeed * Time.deltaTime;
        //checking if turn pos queue is empty
        if (turnPositions.Count == 0) return;

        Vector3 turnPos = turnPositions.Peek();
        Debug.Log($"turnpos: {turnPos}" );
        Debug.Log($"transform.position: {transform.position}");
        //if (Mathf.Approximately(turnPos.x, transform.position.x) && Mathf.Approximately(turnPos.z, transform.position.z))
        //if (turnPos.x - transform.position.x <= 0.2 && turnPos.z - transform.position.z <= 0.2)
        if (Vector3.Distance(turnPos, transform.position) <= 0.02)
        {
            //TODO
            //check if moving horizontally or vertically
            //if horizontal: set z of tail to next tail piece z
            //if vertical: set x of tail piece to next tail piece x



            //transform.position.z = nextTailPiece.transform.position.z;
            Debug.Log("HELLO");
            turnPositions.Dequeue();
            transform.LookAt(nextTailPiece.transform);
        }


        
    }
    public void AddTurnPos(Vector3 turnPos)
    {
        turnPositions.Enqueue(turnPos);
    }
    
}
