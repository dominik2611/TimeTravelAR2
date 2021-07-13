using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisPostionChangeable : AxisChangeable {
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }


    private Vector3 GetPosition() {
        return gameObject.transform.localPosition;
    }

    private void SetPosition(Vector3 pos) {
        gameObject.transform.localPosition = pos;
    }
    
    public override void ChangeXAxis(float value, bool relative) {
        Debug.Log("Position change: " + value);
        Vector3 pos = GetPosition();
        float r = 0;
        if (!relative) {
            r = value;
        } else {
            r = value + pos[0];
        }

         SetPosition(new Vector3(r, pos[1], pos[2]));
    }

    public override void ChangeYAxis(float value, bool relative) {
        Vector3 pos = GetPosition();
        float r = 0;
        if (!relative) {
            r = value;
        } else {
            r = value + pos[1];
        }

        SetPosition( new Vector3(pos[0], r, pos[2]));
    }

    public override void ChangeZAxis(float value, bool relative) {
        Vector3 pos = GetPosition();
        float r = 0;
        if (!relative) {
            r = value;
        } else {
            r = value + pos[2];
        }

        SetPosition( new Vector3(pos[0], pos[1], r));
    }

    private float CleanValue(float f) {
        if ((f < 0.01 && f > 0) || (f > -0.01 && f < 0)) {
            return 0;
        }

        return f;
    }

    public override Vector3 Axis {
        get { return gameObject.transform.position; }
    }
}