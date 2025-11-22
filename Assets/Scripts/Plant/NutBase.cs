public class NutBase : PlantBase
{
    public float cracked1HealthRatio = 0.66f;
    public float cracked2HealthRatio = 0.33f;
    
    public override void ChangeHealth(float num)
    {
        base.ChangeHealth(num);
        var healthRatio = currentHealth / maxHealth;
        if (healthRatio <= cracked2HealthRatio)
        {
            animator?.SetTrigger("Cracked2");
        }
        else if (healthRatio <= cracked1HealthRatio)
        {
            animator?.SetTrigger("Cracked1");
        }
    }
}