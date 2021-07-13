using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChangeable : AxisChangeable
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
        Debug.Log("Scale change: " + value);
        Vector3 scale = gameObject.transform.localScale;
        float x = 0;
        float y = 0;
        if (!relative) {
            var ratio = (scale[1]) / (float)(scale[0]);
            x = value ;
            y =  value * ratio;
        } else {
            var ratio = (scale[1]) / (float)(scale[0]);
            x = value + scale[0];
            y = (value*ratio) + scale[1];
        }

        gameObject.transform.localScale = new Vector3(x, y, scale[2]);
    }
    public override Vector3 Axis {
        get { return gameObject.transform.localScale; }
    }

}
