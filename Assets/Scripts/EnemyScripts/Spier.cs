using UnityEngine;
using System.Collections;

public class Spier : MonoBehaviour
{
    public Transform SpierCube;
    public Transform SpierCollision;
    public Light SpierLight;

    public LayerMask PlayerLayer;

    private Animator SpierAnimator;

    private bool foundPlayer;

    // Use this for initialization
    void Start()
    {
        SpierAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Linecast(SpierCube.position, SpierCollision.position, PlayerLayer.value))
        {
            SpierAnimator.SetBool("Idle", true);
            SpierCube.rotation.SetLookRotation(FindObjectOfType<CubertController>().gameObject.transform.position);
            SpierLight.color = Color.red;
        }
        else
        {
            //SpierAnimator.Play(Animator.StringToHash("")
            SpierLight.color = Color.white;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(SpierCube.position, SpierCollision.position);
    }
}
