using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour
{
    public enum ScreenLocation
    {
        topLeft, topRight, bottomLeft, bottomRight
    };

    public ScreenLocation _screenLoation;
    private void Awake()
    {
        Camera cam = GetComponent<Camera>();

        switch (_screenLoation)
        {
            case ScreenLocation.topLeft:
                cam.rect = new Rect(0, .5f, .5f, .5f);
                break;
            case ScreenLocation.topRight:
                cam.rect = new Rect(.5f, .5f, .5f, .5f);
                break;
            case ScreenLocation.bottomLeft:
                cam.rect = new Rect(0, 0, .5f, .5f);
                break;
            case ScreenLocation.bottomRight:
                cam.rect = new Rect(.5f, 0, .5f, .5f);
                break;

            default:
                print("choose");
                break;
        }

    }
}
