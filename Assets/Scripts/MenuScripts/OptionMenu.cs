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

    [SerializeField] private Image onOffMusicImage;
    [SerializeField] private Image onOffSfxImage;
    [SerializeField] private Sprite audioOn, audioOff;

    public void GetBacktoMain()
    {
        MenuGui.SetActive(true);
        OptionGui.SetActive(false);
        CreditsGui.SetActive(false);
        RewardGui.SetActive(false);
    }

    public void DisableMusic()
    {
        if (onOffMusicImage.sprite == audioOn)
            onOffMusicImage.sprite = audioOff;
        else
            onOffMusicImage.sprite = audioOn;

        AudioManager.Instance.OffMusic = !AudioManager.Instance.OffMusic;
    } 

    public void DisableSFX()
    {
        if (onOffSfxImage.sprite == audioOn)
            onOffSfxImage.sprite = audioOff;
        else
            onOffSfxImage.sprite = audioOn;

        AudioManager.Instance.OffSfx = !AudioManager.Instance.OffSfx;
    }

    public void DisableFullScreen()
    {


    }

}
