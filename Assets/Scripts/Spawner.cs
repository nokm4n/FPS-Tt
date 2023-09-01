using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public static Spawner instance;

	[SerializeField, NotNull] private MovingObstacle _target;
    [SerializeField, NotNull] private List<Transform> _wayPoints;

    [SerializeField] private int _countOfTrgets = 2;
    [SerializeField] private List<MovingObstacle> _alivetargets;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.Log("More than 1 Spawner in scene");
		}
		instance = this;
	}

	private void Start()
    {
		var target = Instantiate(_target, _wayPoints[Random.Range(0, _wayPoints.Count)]);
		target.Set(_wayPoints, Random.Range(3f, 7f));
		_alivetargets.Add(target);
	}

    private void Update()
    {

        if( _alivetargets.Count < _countOfTrgets)
        {
            var target = Instantiate(_target, _wayPoints[Random.Range(0, _wayPoints.Count)]);
            target.Set(_wayPoints, Random.Range(3f, 7f));
			_alivetargets.Add(target);
        }
    }

	public void RemoveTarget(MovingObstacle target)
	{
		_alivetargets.Remove(target);
	}

}
