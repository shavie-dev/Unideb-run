using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawnScript : MonoBehaviour
{

    public GameObject warningSign;
    public GameObject trashBlock;
    public GameObject toxicWaste;
    public GameObject signLeft;
    public GameObject signRight;
    public GameObject trashBlockLeft;
    public float offset = 20;
    public Transform enviroment;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnObstacles(); 
    }

    public void spawnObstacles()
    {
        GameObject[] obstacles = new GameObject[] {warningSign, trashBlock, toxicWaste, signLeft, signRight, trashBlockLeft};
        int ranNum = Random.Range(0, obstacles.Length);

        GameObject[] spawnedObstacle = GameObject.FindGameObjectsWithTag("obstacle");
        System.Array.Sort(spawnedObstacle, (a, b) => a.transform.position.z.CompareTo(b.transform.position.z));

        Vector3 lastpos = spawnedObstacle[spawnedObstacle.Length - 1].transform.position;
        Vector3 spawnPos = new Vector3(lastpos.x, lastpos.y, lastpos.z + offset);

        

        if (spawnedObstacle.Length < 7)
        {
            Instantiate(obstacles[ranNum], spawnPos, transform.rotation, enviroment);
            //Debug.Log("it spawned");
        }

        if (spawnedObstacle[0].transform.position.z < -19.1)
        {
            Destroy(spawnedObstacle[0]);
        }
    }
}
