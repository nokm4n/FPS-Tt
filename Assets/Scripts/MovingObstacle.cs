using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
	[SerializeField] private List<Transform> _waypoints;
	[SerializeField] private float _moveSpeed = 2f;

	private int waypointIndex = 0;

	private void Update()
	{
		Move();
	}

	private void Move()
	{

		if (waypointIndex <= _waypoints.Count - 1)
		{
			transform.position = Vector3.MoveTowards(transform.position,_waypoints[waypointIndex].transform.position,_moveSpeed * Time.deltaTime);

			if (transform.position == _waypoints[waypointIndex].transform.position)
			{
				waypointIndex += 1;
			}
		}
		else
		{
			waypointIndex = 0;
		}
	}

	public void Set(List<Transform> wayPoints, float moveSpeed)
	{
		_waypoints = wayPoints;
		_moveSpeed = moveSpeed;
	}

	private void OnDestroy()
	{
		Spawner.instance.RemoveTarget(this);
	}
}
