using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubertHealth : MonoBehaviour
{
    public GameObject PlayerOrigin;

    public GameObject LastCheckPoint;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == ("Enemy"))
        {
            StartCoroutine(WaitDeath(0));
        }
    }

    IEnumerator WaitDeath(float seconds)
    {
        FindObjectOfType<Fade>().FadeToLevel(-1);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 5);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(FindObjectOfType<Fade>().FadeTime);
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (go.GetComponent<SpiderMove>() != null)
            {
                go.GetComponent<SpiderMove>().Reset();
            }
        }
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        if (LastCheckPoint != null)
        {
            PlayerOrigin.transform.position = LastCheckPoint.transform.position;
            transform.localPosition = Vector3.zero;
        }
        else
        {
            transform.localPosition = Vector3.zero;
        }
    }

    void OnLevelWasLoaded()
    {
        gameObject.transform.localPosition = (Vector3)Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == ("Goal"))
        {
            if (SceneManager.GetActiveScene().buildIndex >= 2)
            {
                PlayerPrefs.SetInt("Unlocked", SceneManager.GetActiveScene().buildIndex);
            }
            Debug.Log("Int = " + PlayerPrefs.GetInt("Unlocked") + " BuildIndex = " + SceneManager.GetActiveScene().buildIndex);
            FindObjectOfType<Fade>().FadeToLevel("+1");
        }
        if (col.gameObject.tag == ("CheckPoint"))
        {
            LastCheckPoint = col.gameObject;
        }
        if (col.gameObject.tag == ("Enemy"))
        {
            StartCoroutine(WaitDeath(10));
            gameObject.SetActive(false);
            FindObjectOfType<Fade>().FadeToLevel(-1);
            gameObject.SetActive(true);
            transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
