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
    [Header("Configuraçao do coin - Moeda")]
    public float _coinTempo;
    public GameObject _coinPrefab;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstaculo");
        StartCoroutine("SpawnCoin");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  //criar uma COROTINA com o IE

  IEnumerator SpawnObstaculo()
  {

    yield return new WaitForSeconds(_ObstaculoTempo); //retorne em segundos em qual variavel

    GameObject ObjetoObstaculoTemp = Instantiate(_ObstaculoPrefab); //vou colar um nome para minha INSTANCIA vai contar o objeto instanciado
    StartCoroutine("SpawnObstaculo"); //serve para EXECUTAR a COROUTINA e vai CHAMAR da função START
  }  

  IEnumerator SpawnCoin()
  {
    int moedasaleatorias = Random.Range(1, 5);
    Debug.Log("oedas sorteadas:" + moedasaleatorias);
    for (int contagem = 1; contagem <= moedasaleatorias; contagem ++);
    {
      yield return new WaitForSeconds(_coinTempo);
      GameObject _objetoSpawn = Instantiate(_coinPrefab);
      _objetoSpawn.transform.position = new Vector3(_objetoSpawn.transform.position.x, _objetoSpawn.transform.position.y, 0);
    }
  }
}
