using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuControlInput : MonoBehaviour

{
    public InputActionReference activateMenu = null;
    [SerializeField] GameObject menuWindow;

    // Start is called before the first frame update
    void Awake()
    {
            activateMenu.action.started += Toggle;
    }

    public void OnDestroy()
    {
        activateMenu.action.started -= Toggle;
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        bool isActive = !menuWindow.activeSelf;
        menuWindow.SetActive(isActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
