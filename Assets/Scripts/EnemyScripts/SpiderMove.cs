using UnityEngine;
using System.Collections.Generic;

public class SpiderMove : MonoBehaviour
{
    protected enum Directions
    {
        Up,
        Down,
        Left,
        Right
    }

    public Transform Linecast1;
    public Transform Linecast2;
    public Transform Linecast3;
    public Transform Linecast4;
    public Transform LinecastCorner1;
    public Transform LinecastCorner2;
    public Transform LinecastCorner3;
    public Transform LinecastCorner4;

    public Transform Body;

    public float speed;

    private Directions direction;

    private Vector2 velocity;

    private bool hitwalldown;
    private bool hitwallup;
    private bool hitwallleft;
    private bool hitwallright;

    private bool hitwallcornerupleft;
    private bool hitwallcornerupright;
    private bool hitwallcornerdownleft;
    private bool hitwallcornerdownright;

    void Start()
    {
        velocity = new Vector2(-1, 0);
        direction = Directions.Left;
    }

    void Update()
    {
        hitwalldown = Physics2D.Linecast(Linecast1.position, transform.position, 1 << LayerMask.NameToLayer("Walls"));
        hitwallup = Physics2D.Linecast(Linecast2.position, transform.position, 1 << LayerMask.NameToLayer("Walls"));
        hitwallleft = Physics2D.Linecast(Linecast3.position, transform.position, 1 << LayerMask.NameToLayer("Walls"));
        hitwallright = Physics2D.Linecast(Linecast4.position, transform.position, 1 << LayerMask.NameToLayer("Walls"));
        hitwallcornerupleft = Physics2D.Linecast(LinecastCorner1.position, transform.position, 1 << LayerMask.NameToLayer("Walls"));
        hitwallcornerupright = Physics2D.Linecast(LinecastCorner2.position, transform.position, 1 << LayerMask.NameToLayer("Walls"));
        hitwallcornerdownleft = Physics2D.Linecast(LinecastCorner3.position, transform.position, 1 << LayerMask.NameToLayer("Walls"));
        hitwallcornerdownright = Physics2D.Linecast(LinecastCorner4.position, transform.position, 1 << LayerMask.NameToLayer("Walls"));

        if (direction == Directions.Down)
        {
            if (hitwalldown && hitwallleft && !hitwallup && !hitwallright)
            {
                velocity = new Vector2(1, 0);
                direction = Directions.Right;
                Debug.Log("Down => Right (Inner Corner)");
                Body.RotateAround(transform.position, Vector3.forward, 90);
            }
            else if (hitwalldown && !hitwallleft && !hitwallup && hitwallright)
            {
                velocity = new Vector2(-1, 0);
                direction = Directions.Left;
                Debug.Log("Down => Left (Inner Corner)");
                Body.RotateAround(transform.position, Vector3.forward, -90);
            }
            else if (hitwallcornerupleft && !hitwalldown && !hitwallleft && !hitwallup && !hitwallright)
            {
                velocity = new Vector2(-1, 0);
                direction = Directions.Left;
                Debug.Log("Down => Left (Outer Corner)");
                Body.RotateAround(transform.position, Vector3.forward, -90);
            }
            else if (hitwallcornerupright && !hitwalldown && !hitwallleft && !hitwallup && !hitwallright)
            {
                velocity = new Vector2(1, 0);
                direction = Directions.Right;
                Debug.Log("Down => Right (Outer Corner)");
                Body.RotateAround(transform.position, Vector3.forward, 90);
            }
        }
        else if (direction == Directions.Left)
        {
            if (hitwalldown && hitwallleft && !hitwallup && !hitwallright)
            {
                velocity = new Vector2(0, 1);
                direction = Directions.Up;
                Debug.Log("Left => Up (Inner Corner)");
                Body.RotateAround(transform.position, Vector3.forward, -90);
            }
            else if (!hitwalldown && hitwallleft && hitwallup && !hitwallright)
            {
                velocity = new Vector2(0, -1);
                direction = Directions.Down;
                Debug.Log("Left => Down (Inner Corner)");
                Body.RotateAround(transform.position, Vector3.forward, 90);
            }
            else if (hitwallcornerupright && !hitwalldown && !hitwallleft && !hitwallup && !hitwallright)
            {
                velocity = new Vector2(0, 1);
                direction = Directions.Up;
                Debug.Log("Left => Up (Outer Corner)");
                Body.RotateAround(transform.position, Vector3.forward, -90);
            }
            else if (hitwallcornerdownright && !hitwalldown && !hitwallleft && !hitwallup && !hitwallright)
            {
                velocity = new Vector2(0, -1);
                direction = Directions.Down;
                Debug.Log("Left => Down (Outer Corner)");
                Body.RotateAround(transform.position, Vector3.forward, 90);
            }
        }
        else if (direction == Directions.Right)
        {
            if (hitwalldown && !hitwallleft && !hitwallup && hitwallright)
            {
                velocity = new Vector2(0, 1);
                direction = Directions.Up;
                Debug.Log("Right => Up (Inner Corner)");
                Body.RotateAround(transform.position, Vector3.forward, -90);
            }
            else if (!hitwalldown && !hitwallleft && hitwallup && hitwallright)
            {
                velocity = new Vector2(0, -1);
                direction = Directions.Down;
                Debug.Log("Right => Down (Inner Corner)");
                Body.RotateAround(transform.position, Vector3.forward, -90);
            }
            else if (hitwallcornerupleft && !hitwalldown && !hitwallleft && !hitwallup && !hitwallright)
            {
                velocity = new Vector2(0, 1);
                direction = Directions.Up;
                Debug.Log("Right => Up (Outer Corner)");
                Body.RotateAround(transform.position, Vector3.forward, 90);
            }
            else if (hitwallcornerdownleft && !hitwalldown && !hitwallleft && !hitwallup && !hitwallright)
            {
                velocity = new Vector2(0, -1);
                direction = Directions.Down;
                Debug.Log("Right => Down (Outer Corner)");
                Body.RotateAround(transform.position, Vector3.forward, 90);
            }
        }
        else if (direction == Directions.Up)
        {
            if (!hitwalldown && hitwallleft && hitwallup && !hitwallright)
            {
                velocity = new Vector2(1, 0);
                direction = Directions.Right;
                Debug.Log("Up => Right (Inner Corner)");
                Body.RotateAround(transform.position, Vector3.forward, -90);
            }
            else if (!hitwalldown && !hitwallleft && hitwallup && hitwallright)
            {
                velocity = new Vector2(-1, 0);
                direction = Directions.Left;
                Debug.Log("Up => Left (Inner Corner)");
                Body.RotateAround(transform.position, Vector3.forward, 90);
            }
            else if (hitwallcornerdownleft && !hitwalldown && !hitwallleft && !hitwallup && !hitwallright)
            {
                velocity = new Vector2(-1, 0);
                direction = Directions.Left;
                Debug.Log("Up => Left (Outer Corner)");
                Body.RotateAround(transform.position, Vector3.forward, 90);
            }
            else if (hitwallcornerdownright && !hitwalldown && !hitwallleft && !hitwallup && !hitwallright)
            {
                velocity = new Vector2(1, 0);
                direction = Directions.Right;
                Debug.Log("Up => Right (Outer Corner)");
                Body.RotateAround(transform.position, Vector3.forward, -90);
            }
        }

        transform.position += (Vector3)velocity * speed * Time.deltaTime;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)velocity);
    }
}
