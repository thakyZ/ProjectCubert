using UnityEngine;

public class Spider : MonoBehaviour
{
    public GameObject legs;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(legs.transform.position, Vector3.forward, 5);
        transform.Rotate(-Vector3.forward * 5);
    }
}
