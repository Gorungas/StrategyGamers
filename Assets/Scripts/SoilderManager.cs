using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilderManager : MonoBehaviour
{
    public Transform[] soldiersPoses;
    public List<GameObject> soldiers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AssignSoldier(GameObject soldier) {
        int index=soldiers.IndexOf(null);
        if (index != -1) {
            soldiers.RemoveAt(index);
            soldiers.Insert(index, soldier);
        }
        else
        {
            index = soldiers.Count;
            soldiers.Add(soldier);
        }
        soldier.GetComponent<SoilderFollow>().followPos = soldiersPoses[index];
    }
}
