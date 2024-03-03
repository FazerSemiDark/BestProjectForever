using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;

    private PlayerHealth _playerHealth;
    private NavMeshAgent _navMeshAgent;
    public PlayerController Player;

    public int Position;
    private bool _isPlayerNoticed;
    public float ViewAngle;
    public float Damage = 30f;

    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = Player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        PatrolUpdate();
        PlayerTracking();
        AttackUpdate();
        ChaseUpdate();
    }

    private void PatrolUpdate()
    {
        if (_isPlayerNoticed == false)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
        
    }

    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void PlayerTracking()
    {
        var direction = Player.transform.position - transform.position;

        _isPlayerNoticed = false;

        if (Vector3.Angle(transform.forward, direction) < ViewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == Player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        } 
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed == true)
        {
            _navMeshAgent.destination = Player.transform.position;
        }
    }
    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _playerHealth.DealDamage(Damage * Time.deltaTime);
            }
        }
    }
}
