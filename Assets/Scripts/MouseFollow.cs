using UnityEngine;

public class MouseFollow : MonoBehaviour
{

    public Transform cubert;

    public Transform cube;

    [HideInInspector]
    public CubertController controller;

    public float VelocityScale;

    public float temp = 100;

    void Start()
    {
        controller = GetComponentInParent<CubertController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetScreenPos = Camera.main.WorldToScreenPoint(cubert.position);
        targetScreenPos.z = 0;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        Vector3 targetToMouseDir = Input.mousePosition - targetScreenPos;
        Vector3 mouseToTargetDir = cubert.position - mouseWorldPos;
        Vector3 targetToMe = transform.position - cubert.position;
        targetToMe.z = 0;

        var angle = Mathf.Atan2(targetToMouseDir.y, targetToMouseDir.x) * Mathf.Rad2Deg;
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
    }
}
