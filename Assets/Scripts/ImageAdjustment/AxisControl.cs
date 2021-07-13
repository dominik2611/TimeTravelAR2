using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AxisControl : MonoBehaviour {
    [SerializeField]
    private NumberAdjustment _xAxis;
    [SerializeField]
    private NumberAdjustment _yAxis;
    [SerializeField]
    private NumberAdjustment _zAxis;

    [SerializeField] private AxisChangeable _axisChangeable;

    [SerializeField]
    private CanvasGroup _canvasGroup;
    
    [SerializeField]
    private TMP_InputField _inputStepWidth;

    [SerializeField]
    private float _stepWidth = 0.01f;
    
    private bool _isVisible = true;

[SerializeField]
    private Button _btnShowHide;
    
    // Start is called before the first frame update
    void Start() {
       
        
        Debug.Log("_xAxis: "+_xAxis.name);
       

        if (_xAxis) {
         
            _xAxis.OnValueChanged += (value, type) => {
          
                _axisChangeable.ChangeXAxis(value, type == AxisValueChangedType.Relative  );
                _xAxis.SetValue(_axisChangeable.Axis[0]);
            };
          
            _xAxis.StepSize = _stepWidth;
        }

        if (_yAxis) {
            _yAxis.OnValueChanged += (value, type) => {
                _axisChangeable.ChangeYAxis(value, type == AxisValueChangedType.Relative ); 
                _yAxis.SetValue(_axisChangeable.Axis[1]);
            };
            
            _yAxis.StepSize = _stepWidth;
        }

        if (_zAxis) {
            _zAxis.OnValueChanged += (value, type) => {
                _axisChangeable.ChangeZAxis(value, type == AxisValueChangedType.Relative ); 
                _zAxis.SetValue(_axisChangeable.Axis[2]);
            };
           
            _zAxis.StepSize = _stepWidth;
        }
   
     
        
        _btnShowHide.onClick.AddListener(() => {
            Debug.Log("clicked show hide");
            if (_isVisible) {
                _isVisible = false;
                _canvasGroup.alpha = 0f;
                _canvasGroup.blocksRaycasts = false;
            } else {
                _isVisible = true;
                _canvasGroup.alpha = 1f;
                _canvasGroup.blocksRaycasts = true;
            }
          
        });


        _inputStepWidth.text = _stepWidth.ToString();
        
        _inputStepWidth.onValueChanged.AddListener(val => {
            _stepWidth = float.Parse(val);
            Debug.Log("new step width = "+_stepWidth);
            if (_xAxis) {
                _xAxis.StepSize = _stepWidth;
            }

            if (_yAxis) {
                _yAxis.StepSize = _stepWidth;
            }

            if (_zAxis) {
                _zAxis.StepSize = _stepWidth;
            }
          
            
        } );

       
       
        
        
    }

    private void InitNewObject() {
        Vector3 axis = _axisChangeable.Axis;
        if (_xAxis) {
         
           
            _xAxis.SetValue(axis[0]);
           
        }

        if (_yAxis) {
          
            _yAxis.SetValue(axis[1]);
       
        }

        if (_zAxis) {
          
            _zAxis.SetValue(axis[2]);
           
        }
   
     
        
       

    }

    public void SetAxisChangeable(AxisChangeable axisChangeable) {
        Debug.Log("Set Axischangeable "+axisChangeable.name);
        _axisChangeable = axisChangeable;
        InitNewObject();
    }

    // Update is called once per frame
    void Update() {
    }
}