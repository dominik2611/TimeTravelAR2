using System;
using System.Collections;
using System.Collections.Generic;using TMPro;
using UnityEngine;

public delegate void SelectorHitEvent(RaycastHit[] objects);




/// <summary>
/// "Fadenkreuz". Schießt Raycast von Bildschirmmitte und informiert per Event über getroffene Objekte
/// </summary>
public class Selector : MonoBehaviour {
    
    public TMP_Text DebugText;


    public List<RectTransform> _uiElements = new List<RectTransform>();
    
    public int _frameCount = 0;
    // Start is called before the first frame update
    void Start() {
        TKTapRecognizer tapRecognizer = new TKTapRecognizer();

      
        
        tapRecognizer.gestureRecognizedEvent += r => {
         //
         // Debug.Log("uiElements_ "+_uiElements.Count);
            foreach (RectTransform el  in _uiElements) {

                for (int i = 0; i < el.childCount; i++) {
                    RectTransform child = el.transform.GetChild(i) as RectTransform;
                   // Debug.Log("Child_ "+child.name);
                    if (RectTransformUtility.RectangleContainsScreenPoint(child, r.touchLocation()))
                    {
                        return;
                    }
                }
                
               
            }
            
            SendRaycast();
        };

        TouchKit.addGestureRecognizer(tapRecognizer);

    }


   void Update() {
       Vector3 pos  = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
       _frameCount++;
       if (_frameCount % 20 == 0) {
         //  Debug.Log("Cam Pos: "+pos);
         //  DebugText.SetText("Cam Pos: "+pos);
       }
     
    }

    public event SelectorHitEvent OnSelectorHit = delegate { };


    private void SendRaycast() {
        Ray ray = Camera.main.ScreenPointToRay(gameObject.transform.position);
        RaycastHit[] hitObjects = Physics.RaycastAll(ray);
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(ray.origin,  Camera.main.transform.forward, Color.cyan, 14);
        Debug.DrawRay(ray.origin,  ray.direction, Color.magenta, 14);
        
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.green, 14);
        
        Debug.Log("Selector pos: "+gameObject.transform.position.ToString("G4"));
        
        OnSelectorHit(hitObjects);

    }

}