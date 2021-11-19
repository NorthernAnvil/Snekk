using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Script.LinkedSnek;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    Vector2 direction;
    bool isAlive;
    

    public GameObject bodyPart;
    public float score = 0;
    public Text scoreText;

    private SLinkedListS<Transform> bodyParts = new SLinkedListS<Transform>();


    void Start()
    {
        reset();    
    }

    void reset()
    {
        isAlive = true;
        transform.position = new Vector2(0, -1);
        transform.rotation = Quaternion.Euler(0, 0, -90);
        direction = Vector2.right;
        Time.timeScale = 0.1f;
               
    }


    void grow()
    {
        Vector2 nextPos = transform.position;
        GameObject newBodyPart = Instantiate(bodyPart);
        newBodyPart.transform.position = nextPos;
        bodyParts.addLast(newBodyPart.transform);
    }


    void Update()
    {
        getUserInput();
        scoreText.text = score.ToString();
    }

    void getUserInput()
    {
        if (Input.GetKeyDown(KeyCode.W) && direction != Vector2.down)
        {
            direction = Vector2.up;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S) && direction != Vector2.up)
        {
            direction = Vector2.down;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (Input.GetKeyDown(KeyCode.D) && direction != Vector2.left)
        {
            direction = Vector2.right;
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (Input.GetKeyDown(KeyCode.A) && direction != Vector2.right)
        {
            direction = Vector2.left;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.R) && isAlive == false)
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }

    void FixedUpdate()
    {
        moveBody();
        moveSnake();
    }

    void moveBody()
    {
        Vector2 nextPossition = transform.position;

        var theHead = bodyParts.head;

        while (theHead != null)
        {
            Vector2 spacingPos = theHead.data.position;
            theHead.data.position = nextPossition;
            nextPossition = spacingPos;
            theHead = theHead.next;
        }
        
    }

    void moveSnake()
    {
        float x = transform.position.x + direction.x;
        float y = transform.position.y + direction.y;
        transform.position = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Wall")
        {
            Time.timeScale = 0;
            isAlive = false;
        }
        else if (collider.tag == "Food")
        {
            grow();
            score++;
        }
        else if (collider.tag == "PwrUps")
        {          
            Time.timeScale = Time.timeScale * 1.5f;
        }
    }
}
