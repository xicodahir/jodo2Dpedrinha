using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 0f; // zero f de flutuante
    public bool isGrounded = true;
    public float jumpForce = 650f;

    private Animator anim; // variavel anim vai controlar tudo que é animator dentro da CENA
    private Rigidbody2D rig; // vai controlar tudo que tem propriedade RIG

    public LayerMask LayerGround;
    public Transform checkGround;
    public string isGroundBool = "eChao";

    private GameController _gameController;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>(); // GETCOMPONENT serve para PEGAR TODAS AS PROPRIEDADES DO COMPONENTE NO CASO RIGIDBODY2D
        anim = GetComponent<Animator>();

        _gameController = FindObjectOfType(typeof(GameController)) as GameController;


        MovimentaPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)) //tecla para CIMA foi pressionada, uma vez pressionada executo JUMP
        {
           Jump(); 
        }
    }

    private void MovimentaPlayer()
    {
        transform.Translate(new Vector3(speed, 0, 0));
    }

    void  FixedUpdate()
    {
         transform.Translate(new Vector3(speed, 0, 0));

         if(Physics2D.OverlapCircle(checkGround.transform.position, 0.2f, LayerGround))  //tudo que for dentro do IF tem que ser verddeiro CRIA UM CIRCULO do seu OBJETO EM CIMA DE UM LAYER GROUND
         {
            anim.SetBool(isGroundBool, true);
            isGrounded = true;  //estou DEFININDO QUE ESTOU NO CHAO
         }
         else
         {
            anim.SetBool(isGroundBool, false);
            isGrounded = false;  //nao estou no CHAO
         }
    }

    public void Jump()
    {
        if(isGrounded) //se for verdadeiro
        {
            _gameController._fxGame.PlayOneShot(_gameController._fxJump);

            rig.velocity = Vector2.zero; // vou falar que a velocidade do rigidbody e zero
            rig.AddForce(new Vector2(0, jumpForce)); // valor de 650f 
        }
    }
}
