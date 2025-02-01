

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header(" Element")]
    // Start is called before the first frame update
    [SerializeField] private Button playButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;

    private void Start()
    {
        menuPanel.SetActive(true);
    }
    private void OnEnable()
    {
        playButton.onClick.AddListener(PlayButtonPressed);
        retryButton.onClick.AddListener(RetryButtonPressed);
        GameManager.onGameStateChanged += OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState state)
    {
        if (state == GameState.GameOver)
        {
            gamePanel.SetActive(true);
        }

    }

    private void RetryButtonPressed()
    {
        SceneManager.LoadScene(0);
        GameManager.instance.SetGameState(GameState.Game);
        menuPanel.SetActive(false);

    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(PlayButtonPressed);
        retryButton.onClick.RemoveListener(RetryButtonPressed);
    }

    // Update is called once per frame
    public void PlayButtonPressed()
    {
        GameManager.instance.SetGameState(GameState.Game);
        menuPanel.SetActive(false);

    }
}
