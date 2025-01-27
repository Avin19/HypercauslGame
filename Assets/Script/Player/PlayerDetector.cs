using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private CrowdSystem crowdSystem;
    private void Update()
    {
        PlayerDetected();
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
                door.Disable();

            }


            if (colliders[i].tag == "FinishLine")
            {
                GameManager.instance.SetGameState(GameState.LevelCompleted);
            }
        }
    }
}

