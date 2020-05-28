using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuListener : MonoBehaviour
{
    public Button btn_Add_Model;
    // Start is called before the first frame update
    void Start()
    {
        btn_Add_Model.onClick.AddListener(toAddScene);
    }

    void toAddScene(){
        SceneManager.LoadScene("mainScene");
    }

}
