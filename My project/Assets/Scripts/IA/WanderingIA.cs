using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingIA : MonoBehaviour
{
    private NavMeshAgent agent;
    public int random;
    public float contador;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        random = Random.Range(0, 100);
    }

    private void FixedUpdate()
    {
        if(random <= 60)
        {
            Vagar();
        }
        else if(random > 60)
        {
            Parado();
            contador += Time.fixedDeltaTime;
            if(contador >= 3)
            {
                contador = 0;
                random = Random.Range(0, 100);
            }
        }
    }


    private void Vagar()
    {
        if (!agent.pathPending && agent.remainingDistance <= 1f)
        {
            Vector3 randomPoint = RandomNavmeshLocation(15f);
            agent.SetDestination(randomPoint);
            agent.speed = 3f;
            random = Random.Range(0, 100);
        }

    }

    private void Parado()
    {
        agent.speed = 0;
        agent.SetDestination(transform.position);
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas);
        return hit.position;
    }
}
