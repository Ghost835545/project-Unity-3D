using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[RequireComponent(typeof(Camera))]
public class SnapshotCamera : MonoBehaviour
{
    Camera snapCam;

    int resWidth = 256;
    int resHeight = 256;

    void Awake()
    {
        snapCam = GetComponent<Camera>();
        //проверка, задана ли целевая текстура
        if (snapCam.targetTexture == null)
        {
            snapCam.targetTexture = new RenderTexture(resWidth, resHeight, 24);
        }
        else
        {
            resWidth = snapCam.targetTexture.width;
            resHeight = snapCam.targetTexture.height;
        }
        snapCam.gameObject.SetActive(false); 
    }
 
 
   public void CallTakeSnapshot()
    {
        snapCam.gameObject.SetActive(true);
    }
    void LateUpdate()
    {
        if (snapCam.gameObject.activeInHierarchy)
        {
            Texture2D snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            snapCam.Render();
            RenderTexture.active = snapCam.targetTexture;
            snapshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            byte[] bytes = snapshot.EncodeToPNG();
            string fileName = SnapshotName();
            string dir = Application.dataPath + "/Screenshots";
            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                    File.WriteAllBytes(fileName, bytes);
                }
                else {
                    File.WriteAllBytes(fileName, bytes);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            snapCam.gameObject.SetActive(false);
        }    
    }
    //Установка формата названия снимков
    string SnapshotName()
    {
        return string.Format("{0}/Screenshots/snap_{1}x{2}_{3}.png",
            Application.dataPath,
            resWidth,
            resHeight,
            DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }
}
