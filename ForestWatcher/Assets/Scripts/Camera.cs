using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject helicoptero;
    float posicaoX;
    float posicaoY;
    float posicaoZ;

    void Start()
    {
        posicaoX = transform.position.x;
        posicaoZ = transform.position.z;
        posicaoY = transform.position.y - helicoptero.transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(helicoptero.transform.position.x + posicaoX, helicoptero.transform.position.y + posicaoY, helicoptero.transform.position.z + posicaoZ);
    }
}
