
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState
    {
        Menu,
        Game,
        LevelCompleted,
        GameOver
    }
    private GameState state;

    private void Awake()
    {
        if(instance !=null)
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

    }
}
