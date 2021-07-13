using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image : MonoBehaviour
{
    private void Awake() {
        Debug.Log("Image Awake");
        gameObject.AddComponent<ScaleChangeable>();
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
