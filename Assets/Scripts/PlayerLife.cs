using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    bool dead = false;

    Rigidbody rb;

    [SerializeField] private float desiredHeight = -3f; // Desired height threshold
    [SerializeField] AudioSource deathSound;
    private void Update()
    {
        if (transform.position.y <= desiredHeight && !dead)
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Enemy Body")) 
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayementMovement>().enabled = false;
            Die();
        }
    }

    void Die() 
    {
        Invoke(nameof(ReloadLevel), 1.3f);
        dead = true;
        deathSound.Play();
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        dead = true;
    }
}
