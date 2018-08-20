using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	void Start ()
	{
		rigidbody.velocity = transform.forward * 20;
	}
}
