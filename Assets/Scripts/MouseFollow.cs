using UnityEngine;

public class MouseFollow : MonoBehaviour
{

    public Transform cubert;

    public Transform cube;

    [HideInInspector]
    public CubertController controller;

    public float VelocityScale;

    public float temp = 100;

    public float angle;

    public Vector3 targetToMouseDir;

    public Vector3 targetScreenPos;

    public Vector3 mouseWorldPos;

    void Start()
    {
        controller = GetComponentInParent<CubertController>();
    }

    // Update is called once per frame
    void Update()
    {
        targetScreenPos = Camera.main.WorldToScreenPoint(cubert.position);
        targetScreenPos.z = 0;
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        targetToMouseDir = Input.mousePosition - targetScreenPos;
        Vector3 mouseToTargetDir = cubert.position - mouseWorldPos;
        Vector3 targetToMe = transform.position - cubert.position;
        targetToMe.z = 0;

        angle = Mathf.Atan2(targetToMouseDir.y, targetToMouseDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        float scale = Vector3.Magnitude(targetToMouseDir);
        float offset = 0.0f * scale - 0.15f;
        VelocityScale = scale / 1 - offset;
        float worldScale = Mathf.Abs(Vector3.Magnitude(mouseToTargetDir) - 0.5f);
        worldScale = Mathf.Clamp(worldScale, 0.05f, 6);

        VelocityScale = Mathf.Clamp(VelocityScale, 0.05f, worldScale);

        cube.transform.localScale = new Vector3(0.15f, 0.15f, VelocityScale);

        cube.transform.localPosition = new Vector3(0.5f + VelocityScale / 2, 0, 0);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0);
        Gizmos.DrawLine(cubert.transform.position, cubert.transform.position + (Vector3)cubert.GetComponent<Rigidbody2D>().velocity / 2);
       // Gizmos.color = new Color(1, 0, 0);
       // Gizmos.DrawSphere(targetToMouseDir, 1);
       // Gizmos.color = new Color(1, 1, 0);
        //Gizmos.DrawSphere(targetScreenPos, 1);
       // Gizmos.color = new Color(0, 0, 1);
       // Gizmos.DrawSphere(mouseWorldPos, 1);
    }
}
