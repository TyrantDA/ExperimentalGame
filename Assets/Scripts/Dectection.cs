using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dectection : MonoBehaviour
{
    public float mRaycastRadius;  // width of our line of sight (x-axis and y-axis)
    public float mTargetDetectionDistance;  // depth of our line of sight (z-axis)

    float currentTime;
    float minTimeBetweenSpawns = 10;
    float maxTimeBetweenSpawns = 50;


    private RaycastHit _mHitInfo;   // allocating memory for the raycasthit
    // to avoid Garbage
    private bool _bHasDetectedEnnemy = false;   // tracking whether the player
                                                // is detected to change color in gizmos
                                                // Start is called before the first frame update

    Patrol pat;
    NavMeshAgent agent;
    bool seen;
    Vector3 lastSeen;
    

    void Start()
    {
        pat = GetComponent<Patrol>();
        agent = GetComponent<NavMeshAgent>();
        seen = false;
        lastSeen = new Vector3(0f, 0f, 0f);
        currentTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
    }
    public void CheckForTargetInLineOfSight()
    {
        _bHasDetectedEnnemy = false;
        _bHasDetectedEnnemy = Physics.SphereCast(transform.position, mRaycastRadius, transform.forward, out _mHitInfo, mTargetDetectionDistance);

       

        if (_bHasDetectedEnnemy)
        {
            if (_mHitInfo.transform.CompareTag("Player"))
            {
                Debug.Log("Detected Player");
                lastSeen = _mHitInfo.transform.position;
                agent.destination = lastSeen;
                
                seen = true;
            }
            else
            {

                if (!seen)
                {
                    Debug.Log("start Patrolling");
                    pat.PatrolRunning();
                }
                else
                {
                    Debug.Log("start searching");
                    agent.destination = lastSeen;
                    if (transform.position.x == lastSeen.x && transform.position.z == lastSeen.z)
                    {
                        currentTime -= Time.deltaTime;

                        if (currentTime <= 0)
                        {
                            seen = false;
                            Debug.Log("stop search");
                            currentTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
                        }
                        else
                        {
                            transform.Rotate(Vector3.up * 4 * Time.deltaTime);
                        }

                    }
                }
            }

        }
        else
        {
            if (!seen)
            {
                Debug.Log("start Patrolling");
                pat.PatrolRunning();
            }
            else
            {
                Debug.Log("start searching");
                agent.destination = lastSeen;
                if (transform.position.x == lastSeen.x && transform.position.z == lastSeen.z)
                {
                    currentTime -= Time.deltaTime;

                    if (currentTime <= 0)
                    {
                        seen = false;
                        Debug.Log("stop search");
                        currentTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
                    }
                    else
                    {
                        transform.Rotate(Vector3.up * 4 * Time.deltaTime);
                    }
                }
            }

        }

            //if (seen)
            //{
            //    // no player detected, insert your own logic
            //    Debug.Log("Player Losed");

            //    //search player
            //    agent.destination = lastSeen;

            //    if (transform.position.x == lastSeen.x && transform.position.z == lastSeen.z)
            //    {

            //        currentTime -= Time.deltaTime;

            //        if (currentTime >= 0)
            //        {


            //            if (transform.position.x == lastSeen.x && transform.position.z == lastSeen.z)
            //            {
            //                Quaternion newRotation = Quaternion.AngleAxis(90, Vector3.up);
            //                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, .05f);
            //            }
            //        }
            //    }
            //}
            //currentTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            //seen = false;



        }

    private void OnDrawGizmos()
    {
        if (_bHasDetectedEnnemy)
        {
            if (_mHitInfo.transform.CompareTag("Player"))
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.yellow;
            }
        }
        else
        {
            Gizmos.color = Color.green;
        }

        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.DrawCube(new Vector3(0f, 0f, mTargetDetectionDistance / 2f), new Vector3(mRaycastRadius, mRaycastRadius, mTargetDetectionDistance));
    }


    // Update is called once per frame
    void Update()
    {
        CheckForTargetInLineOfSight();
        //OnDrawGizmos();
    }
}
