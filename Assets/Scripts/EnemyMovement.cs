using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : CharacterMovement
{
    [SerializeField] private Transform[] _patrolPoints;
    private Vector2 _destination;

    private int _nextPatrolPointIndex = 0;

    private void Start()
    {
        isMoving = true;
        _destination = _patrolPoints[_nextPatrolPointIndex].position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == _patrolPoints[_nextPatrolPointIndex])
        {
            ChangeDestination();
        }
    }

    protected override void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _destination, _velocity * Time.deltaTime);
    }

    private void ChangeDestination()
    {
        _nextPatrolPointIndex++;

        if (_nextPatrolPointIndex >= _patrolPoints.Length)
        {
            _nextPatrolPointIndex = 0;
        }

        _destination = _patrolPoints[_nextPatrolPointIndex].position;
    }
}