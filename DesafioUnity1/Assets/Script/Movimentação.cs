using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentação : MonoBehaviour
{
    //variavel da força de pulo
    public float jumpForce = 3.0f;
    //variavel de massa
    public float mass = 3.0f;
    //variavel para receber o rigidybody do player
    private Rigidbody rigidbody;
    //variavel de velocidade
    public float _velocidade = 20.0f;
    //variavel de rotação
    public float _girar = 60.0f;
    //variavel do som dos passos
    public AudioSource andar;
    // Start is called before the first frame update
    void Start()
    {
        //recebe o rigidbody do player
        rigidbody = GetComponent<Rigidbody>();
        //massa do player recebe massa do script
        rigidbody.mass = mass;

    }

    // Update is called once per frame
    void Update()
    {
       movimentação();
    }
    private void movimentação()
    {
        //da play no som dos passos
        andar.UnPause();
        //função que coloca na variavel o quanto o player andou
        float translate = (Input.GetAxis ("Vertical") * _velocidade) * Time.deltaTime;
        //função que coloca na variavel a rotação do player
        float rotate = (Input.GetAxis("Horizontal") * _girar) * Time.deltaTime;
        //efetuação do movimento de andar
        transform.Translate (0, 0, translate);
        //efetuação da rotação
        transform.Rotate (0, rotate, 0);
        if(translate == 0 && rotate == 0)
        {
            //para a musica
            andar.Pause();
        }
    }
}
