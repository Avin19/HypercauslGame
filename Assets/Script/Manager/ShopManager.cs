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
    }

    private void ConfigureButton()
    {
        for (int i = 0; i < skinButtons.Length; i++)
        {
            skinButtons[i].Configure(skinArray[i], true);
            int skinIndex = i;
            skinButtons[i].GetButton().onClick.AddListener(() => SelectSkin(skinIndex));
        }
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


