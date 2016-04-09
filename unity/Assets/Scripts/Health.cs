using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 1000f;
    private float currentHealth;
    private float leakRate = 0f;

	public float HealthPercentage {
		get {
			return currentHealth / maxHealth;
		}
	}

	public bool IsAlive {
		get {
			return currentHealth > 0.0f;
		}
	}

	public void GetOutsideOfWorld() {
		currentHealth = -1.0f;
	}

    /// <summary>
    /// Gets the leak rate. The leak rate specifies how much health is lost per second.
    /// </summary>
    public float LeakRate {
        get {
            return leakRate;
        }
    }

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void IncreaseLeakRate (float leakRate)
    {
		Debug.Assert(leakRate > 0.0f, "leak rate needs to be positive");
        leakRate += leakRate;
    }

    public void DecreaseLeakRate (float leakRate)
    {
		Debug.Assert(leakRate > 0.0f, "leak rate needs to be positive");
		leakRate = Mathf.Max(leakRate - leakRate, 0.0f);
    }

    public void ResetLeak ()
    {
        leakRate = 0f;
    }

    public void Update ()
    {
		currentHealth -= LeakRate * Time.deltaTime;
    }
}
