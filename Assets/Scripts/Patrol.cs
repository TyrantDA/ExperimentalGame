using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public List<GameObject> patrolList;
    public GameObject Patroller;
    public float speed;

    public int currentMovingTo;
    public GameObject target;
    public float distance;
    NavMeshAgent agent;
    private NavMeshPath path;
    bool patrolling;

    // Start is called before the first frame update
    void Start()
    {
        target = patrolList[0];
        agent = GetComponent<NavMeshAgent>();
        patrolling = false;
        path = new NavMeshPath();
    }

    public void setPatrolling(bool set)
    {
        patrolling = set;
    }
    
    float Lenth(GameObject p, GameObject pat)
    {
        float x = pat.transform.position.x * p.transform.position.x;
        float y = pat.transform.position.y * p.transform.position.y;
        float z = pat.transform.position.z * p.transform.position.z;

        x = Mathf.Pow(x, 2);
        y = Mathf.Pow(y, 2);
        z = Mathf.Pow(z, 2);

        float answer = x + y + z;

        answer = Mathf.Sqrt(answer);

        return answer;
    }

    GameObject closest(GameObject player)
    {
        int key = 0;
        float comareHold = 0;
        float comare = 0;

        for (int x = 0; x < patrolList.Count; x++)
        {
            comare = Lenth(player, patrolList[x]);
            if(comareHold > comare)
            {
                comareHold = comare;
                key = x;
            }
            else if(comareHold == comare)
            {
                comareHold = comare;
                key = x;
            }
              
        }

        GameObject hold = patrolList[key];
        currentMovingTo = key;
        return hold;
    }

    void nextTarget()
    {
        

        currentMovingTo++;

        if(currentMovingTo >= patrolList.Count)
        {
            currentMovingTo = 0;
        }

        target = patrolList[currentMovingTo];
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, path);
        agent.SetPath(path);
    }

    // Update is called once per frame
    public void PatrolRunning()
    {

        
        distance = agent.remainingDistance;
        Debug.Log("point " + currentMovingTo + " | target " + target.name + " | Distance " + distance);
        if (distance < 0.1f)
        {
            Debug.Log("next target");
                nextTarget();
            
        }
        
    }

    void Update()
    {
        //if (patrolling)
        //{
        //    agent.destination = target.transform.position;
        //    //float step = speed * Time.deltaTime;
        //    //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

        //    //Debug.Log("patrol pos: " + transform.position.x + " : " + transform.position.z + " | point pos : "+ target.transform.position.x + " : " + target.transform.position.z);

        //    if (transform.position.x == target.transform.position.x && transform.position.z == target.transform.position.z)
        //    {
        //        target = nextTarget();
        //    }
        //}
          
    }
}
