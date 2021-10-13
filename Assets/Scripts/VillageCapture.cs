using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageCapture : MonoBehaviour
{
    public int villigers;
    public float recoverTime=10f;
    public float captureTime=3f;
    private bool isCapturing;
    private GameObject lastKing;
    //private SoilderManager soilderManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Recover());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //King enter village
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("King")&&!isCapturing)
        {
            isCapturing = true;
            lastKing = collision.gameObject;
            StartCoroutine(Capture(collision.GetComponent<SoilderManager>()));
            
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("King")&&collision.gameObject==lastKing)
        {
            isCapturing = false;
            lastKing = null;
        }
    }
    //capturing
    IEnumerator Capture(SoilderManager soilderManager)
    {
        float stayTime = 0;
        while (isCapturing&&stayTime<captureTime) {
            stayTime += Time.deltaTime;
            yield return null;
        }
        if (stayTime >= captureTime)
        {
            villigers -= soilderManager.SetSoldier(villigers);
        }
    }
    IEnumerator Recover()
    {
        while (true)
        {
            villigers += 1;
            yield return new WaitForSeconds(recoverTime);
        }
    }
    //King leave viilage
}
