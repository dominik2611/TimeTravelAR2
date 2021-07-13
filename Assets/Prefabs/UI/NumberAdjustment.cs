using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public enum AxisValueChangedType {
    Absolute,
    Relative
}

public class NumberAdjustment : MonoBehaviour {



    public delegate void ValueChanged(float value, AxisValueChangedType type);
    
    [SerializeField] private Button _buttonPlus;

    [SerializeField] private Button _buttonMinus;
    [SerializeField] private Button _buttonCheck;
    [SerializeField] private Button _buttonLock;
    [SerializeField] private TMP_InputField _numberInput;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField]
    private String _titleText;

     private float _stepSize = 1.0f;

    public event ValueChanged OnValueChanged = delegate { };
    
    
    // Start is called before the first frame update
    void Start() {
        _title.text = _titleText;
        _buttonPlus.onClick.AddListener(() => {
         
           // OnValueChanged(ParseFloat(_numberInput.text)+_stepSize, AxisValueChangedType.Relative);
            OnValueChanged(_stepSize, AxisValueChangedType.Relative);

        });
        
        _buttonMinus.onClick.AddListener(() => {
          //  OnValueChanged(ParseFloat(_numberInput.text)-_stepSize, AxisValueChangedType.Relative);
            OnValueChanged(-_stepSize, AxisValueChangedType.Relative);

        });
        
        _buttonCheck.onClick.AddListener(() => {
            Debug.Log("check: "+_numberInput.text + " parsed: "+float.Parse(_numberInput.text));
            OnValueChanged(ParseFloat(_numberInput.text), AxisValueChangedType.Absolute);
           

        });
        
    }

    public float StepSize {
        get => _stepSize;
        set => _stepSize = value;
    }

    private float ParseFloat(string value) {
        Debug.Log("Parse: "+value);
        var f = float.Parse(_numberInput.text, NumberStyles.Float);
       

        return f;
    }
    
    // Update is called once per frame
    void Update() {
    }

    public void SetValue(float value) {
        _numberInput.text = value.ToString();
    }
}