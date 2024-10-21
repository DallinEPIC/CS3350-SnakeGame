using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//neext Tail piece is a reference to the next body piece's class
//next Tail piece always points towards head
// queue of turn positions, that is  a deep copy of the next tail piece's queue
// same speed as head but different movement direction



public class TailBehaviour : MonoBehaviour
{
    public TailBehaviour nextTailPiece;
    public Queue<Vector3> turnPositions = new Queue<Vector3>();
    void Start()
    {
        //Mathf.Approximately();

    }

    
    void Update()
    {
        //when we eat fruit
        //instantiate tail prefab,
        //set next tail piece;
    }
}
