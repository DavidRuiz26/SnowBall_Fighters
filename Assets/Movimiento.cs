using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movimiento : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        var target = GameObject.FindGameObjectWithTag("Goal");
        navMeshAgent.destination = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var target = GameObject.FindGameObjectWithTag("Goal");
        navMeshAgent.destination = target.transform.position;
    }
}
