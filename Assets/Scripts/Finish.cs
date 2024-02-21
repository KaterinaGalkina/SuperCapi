using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] AudioSource levelCompleted;
    private void OnTriggerEnter(Collider other) 
    {
       if (other.gameObject.name == "Player") 
       {
            Invoke(nameof(NextLevel), .3f);
            levelCompleted.Play();
       }
    }
    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
