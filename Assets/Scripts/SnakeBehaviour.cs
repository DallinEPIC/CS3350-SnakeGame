using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject head;
    [SerializeField] private TailBehaviour firstTail;
    public GameObject tail;
    public List<TailBehaviour> tailPieces = new();
    public AudioClip dieSound;
    public AudioClip eatSound;
    public static SnakeBehaviour instance;

    void Start()
    {
        //add head to pieces when game starts
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
            StartCoroutine(Die());
        }
        else
        {
            EatFruit();
        }
    }
    
    public IEnumerator Die()
    {
        GameController.instance.GameOver();
        float timeToWait = 0.2f;
        for (int i = tailPieces.Count - 1; i >= 0; i--)
        {
            yield return new WaitForSeconds(timeToWait);

            timeToWait *= 0.95f;
            GameController.instance.audioSource.clip = dieSound;
            GameController.instance.audioSource.Play();
            tailPieces[i].gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(timeToWait);
        GameController.instance.audioSource.clip = dieSound;
        GameController.instance.audioSource.Play();
        gameObject.SetActive(false);
    }
    public void EatFruit()
    {
        Debug.Log("Fruit Eaten");
        GameController.instance.audioSource.clip = eatSound;
        GameController.instance.audioSource.Play();
        GameObject tailInstance = Instantiate(tail);
        tailPieces[tailPieces.Count - 1].SpawnNextTailPiece(tailInstance);
        tailPieces.Add(tailInstance.GetComponent<TailBehaviour>());
        GameController.instance.OnEatFruit();
    }

}
