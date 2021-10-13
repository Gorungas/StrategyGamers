using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VillageCapture : MonoBehaviour
{
    private int villigers;
    public int maxVilligers;
    public float recoverTime=10f;
    public float captureTime=3f;
    private bool isCapturing;
    private GameObject lastKing;
    public TMP_Text numTxt;
    public SpriteRenderer sr;
    private Color kingColor;
    //private SoilderManager soilderManager;
    // Start is called before the first frame update
    void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
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
            kingColor = collision.GetComponent<SpriteRenderer>().color;
            StartCoroutine(Capture(collision.GetComponent<SoilderManager>()));
            
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("King")&&collision.gameObject==lastKing)
        {
            isCapturing = false;
            lastKing = null;
            sr.color=Color.white;
        }
    }
    //capturing
    IEnumerator Capture(SoilderManager soilderManager)
    {
        float stayTime = 0;
        float colorNum = 0;
        while (isCapturing&&stayTime<=captureTime) {
            
            colorNum += Time.deltaTime / captureTime;
            stayTime += Time.deltaTime;
            //Debug.Log(stayTime);
            //Debug.Log(colorNum);
            sr.color = Color.Lerp(Color.white,kingColor,colorNum);
            yield return null;
        }
        //Debug.Log(stayTime);
        if (stayTime >= captureTime)
        {
            villigers -= soilderManager.SetSoldier(villigers);
        }
        numTxt.text = villigers.ToString();
    }
    IEnumerator Recover()
    {
        while (true)
        {
            if (villigers< maxVilligers) {
                villigers += 1;
                numTxt.text = villigers.ToString();
                yield return new WaitForSeconds(recoverTime);
            }
            else
            {
                yield return null;
            }
        }
    }
    //King leave viilage
}
