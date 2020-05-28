using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


public class ChangeLighting : MonoBehaviour
{
    public Light customLight;
    public Slider intSlider;
    public Text valueIntesity;

    public InputField pX;
    public InputField pY;
    public InputField pZ;

    public InputField rX;
    public InputField rY;
    public InputField rZ;

    public GameObject settingPanel;





    public void Slider_Changed(float newValue)
    {
        valueIntesity.text = newValue.ToString();
        customLight.intensity = newValue;
    }

    //Изменение позиции света
    public void LightPosition_Changed()
    {

        if (pX.text == "")
        {
            pX.text = "0";
        }
        if (pY.text == "")
        {
            pY.text = "0";
        }
        if (pZ.text == "")
        {
            pZ.text = "0";
        }
        float fpX = float.Parse(pX.text, CultureInfo.InvariantCulture);
        float fpY = float.Parse(pY.text, CultureInfo.InvariantCulture);
        float fpZ = float.Parse(pZ.text, CultureInfo.InvariantCulture);

        customLight.gameObject.transform.position = new Vector3(fpX, fpY, fpZ);
    }
    //Изменение поворота света
    public void LightRotation_Changed()
    {
        if (rX.text == "")
        {
            rX.text ="0";
        }
        if (rY.text == "")
        {
            rY.text = "0";
        }
        if (rZ.text == "")
        {
            rZ.text = "0";
        }
        float frX = float.Parse(rX.text, CultureInfo.InvariantCulture);
        float frY = float.Parse(rY.text, CultureInfo.InvariantCulture);
        float frZ = float.Parse(rZ.text, CultureInfo.InvariantCulture);

        customLight.gameObject.transform.Rotate(frX, frY, frZ);
    }
    public void QuitApplication()
    {
        #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    void Start()
    {
        pX.text = customLight.gameObject.transform.position.x.ToString();
        pY.text = customLight.gameObject.transform.position.y.ToString();
        pZ.text = customLight.gameObject.transform.position.z.ToString();

        rX.text = customLight.gameObject.transform.eulerAngles.x.ToString();
        rY.text = customLight.gameObject.transform.eulerAngles.y.ToString();
        rZ.text = customLight.gameObject.transform.eulerAngles.z.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {

            settingPanel.SetActive(true);
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            Cursor.lockState = CursorLockMode.Confined;

        }

    }
}
