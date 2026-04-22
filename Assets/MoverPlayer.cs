using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    //Variaveis para configurar a camera
    private Transform cameraPlayer;
    private float Valordegirosuave = 0.1f;
    private float Velocidadedegirosuave;

    //variavel de movimentacao do plyes
    [Header("config Movimento")]
    [SerializeField] float VelocidadeCaminhada; //velocidade caminhada
    [SerializeField] float Velocidadecorrida; //velocidade corrida
    [SerializeField] float forcapulo; //força pulo
    [SerializeField] float forcaqueda; //força queda
    private CharacterController playerController; //controlador da movimentação do playes
    private float velocidadevertical = 0; //A velocidade na vertical do player


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //configurar a variavel playerController
        playerController = GetComponent<CharacterController>();

        //Configurar a posicao da camera do player
        cameraPlayer = Camera.main.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarXYZ();
    }

    //Metodo para movimentar o player nos eixos xyz
     private void MovimentarXYZ()
    {
        //verificar se o player esta correndo
        bool estaCorrendo = Input.GetAxisRaw("Correr") > 0;

        //definir a velocidade de movimentacao
        float velocidade = estaCorrendo ? Velocidadecorrida : VelocidadeCaminhada;

        //definir a direçãõ  de movimentacao vertical
        float direcaoVertical = Input.GetAxisRaw("Vertical");

        //definir a direçãõ  de movimentacao horizontal
        float direcaoHorizontal = Input.GetAxisRaw("Horizontal");

        //Definir a direção no plano xyz
        Vector3 direcaoxz = new Vector3(direcaoHorizontal,0,direcaoVertical).normalized;

        //Combinar a direcao do plano x e z com a velocidade de movimentacao
        Vector3 direcaoFinal = direcaoxz * velocidade;

        //movimentar o player
        playerController.Move(direcaoFinal * Time . deltaTime);

    }
}
