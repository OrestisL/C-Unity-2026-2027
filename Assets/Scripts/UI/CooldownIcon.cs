using UnityEngine;
using UnityEngine.UI;
public class CooldownIcon : MonoBehaviour
{
    public Image Loading;
    public GameObject ReadyParticle;
    public void UpdateCooldown(float cooldown)
    {
        Loading.fillAmount = 1 - cooldown;
        if (Loading.fillAmount >= 1.0f)
        {
            Instantiate(ReadyParticle, transform.position, Quaternion.identity, transform);
        }
    }
}
