using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private CrowdSystem crowdSystem;
    private void Update()
    {
        if (transform.childCount > 0) { PlayerDetected(); }
        else
        {
            GameManager.instance.SetGameState(GameState.GameOver);
        }
    }

    private void PlayerDetected()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position + Vector3.up * 2, 1);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent(out Door door))
            {
                Debug.Log("Hit a door");

                int doorAmount = door.GetDoorAmount(transform.position.x);
                BouseType bouseType = door.GetBouseType(transform.position.x);
                crowdSystem.ApplyBonus(doorAmount, bouseType);
                SoundManager.instance.DoorSound();
                door.Disable();

            }
            if (colliders[i].TryGetComponent(out DoorPanel1 door1))
            {
                int doorAmount = door1.GetDoorAmount(transform.position.x);
                BouseType bouseType = door1.GetBouseType(transform.position.x);
                crowdSystem.ApplyBonus(doorAmount, bouseType);
                SoundManager.instance.DoorSound();
                door1.Disable();
            }


            if (colliders[i].CompareTag("FinishLine"))
            {
                GameManager.instance.SetGameState(GameState.LevelCompleted);
                SoundManager.instance.FinishLine();
            }
            if (colliders[i].CompareTag("Coin"))
            {
                int _coin = DataManager.instance.GetCoin();
                DataManager.instance.SetCoin(_coin + 1);
                Debug.Log(_coin);
                SoundManager.instance.CoinPickUp();
                Destroy(colliders[i].gameObject);
            }
        }
    }
}

