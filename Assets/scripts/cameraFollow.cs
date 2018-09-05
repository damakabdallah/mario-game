using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    public GameObject target;
    public float smoothFactor;

    // Use this for initialization
    void Start()
    {

    }

    // FixedUpdate is called on a fixed time interval
    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);
    }
}
