using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    public List<GameObject> fruits = new();
    public Transform maxBounds;
    public Transform minBounds;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        SpawnFruit();


    }
    IEnumerator SpawnFruit()
    {
        float min = Random.Range(minBounds.position.x, maxBounds.position.x);
        float max = Random.Range(minBounds.position.z, maxBounds.position.z);
        int fruitNum = Random.Range(0, fruits.Count);
        yield return new WaitForSeconds(2f);
        GameObject newFruit = Instantiate(fruits[fruitNum]);
        newFruit.transform.position = new Vector3(min, 0, max);



    }
}
