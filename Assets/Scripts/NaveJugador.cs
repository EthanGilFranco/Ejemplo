using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaveJugador : MonoBehaviour
{
    private float _Vel;
    
    // Start is called before the first frame update
    void Start()
    {
        _Vel = 8;    
    }

    // Update is called once per frame
    void Update()
    {
        float DireccionIndicadaX = Input.GetAxisRaw("Horizontal");
        float DireccionIndicadaY = Input.GetAxisRaw("Vertical");
        //Debug.Log("X: " + DireccionIndicadaX + " - Y: " + DireccionIndicadaY);

        Vector2 DireccionIndicada = new Vector2(DireccionIndicadaX, DireccionIndicadaY).normalized;

        Vector2 NuevaPos = transform.position;
        NuevaPos = NuevaPos + DireccionIndicada * _Vel * Time.deltaTime;
        transform.position = NuevaPos;  

    }
}
