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
    

    private void Start()
    {
        transform.LookAt(nextTailPiece.transform);
    }


    void Update()
    {
        
        if (turnPositions.Count != 0 && Mathf.Approximately(turnPositions.Peek().x, transform.position.x) && Mathf.Approximately(turnPositions.Peek().z, transform.position.z))
        {
            turnPositions.Dequeue();
            transform.LookAt(nextTailPiece.transform);
        }


        transform.position += transform.forward * SnakeMovementBehaviour.instance._movementSpeed * Time.deltaTime;
    }
    public void AddTurnPos(Vector3 turnPos)
    {
        turnPositions.Enqueue(turnPos);
    }
    
}
