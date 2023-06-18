using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class Woodcutter : MonoBehaviour
{
    [SerializeField] private LayerMask collectableLayer;
    [SerializeField] private Transform bagTransform;
    [SerializeField] private Transform baseTransform;
    [SerializeField] private Vector3 offset;

    [SerializeField] private float radius;
    [SerializeField] private int bagCapacity = 2;

    private List<GameObject> _woods;
    private int collectedTrees;
    private NavMeshAgent _agent;
    private bool _isCrafting;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _woods = GameObject.FindGameObjectsWithTag("Collectable").ToList();
    }

    private void Update()
    {
        if (collectedTrees >= bagCapacity)
        {
            _agent.SetDestination(baseTransform.position);
            return;
        }

        if (!_isCrafting)
        {
            _agent.SetDestination(FindClosestWood().transform.position);
            _isCrafting = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            other.tag = "Collected";

            other.transform.parent = bagTransform;

            other.transform.DOLocalJump(Vector3.zero + offset, 2, 1, 0.5f);

            offset += new Vector3(0, 0.6f, 0);
            collectedTrees++;

            _woods.Remove(other.gameObject);
            _isCrafting = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
 
    }

    private GameObject FindClosestWood()
    {
        GameObject closestWood = _woods[0];

        foreach (var wood in _woods)
        {
            float distance = Vector3.Distance(transform.position, wood.transform.position);
            float closestWoodDistance = Vector3.Distance(transform.position,
                closestWood.transform.position);

            if (distance < closestWoodDistance)
            {
                closestWood = wood;
            }
        }

        return closestWood;
    }
}