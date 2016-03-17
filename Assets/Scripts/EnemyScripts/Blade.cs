using UnityEngine;

public class Blade : MonoBehaviour
{

    GameObject cubert;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.forward * Time.deltaTime * 100);
    }
}
