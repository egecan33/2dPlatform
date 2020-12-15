using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
	//offset from the viewport center to fix damping

	public GameObject player;
	float FollowSpeed = 5f;

	void Update()
	{
		Vector3 newPosition = player.transform.position;
		newPosition.x += 3;
		newPosition.z = -10;
		newPosition.y += 3.8f;
		transform.position = Vector3.Slerp(transform.position,newPosition,FollowSpeed*Time.deltaTime);
	}
}