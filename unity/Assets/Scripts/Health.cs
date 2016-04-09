using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 1000f;
    private float currentHealth;
    private float leakRate = 0f;

	public float HealthPercentage {
		get {
			return this.currentHealth / this.maxHealth;
		}
	}

	public bool IsAlive {
		get {
			return this.currentHealth > 0.0f;
		}
	}

	public void GetOutsideOfWorld() {
		this.currentHealth = -1.0f;
	}

    /// <summary>
    /// Gets the leak rate. The leak rate specifies how much health is lost per second.
    /// </summary>
    public float LeakRate {
        get {
			return this.leakRate;
        }
    }

    public void Start()
    {
		this.currentHealth = this.maxHealth;
    }

    public void IncreaseLeakRate (float leakRate)
    {
		Debug.Assert(leakRate > 0.0f, "leak rate needs to be positive");
		this.leakRate += leakRate;
    }

    public void DecreaseLeakRate (float leakRate)
    {
		Debug.Assert(leakRate > 0.0f, "leak rate needs to be positive");
		this.leakRate = Mathf.Max(this.leakRate - leakRate, 0.0f);
    }

    public void ResetLeak ()
    {
		this.leakRate = 0f;
    }

    void Update ()
    {
		this.currentHealth -= this.LeakRate * Time.deltaTime;
    }
}
