using System.Collections;
using System.IO;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Screenshot()
    {

        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        string name = "PhotoPals_Screenshot " + System.DateTime.Now.ToString("dd-MM-yyyy_ss-mm-HH") + ".png";

        //PC
        //byte[] bytes = texture.EncodeToPNG();
        //File.WriteAllBytes(name, bytes);

        //MOBILE
        NativeGallery.SaveImageToGallery(texture,"Myapp pictures", name);


        Destroy(texture);

    }

    public void TakeScreenshot()
    {

        StartCoroutine("Screenshot");
    }
}

