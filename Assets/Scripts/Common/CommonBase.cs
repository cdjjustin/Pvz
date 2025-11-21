using UnityEngine;

public class CommonBase : MonoBehaviour
{
    public float maxHealth = 10f;
    protected float currentHealth;
    
    protected void Init()
    {
        currentHealth = maxHealth;
    }
}