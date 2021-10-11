using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageInstantiate : MonoBehaviour
{
    public int numVillages;
    public GameObject villagePrefab;
    public GameObject[] villageArray;

    void Start()
    {
        for (int i = 0; i < villageArray.Length; i++)
        {
            villageArray[i] = Instantiate(villagePrefab, new Vector2(Random.Range(-10, 10), Random.Range(-10, 10)), Quaternion.identity);
        }

        for (int i = 0; i < villageArray.Length; i++)
        {
            
            
        }
    }
}
