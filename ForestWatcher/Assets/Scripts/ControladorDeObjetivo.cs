using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorDeObjetivo : MonoBehaviour
{
    public Text incendiosEncontradosTxt, tempoDeOperacaoTxt;
    public static int incendiosEncontrados = 0;
    float segundos = 0, minutos = 0;

    // Start is called before the first frame update
    void Start()
    {
        incendiosEncontrados = 0;
    }

    // Update is called once per frame
    void Update()
    {
        incendiosEncontradosTxt.text = "Incêndios encontrados: " + incendiosEncontrados;
        tempoDeOperacaoTxt.text = "Tempo de operação: " + minutos.ToString("00") + ":" + segundos.ToString("00");
        segundos += Time.deltaTime;
        if(segundos > 59)
        {
            segundos = 0;
            minutos++;
        }
        if(incendiosEncontrados == 10)
        {
            SceneManager.LoadScene("Vitoria");
        }
    }
}
