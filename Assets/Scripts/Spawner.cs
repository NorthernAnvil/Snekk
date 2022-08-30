using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GridManager gridManager;

    public GameObject Food;
    public GameObject PwrUps;


    private void Start()
    {
        InvokeRepeating("SpawnFood", 2.0f, 1f);
        InvokeRepeating("SpawnPwrUp", 2.0f, 2f);
        SpawnFood();
        SpawnPwrUp();
    }


    public void SpawnFood()
    {
        int x = Random.Range(0, gridManager.gridWidth - 1);
        int y = Random.Range(0, gridManager.gridHeight - 1);
        transform.position = new Vector2(x, y);


        Vector2 newPos = transform.position;
        GameObject food = Instantiate(Food);
        food.transform.position = newPos;


    }

    private void SpawnPwrUp()
    {
        int x = Random.Range(0, gridManager.gridWidth -1);
        int y = Random.Range(0, gridManager.gridHeight -1);
        transform.position = new Vector2(x, y);


        Vector2 newPos = transform.position;
        GameObject pwrUp = Instantiate(PwrUps);
        pwrUp.transform.position = newPos;
    }


}
