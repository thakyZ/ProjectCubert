using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubertHealth : MonoBehaviour
{
    public GameObject PlayerOrigin;


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
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        transform.localPosition = Vector3.zero;
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
            PlayerOrigin.transform.position = new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y, 0);
            transform.localPosition = new Vector3(0, 0, 0);
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
