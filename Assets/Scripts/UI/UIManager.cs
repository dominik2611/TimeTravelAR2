using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

[SerializeField]
    private List<CanvasGroup> _canvasHideable;
    private bool _isVisible = true;

    [SerializeField]
    private Button _btnShowHide;
    // Start is called before the first frame update
    void Start()
    {
        _btnShowHide.onClick.AddListener(() => {
            Debug.Log("clicked show hide");
          
            if (_isVisible) {
                _isVisible = false;
              
            } else {
                _isVisible = true;
            
            }

            foreach (var canvasGroup in _canvasHideable) {
                canvasGroup.alpha = _isVisible ? 1.0f : 0;
                canvasGroup.blocksRaycasts = !_isVisible;
            }
          
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ToggleHideUi() {
        
    }
}
