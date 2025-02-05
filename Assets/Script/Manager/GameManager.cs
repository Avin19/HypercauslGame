using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Action<GameState> onGameStateChanged;
    [SerializeField] private int gameLevel;
    [SerializeField] private Levels levels;
    private LevelsDesign currentlevel;

    [SerializeField] private Transform environmentTransform;


    private GameState gameState;

    private void Awake()
    {
        PLayerCurrentGameLevel();
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    private void PLayerCurrentGameLevel()
    {
        gameLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
    }
    public int GetGameLevel()
    {
        return gameLevel;
    }
    public void SetGameLevel(int levelNum)
    {
        gameLevel = levelNum;
        PlayerPrefs.SetInt("CurrentLevel", gameLevel);
        SceneManager.LoadScene(0);

    }
    void Start()
    {
        SettingUpLevel();
        PLayerCurrentGameLevel();

    }

    private void SettingUpLevel()
    {


        if (levels.LevelList.Capacity > gameLevel)
        {
            currentlevel = levels.LevelList[gameLevel];
        }
        else
        {
            currentlevel = levels.LevelList[0];
        }
        new PlatformGenerator(currentlevel, environmentTransform);
    }

    // Update is called once per frame
    public void SetGameState(GameState state)
    {
        gameState = state;
        onGameStateChanged?.Invoke(gameState);



    }

}

