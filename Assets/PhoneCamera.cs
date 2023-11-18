using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhoneCamera : MonoBehaviour
{
    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;




      

    // Start is called before the first frame update
    void Start()
    {
        
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if(devices.Length==0)
        {
            Debug.Log("No camera detected");
            camAvailable = false;
            return;
        }        

        for (int i = 0; i<devices.Length; i++)
        {
            if(devices[i].isFrontFacing){
                backCam = new WebCamTexture(devices[i].name,Screen.width,Screen.height);
                break;
            }
        }

        if(backCam == null)
        {
            Debug.Log("Unable to find back camera");
            return;
        }
        backCam.Play();
        background.texture = backCam;

        camAvailable = true;
        StartCoroutine(Waiter());

    }

    IEnumerator Waiter(){

        yield return new WaitForSecondsRealtime(10);
        yield return new WaitForEndOfFrame();
/*
        Texture2D foto = ScreenCapture.CaptureScreenshotAsTexture();
        //foto = Resize(foto, 1080, 1920);
        byte[] bytesImagen = foto.EncodeToPNG(); 
                // Define la ruta de almacenamiento en el dispositivo (puedes cambiarla según tus necesidades)
        string rutaDeAlmacenamiento = Application.persistentDataPath + "/CapturaDePantalla.png";
        // Escribe los bytes en un archivo en la ruta especificada
        System.IO.File.WriteAllBytes(rutaDeAlmacenamiento, bytesImagen);
        // Imprime un mensaje indicando la ruta de almacenamiento
        //Debug.Log("Imagen guardada en: " + rutaDeAlmacenamiento);
*/      
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

        yield return new WaitForSecondsRealtime(10);
        SceneManager.LoadScene(0);


    }


    // Update is called once per frame
    void Update()
    {
        if(!camAvailable){
            return;
        }

        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;

        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3 (1f,scaleY,1f);

        int orient = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0,0, orient);



    }
}
