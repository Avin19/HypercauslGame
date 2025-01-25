
using UnityEngine;
using System;
using Codice.Client.Common;
public enum GameState
{
    Menu,
    Game,
    LevelCompleted,
    GameOver
}
namespace HyperCausal.Manager
{

    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public static Action<GameState> onGameStateChanged;
        [SerializeField] private int gameLevel;
        [SerializeField] private Levels levels;
        private LevelsDesign currentlevel;
        private PlatformGenerator platformGenerator;
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

        void Start()
        {

            SettingUpLevel();
            platformGenerator = new PlatformGenerator();
            platformGenerator.SetLevel(currentlevel, environmentTransform);

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
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetGameState(GameState state)
        {
            gameState = state;
            onGameStateChanged?.Invoke(gameState);
            Debug.Log("GameState : " + gameState);

        }
    }
}
