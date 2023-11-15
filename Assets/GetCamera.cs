using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCamera : MonoBehaviour
{
    WebCamTexture webCamTexture;
    public string path;
    public RawImage imgDisplayForPhotoSnap;



    // Start is called before the first frame update
    void Start()
    {
        webCamTexture = new WebCamTexture();
        GetComponent<Renderer>().material.mainTexture = webCamTexture;
        webCamTexture.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
