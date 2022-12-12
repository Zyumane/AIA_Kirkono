using UnityEngine;

public class MinionBehavior : MonoBehaviour
{
    PlayerManager player;
    public float speed;
    public float stoppingDistance;

    public Transform playerTarget;
    public Transform minionPosition;
    Vector3 minionVector;

    Animator animationChara;
    CapsuleCollider capsule;

    public int minionGroup = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerManager>();
        animationChara = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Vector3.Distance(transform.position, playerTarget.position) > stoppingDistance)
        {
            minionPosition.LookAt(playerTarget.position);
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, speed / 2 * Time.deltaTime);
            minionVector.y = 0;
            animationChara.Play("Run_Fwd");
        }
        minionGroup++;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Vector3.Distance(transform.position, playerTarget.position) > stoppingDistance)
        {
            minionPosition.LookAt(playerTarget.position);
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, speed / 2 * Time.deltaTime);
            minionVector.y = 0;
            animationChara.Play("Run_Fwd");
        }
        else if (Vector3.Distance(transform.position, playerTarget.position) <= stoppingDistance)
        {
            minionPosition.LookAt(playerTarget.position);
            animationChara.Play("Idle");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        minionPosition.LookAt(playerTarget.position);
        animationChara.Play("Idle");
    }
}
