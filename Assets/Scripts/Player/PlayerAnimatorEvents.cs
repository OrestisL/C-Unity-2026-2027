using UnityEngine;

public class PlayerAnimatorEvents : MonoBehaviour
{
    public float HitRadius = 2.0f;
    public float ForceMagnitude = 10.0f;
    public LayerMask HitLayer;
    public void OnKick()
    {      
        Collider[] results = Physics.OverlapSphere(transform.position + transform.up, HitRadius, HitLayer);
        Debug.Log($"Kick hit {results.Length} colliders");
        if (results.Length == 0)
            return;

        for (int i = 0; i < results.Length; i++)
        {
            var hit = results[i];
            if (hit.TryGetComponent(out Rigidbody body))
            {
                Vector3 direction = (hit.transform.position - (transform.position + transform.up)).normalized;
                body.AddForce(direction * ForceMagnitude, ForceMode.Impulse);
            }
        }
    }

    public void OnPunch()
    {
        Collider[] results = Physics.OverlapSphere(transform.position + transform.up, HitRadius, HitLayer);
        Debug.Log($"Punch hit {results.Length} colliders");
        if (results.Length == 0)
            return;

        for (int i = 0; i < results.Length; i++)
        {
            var hit = results[i];
            if (hit.TryGetComponent(out Rigidbody body))
            {
                Vector3 direction = (hit.transform.position - (transform.position + transform.up)).normalized;
                body.AddForce(direction * ForceMagnitude, ForceMode.Impulse);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + transform.up, HitRadius);
    }
}
