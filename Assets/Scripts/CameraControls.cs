using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Camera cam;
    public GameObject player;

    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = cam.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 5.0f, Vector3.up) * offset;
        cam.transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
    }
}
