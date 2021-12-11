using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class ToggleVR : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle toggle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToggle()
    {
        toggle.isOn = !toggle.isOn;
    }
}
