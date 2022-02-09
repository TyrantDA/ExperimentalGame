using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public List<GameObject> patrolList;
    public GameObject Patroller;
    public float speed;

    int currentMovingTo;
    GameObject target;
    NavMeshAgent agent;
    bool patrolling;

    // Start is called before the first frame update
    void Start()
    {
        target = closest(Patroller);
        agent = GetComponent<NavMeshAgent>();
        patrolling = false;
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
            if(comareHold < comare)
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

    GameObject nextTarget()
    {
        

        currentMovingTo++;

        if(currentMovingTo >= patrolList.Count)
        {
            currentMovingTo = 0;
        }

        return patrolList[currentMovingTo];
    }

    // Update is called once per frame
    public void PatrolRunning()
    {
            agent.destination = target.transform.position;
            //float step = speed * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

            //Debug.Log("patrol pos: " + transform.position.x + " : " + transform.position.z + " | point pos : "+ target.transform.position.x + " : " + target.transform.position.z);

            if (transform.position.x == target.transform.position.x && transform.position.z == target.transform.position.z)
            {
                target = nextTarget();
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
