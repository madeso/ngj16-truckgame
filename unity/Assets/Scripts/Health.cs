public class Health
{
    private float maxHealth = 1000f;
    private float currentHealth;
    private float leakRate = 0f;

    /// <summary>
    /// Gets the leak rate. The leak rate specifies how much health is lost per tick.
    /// </summary>
    /// <value>The leak rate.</value>
    public float LeakRate {
        get {
            return leakRate;
        }
    }

    public Health (float maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
    }

    public Health ()
    {
        currentHealth = maxHealth;
    }

    public void IncreaseLeakRate (float leakRate)
    {
        leakRate += leakRate;
    }

    public void DecreaseLeakRate (float leakRate)
    {
        leakRate -= leakRate;
    }

    public void ResetLeak ()
    {
        leakRate = 0f;
    }

    public void Leak ()
    {
        currentHealth -= LeakRate;
    }
}
