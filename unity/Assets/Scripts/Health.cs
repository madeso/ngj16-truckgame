using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public delegate void SingleParamEvent(GameObject gameObject);
    public static event SingleParamEvent OnPlayerDied;

    public GameObject leakParticlePrefab;
    public Image healthImage;
    public float leakPercentageInterval = 20f;
    public float maxHealth = 1000f;
    private float currentHealth;
    private float leakRate = 0f;
    private int leakParticleCount = 0;
    private float nextLeakSpawnPercentage = 80f;

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
		this.leakRate += leakRate * 4f;
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
        healthImage.fillAmount = HealthPercentage;
        if (HealthPercentage * 100f <= nextLeakSpawnPercentage) 
        {
            GameObject newLeakParticleEffect = (GameObject) Instantiate(leakParticlePrefab, transform.position, Quaternion.identity);
            newLeakParticleEffect.transform.SetParent(transform);
            newLeakParticleEffect.transform.localPosition = new Vector3(0, 2, -leakParticleCount / 2f);
            newLeakParticleEffect.transform.Rotate(Vector3.up, 90f);
            leakParticleCount++;
            nextLeakSpawnPercentage -= leakPercentageInterval;
        }

        if (!IsAlive && OnPlayerDied != null)
        {
            OnPlayerDied(gameObject);
        }
    }
}
