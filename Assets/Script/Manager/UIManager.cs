using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header(" Element")]
    // Start is called before the first frame update
    [SerializeField] private Button playButton;
    void Start()
    {

    }
    private void OnEnable()
    {
        playButton.onClick.AddListener(PlayButtonPressed);
    }
    private void OnDisable()
    {
        playButton.onClick.RemoveListener(PlayButtonPressed);
    }

    // Update is called once per frame
    public void PlayButtonPressed()
    {
        GameManager.instance.SetGameState(GameManager.GameState.Game);
    }
}
