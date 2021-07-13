using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ImageLoader : MonoBehaviour {

    public SceneManager SceneManager;


    public Material Material;
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }


    public void SelectImage() {
        Debug.Log("Open image");
     //   NativeGallery.GetImageFromGallery(MediaPickCallback callback, string title = "", string mime = "image/*");
     NativeGallery.Permission permission = NativeGallery.GetImageFromGallery(path => { Debug.Log("Image loaded " + path); LoadImage(path); }, "", "image/*");
     Debug.Log("permission: "+permission);
    }
    

    private void LoadImage(string path) {
       
        if (path != null) {
            Texture2D texture = NativeGallery.LoadImageAtPath(path, -1, false, false, false);
            //Debug.Log("Loaded image: "+t.name);
           
          //Texture2D texture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
          //  texture.SetPixels(t.GetPixels());   
          //  texture.Apply();
            if(texture == null )
            {
                Debug.Log( "Couldn't load texture from " + path );
                return;
            }

            // Assign texture to a temporary quad and destroy it after 5 seconds
            GameObject quad = GameObject.CreatePrimitive( PrimitiveType.Quad );
            quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
            quad.transform.forward = Camera.main.transform.forward;
            quad.transform.localScale = new Vector3( 1f, texture.height / (float) texture.width, 1f );
            quad.name = "img_"+texture.name;
            quad.AddComponent<Image>();
            
           /* Material m   = new Material(Shader.Find("Standard"));
            m.SetOverrideTag("RenderType", "Cutout");
            m.SetFloat("_Mode", 2);
            m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            m.SetInt("_ZWrite", 0);
            m.DisableKeyword("_ALPHATEST_ON");
            m.EnableKeyword("_ALPHABLEND_ON");
            m.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            m.renderQueue = 3000;
            */
          Material m = Material;
            
            
            //Material material = quad.GetComponent<Renderer>().material;
            if( !m.shader.isSupported ) {// happens when Standard shader is not included in the build
                Debug.Log("Shader error");
              //  m.shader = Shader.Find( "Legacy Shaders/Diffuse" );
            } 
            m.mainTexture = texture;
            quad.GetComponent<Renderer>().material = m;

            SceneManager.AddObject(quad);
            
           // Destroy( quad, 5f );

            // If a procedural texture is not destroyed manually, 
            // it will only be freed after a scene change
           // Destroy( texture, 5f );
        }
        
    }
}