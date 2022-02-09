using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dectection : MonoBehaviour
{
    public float mRaycastRadius;  // width of our line of sight (x-axis and y-axis)
    public float mTargetDetectionDistance;  // depth of our line of sight (z-axis)

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
    }
    public void CheckForTargetInLineOfSight()
    {
        _bHasDetectedEnnemy = Physics.SphereCast(transform.position, mRaycastRadius, transform.forward, out _mHitInfo, mTargetDetectionDistance);

        if (_bHasDetectedEnnemy)
        {
            if (_mHitInfo.transform.CompareTag("Player"))
            {
                Debug.Log("Detected Player");
                pat.setPatrolling(false);
                agent.destination = _mHitInfo.transform.position;
                lastSeen = _mHitInfo.transform.position;
                seen = true;
            }
            else
            {
                Debug.Log("No Player detected");
                pat.setPatrolling(true);


            }

        }
        else
        {
            // no player detected, insert your own logic
            Debug.Log("Player Losed");

            //search player
            pat.setPatrolling(true);
        }
    }

    private void OnDrawGizmos()
    {
        if (_bHasDetectedEnnemy)
        {
            Gizmos.color = Color.red;
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
