using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform targetObject;
    public Vector3 cameraOffset;
    public bool lookAtTarget = false;


    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;
    }



    void LateUpdate()
    {
        Vector3 newPosition = targetObject.transform.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPosition, 0.125f);


        if (lookAtTarget)
        {

            transform.LookAt(targetObject);
        }

    }



}
