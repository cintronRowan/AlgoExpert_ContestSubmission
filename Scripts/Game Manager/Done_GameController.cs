using UnityEngine;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public Transform spawnValues2;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public HealthBarManager HealBarM;
	public HealthSystem healthS;
	public HealthBarManager SheildBarM;
	public HealthSystem sheildS;
	
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText salvageText;
	
	private bool gameOver;
	private bool restart;
	private int score;
	private int salvage;
	
	void Start ()
	{
		healthS = new HealthSystem (100);
		HealBarM.Setup (healthS);
		sheildS = new HealthSystem (100);
		SheildBarM.Setup (sheildS);
		sheildS.Damage (10);

		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		salvage = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	
	void Update ()
	{
		if (healthS.Health > 0) 
		{
			sheildS.Heal (0.1f);
			Debug.Log (sheildS.Health);
		}
			
		
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
			if (Input.GetKeyDown (KeyCode.M))
			{
				Application.LoadLevel (0);
			}
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues2.position.x, spawnValues2.position.x), 
													 spawnValues2.position.y, spawnValues2.position.z);
				//Vector3 spawnPosition = spawnValues2.position;
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);	
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
		salvageText.text = "Salvage: "+ salvage;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
		restartText.text = "Press 'R' for Restart \n" +
							"Press 'M' for Menu";
		restart = true;
	}
}