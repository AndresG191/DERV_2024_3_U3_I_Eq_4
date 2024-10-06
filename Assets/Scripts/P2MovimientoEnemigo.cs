using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    // Start is called before the first frame update2

    Transform ubicacion_jugador;
    P2_Distance_BetweeObjects auxDistancia;

    void Awake(){
        ubicacion_jugador = GameObject.Find("Personaje").GetComponent<Transform>();
    }//awake se inicializa antes de los objetos
    void Start()
    {
        auxDistancia = GetComponent<P2_Distance_BetweeObjects>();
    }

    // Update is called once per frame
    void Update()
    {   
        float distancia_a_jugador = auxDistancia.distance;
        if(distancia_a_jugador<7.0f && distancia_a_jugador> 1.7f){
        float velocidad = 10f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, ubicacion_jugador.position, velocidad);
        }
    }
}
