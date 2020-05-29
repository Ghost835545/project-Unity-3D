using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapshot : MonoBehaviour
{
    private static Snapshot instance;

    private Camera myCamera;
    private bool takeScreenshotOnNetFrame;
    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();

    }

    private void OnPostRender()
    {
        if (takeScreenshotOnNetFrame)
        {
            takeScreenshotOnNetFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/CameraScreens.png",byteArray);
            Debug.Log("Saved Screen");

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;

        }
    }

    private void TakeScreenshot(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height,24);
        takeScreenshotOnNetFrame = true; 

    }
    public static void TakeScreenshot_Static(int width, int height)
    {
        instance.TakeScreenshot(width, height);
    }
}
