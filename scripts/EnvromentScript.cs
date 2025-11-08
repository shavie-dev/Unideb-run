using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvromentScript : MonoBehaviour
{
    public logicScript logic;
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        moveTowardsCamera();
        if(logic.score > 10000 && logic.isAlive)
        {
            moveSpeed = 7;
        }

        if (logic.score > 20000 && logic.isAlive)
        {
            moveSpeed = 8;
        }

        if (logic.score > 30000 && logic.isAlive)
        {
            moveSpeed = 9;
        }

        if (logic.score > 40000 && logic.isAlive)
        {
            moveSpeed = 10;
        }

        if (logic.score > 50000 && logic.isAlive)
        {
            moveSpeed = 11;
        }

        if (logic.score > 60000 && logic.isAlive)
        {
            moveSpeed = 12;
        }

        
    }

    public void moveTowardsCamera()
    {
        transform.position += Vector3.back * moveSpeed * Time.deltaTime; 
    }
}
