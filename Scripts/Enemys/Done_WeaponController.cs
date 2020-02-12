using UnityEngine;
using System.Collections;

public class Done_WeaponController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	public float bulletspeed;

	void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire ()
	{
		//Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		GameObject newBullet = Instantiate (shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
		newBullet.GetComponent<Rigidbody> ().velocity = transform.forward * bulletspeed;
		GetComponent<AudioSource>().Play();
	}
}
