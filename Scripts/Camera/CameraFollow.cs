using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject player;
	[Header("Camera follow values")]
	public float X=3,Z= -10,Y=3.8f;
	
	float FollowSpeed = 5f;
	
	void Update()
	{
		Vector3 newPosition = player.transform.position;
		newPosition.x += X;
		newPosition.z = Z;
		newPosition.y += Y;
		transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
	}
}
