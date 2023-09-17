using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject objectPrefab;
    public GameObject spawnPlace;
    public GameObject objectsParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiatePrefab()
    {
        GameObject instantiatedObj = Instantiate(objectPrefab, spawnPlace.transform.position, Quaternion.identity) ;
        instantiatedObj.SetActive(true);
        instantiatedObj.transform.SetParent(objectsParent.transform);
    }

}
