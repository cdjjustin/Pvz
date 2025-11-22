using System;
using UnityEngine;

public class CommonBase : MonoBehaviour
{
    public float maxHealth = 10f;
    protected float currentHealth;
    protected Animator animator;

    public virtual void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }
}