using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision!");
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log($"End collision with {collision.gameObject.name}");
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log($"Collision with {collision.gameObject.name}");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger!");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log($"Trigger exit {other.gameObject.name}");   
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log($"Trigger stay {other.gameObject.name}");        
    }
}
