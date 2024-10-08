using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_ReyCastEnemigo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform jugador;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //calculo de la direccion de origen a destino ...
        Vector3 direccion = jugador.position - transform.position; //destino - origen
        direccion = direccion.normalized;
        RaycastHit hit; //almacena toda la colision que hace el rayo.
        if(Physics.Raycast(transform.position,
        transform.forward, out hit, 10f)){
            //hace colision el rayo
            Debug.Log("Colisiona con algo");
            Debug.DrawRay(transform.position, direccion * hit.distance, Color.blue);
            

        }else{
        //no hace colision
        Debug.Log("No colisiona con algo");
        Debug.DrawRay(transform.position, direccion *10f, Color.black);
       }
    }
}
