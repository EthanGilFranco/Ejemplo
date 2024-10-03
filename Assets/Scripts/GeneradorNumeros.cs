using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNumeros : MonoBehaviour
{
    [SerializeField] private GameObject prefabNumero;

    private Vector2 minPantalla, maxPantalla;

    // Start is called before the first frame update
    void Start()
    {
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        InvokeRepeating("GeneraNumeros", 1f, 2f);
    }

    private void GeneraNumeros()
    {
        GameObject numero = Instantiate(prefabNumero);

        numero.transform.position = new Vector2(Random.Range(minPantalla.x, maxPantalla.x), maxPantalla.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
