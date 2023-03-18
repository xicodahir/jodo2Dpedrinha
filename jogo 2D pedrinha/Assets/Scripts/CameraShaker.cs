using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{


    [Header ("Camera Shaker Config")]
    private Vector3 cameraInitialPosition; //posição inicial da CAMERA
    public float shakeMagnitude = 0.05f; //valor da energia emitida PARA TREMER A TELA, camera vai balançar
    public float shakeTime = 0.05f;
    public Camera mainCamera;

    public void ShakeIt() //primeira funçao é publica vou chamar de outro scrpit
    {
        cameraInitialPosition = mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f); // VAI FAZER REPETIDAMENTE BALANÇAR nome da funçao, tempo , qto quero de repeticao
        Invoke("StopCameraShaking", shakeTime); //vou parar o TREMOR da camera
    }

    void StartCameraShaking() //sao privativas NAO SERA CHAMADAS EM OUTROS SCRITP
    {
        float cameraShakingOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude; //RANDOM VALUE valor aleatorio 
        float cameraShakingOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;

        Vector3 cameraIntermediatePosition = mainCamera.transform.position; //vou pegar a posiçao modificada da camara X Y Z e vou colocar nessa VARIAVEL INTERMEDIARIA

        cameraIntermediatePosition.x += cameraShakingOffsetX; // tremor tem que ser de cima pra baixo
        cameraIntermediatePosition.y += cameraShakingOffsetY; // tremor tem que ser tb da direita pra esquerda 
        mainCamera.transform.position = cameraIntermediatePosition;
    }

    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShake"); //funçao que quero parar o TREMOR no CASO START CAMERA SHAKING
        mainCamera.transform.position = cameraInitialPosition;
    }
  
}
