using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InformationPanel : MonoBehaviour
{
    public TextMeshProUGUI header;
    public TextMeshProUGUI information;
    [SerializeField] GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseWindow()
    {
        header.text = null;
        information.text = null;
        Panel.SetActive(false);
    }

    public void ShowWindow()
    {
        Panel.SetActive(true);
    }
}
