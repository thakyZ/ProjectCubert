using UnityEngine;
using System.Collections;

public class CubertController : MonoBehaviour {

    public GameObject cubert;

    //Allows player to jump
    public float JumpForce = 20;
    public float jumpDuration = .1f;
    float jmpDuration;
    float jmpForce;
    bool JumpKey;
    Rigidbody2D rig2d;
    //Checks if player is on the ground
    public bool onGround;

    float flip = 1;
    float ups;
    float sides;

    void Start ()
    {
        jmpForce = JumpForce;
    }
	
    void Update ()
    {

        //Debug.Log("JumpKey: " + JumpKey + " OnGround: " + onGround);
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        JumpKey = false;

        var MousePosition = Input.mousePosition;
        var PlayerPosition = Camera.main.WorldToScreenPoint(transform.position);
        

        #region ups
        //Creates a float based on the displacement between the player and the mouses y positions. Used for launching the player upwards
        ups = (MousePosition.y / 10) - PlayerPosition.y / 10;

        if (ups > 9)
        {
            ups = 9;
        }

        if (ups < 1)
        {
            ups = 0.5f;
        }
        #endregion

        #region sides
        //similar to the ups float. Find difference in x between the players and mouses x position.
        
        if (MousePosition.x < PlayerPosition.x)
        {
            sides = Mathf.Abs((MousePosition.x / 6) - PlayerPosition.x / 6);
        }
        else if (MousePosition.x > PlayerPosition.x)
        {
            sides = (MousePosition.x / 6) - PlayerPosition.x / 6;
        }

        if (sides > 7)
        {
            sides = 7;
        }
        if (sides < 0.5)
        {
            sides = 0;
        }
        #endregion

        #region flip
        //Checks the mouses position versus the player, so we can use flip to decide which direction we launch the player
        if (MousePosition.x < PlayerPosition.x)
        {
            flip = -1;
        }
        else if (MousePosition.x > PlayerPosition.x)
        {
            flip = 1;
        }
        #endregion

        #region jump
        //Launches the player based on a left mouse click.
        if (Input.GetButtonDown("Fire1") && onGround)
        {
            Debug.Log("playx: " + PlayerPosition.x + " playy: " + PlayerPosition.y + " mousex: " + Input.mousePosition.x + " mousey: " + Input.mousePosition.y + " ups: " + ups + " sides: " + sides);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray))
            {
                if (!JumpKey)
                {
                    jmpDuration += Time.deltaTime;
                    jmpForce += Time.deltaTime;

                    if (jmpDuration < jumpDuration)
                    {
                        cubert.GetComponent<Rigidbody2D>().velocity = new Vector2(sides * flip, ups); //Uses sides and ups to launch player
                        onGround = false;
                        JumpKey = true;
                    }
                    else
                    {
                        JumpKey = true;
                        // Debug.Log("Shit...");
                    }
                }
                //Instantiate(cubert, transform.position, transform.rotation);
            }
        }
        #endregion
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "NormalWall")
        {
            onGround = true;
            
            JumpKey = false;
            jmpDuration = 0;
            jmpForce = JumpForce;

            //Debug.Log("OnGround");
        }
    }
}
