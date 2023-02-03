using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Botões : MonoBehaviour
{
    //variavel que pega o nome da cena do game
   [SerializeField] private string nomedojogo;
   [SerializeField] private GameObject painelMenuInicial;
   [SerializeField] private GameObject painelTutorial;
   [SerializeField] private GameObject painelOpcoes;
   //variavel que guarda o slider
   public Slider volume;
   //pega o som da musica
   [SerializeField] private AudioMixer aMixer;
    void Start()
    {
    volume.value = 0;
    //começa o volume como 0
    aMixer.SetFloat("Som1", -80);
    }
    //começa o game
    public void Comeca()
    {
        //carrega a cena
        SceneManager.LoadScene(nomedojogo); 
    } 
    //abre tutorial
    public void AbreTutorial()
    {
        //dasativa menu inicial
        painelMenuInicial.SetActive(false);
        //ativa opções
        painelTutorial.SetActive(true);
    }
    //fecha tutorial
    public void FechaTutorial()
    {
        //dasativa menu inicial
        painelMenuInicial.SetActive(true);
        //ativa opções
        painelTutorial.SetActive(false);

    }
    //abre opções
    public void AbreOpcoes()
    {
        //dasativa menu inicial
        painelMenuInicial.SetActive(false);
        //ativa opções
        painelOpcoes.SetActive(true);
    }
    //fecha opções
    public void FechaOpcoes()
    {
        //dasativa menu inicial
        painelMenuInicial.SetActive(true);
        //ativa opções
        painelOpcoes.SetActive(false);

    }
    //sair do game
    public void Sair()
    {
        Application.Quit();
    }
    //controla o som
    public void ChargeValue()
    {
        aMixer.SetFloat("Som1", -80 + (volume.value*70));
    }
}
