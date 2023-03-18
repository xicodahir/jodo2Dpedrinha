using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoController : MonoBehaviour
{
    private Rigidbody2D ObstaculoRB;

    private GameController _GameController;

    private CameraShaker _cameraShaker;
    
    // Start is called before the first frame update
    void Start()
    {
        ObstaculoRB = GetComponent<Rigidbody2D>(); //esta linha garante que OBSTACULO RB tera todas as propriedades do rigibody 2d do objeto PEDRA
        //ObstaculoRB.velocity = new Vector2(-5f, 0); //-5 para esquerda e 0 na direita ou Y


        _GameController = FindObjectOfType(typeof(GameController)) as GameController;  //encontrar objeto do TIPO (tipe off) tudo sera colocado dentro da variavel 

        _cameraShaker = FindObjectOfType(typeof(CameraShaker)) as CameraShaker;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveObjeto();
    }

    void MoveObjeto()
    {
        transform.Translate(Vector2.left * _GameController._ObstaculoVelocidade * Time.smoothDeltaTime);
    }

    void  OnTriggerEnter2D(Collider2D collision)  //função responsavel OnTriggerEnter2D gatilho se houve uma colisao
    {
        if(collision.tag == "Player")  //tag é uma etique ou rotulo que estou fazendo uma colisão com um objeto
        {
            Debug.Log("Tocou no OBSTACULO!!");
            
            _cameraShaker.ShakeIt(); //AQUI VOU CHAMAR O TREMOR da tela quando colidir o player com o obstaculo
        }
    }

    private void OnBecameInvisible()  //para fazer o objeto PREFAB ser destruido IDENTIFICA que o objeto saiu da cena
    {
        Destroy(this.gameObject); //usar essa funçao para destruir
        Debug.Log("Pedra foi DESTRUIDA!!!!");
    }
}
