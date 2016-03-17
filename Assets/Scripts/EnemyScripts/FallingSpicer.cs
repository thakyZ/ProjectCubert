using UnityEngine;
using System.Collections;

public class FallingSpicer : MonoBehaviour {

    //used to find rotation tranform and manipulate p.system respectively
    public Transform body;
    public GameObject spitter;
	
	// Update is called once per frame
	void Update ()
    {
        var em = spitter.GetComponent<ParticleSystem>().emission;

        if (body.rotation.eulerAngles.z > 4 && body.rotation.eulerAngles.z < 90 || body.rotation.eulerAngles.z < 354 && body.rotation.eulerAngles.z > 270)
        {
            //Debug.Log("The heckity heck");
            em.enabled = false;
        }
    }
}
