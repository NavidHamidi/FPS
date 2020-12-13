using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] private float maxHp;
	[SerializeField] private float curHp;

	private bool isAlive;

	public void TakeDamage(float amount)
	{
		curHp -= amount;
		if (curHp <= 0)
			isAlive = false;
	}

	public void Heal(float amount)
	{
		curHp += amount;
		if (curHp >= maxHp)
			curHp = maxHp;
	}

	public void Die()
	{
		Debug.Log("Player die");
	}

	public void Start()
	{
		isAlive = true;
	}

	public void Update()
	{
		if (!isAlive)
			Die();
	}
}
