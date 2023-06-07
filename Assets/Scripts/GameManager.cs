using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text hiscoreText;
    [SerializeField] private TMP_Text scoreText;
    public static GameManager Instance { get; private set; }

    public Canvass canvas;

    private int score;
    private float timer;

    //public int TiempoTotal { get; private set; }

    private int vidas = 3;


    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
    }

    void Update()
    {
        UpdateScore();
        UpdateHiscore();
    }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        //if(Instance == null)
        //{
        //    Instance = this;
        //}
        //else
        //{
        //    Debug.Log("Warning, mas de un GameManager en escena");
        //}
    }

    //public void ContarTiempo(int tiempo)
    //{
    //    TiempoTotal += tiempo;
    //    canvas.ActualizarPuntos(TiempoTotal);
    //}

    public void PerderVida()
    {
        vidas -= 1;

        //if(vidas == 0)
        //{
        //    
        //    SceneManager.LoadScene(0);
        //}

        canvas.DesactivarVida(vidas);
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
    
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    private void UpdateScore()
    {
        int scorePerSecornds = 10;

        timer += Time.deltaTime;
        score = (int)(timer * scorePerSecornds);
        //scoreText.text = string.Format("{0:0000}", score);
        scoreText.text = Mathf.FloorToInt(score).ToString("D4");
    }

    private void UpdateHiscore()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if (score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }
        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D4");
    }
}
