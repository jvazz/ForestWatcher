using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogo : MonoBehaviour
{
    public GameObject particulas;
    bool aconteceu = false;

    public GameObject painelAvisados;
    public GameObject luz1, luz2;
    int vezLuz = 0;
    bool encontrado = false;
    public GameObject miniMapaDeCalor;
    public GameObject sirenes;

    // Start is called before the first frame update
    void Start()
    {
        miniMapaDeCalor.SetActive(true);
        particulas.SetActive(false);
        aconteceu = false;
        painelAvisados.SetActive(false);
        luz1.SetActive(false);
        luz2.SetActive(false);
        sirenes.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!aconteceu)
        {
            if(Arvores.jogoIniciado == true)
            {
                transform.position = new Vector3(Random.Range(-450, 450), 0, Random.Range(-450, 450));
                aconteceu = true;
                particulas.SetActive(true);
                if(transform.position.x > -90 && transform.position.x < 90)
                {
                    transform.position = new Vector3(Random.Range(-450, 450), 0, Random.Range(-450, 450));
                }
                if(transform.position.z > -90 && transform.position.z < 90)
                {
                    transform.position = new Vector3(Random.Range(-450, 450), 0, Random.Range(-450, 450));
                }
            }
        }
        if(transform.position.x > -90 && transform.position.x < 90)
        {
            transform.position = new Vector3(Random.Range(-450, 450), 0, Random.Range(-450, 450));
        }
        if(transform.position.z > -90 && transform.position.z < 90)
        {
            transform.position = new Vector3(Random.Range(-450, 450), 0, Random.Range(-450, 450));
        }
    }

    void OnMouseOver()
    {
        if(!encontrado)
        {
            if(Input.GetMouseButtonDown(0))
            {
                encontrado = true;
                ControladorDeObjetivo.incendiosEncontrados++;
                painelAvisados.SetActive(true);
                sirenes.transform.position = new Vector3(0, 0, 0);
                sirenes.SetActive(true);
                sirenes.transform.position = Vector3.MoveTowards(sirenes.transform.position, transform.position, 1000);
                InvokeRepeating("PiscarLuzes", 5f, 0.5f);
                Invoke("PararDePiscarLuzes", 20f);
            }
        }
    }

    void PiscarLuzes()
    {
        painelAvisados.SetActive(false);
        if(vezLuz == 0)
        {
            luz1.SetActive(true);
            luz2.SetActive(false);
            vezLuz = 1;
        }
        else if(vezLuz == 1)
        {
            luz1.SetActive(false);
            luz2.SetActive(true);
            vezLuz = 0;
        }
    }

    void PararDePiscarLuzes()
    {
        sirenes.SetActive(false);
        particulas.SetActive(false);
        CancelInvoke("PiscarLuzes");   
        luz1.SetActive(false);
        luz2.SetActive(false);
        miniMapaDeCalor.SetActive(false);
    }
}
