using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisChangeable : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public virtual void ChangeXAxis(float value, bool relative) {
        
    }
    
    public virtual void ChangeYAxis(float value, bool relative) {
        
    }
    
    public virtual void ChangeZAxis(float value, bool relative) {
        
    }

    public virtual Vector3 Axis {
        get {
            return new Vector3(0, 0, 0);
        }
    }
    
}
