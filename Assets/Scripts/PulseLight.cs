using UnityEngine;

public class PulseLight : MonoBehaviour
{
    public Light Light;
    public float Base;
    public float Range;
    public float Frequency;
    void Start()
    {
        if(Light == null)
        {
            Light = GetComponent<Light>();
            if (Light == null)
            {
                Debug.LogError($"Light not found in {gameObject.name}");
                Destroy(this);
            }
        }
    }


    void Update()
    {
        Light.intensity = Base + Range * Mathf.Sin(Time.time * Frequency)+ 0.75f * Range * Mathf.Sin(Time.time * Frequency * 2);
    }
}
