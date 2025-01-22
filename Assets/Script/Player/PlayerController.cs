using System;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float slideSpeed = 2f;
    private float inputY;
    public event EventHandler<string> PlayerAnimator;
    public event EventHandler<string> IdleAnimation;

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
    private void OnEnable() => HyperCausal.Manager.GameManager.onGameStateChanged += GameStateChangeCallback;

    private void GameStateChangeCallback(GameState state)
    {
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
        PlayerAnimator?.Invoke(this, "isRunning");


    }
    private void StopMoving()
    {
        canMove = false;
        IdleAnimation?.Invoke(this, "isRunning");
    }
    private void Update()
    {
        if (canMove)
        {

            inputY = Input.GetAxisRaw("Horizontal");
            Movement();
            ManageControl();
        }
    }
    private void Movement()
    {

        PlayerAnimator?.Invoke(this, "isRunning");
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
