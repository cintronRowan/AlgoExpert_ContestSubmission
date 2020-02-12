using UnityEngine;
using System.Collections;

public class DestroyAircraft : MonoBehaviour {

	public GameObject explosion;
	public GameObject smallExplotion;
	public bool Player;
	private Done_GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider impactObject)
	{
		if (impactObject.tag != "ChaseSensor" && impactObject.tag != "EnemyAI"&& impactObject.tag != "Boundery"
			&& impactObject.tag != "Blast"&& impactObject.tag != "echoBlast") {

			if (Player)
			{
				float damage = 10;
				gameController.sheildS.Damage (damage);
				damage = damage - gameController.sheildS.Health;
				if(damage>0)
					gameController.healthS.Damage (damage);
				
				Instantiate (smallExplotion, transform.position, transform.rotation);
				if (gameController.healthS.Health == 0) 
				{
					gameController.GameOver();
					Instantiate (explosion, transform.position, transform.rotation);
					Destroy (transform.parent.parent.gameObject);
				}
			}
		}
	}
}
