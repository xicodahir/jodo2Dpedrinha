using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [Header("Configuração do CHAO")]

    public float _chaoDestruido;
    public float _chaoTamanho;
    public GameObject _chaoPrefab;
    public float _chaoVelocidade;

    [Header("Configuraçao do Obstáculo")]
    public float _ObstaculoTempo;
    public GameObject _ObstaculoPrefab;
    public float _ObstaculoVelocidade;

    // INSTANCIA = CRIAR OBJETO PEDRA NO JOGO E CONTROLAR A QTDE QUE VAI APARECER E A VELOCIDADE TB
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawObstaculo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  //criar uma COROTINA com o IE

  IEnumerator SpawObstaculo()
  {

    yield return new WaitForSeconds(_ObstaculoTempo); //retorne em segundos em qual variavel

    GameObject ObjetoObstaculoTemp = Instantiate(_ObstaculoPrefab); //vou colar um nome para minha INSTANCIA vai contar o objeto instanciado
    StartCoroutine("SpawObstaculo"); //serve para EXECUTAR a COROUTINA e vai CHAMAR da função START
  }  
}
