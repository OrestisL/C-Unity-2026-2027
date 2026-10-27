using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Unity.AI.Navigation;

[RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent _agent;
    private InputAction _click;
    private InputAction _mousePos;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _click = InputSystem.actions.FindAction(Constants.InputNames.LEFT_CLICK);
        _mousePos = InputSystem.actions.FindAction(Constants.InputNames.LOOK);

        _click.performed+=Click;
    }

    void Click(InputAction.CallbackContext ctx)
    {
        Camera cam = Camera.main;
        var v = Mouse.current.position.ReadValue();
        Ray ray = cam.ScreenPointToRay(v);
        if (!Physics.Raycast(ray, out var hitInfo))
            return;   


        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = hitInfo.point; 

        _agent.SetDestination(hitInfo.point);
    }

}
