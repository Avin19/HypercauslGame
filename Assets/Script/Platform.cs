
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform pfPlatform;

    private void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(pfPlatform, new Vector3(0f, 0f, i * 50), Quaternion.identity, transform.parent);
        }
    }
}
