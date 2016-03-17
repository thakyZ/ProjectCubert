using UnityEngine;

public class Spider : MonoBehaviour
{
    public GameObject legs;
    public GameObject body;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (body.transform.lossyScale.z > 0)
        {
            transform.RotateAround(legs.transform.position, Vector3.forward, 5);
            transform.Rotate(-Vector3.forward * 5);
        }
        if (body.transform.lossyScale.z < 0)
        {
            transform.RotateAround(legs.transform.position, -Vector3.forward, 5);
            transform.Rotate(Vector3.forward * 5);
        }
    }
}
