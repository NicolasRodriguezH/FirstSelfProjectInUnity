using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedCollitions : MonoBehaviour
{
    //public bool estaEnElSuelo;
    //public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //Verifica si el objeto que entró en contacto es el que deseas hacer desaparecer
        if (other.gameObject.CompareTag("Wine"))
        {
            //Destruye el objeto
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.ShowGameOverScreen();
            Time.timeScale = 0f;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Suelo"))
    //    {
    //        estaEnElSuelo = true;
    //    }
    //    else if(collision.gameObject.CompareTag("Obstacle"))
    //    {
    //        Debug.Log("Game Over");
    //        gameOver = true;
    //    }
    //}
}
