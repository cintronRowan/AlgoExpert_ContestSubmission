using System;


public class HealthSystem
{
	public event EventHandler OnHealthChanged;
	public float Health;
	public float HealthMax;
	public HealthSystem(int health)
	{
		HealthMax = health;
		Health = health;
	}

	public float GetHealth()
	{
		return Health;
	}

	public float GetHealthPercent()
	{
		return Health / HealthMax;
	}

	public void Damage(float dam)
	{
		Health -= dam;
		if (Health < 0)
			Health = 0;
		if (OnHealthChanged != null)
			OnHealthChanged (this, EventArgs.Empty);
	}

	public void Heal(float heal)
	{
		Health += heal;
		if (Health > HealthMax)
			Health = HealthMax;
		if (OnHealthChanged != null)
			OnHealthChanged (this, EventArgs.Empty);
	}
}
