using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class menu : MonoBehaviour
{
    public int starNeed = 10;
    public GameObject candado;
    public TMP_Text score;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + PlayerPrefs.GetInt("Score");
        Debug.Log(PlayerPrefs.GetInt("Score"));
        if (starNeed >= PlayerPrefs.GetInt("Score"))
        {
            candado.SetActive(true);
            Debug.Log("hola");
        }
        else
        {
            candado.SetActive(false);
            Debug.Log("adios");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void EscenaJuego()
    {
        SceneManager.LoadScene("level1 1");
    }
    public void EscenaJuegoHARD()
    {
        SceneManager.LoadScene("level2");
    }
    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }
}
