using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform cameraTarget;
    [SerializeField] Transform lookTarget;
    [SerializeField] float sSpeed = 10f;
    [SerializeField] Vector3 distance;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        Vector3 dPos = cameraTarget.position + distance;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos , sSpeed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(lookTarget.position);
    }


    void Update()
    {
        
    }
}
