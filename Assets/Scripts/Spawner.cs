using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject Food;
    public GameObject PwrUps;


    private void Start()
    {
        InvokeRepeating("SpawnFood", 2.0f, 1f);
        InvokeRepeating("SpawnPwrUp", 2.0f, 2f);
        SpawnFood();
        SpawnPwrUp();
    }
    private void SpawnFood()
    {
        int x = Random.Range(-18, 18);
        int y = Random.Range(-18, 18);
        transform.position = new Vector2(x, y);


        Vector2 nextPos = transform.position;
        GameObject newBodyPart = Instantiate(Food);
        newBodyPart.transform.position = nextPos;
    }

    private void SpawnPwrUp()
    {
        int x = Random.Range(-18, 18);
        int y = Random.Range(-18, 18);
        transform.position = new Vector2(x, y);


        Vector2 nextPos = transform.position;
        GameObject newBodyPart = Instantiate(PwrUps);
        newBodyPart.transform.position = nextPos;
    }


}
