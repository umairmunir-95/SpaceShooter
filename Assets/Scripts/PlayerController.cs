using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
	//public Boundary boundary;
	public GameObject shot;
	public Transform ShotSpawn;
	public float fireRate;
	private float nextFire;

	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, ShotSpawn.position, ShotSpawn.rotation);
		}
	}

	void FixedUpdate()
	{
		float xMin, xMax, zMin, zMax,tilt;
		xMin = -6.0f;
		xMax = 6.0f;
		zMin = -4.0f;
		zMax = 8.0f;
		tilt = -4.0f;
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float movVertical=Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, movVertical);
		movement = movement * 10;
		rigidbody.velocity = movement;
		rigidbody.position = new Vector3
		(
			Mathf.Clamp (rigidbody.position.x, xMin, xMax),
			0.0f,
			Mathf.Clamp (rigidbody.position.z, zMin, zMax)
		);
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * tilt);
	}
}
