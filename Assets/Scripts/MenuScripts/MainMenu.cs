using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuGui;
    [SerializeField]
    public GameObject OptionGui;
    [SerializeField]
    private GameObject RewardGui;
    [SerializeField]
    private GameObject CreditsGui;
    [SerializeField]
    private GameObject BackgroundCanvas; 

    [SerializeField]
    public AudioSource EngineSound; 
    [SerializeField]
    private GameObject ActorPrefab;
    [SerializeField]
    private Camera MainActorCamera;

    Vector3 ActorPosition = new Vector3(0, 0, -15); 

    public SpriteRenderer rendbg1;
    public SpriteRenderer rendbg2;


    public void ChangeScene()
    {
        SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
    }

    public void PlayGame()
    {
        MenuGui.SetActive(false);
        OptionGui.SetActive(false);
        RewardGui.SetActive(false);
        BackgroundCanvas.SetActive(false);
        rendbg1.enabled = true;
        rendbg2.enabled = true;
        Instantiate(ActorPrefab, ActorPosition, Quaternion.identity);
        //EngineSound.Play();
        Invoke("ChangeScene", 5f); 
 

    }
    
    public void Option()
    {
        MenuGui.SetActive(false); 
        OptionGui.SetActive(true);
    }

    public void Shop()
    {
        MenuGui.SetActive(false);
        OptionGui.SetActive(false);
        RewardGui.SetActive(true);
    }


    public void Credits()
    {
        MenuGui.SetActive(false);
        OptionGui.SetActive(false);
        RewardGui.SetActive(false);
        CreditsGui.SetActive(true);

    }


    public void QuitGame()
    {
        Application.Quit(); 
    }

    void Start()
    {
        rendbg1.enabled = false;
        rendbg2.enabled = false;
        CreditsGui.SetActive(false);
        OptionGui.SetActive(false);
        RewardGui.SetActive(false);

    }
}
