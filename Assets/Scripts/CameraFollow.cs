using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Rect levelBounds;
    public float _leftBound;
    public float _rightBound;
    public float _bottomBound;
    public float _topBound;

    // Use this for initialization
    void Start()
    {
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        _leftBound = levelBounds.xMin + horzExtent; //(horzExtent - levelBounds.width / 2.0f);
        _rightBound = levelBounds.xMax - horzExtent; //(levelBounds.width / 2.0f - horzExtent);
        _bottomBound = levelBounds.yMin + vertExtent; //(vertExtent - levelBounds.height / 2.0f);
        _topBound = levelBounds.yMax - vertExtent; //(levelBounds.height / 2.0f - vertExtent);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, 0, -100);
    }

    void LateUpdate()
    {
        Vector3 vectorClamp = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        vectorClamp.x = Mathf.Clamp(vectorClamp.x, _leftBound, _rightBound);
        vectorClamp.y = Mathf.Clamp(vectorClamp.y, _bottomBound, _topBound);
        vectorClamp.z = -100;

        transform.position = vectorClamp;
    }

    // Starts when the level was loaded.
    void OnLevelWasLoaded()
    {
        Start();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(new Vector2(levelBounds.xMin, levelBounds.yMax), new Vector3(levelBounds.xMax, levelBounds.yMax));
        Gizmos.DrawLine(new Vector2(levelBounds.xMin, levelBounds.yMin), new Vector3(levelBounds.xMax, levelBounds.yMin));
        Gizmos.DrawLine(new Vector2(levelBounds.xMin, levelBounds.yMax), new Vector3(levelBounds.xMin, levelBounds.yMin));
        Gizmos.DrawLine(new Vector2(levelBounds.xMax, levelBounds.yMax), new Vector3(levelBounds.xMax, levelBounds.yMin));


        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(_leftBound, _topBound), new Vector3(_rightBound, _topBound));
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector2(_leftBound, _bottomBound), new Vector3(_rightBound, _bottomBound));
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector2(_leftBound, _topBound), new Vector3(_leftBound, _bottomBound));
        Gizmos.color = Color.white;
        Gizmos.DrawLine(new Vector2(_rightBound, _topBound), new Vector3(_rightBound, _bottomBound));
    }
}
