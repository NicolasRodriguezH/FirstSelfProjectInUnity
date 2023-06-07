using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Canvass : MonoBehaviour
{
    //public TextMeshProUGUI puntos;
    public GameObject[] vidas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    puntos.text = GameManager.Instance.TiempoTotal.ToString();
    //}

    //public void ActualizarPuntos(int tiempoTotal)
    //{
    //    puntos.text = tiempoTotal.ToString();
    //}

    public void DesactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
    }

    //public void ActivarVida(int indice)
    //{
    //    vidas[indice].SetActive(true);
    //}
}
