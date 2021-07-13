using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class ImageFitter : MonoBehaviour {


    [SerializeField] private AxisControl _rotationControl;
    [SerializeField] private AxisControl _positionControl;
    [SerializeField] private AxisControl _scaleControl;
    
    [SerializeField]
    private Selector _selector;
    
    // Start is called before the first frame update
    void Start() {
        _selector.OnSelectorHit += objects => {
            Debug.Log("Selector hit "+objects.Length);
            foreach (RaycastHit hit in objects) {
                Debug.Log("Hit: " + hit.collider.gameObject.name);
                GameObject hitObj = hit.collider.gameObject;
                if (hitObj.GetComponent(typeof(Image)) != null ) {
                    Debug.Log("Hit an Image!");
                    // TODO set it as active image to manipulate
                    var axisPostionChangeable = hitObj.GetComponent<AxisPostionChangeable>();
                    var axisRotationChangeable = hitObj.GetComponent<AxisRotationChangeable>();
                    var scaleChangeable = hitObj.GetComponent<ScaleChangeable>();
                    _rotationControl.SetAxisChangeable(axisRotationChangeable);
                    _positionControl.SetAxisChangeable(axisPostionChangeable);
                    _scaleControl.SetAxisChangeable(scaleChangeable);
                }else if (hitObj.GetComponent(typeof(Object3D)) != null) {
                    var axisPostionChangeable = hitObj.GetComponent<AxisPostionChangeable>();
                    var axisRotationChangeable = hitObj.GetComponent<AxisRotationChangeable>();
                    var scaleChangeable = hitObj.GetComponent<Scale3DChangeable>();
                    _rotationControl.SetAxisChangeable(axisRotationChangeable);
                    _positionControl.SetAxisChangeable(axisPostionChangeable);
                    _scaleControl.SetAxisChangeable(scaleChangeable);
                }
            }
        };
    }

    // Update is called once per frame
    void Update() {
    }
}