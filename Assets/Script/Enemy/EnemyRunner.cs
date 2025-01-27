using UnityEngine;

public enum EnemyState
{
    Idle,
    Running
}
public class EnemyRunner : MonoBehaviour
{
    [Header(" Element")]
    [SerializeField] private Animator animator;
    [Header(" Setting")]
    [SerializeField] private float searchRadius;
    [SerializeField] private float moveSpeed;

    private EnemyState state;



    private Transform targetRunner;

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        switch (state)
        {
            case EnemyState.Idle:
                SearchForTarget();
                break;
            case EnemyState.Running:
                RunTowardTarget();
                break;
        }
    }

    private void RunTowardTarget()
    {
        if (targetRunner == null)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetRunner.position, Time.deltaTime * moveSpeed);
        // Enemy will look at the player
        //transform.rotation = Quaternion.LookRotation(targetRunner.position);

        if (Vector3.Distance(transform.position, targetRunner.position) < 0.5f)
        {

            Destroy(targetRunner.gameObject);

            Destroy(gameObject);
        }
    }

    private void SearchForTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, searchRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Target runner))
            {
                if (runner.IsTarget)
                {
                    continue;
                }
                runner.SetTarget();
                targetRunner = runner.GetComponent<Transform>();
                StartRunningTowardsTarget();
            }
        }
    }

    private void StartRunningTowardsTarget()
    {
        state = EnemyState.Running;
        animator.SetBool("isRunning", true);
    }
}
