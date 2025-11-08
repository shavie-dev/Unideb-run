using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class streetSpawnerScript : MonoBehaviour
{
    public GameObject streetBuilding;
    public Transform enviroment;
    // Start is called before the first frame update
    void Start()
    {
        spawnStreet();
    }

    // Update is called once per frame
    void Update()
    {
       spawnTiming();
    }

    public void spawnStreet()
    {
        GameObject[] streets = GameObject.FindGameObjectsWithTag("street");
        System.Array.Sort(streets, (a, b) => a.transform.position.z.CompareTo(b.transform.position.z));

        Vector3 lastPos = streets[streets.Length - 1].transform.position;
        Vector3 spawnPos = new Vector3(lastPos.x, lastPos.y, lastPos.z + 31);

        Instantiate(streetBuilding, spawnPos, transform.rotation, enviroment);
        
    }



    
    public void spawnTiming()
    {
        GameObject[] streets = GameObject.FindGameObjectsWithTag("street");

        System.Array.Sort(streets, (a,b) => a.transform.position.z.CompareTo(b.transform.position.z));

        if (streets.Length < 4)
        {
            spawnStreet();
            //Debug.Log("street spawned");
        }

        if(streets[0].transform.position.z <= -19.1)
        {
            Destroy(streets[0]);
            //Debug.Log("it has deleted");
        }
    }
    
}
