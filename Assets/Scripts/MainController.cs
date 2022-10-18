using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField] public Transform _centerPoint;
    [SerializeField] public float _speed = 1f;
    [SerializeField] private float distanceToTarget = 10;
    [SerializeField] private Camera cam;

    private Vector3 previousPosition;

    private void Awake()
    {
        cam.transform.position = _centerPoint.position;

        cam.transform.Rotate(new Vector3(0, 0, 0), _speed, Space.World); // <— This is what makes it work!

        cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveCameraAroundTargetVertical(Vector3.up);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            MoveCameraAroundTargetVertical(Vector3.down);
        }

        if (Input.GetKey(KeyCode.W))
        {
            MoveCameraAroundTargetHorizontal(Vector3.right);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            MoveCameraAroundTargetHorizontal(Vector3.left);
        }
    }

    private void MoveCameraAroundTargetVertical(Vector3 direction)
    {
        cam.transform.position = _centerPoint.position;
        cam.transform.Rotate(direction, _speed, Space.World); // <— This is what makes it work!
        cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
    }
    
    private void MoveCameraAroundTargetHorizontal(Vector3 direction)
    {
        cam.transform.position = _centerPoint.position;
        cam.transform.Rotate(direction, _speed);
        cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
    }
}
