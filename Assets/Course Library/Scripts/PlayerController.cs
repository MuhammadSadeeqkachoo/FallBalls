using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float playerSpeed = 500.0f;
    public GameObject focalPoint;
    public float vertical;
    public bool hasPowerUp ;
    public float powerStrength = 10 ;
    public GameObject powerUpIndicator;
    private string gameOver = "GameOver";
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * playerSpeed * vertical * Time.deltaTime);
        powerUpIndicator.gameObject.transform.position = transform.position + new Vector3(0, -0.3f, 0);

        if(transform.position.y < -5)
        {
            SceneManager.LoadScene(gameOver);

        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerUpIndicator.gameObject.SetActive(true);

        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * powerStrength, ForceMode.Impulse);
        }
        

    }
}
