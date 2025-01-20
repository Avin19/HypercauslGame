
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform pfPlatform;
    [SerializeField] private Transform pfFinishLine;

    private void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i >= 9)
            {
                Transform pf = Instantiate(pfFinishLine, new Vector3(0f, 0f, i * 50), Quaternion.identity, transform.parent);
            }
            else
            {

                Transform pf = Instantiate(pfPlatform, new Vector3(0f, 0f, i * 50), Quaternion.identity, transform.parent);
                pf.GetComponent<Door>().Trigger();

            }
        }
    }
}
