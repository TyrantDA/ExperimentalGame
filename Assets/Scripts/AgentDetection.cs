using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentDetection : MonoBehaviour
{
    public LayerMask detectLayers;
    [Range(0.5f,100)]
    public float detectRange = 10;
    public float sightRange = 10;
    [SerializeField]
    List<Transform> targets= new List<Transform>();

    SphereCollider detectTrigger;
    Transform currentTarget;

    private void Awake()
    {
        detectTrigger = GetComponent<SphereCollider>();
        detectTrigger.radius = detectRange;
    }

    private void Update()
    {
        foreach (Transform t in targets)
        {
            RaycastHit hitInfo;

            //if (Physics.Raycast(transform.position, (transform.position-t.position).normalized, out hitInfo, sightRange, detectLayers,QueryTriggerInteraction.Ignore))
            if (Physics.Linecast(transform.position, t.position, out hitInfo, detectLayers))
            {
                Debug.Log("hit something: " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform == t)
                {
                    Debug.Log("Target in sight");
                    currentTarget = t;
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        targets.Add(other.transform);
        //Debug.Log(other.transform.gameObject.name);
    }


    private void OnTriggerExit(Collider other)
    {
        targets.Remove(other.transform);
    }

}
