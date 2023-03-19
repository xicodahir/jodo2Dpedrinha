using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{

    private GameController _gameController;

    private Rigidbody2D _moedasRB2D;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = FindObjectOfType(typeof(GameController)) as GameController; //essa linha procura um obje chamado um objeto game controle que é um game controler
        _moedasRB2D = GetComponent<Rigidbody2D>();
        _moedasRB2D.velocity = new Vector2(-6f,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision) // vai fazer que a moeda tenhoa uma colisao com o objeto player
    {
        if(collision.tag == "Player")
        {
            _gameController.Pontos(1);

            _gameController._fxGame.PlayOneShot(_gameController._fxMoedaColetada);
            Debug.Log("Pegou a moeda!!");
            Destroy(this.gameObject);
        }
    }

     private void OnBecameInvisible()  //para fazer o objeto PREFAB ser destruido IDENTIFICA que o objeto saiu da cena
    {
        Destroy(this.gameObject); //usar essa funçao para destruir
        Debug.Log("a MOEDA foi DESTRUIDA!!!!");
    }
}
