using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Spawn : MonoBehaviour
{
    //variavel auxiliar
    private int aux = 0;
    //numero para ser randomizado
    private int rand = 0;
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
    //variavel de tempo
    private int tempo = 60;
    //variavel que irá pegar o texto do unity
    public Text tempotxt;
    // Start is called before the first frame update
    void Start()
    {
        //pega rigidbody
        rigidbody = GetComponent<Rigidbody>();
        //spawna objetos
        if(achados == 0 && spawnados < 4)
        {
            
        for(int i=spawnados; i<4; i++)
        {
            Spawnar();
        }
        }
    }

    // Update is called once per frame
    void Update()
    {   
        //spawn do 5 objeto
        float x=0, z=0; 
        if(achados == 4 && spawnados == 0)
        {
            Spawnar();
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
            spawnados-=1;
        }
    }
    //spawna objetos para serem achados
    private void Spawnar()
    {
        float x=0, z=0;
            //chama função de randomização
            Randomizar(out x, out z);
            //randomiza a posição de spawn
            Vector3 randowSpawnPosition = new Vector3(x, 1, z);
            //instancializa o objeto coloando-o no mapa
            Instantiate(objeto, randowSpawnPosition, Quaternion.identity);
            //adição de spawnados
            spawnados += 1;
    }
    //ao restartar
    public void Restart()
    {
        tempo = 60;
        achados = 0;
        aux = 0;
        //repawna objetos
        if(achados == 0 && spawnados < 4)
        {
            
        for(int i=spawnados; i<4; i++)
        {
            Spawnar();
        }
        }
        rigidbody.transform.position = new Vector3 (0, 3, 0); 
        gameOver.SetActive(false);
    }
    
    //randomiza x e z
    private void Randomizar(out float x, out float z)
    {
        x=0;
        z=0;
         //sorteia um numero aleatorio de 1 a 7 para spawn e sorteia variaveis de x e z
            rand = Random.Range(1,7);
            switch(rand)
            {
            case 1:  x = Random.Range(10,13);
                     z = Random.Range(-17, -14);
                     break;
            case 2: x = Random.Range(18,23);
                    z = Random.Range(-32, -25);
                    break;
            case 3: x = Random.Range(-12, 16);
                    z = Random.Range(-33, -20);
                    break;
            case 4: x = Random.Range(-23, -10);
                    z = Random.Range(-18, -12);
                    break;
            case 5: x = Random.Range(-21, -17);
                    z = Random.Range(-30, -21);
                    break;
            case 6: x = Random.Range(-28, -24);
                    z = Random.Range(-25, -20);
                    break;
            case 7: x = Random.Range(-27, -25);
                    z = Random.Range(-32, -27);
                    break;
            }
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
