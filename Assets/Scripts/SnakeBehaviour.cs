using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject head;
    [SerializeField] private TailBehaviour firstTail;
    private GameController GameController;
    public GameObject tail;
    public List<TailBehaviour> tailPieces = new();
    public AudioSource dieSound;
    public AudioSource eatSound;
    public static SnakeBehaviour instance;

    void Start()
    {
        //add head to pieces when game starts
        tailPieces.Add(firstTail);
        instance = this;
        GameController = GameController.instance;
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
        dieSound.Play();
        gameObject.SetActive(false);
        GameController.GameOver();
    }
    public void EatFruit()
    {
        Debug.Log("Fruit Eaten");
        eatSound.Play();
        GameObject tailInstance = Instantiate(tail);
        tailPieces[tailPieces.Count - 1].SpawnNextTailPiece(tailInstance);
        tailPieces.Add(tailInstance.GetComponent<TailBehaviour>());
        GameController.score += GameController.instance.fruitScore;
    }

}
