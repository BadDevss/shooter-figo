using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject MenuGui;

    [SerializeField]
    private GameObject OptionGui;



    public void GetBacktoMain()
    {
        MenuGui.SetActive(true);
        OptionGui.SetActive(false); 
    }

    public void DisableMusic()
    {


    } 

    public void DisableFullScreen()
    {


    }

}
