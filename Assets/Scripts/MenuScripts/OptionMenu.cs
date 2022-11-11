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
    [SerializeField]
    private GameObject CreditsGui;
    [SerializeField]
    private GameObject RewardGui;

    public void GetBacktoMain()
    {
        MenuGui.SetActive(true);
        OptionGui.SetActive(false);
        CreditsGui.SetActive(false);
        RewardGui.SetActive(false);
    }

    public void DisableMusic()
    {


    } 

    public void DisableFullScreen()
    {


    }

}
