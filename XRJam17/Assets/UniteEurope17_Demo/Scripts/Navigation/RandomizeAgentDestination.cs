using UnityEngine;
using UnityEngine.AI;
using Mapbox.Unity.Utilities;

[RequireComponent(typeof(NavMeshAgent))]
public class RandomizeAgentDestination : MonoBehaviour, ITouchable
{
	[SerializeField]
	Vector2 _timeRange;

	[SerializeField]
	Vector2 _distanceRange;

	[SerializeField]
	GameObject[] _boats;

	NavMeshAgent _agent;

	float _elapsedTime;
	float _waitTime;

	bool _isFocused;

	public string Description
	{
		get
		{
			return "Boat";
		}
	}

	void Awake()
	{
		_agent = GetComponent<NavMeshAgent>();
		ActivateChild();
		SetDestination();
	}

	void ActivateChild()
	{
		var index = Random.Range(0, _boats.Length);
		_boats[index].SetActive(true);
	}

	void Update()
	{
		if (_isFocused)
		{
			return;
		}

		//Debug.DrawLine(transform.position, _agent.destination, Color.red);
		if (_elapsedTime >= _waitTime || (transform.position - _agent.destination).sqrMagnitude < 1)
		{
			_elapsedTime = 0f;
			_waitTime = Random.Range(_timeRange.x, _timeRange.y);
			SetDestination();
		}

		_elapsedTime += Time.deltaTime;
	}
	void SetDestination()
	{
		var target = (Random.insideUnitCircle * Random.Range(_distanceRange.x, _distanceRange.y)).ToVector3xz() + transform.position;
		if (_agent.isOnNavMesh)
		{
			_agent.destination = target;
		}
	}

	public void Activate()
	{
		Destroy(gameObject);
	}

	public void Focus()
	{
		_agent.isStopped = true;
	}

	public void Deactivate()
	{
		if (_agent)
		{
			_agent.isStopped = false;
			SetDestination();
		}
	}
}