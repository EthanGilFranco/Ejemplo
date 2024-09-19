using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaveJugador : MonoBehaviour
{
    private float _Vel;
    private Vector2 MinPantalla, MaxPantalla;
    
    // Start is called before the first frame update
    void Start()
    {
        _Vel = 8;  

        MinPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        MaxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //Se coge el numero mirando lo que ocupa la mitad de la nave, como mi nave ocupa 0,5 se lo restamos o sumamos segun el eje y asi no se pasa, cogiuendo de referencia
        //la mitad justo
        MinPantalla.x = MinPantalla.x + 0.5f;
        MaxPantalla.x = MinPantalla.x - 0.5f;

        MinPantalla.y = MinPantalla.x + 0.5f;
        MaxPantalla.y = MinPantalla.y - 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        //Todo esto para que se mueva el jugador y para que la camara tenga limites.
        float DireccionIndicadaX = Input.GetAxisRaw("Horizontal");
        float DireccionIndicadaY = Input.GetAxisRaw("Vertical");
        //Debug.Log("X: " + DireccionIndicadaX + " - Y: " + DireccionIndicadaY);

        Vector2 DireccionIndicada = new Vector2(DireccionIndicadaX, DireccionIndicadaY).normalized;

        Vector2 NuevaPos = transform.position;
        NuevaPos = NuevaPos + DireccionIndicada * _Vel * Time.deltaTime;

        NuevaPos.x = Mathf.Clamp(NuevaPos.x, MinPantalla.x, MaxPantalla.x);
        NuevaPos.y = Mathf.Clamp(NuevaPos.x, MinPantalla.y, MaxPantalla.y);

        transform.position = NuevaPos;  

        


    }
}
