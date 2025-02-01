using System;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float slideSpeed = 2f;
    private float inputY;
    public event EventHandler<string> PlayerAnimatorPerformAnimation;
    public event EventHandler<string> PlayerAnimatorStopAnimation;



    public static PlayerController Instance { get; private set; }

    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPsotion;
    private bool canMove;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;

    }
    private void OnEnable() => GameManager.onGameStateChanged += GameStateChangeCallback;

    private void GameStateChangeCallback(GameState state)
    {
        // Animation triggers are bad here need to imporve this !!!!
        switch (state)
        {
            case GameState.LevelCompleted:
                StopMoving();
                PlayerAnimatorPerformAnimation?.Invoke(this, "IsVictory");
                PlayerAnimatorStopAnimation?.Invoke(this, "isRunning");
                break;
            case GameState.Game:
                PlayerAnimatorStopAnimation?.Invoke(this, "IsVictory");
                PlayerAnimatorPerformAnimation?.Invoke(this, "isRunning");
                StartMoving();
                break;
            case GameState.Menu:
                break;
        }
        if (state == GameState.Game)
        {
            StartMoving();

        }
        else
        {
            StopMoving();
        }
    }
    private void StartMoving()
    {
        canMove = true;



    }
    private void StopMoving()
    {
        canMove = false;
        PlayerAnimatorStopAnimation?.Invoke(this, "isRunning");
    }
    private void Update()
    {
        if (canMove)
        {
            PlayerAnimatorPerformAnimation?.Invoke(this, "isRunning");
            inputY = Input.GetAxisRaw("Horizontal");
            Movement();
            ManageControl();
        }
    }
    private void Movement()
    {


        Vector3 moveDir = new Vector3(inputY, 0f, 1f).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;


    }
    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // when the screen is touched storing the mouse and player position 
            clickedPlayerPsotion = transform.position;
            clickedScreenPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            // When the player is pressing the screen

            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;
            xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;
            // Now that we have the difference between the clicked position and the actual position of the screen 

            // making the z position indpenedent of these changes . The changes are implemented on the x axis so . the player wont run on the spot . 
            Vector3 position = transform.position;
            position.x = clickedPlayerPsotion.x + xScreenDifference;
            transform.position = position;


            // transform.position = clickedPlayerPsotion + Vector3.right * xScreenDifference;

        }
    }
}
