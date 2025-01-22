using UnityEngine;

public class Target : MonoBehaviour
{
    public bool IsTarget { get; private set; }
    private void Start()
    {
        IsTarget = false;
    }
    public void SetTarget()
    {
        IsTarget = true;
    }
}
