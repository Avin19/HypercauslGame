using System;
using UnityEngine;

/// <summary>
///  
/// </summary>

public class ShopManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private SkinButton[] skinButtons;
    [Header("Skin")]
    [SerializeField] private Sprite[] skinArray;
    private void Start()
    {
        ConfigureButton();
        UnlockSkin(5);
    }

    private void ConfigureButton()
    {
        for (int i = 0; i < skinButtons.Length; i++)
        {
            bool unlocked = PlayerPrefs.GetInt("skinButton" + i) == 1;
            skinButtons[i].Configure(skinArray[i], unlocked);
            int skinIndex = i;
            skinButtons[i].GetButton().onClick.AddListener(() => SelectSkin(skinIndex));
        }
    }
    public void UnlockSkin(int skinIndex)
    {
        PlayerPrefs.SetInt("skinButton" + skinIndex, 1);
        skinButtons[skinIndex].Unlocked();
    }
    private void SelectSkin(int skinIndex)
    {
        for (int i = 0; i < skinButtons.Length; i++)
        {
            if (skinIndex == i)
            {
                skinButtons[i].Selector();
            }
            else
            {
                skinButtons[i].Deselector();
            }
        }
    }

}


