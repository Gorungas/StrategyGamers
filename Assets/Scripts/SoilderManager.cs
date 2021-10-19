using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilderManager : MonoBehaviour
{
    public Transform[] soldiersPoses;
    public List<GameObject> soldiers;
    public GameObject soldierPrefab;
    int playerNum;
    // Start is called before the first frame update
    void Start()
    {
        playerNum = GetComponent<PlayerNumberManager>().playerNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AssignSoldier(GameObject soldier) {
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
        soldier.GetComponent<PlayerNumberManager>().playerNum = playerNum;
        soldier.GetComponent<SoilderFollow>().followPos = soldiersPoses[index];
    }
    public int SetSoldier(int num)
    {
        int soldierNum = soldiersPoses.Length - soldiers.Count;
        if (num < soldierNum)
        {
            soldierNum = num;
        }
        Debug.Log(soldierNum);
        for (int i=0; i< soldierNum; i++)
        {
            GameObject solider = Instantiate(soldierPrefab,transform.position,Quaternion.identity);
            AssignSoldier(solider);
        }
        //if (soldierNum < 0) { soldierNum = 0; }
        return soldierNum;
    }
}
