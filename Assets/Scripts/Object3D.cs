using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object3D : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake() {
        Debug.Log("Object Awake");
        gameObject.AddComponent<Scale3DChangeable>();
        gameObject.AddComponent<AxisPostionChangeable>();
        gameObject.AddComponent<AxisRotationChangeable>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
