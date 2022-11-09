using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject MenuGui;
    [SerializeField]
    public GameObject OptionMenu;
    [SerializeField]
    public GameObject ShopMenu; 

    public void PlayGame()
    {
      SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    
    public void Option()
    {
        MenuGui.SetActive(false); 
        OptionMenu.SetActive(true);
    }

    public void Shop()
    {
        MenuGui.SetActive(false);
        OptionMenu.SetActive(false);
        ShopMenu.SetActive(true);
    }


    public void Credits()
    {
        Debug.Log("ciao");
    }


    public void QuitGame()
    {
        Debug.Log("ciao");
    }

    void Start()
    {
        OptionMenu.SetActive(false);
        ShopMenu.SetActive(false); 
    }


}
