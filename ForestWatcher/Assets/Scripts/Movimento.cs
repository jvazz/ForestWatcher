using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movimento : MonoBehaviour
{
    public float velocidade;
    Rigidbody meuRig;
    static public float velX = 0, velZ = 0;
    int ultimaTeclaZ = 0;
    float rotacaoY = 0;
    public float velocidadeMaxima;
    public Slider gasolinaSlider;
    bool pousado = false;
    public GameObject pausePanel;
    bool pausado = false;

    void Start()
    {
        meuRig = GetComponent<Rigidbody>();
        gasolinaSlider.value = 1;
        pausePanel.SetActive(false);
    }

    void Update()
    {
        //float velX = Input.GetAxisRaw("Horizontal");
        //float velZ = Input.GetAxisRaw("Vertical");

        if(Arvores.jogoIniciado == true)
        {
            meuRig.velocity = Quaternion.AngleAxis(rotacaoY, Vector3.up)*(new Vector3(velX, 0, velZ) * velocidade * Time.deltaTime);   
            if(!pousado)
            { 
                MovimentoLiso();
            }

            transform.eulerAngles = new Vector3(velZ * 4, rotacaoY, -velX * 3);

            if(!pousado)
            {
                if(Input.GetKey(KeyCode.RightArrow))
                {
                    rotacaoY += 1;
                    //transform.Rotate(0, +0.5f, 0);
                }
                if(Input.GetKey(KeyCode.LeftArrow))
                {
                    rotacaoY -= 1;
                    //transform.Rotate(0, -0.5f, 0);
                    //transform.localRotation.y
                }   
            }

            if(Input.GetKey(KeyCode.UpArrow))
            {
                if(transform.position.y < 40)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 0.08f, transform.position.z);
                }
            }
            if(Input.GetKey(KeyCode.DownArrow))
            {
                if(transform.position.y > 6)
                {
                    if(!pousado)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - 0.08f, transform.position.z);
                    }
                }
            }

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(!pausado)
                {
                    pausado = true;
                    Time.timeScale = 0;
                    pausePanel.SetActive(true);
                }
                else if(pausado)
                {
                    pausado = false;
                    Time.timeScale = 1;
                    pausePanel.SetActive(false);
                }
            }
        }

        /*if(transform.position.z > 465)
        {
            velZ = 0;
            transform.position = new Vector3(transform.position.x, transform.position.y, 465);
        }
        if(transform.position.z < -465)
        {
            velZ = 0;
            transform.position = new Vector3(transform.position.x, transform.position.y, -465);
        }
        if(transform.position.x > 440)
        {
            velZ = 0;
            transform.position = new Vector3(440, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -440)
        {
            velZ = 0;
            transform.position = new Vector3(-440, transform.position.y, transform.position.z);
        }*/

        if(transform.position.y > 40)
        {
            transform.position = new Vector3(transform.position.x, 40, transform.position.z);
        }
        if(transform.position.y < 6)
        {
            transform.position = new Vector3(transform.position.x, 6, transform.position.z);
        }
    }

    void FixedUpdate()
    {
        gasolinaSlider.value -=  0.0001f;
        if(pousado)
        {
            gasolinaSlider.value +=  0.0008f;
        }
    }

    public void Pause(int numero)
    {
        if(numero == 1)
        {
            pausado = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
        if(numero == 2)
        {
            SceneManager.LoadScene("TelaInicial");
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Heliponto")
        {
            velZ = 0;
            velX = 0;
            pousado = true;
        }
    }
    void OnCollisionStay(Collision col)
    {
        if(col.gameObject.name == "Heliponto")
        {
            velZ = 0;
            velX = 0;
            pousado = true;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.name == "Heliponto")
        {
            pousado = false;
        }
    }

    void MovimentoLiso()
    {
        //Z
        if(Input.GetKey(KeyCode.W))
        {
            if(velZ < velocidadeMaxima)
            {
                velZ += 0.08f;
            }
        }

        if(Input.GetKey(KeyCode.S))
        {
            if(velZ > -(velocidadeMaxima/2))
            {
                velZ -= 0.08f;
            }
        }

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
        {

        }else
        {
            if(velZ > 0)
            {
                if(velZ > 2)
                {
                    velZ -= 0.06f;
                }else
                {
                    velZ -= 0.02f;
                }
            }
            if(velZ < 0)
            {
                if(velZ < -2)
                {
                    velZ += 0.06f;
                }else
                {
                    velZ += 0.02f;
                }
            }
        }

        //X
        if(Input.GetKey(KeyCode.D))
        {
            if(velX < (velocidadeMaxima*0.9f))
            {
                velX += 0.08f;
            }
        }

        if(Input.GetKey(KeyCode.A))
        {
            if(velX > -(velocidadeMaxima*0.9f))
            {
                velX -= 0.08f;
            }
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {

        }else
        {
            if(velX > 0)
            {
                if(velX > 2)
                {
                    velX -= 0.06f;
                }else
                {
                    velX -= 0.02f;
                }
            }
            if(velX < 0)
            {
                if(velX < -2)
                {
                    velX += 0.06f;
                }else
                {
                    velX += 0.02f;
                }
            }
        }
    }

    /*void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("oi");
        }
    }*/
}
