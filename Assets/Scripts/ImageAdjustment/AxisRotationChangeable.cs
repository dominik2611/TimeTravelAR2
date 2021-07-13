using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AxisRotationChangeable : AxisChangeable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ChangeXAxis(float value, bool relative) {
     
        Vector3 angles = gameObject.transform.eulerAngles;
        
        if (!relative) {
           float r = value;
            Vector3 rot = gameObject.transform.eulerAngles;
            gameObject.transform.eulerAngles = new Vector3(r, rot[1], rot[2]);
        } else {
            float r =  value;
            gameObject.transform.Rotate(CleanValue(r), 0,0);
        }
       
    }

    public override void ChangeYAxis(float value, bool relative) {
    
        Vector3 angles = gameObject.transform.eulerAngles;
        if (!relative) {
            float r = value;
            Vector3 rot = gameObject.transform.eulerAngles;
            gameObject.transform.eulerAngles = new Vector3(rot[0], r, rot[2]);
        } else {
            float r =  value;
            gameObject.transform.Rotate(0,  CleanValue(r),0);
        }
    }

    public override void ChangeZAxis(float value, bool relative) {
      
        Vector3 angles = gameObject.transform.eulerAngles;
        if (!relative) {
            float r = value;
            Vector3 rot = gameObject.transform.eulerAngles;
            gameObject.transform.eulerAngles = new Vector3(rot[0], rot[1], r);
        } else {
            float r = value;
            gameObject.transform.Rotate(0,0,CleanValue(r));
        }
    }

    private float CleanValue(float f) {
        if ((f < 0.001 && f > 0) || (f > -0.001 && f < 0)) {
            return 0;
        }

        return f;
    }
    
    public override Vector3 Axis {
        get {
            return gameObject.transform.eulerAngles;
        }
    }
}
