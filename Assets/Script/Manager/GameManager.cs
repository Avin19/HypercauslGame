
using UnityEngine;
using System;
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

        private GameState gameState;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(instance);
            }
            else
            {
                instance = this;
            }
        }
        void Start()
        {

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
