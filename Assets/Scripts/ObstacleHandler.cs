using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{

    [SerializeField] GameObject obstaclePrefab;

    void Start()
    {
        for(int i=0; i<Random.Range(10, 30); i++)
        {
            GameObject temp = Instantiate(obstaclePrefab,
                new Vector3(Random.Range(-19, 19), 2, Random.Range(transform.position.z - 20, transform.position.z + 40)), 
                Quaternion.identity);
            temp.transform.parent = gameObject.transform; 
        }
    }

}
