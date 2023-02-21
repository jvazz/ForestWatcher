using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontoMapa : MonoBehaviour
{
    public GameObject minimapCamera;
    public GameObject heliponto;
    public float raioCamera;
    public float velocidade;
    Vector3 ondeIr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ondeIr = new Vector3(heliponto.transform.position.x, transform.position.y, heliponto.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, ondeIr, velocidade);

        if(transform.position.z > minimapCamera.transform.position.z + raioCamera)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, minimapCamera.transform.position.z + raioCamera);
        }
        if(transform.position.z < minimapCamera.transform.position.z - raioCamera)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, minimapCamera.transform.position.z - raioCamera);
        }

        if(transform.position.x > minimapCamera.transform.position.x + raioCamera)
        {
            transform.position = new Vector3(minimapCamera.transform.position.x + raioCamera, transform.position.y, transform.position.z);
        }
        if(transform.position.x < minimapCamera.transform.position.x - raioCamera)
        {
            transform.position = new Vector3(minimapCamera.transform.position.x - raioCamera, transform.position.y, transform.position.z);
        }
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontoMapa : MonoBehaviour
{
    public GameObject minimapCamera;
    public GameObject heliponto;
    public float raioCamera;
    public float velocidade;
    Vector3 ondeIr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ondeIr = new Vector3(heliponto.transform.position.x, transform.position.y, heliponto.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, ondeIr, velocidade);

        if(transform.position.z > minimapCamera.transform.position.z + raioCamera)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, minimapCamera.transform.position.z + raioCamera);
        }
        if(transform.position.z < minimapCamera.transform.position.z - raioCamera)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, minimapCamera.transform.position.z - raioCamera);
        }

        if(transform.position.x > minimapCamera.transform.position.x + raioCamera)
        {
            transform.position = new Vector3(minimapCamera.transform.position.x + raioCamera, transform.position.y, transform.position.z);
        }
        if(transform.position.x < minimapCamera.transform.position.x - raioCamera)
        {
            transform.position = new Vector3(minimapCamera.transform.position.x - raioCamera, transform.position.y, transform.position.z);
        }
    }
}
*/
