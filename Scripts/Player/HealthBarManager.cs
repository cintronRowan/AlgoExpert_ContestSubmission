using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour {

	private HealthSystem HealthS;
	public float width;

	public void Setup(HealthSystem healthS)
	{
		HealthS = healthS;
		HealthS.OnHealthChanged+= HealthS_OnHealthChanged;
	}

	void HealthS_OnHealthChanged (object sender, System.EventArgs e)
	{
		this.transform.localScale = new Vector3 (width * HealthS.GetHealthPercent(),
												this.transform.localScale.y,this.transform.localScale.z);
	}
}
