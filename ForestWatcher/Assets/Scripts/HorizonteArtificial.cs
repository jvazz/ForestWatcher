using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HorizonteArtificial : MonoBehaviour
{
    public GameObject horizonte;
    public GameObject representacao;
    public Text velocidadeTxt;
    public Text altitudeTxt;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        representacao.transform.eulerAngles = new Vector3(representacao.transform.rotation.x, representacao.transform.rotation.y, transform.rotation.z*300);
        horizonte.transform.position = new Vector3(horizonte.transform.position.x, transform.rotation.x*300 + 100, horizonte.transform.position.z);
        velocidadeTxt.text = (Movimento.velZ*100).ToString("F0");
        altitudeTxt.text = transform.position.y.ToString("F0");
    }
}
