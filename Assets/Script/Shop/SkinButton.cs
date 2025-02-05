using System;
using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour
{

    [Header("Element")]
    [SerializeField] private Button skinButton;
    [SerializeField] private Image skinImage;
    [SerializeField] private GameObject lockImage;
    [SerializeField] private GameObject selector;
    private bool unlocked;

    public void Configure(Sprite skinSprite, bool _unlocked)
    {
        skinImage.sprite = skinSprite;
        this.unlocked = _unlocked;

        if (_unlocked)
        {
            Unlocked();
        }
        else
        {
            Lock();
        }

    }
    public Button GetButton()
    {
        return skinButton;
    }
    private void Lock()
    {
        skinButton.interactable = false;
        skinImage.gameObject.SetActive(false);
        lockImage.gameObject.SetActive(true);
    }

    public void Unlocked()
    {
        skinButton.interactable = true;
        skinImage.gameObject.SetActive(true);
        lockImage.gameObject.SetActive(false);
        unlocked = true;
    }

    public void Selector()
    {
        selector.SetActive(true);
    }
    public void Deselector()
    {
        selector.SetActive(false);
    }

    public bool IsUnlocked()
    {
        return unlocked;
    }
}
