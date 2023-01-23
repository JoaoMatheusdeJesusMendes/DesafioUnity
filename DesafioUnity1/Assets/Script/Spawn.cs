using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Spawn : MonoBehaviour
{
    //variavel auxiliar
    private int aux = 0;
    //numero de objetos achados
    public int achados = 0;
    //numero de objetos spawnados
    public int spawnados = 0;
    //variavel para pegar o prefab dos objetos
    public GameObject objeto;
    //variavel para pegar menu de game over
    public GameObject gameOver;
    //pega rigidybody do player
    private Rigidbody rigidbody;
    //pega a musica de fundo para tocar
    public AudioSource soundtrack;
    //variavel de tempo
    private int tempo = 30;
    //variavel que irá pegar o texto do unity
    public Text tempotxt;
    // Start is called before the first frame update
    void Start()
    {
        //pega rigidbody
        rigidbody = GetComponent<Rigidbody>();
        //inicia o som do game
        soundtrack.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(achados == 0 && spawnados < 4)
        {
            for(int i=spawnados; i<4; i++)
        {
            //randomiza a posição de spawn
            Vector3 randowSpawnPosition = new Vector3(Random.Range(-27,18), 1, Random.Range(-13, -33));
            //instancializa o objeto coloando-o no mapa
            Instantiate(objeto, randowSpawnPosition, Quaternion.identity);
            //adição de spawnados
            spawnados += 1;
        }
        }
        if(achados == 4 && spawnados == 4)
        {
            Vector3 randowSpawnPosition = new Vector3(Random.Range(-27,18), 1, Random.Range(-13, -33));
            Instantiate(objeto, randowSpawnPosition, Quaternion.identity);
            spawnados += 1;
        }
        if(achados == 5)
        {
            gameOver.SetActive(true);
        }
        if(tempo == 0)
        {
            gameOver.SetActive(true);
        }
        if(aux == 0)
        {
            Wait(1f);
            aux+=1;
        }
    }
    //ao colidir
    private void OnTriggerEnter(Collider other)
    {
        //se colidir com objeto do tesouro
        if(other.gameObject.layer == 6)
        {
            //destroi ele e adiciona ao contador
            Destroy(other.gameObject);
            achados+=1;
        }
    }
    //ao restartar
    public void Restart()
    {
        tempo = 30;
        spawnados -= achados;
        achados = 0;
        aux = 0;
       
        rigidbody.transform.position = new Vector3 (0, 3, 0); 
        gameOver.SetActive(false);
    }
    //delay de 1 segundo para o temporizador
    private async void Wait(float duration)
    {
        while(tempo>0)
        {
            if(tempo>0)
            {
                await Task.Delay((int)(duration*1000));
                tempo-=1;
                tempotxt.text = "Tempo: " + tempo.ToString();
            }
        }
    }
}
