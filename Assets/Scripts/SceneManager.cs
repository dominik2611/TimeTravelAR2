using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SceneManager : MonoBehaviour {


    public ARAnchorManager AnchorManager;

    public ARTrackedImageManager TrackedImageManager;

    private ARAnchor _sceneAnchor;
    [SerializeField]
    private TMP_Text _debugText;
    
    private string _anchorName = "ANCHOR";

    [SerializeField] private Material _materialAnchor;
    [SerializeField]
    private Material _materialImage;


    private ARTrackable _trackable;
    
    private bool _imageTracked;


    [SerializeField]
    private GameObject _objectPrefab;
    
    // Start is called before the first frame update
    void Start() {
        AnchorManager.anchorsChanged += args => {
            Debug.Log("anchors changed: " + args.added);
            foreach (ARAnchor anchor in args.added) {
                if (anchor.gameObject.name.Equals(_anchorName)) {
                    _sceneAnchor = anchor;
                    Debug.Log("Scene anchor found");
                    
                    
                    GameObject cubeMarker = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cubeMarker.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    cubeMarker.transform.parent = _sceneAnchor.transform;
                    cubeMarker.transform.localPosition = Vector3.zero;
                    cubeMarker.GetComponent<Renderer>().material = _materialAnchor;
                }
            }
        };



        TrackedImageManager.trackedImagesChanged += changed => {
            foreach (var newImage in changed.added)
            {
                Debug.Log("Image added: "+newImage.referenceImage.name);
              
               
            }

            foreach (var updatedImage in changed.updated)
            {
           //     Debug.Log("Image updated: "+updatedImage.referenceImage.name);

           if (updatedImage.trackingState.Equals(TrackingState.Tracking) && !_imageTracked) {
               GameObject cubeMarker = GameObject.CreatePrimitive(PrimitiveType.Cube);
               cubeMarker.transform.localScale = new Vector3(updatedImage.size.x, 0.1f, updatedImage.size.y);
               cubeMarker.transform.parent = updatedImage.transform;
               cubeMarker.transform.localPosition = Vector3.zero;
               cubeMarker.GetComponent<Renderer>().material = _materialImage;
               // cubeMarker.AddComponent<ARAnchor>();
               //  cubeMarker.name = _anchorName;
               _trackable = updatedImage;
               //GameObject anchor = new GameObject();
               //anchor.transform.position = updatedImage.transform.position;
               //anchor.name = _anchorName;
              // anchor.AddComponent<ARAnchor>();
               _debugText.SetText("Image FOund");
               _imageTracked = true;
           }
           
           
            }

            foreach (var removedImage in changed.removed)
            {
                Debug.Log("Image removed: "+removedImage.referenceImage.name);
            }
        };
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddObject(GameObject obj) {
        obj.transform.parent = _sceneAnchor.transform;
      // obj.transform.parent = _trackable.transform;
       // obj.transform.localPosition = Vector3.zero;
       //    obj.AddComponent<ARAnchor>();
       //  GameObject cubeMarker = GameObject.CreatePrimitive(PrimitiveType.Cube);
       //  cubeMarker.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
       // cubeMarker.transform.parent = obj.transform;
       //cubeMarker.transform.localPosition = obj.transform.localPosition;

    }

    public void CreatePrefabObject() {
        Debug.Log("Create prefab");
        Vector3 camPos = Camera.main.transform.position + Camera.main.transform.forward * 10f;

        GameObject instantiate = Instantiate(_objectPrefab, camPos, Quaternion.identity);
        instantiate.transform.parent = _sceneAnchor.transform;
        instantiate.transform.forward = Camera.main.transform.forward;
        instantiate.transform.Rotate(new Vector3(-90, 180, 0));
        
    }


    public void CreateAnchor() {
        Debug.Log("Add Anchor");
        GameObject anchor = new GameObject();
        anchor.transform.position = Camera.main.transform.position;
        anchor.name = _anchorName;
       anchor.AddComponent<ARAnchor>();
       // AnchorManager.gameObject.AddComponent<ARAnchor>();

  
       ;
       
       
       
    }
}
