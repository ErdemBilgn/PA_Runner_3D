using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _runSpeed;
    [SerializeField] float _xSpeed;
    [SerializeField] float _limitX;

    void Start()
    {
        
    }


    void Update()
    {
        SwipeCheck();
    }

    void SwipeCheck()
    {
        float newX = 0;
        float touchXDelta = 0;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //Debug.Log(Input.GetTouch(0).deltaPosition.x / Screen.width);
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }

        newX = transform.position.x + _xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -_limitX, _limitX);

        Vector3 newPos = new Vector3(newX, transform.position.y, transform.position.z + _runSpeed * Time.deltaTime);
        transform.position = newPos;
    }
}
