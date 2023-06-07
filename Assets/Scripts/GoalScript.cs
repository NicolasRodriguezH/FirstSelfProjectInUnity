using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Finish")
    //    {
    //        // Llama al método PlayGoalSound() del GameManager Script
    //        FindObjectOfType<GameManager>().PlayGoalSound();
    //    }
    //}

    public AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }
}
