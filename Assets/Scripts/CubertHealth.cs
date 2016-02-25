using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubertHealth : MonoBehaviour
{

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
            Destroy(gameObject);
            StartCoroutine(Wait(4));
            FindObjectOfType<Fade>().FadeToLevel(-1);
        }
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    void OnLevelWasLoaded()
    {
        gameObject.transform.localPosition = (Vector3)Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == ("Goal"))
        {
            PlayerPrefs.SetInt("Unlocked", SceneManager.GetActiveScene().buildIndex - 1);
            StartCoroutine(Wait(4));
            FindObjectOfType<Fade>().FadeToLevel("+1");
        }
        if (col.gameObject.tag == ("Enemy"))
        {
            Destroy(gameObject);
            StartCoroutine(Wait(4));
            FindObjectOfType<Fade>().FadeToLevel(-1);
        }
    }
}
