using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header(" Element")]
    // Start is called before the first frame update
    [SerializeField] private Button playButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject nextLevelPanel;

    private void OnEnable()
    {
        playButton.onClick.AddListener(PlayButtonPressed);
        retryButton.onClick.AddListener(RetryButtonPressed);
        nextButton.onClick.AddListener(NextButtonPressed);
        GameManager.onGameStateChanged += OnGameStateChanged;
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
