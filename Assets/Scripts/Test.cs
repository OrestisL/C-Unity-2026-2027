using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    InputAction _help;
    void OnEnable()
    {
        Debug.Log("On Enable!!");
        _help.canceled += DisplayHelpMessage;
        _help.started += DisplayHelpMessage;
    }
    void Awake()
    {
        Debug.Log("Awake!!");
        _help = InputSystem.actions.FindAction("ShowHelp");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start!!");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update!!");
        if (_help.IsPressed())
            ContinuousMessage();
    }

    void LateUpdate()
    {
        Debug.Log("Late Update!!");
    }

    void OnDisable()
    {
        Debug.Log("On Disable!!");
        _help.started -= DisplayHelpMessage;
        _help.canceled -= DisplayHelpMessage;
    }

    void OnDestroy()
    {
        Debug.Log("On Destroy!!");
    }

    void OnApplicationQuit()
    {
        Debug.Log("On Application Quit!!");
    }

    private void DisplayHelpMessage(InputAction.CallbackContext ctx)
    {
        Debug.Log("This is a helpful message.");        
    }

    private void ContinuousMessage()
    {
        Debug.Log("This is a continuous message.");  
    }
}
