using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
            Debug.Log("fruit eaten");
        }
    }
    

    public void Die()
    {

        gameObject.SetActive(false);

    }
}
