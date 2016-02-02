using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour {

    public GameObject cubert;
	
	// Update is called once per frame
	void Update ()
    {

        var MousePosition = Input.mousePosition;
        var PlayerPosition = Camera.main.WorldToScreenPoint(transform.position);
        transform.LookAt(MousePosition - PlayerPosition);

    }
}
