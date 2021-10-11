using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageInstantiate : MonoBehaviour
{
    public int numVillages;
    public GameObject villagePrefab;
    public List<GameObject> villageArray = new List<GameObject>();
    public GameObject[] possibleLocation;

    void Start()
    {
        bool[] checklist=new bool[possibleLocation.Length];
        for (int i = 0; i < possibleLocation.Length; i++)
        {
            if (villageArray.Count < numVillages)
            {
                int index = Random.Range(0, possibleLocation.Length);
                while (checklist[index]) {
                    index = Random.Range(0, possibleLocation.Length);
                }
                checklist[index] = true;    
                villageArray.Add(Instantiate(villagePrefab, possibleLocation[index].transform.position, Quaternion.identity));

            }
        }
    }
}
