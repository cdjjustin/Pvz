using UnityEngine;

public class ZombieBase : CommonBase, IHelth
{
    public virtual void ChangeHealth(float num)
    {
        currentHealth = Mathf.Clamp(currentHealth + num, 0, maxHealth);
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}