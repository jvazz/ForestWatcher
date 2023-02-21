using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaInicial : MonoBehaviour
{
    public GameObject painelInformacoes;

    void Start()
    {
        painelInformacoes.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Informacoes()
    {
        painelInformacoes.SetActive(true);
    }

    public void FecharInformacoes()
    {
        painelInformacoes.SetActive(false);
    }

    public void TelaDeInicio()
    {
        SceneManager.LoadScene("TelaInicial");
    }

}
