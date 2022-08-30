using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Spawner spawner;


    void Start()
    {
        randomPosition();
    }

    void randomPosition()
    {
        

       // int x = Random.Range(-18, 18);
       // int y = Random.Range(-18, 18);
       // transform.position = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spawner.SpawnFood();
    }

}
