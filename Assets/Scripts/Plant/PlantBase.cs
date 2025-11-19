using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlantBase : CommonBase, IHelth
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
}