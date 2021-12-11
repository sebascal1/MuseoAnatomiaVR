using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalSettings : MonoBehaviour
{
    public bool _invertX = true;
    public bool _invertY = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeInvertX()
    {
        _invertX = !_invertX;
        Debug.Log($"X is now {_invertX}");
    }

    public void changeInvertY()
    {
        _invertY = !_invertY;
        Debug.Log($"Y is now {_invertY}");
    }
}
