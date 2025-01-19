using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private void Update()
    {
        PlayerDetected();
    }

    private void PlayerDetected()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.2f);

        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].TryGetComponent(out Door door);
            // float doorAmount = door.GetDoorAmount(transform.position.x);
            // BouseType bouseType = door.GetBouseType(transform.position.x);

            Debug.Log("Hit a door");
        }
    }
}
