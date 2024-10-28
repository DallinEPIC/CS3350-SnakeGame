using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameController instance;
    [HideInInspector] public int score;
    void Start()
    {
        instance = this;
    }
    void Update()
    {
        
    }
}
