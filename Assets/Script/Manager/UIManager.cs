using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Button")]
    // Start is called before the first frame update

    [SerializeField] private Button playButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button purchaseButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button closeSettingButton;

    [Header("Panel")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject nextLevelPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject settingpanel;

    [SerializeField] private ShopManager shopManager;



    private void OnEnable()
    {
        playButton.onClick.AddListener(PlayButtonPressed);
        retryButton.onClick.AddListener(RetryButtonPressed);
        nextButton.onClick.AddListener(NextButtonPressed);
        purchaseButton.onClick.AddListener(PurchaseButtonPressed);
        settingButton.onClick.AddListener(SettingButtonPressed);
        backButton.onClick.AddListener(BackButtonPressed);
        shopButton.onClick.AddListener(ShopButtonPressed);
        closeSettingButton.onClick.AddListener(CloseButtonPressed);
        GameManager.onGameStateChanged += OnGameStateChanged;
    }

    private void CloseButtonPressed()
    {

        //Setting close button 
        settingpanel.SetActive(false);
        settingButton.gameObject.SetActive(true);

        // Game State to Pause 
    }

    private void ShopButtonPressed()
    {

        //Shop Button Press 
        settingButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
        shopPanel.SetActive(true);
    }

    private void BackButtonPressed()
    {

        settingButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);

        shopPanel.SetActive(false);

    }

    private void SettingButtonPressed()
    {
        settingButton.gameObject.SetActive(false);

        settingpanel.SetActive(true);
    }

    private void PurchaseButtonPressed()
    {
        shopManager.PurchaseSkin();
    }

    private void NextButtonPressed()
    {
        nextLevelPanel.SetActive(false);
        GameManager.instance.SetGameLevel(GameManager.instance.GetGameLevel() + 1);
    }

    private void Start()
    {
        menuPanel.SetActive(true);
    }

    private void OnGameStateChanged(GameState state)
    {
        if (state == GameState.GameOver)
        {
            gamePanel.SetActive(true);
        }
        if (state == GameState.LevelCompleted)
        {
            nextLevelPanel.SetActive(true);
        }

    }

    private void RetryButtonPressed()
    {
        SoundManager.instance.PlayButton();
        SceneManager.LoadScene(0);
        GameManager.instance.SetGameState(GameState.Game);

    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(PlayButtonPressed);
        retryButton.onClick.RemoveListener(RetryButtonPressed);
        nextButton.onClick.RemoveListener(NextButtonPressed);
        purchaseButton.onClick.RemoveListener(PurchaseButtonPressed);
        settingButton.onClick.RemoveListener(SettingButtonPressed);
        backButton.onClick.RemoveListener(BackButtonPressed);
        shopButton.onClick.RemoveListener(ShopButtonPressed);
        closeSettingButton.onClick.RemoveListener(CloseButtonPressed);
        GameManager.onGameStateChanged -= OnGameStateChanged;
    }

    // Update is called once per frame
    public void PlayButtonPressed()
    {
        SoundManager.instance.PlayButton();
        GameManager.instance.SetGameState(GameState.Game);
        menuPanel.SetActive(false);

    }


}
