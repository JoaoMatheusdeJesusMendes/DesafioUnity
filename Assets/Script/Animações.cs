using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animações : MonoBehaviour
{
    //pegar o game object porta
    public GameObject porta;
    //variavel booleana se a porta está aberta ou fechada
    private bool aberta = false;
    //pega o som da porta abrindo
    public AudioSource abrindo;
    //pega o som da porta fechando
    public AudioSource fechando;

    // Start is called before the first frame update
    void Start()
    {
    }
    //se o player colidir com a porta
    private void OnTriggerEnter(Collider other)
    {
    //Ativação da animação
        if(other.gameObject.layer == 8 && aberta)
        {
            fechando.Play();
            porta.transform.Rotate(0, 82.178f, 0);
            aberta = false;
        }
        else if(other.gameObject.layer == 8 && !aberta)
        {
            porta.transform.Rotate(0, -82.178f, 0);
            aberta = true;
            abrindo.Play(); 
        }
    } 
}
