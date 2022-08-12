using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnPoints : MonoBehaviour
{

    public GameObject[] collectiblePrefabArray;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            Instantiate(collectiblePrefabArray[Random.Range(0, 4)], transform.position, transform.rotation);
            throw new UnassignedReferenceException(" Collectible not appearing " + name + " back off get your own sandwich. ");
        }

        finally
        {
            Debug.Log("Objects are placed. You can continue.");
        }
    }

    //void onTriggerEnter
    void Update()
    {
        
    }
}