using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    public List<GameObject> fruits = new();
    public GameObject fruit;
    public Transform maxBounds;
    public Transform minBounds;
    bool isCoroutineRunning = false;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if(!isCoroutineRunning && GameController.instance.gameRunning == true) StartCoroutine(SpawnFruit());
        
    }
    IEnumerator SpawnFruit()
    {
        isCoroutineRunning = true;
        float min = Random.Range(minBounds.position.x, maxBounds.position.x);
        float max = Random.Range(minBounds.position.z, maxBounds.position.z);
        int fruitNum = Random.Range(0, fruits.Count);

        yield return new WaitForSeconds(2);

        GameObject newFruit = Instantiate(fruits[fruitNum]);
        
        newFruit.transform.position = new Vector3(min, 1, max);




        isCoroutineRunning = false;
    }

}
