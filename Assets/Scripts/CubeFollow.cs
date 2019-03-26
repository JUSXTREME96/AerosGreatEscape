using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeFollow : MonoBehaviour
{
    public GameObject target = null;
    private NavMeshAgent nma = null;

    private void Start()
    {
        nma = this.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        nma.SetDestination(target.transform.position);
    }
}