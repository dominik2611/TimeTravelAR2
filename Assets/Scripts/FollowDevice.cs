using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enables a gameobject to follow the camera.
/// </summary>
public class FollowDevice : MonoBehaviour {

    private GameObject _target;
    [SerializeField]
    private bool _active;
    [SerializeField]
    private bool xAxisLock;
    [SerializeField]
    private bool yAxisLock;
    [SerializeField]
    private bool zAxisLock;
    
    
    private Vector3 _fixedPosAxis;
    
    // Start is called before the first frame update
    void Start() {
        _target = gameObject;
        _active = true;

       _fixedPosAxis =  buildFixedPosAxisVector(xAxisLock, yAxisLock, zAxisLock);
    }

    // Update is called once per frame
    void Update() {
        var transform1 = Camera.main.transform;
        Vector3 camPos = transform1.position + transform1.forward;
        if (_active && _target != null) {
         _target.transform.position =    CalculatePos(_target.transform.position, camPos, _fixedPosAxis, Vector3.zero);
        }
        
    }
    
    
    private Vector3 CalculatePos(Vector3 targetPos, Vector3 currentPos, Vector3 fixedPosAxis, Vector3 offset) {
        Vector3 newPos = new Vector3();
        for (int i = 0; i < 3; i++) {
            newPos[i] = DetermineValue(targetPos[i], currentPos[i], fixedPosAxis[i]) + offset[i];
        }
      
        return newPos;
    }

    private Vector3 CalculateRotation(Vector3 targetRotation, Vector3 currentRotation, Vector3 fixedRoationAxis) {
        Vector3 newRotation = new Vector3();
        for (int i = 0; i < 3; i++) {
            newRotation[i] = DetermineValue(targetRotation[i], currentRotation[i], fixedRoationAxis[i]);
        }
        return newRotation;
    }

    private float DetermineValue(float target, float current, float fixedAxis) {
        return fixedAxis > 0 ? target : current;
    }

    private Vector3 buildFixedPosAxisVector(bool fixedX, bool fixedY, bool fixedZ) {
        int x = fixedX ? 1 : 0;
        int y = fixedY ? 1 : 0;
        int z = fixedZ ? 1 : 0;
        return new Vector3(x, y, z);
    }
    
}