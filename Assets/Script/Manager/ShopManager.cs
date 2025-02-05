using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Shop Manager Working on the Coin 
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
    private void UnlockSkin(SkinButton _skinButton)
    {
        int _skinIndex = _skinButton.transform.GetSiblingIndex();
        UnlockSkin(_skinIndex);
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
    public void PurchaseSkin()
    {
        List<SkinButton> skinButtonsList = new List<SkinButton>();
        for (int i = 0; i < skinButtons.Length; i++)
        {
            if (!skinButtons[i].IsUnlocked())
            {
                skinButtonsList.Add(skinButtons[i]);
            }
        }
        if (skinButtonsList.Count <= 0)
        {
            return;
        }
        // At this point we still have some locked skins
        // And we have a list of all of them !!!


        SkinButton randomSkinButton = skinButtonsList[Random.Range(0, skinButtonsList.Count)];
        UnlockSkin(randomSkinButton);
        SelectSkin(randomSkinButton.transform.GetSiblingIndex());
    }

}


