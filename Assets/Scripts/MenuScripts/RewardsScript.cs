using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardsScript : MonoBehaviour
{
    [SerializeField] private Image[] rewardsIcons;
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color defaultColor;

    private void Start()
    {
        int index = PlayerPrefs.GetInt("Character");
        Debug.Log(index);
        rewardsIcons[index].color = selectedColor;

        for (int i = 0; i < rewardsIcons.Length; i++)
        {
            if (i != index)
                rewardsIcons[i].color = defaultColor;
        }
    }

    public void UnlockCharacter(int pointsToUnlock)
    {
        if(PlayerPrefs.GetInt("HighScore") >= pointsToUnlock)
        {
            for (int i = 0; i < rewardsIcons.Length; i++)
            {
                    rewardsIcons[i].color = defaultColor;
            }
            //rewardsIcons[characterIndex].color = selectedColor;
        }
    }
}
