using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject head;
    [SerializeField] private GameObject firstTail;
    GameObject tail;
    public List<GameObject> tailPieces = new();
    public static SnakeBehaviour instance;
    void Start()
    {
        //add head to pieces when game starts
        tailPieces.Add(head);
        tailPieces.Add(firstTail);
        instance = this;

    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.gameObject.CompareTag("fruit"))
        {
            Die();
        }
        else
        {
            EatFruit();
            Debug.Log("fruit eaten");
        }
    }
    

    public void Die()
    {

        gameObject.SetActive(false);

    }
    public void EatFruit()
    {
        Debug.Log("Fruit Eaten");
        Instantiate(tail);
        TailBehaviour tailBehaviour = tail.GetComponent<TailBehaviour>();
        tailBehaviour.nextTailPiece = gameObject;

    }

}
