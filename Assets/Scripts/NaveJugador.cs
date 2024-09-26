using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaveJugador : MonoBehaviour
{
    private float _Vel;
    private Vector2 MinPantalla, MaxPantalla;

    [SerializeField]
    private GameObject prefabProyectil;
    
    // Start is called before the first frame update
    void Start()
    {
        _Vel = 8;  

        MinPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        MaxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //SE PUEDE HACER DE LAS DOS MANERAS, PEROI ESTA ALGO MEJOR LA SEGUNDA.
        float medidaMitadImagenX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float medidaMitadImagenY = GetComponent<SpriteRenderer>().bounds.size.y/ 2;

        //Se coge el numero mirando lo que ocupa la mitad de la nave, como mi nave ocupa 0,5 se lo restamos o sumamos segun el eje y asi no se pasa, cogiuendo de referencia
        //la mitad justo, y sirve para hacer limites en la pantalla del juego.
        //MinPantalla.x = MinPantalla.x + 0.5f;
        //MinPantalla.x += 0,5f; Es  sinonimo a la linea de arriba
        MinPantalla.x += medidaMitadImagenX; 
        MaxPantalla.x -= medidaMitadImagenX;

        MinPantalla.y += medidaMitadImagenY;
        MaxPantalla.y -= medidaMitadImagenY;

    }

    // Update is called once per frame
    void Update()
    {
        MovimientoNave();
        DisparaProyectil();

    }
    private void MovimientoNave()
    {
        //Todo esto para que se mueva el jugador y para que la camara tenga limites.
        float DireccionIndicadaX = Input.GetAxisRaw("Horizontal");
        float DireccionIndicadaY = Input.GetAxisRaw("Vertical");
        //Debug.Log("X: " + DireccionIndicadaX + " - Y: " + DireccionIndicadaY);

        Vector2 DireccionIndicada = new Vector2(DireccionIndicadaX, DireccionIndicadaY).normalized;

        Vector2 NuevaPos = transform.position;
        NuevaPos = NuevaPos + DireccionIndicada * _Vel * Time.deltaTime;

        Debug.Log(NuevaPos);

        NuevaPos.x = Mathf.Clamp(NuevaPos.x, MinPantalla.x, MaxPantalla.x);
        NuevaPos.y = Mathf.Clamp(NuevaPos.y, MinPantalla.y, MaxPantalla.y);

        transform.position = NuevaPos;

    }
    
    private void DisparaProyectil()
    {
        if (Input.GetKeyDown(name: "space"))
        {
            GameObject proyectil = Instantiate(prefabProyectil);
            proyectil.transform.position = transform.position;
        }
    }

}
