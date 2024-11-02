using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaTomaObjetos : MonoBehaviour


{
    public GameObject tomado;
    public bool isTaken;
    public bool estaElObjetoCerca;

    public Vector3 original_scale;

    Transform padre;

    private void Awake() {
        padre = GameObject.Find("Personaje").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isTaken = false;
        estaElObjetoCerca = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
                if(!isTaken){
                    isTaken = true;                    
                }
                else{
                    isTaken = false;                    
                }
            }
    }

    private void OnTriggerEnter(Collider other) {
        GameObject temporal = other.gameObject;
        if(temporal.CompareTag("ObjetoTomable")){  
            estaElObjetoCerca = true; //variable que puede ser alterada por algun evento externo
            //como podria ser una corrutina
        }
    }

    private void OnTriggerStay(Collider other) {
        GameObject temporal = other.gameObject;
        if(estaElObjetoCerca){  //si esta el objeto tomable cerca del personaje                                      
                if(isTaken){ //y presiono la tecla de tomar
                    tomado = temporal;    //guardo la referencia                    
                    temporal.transform.SetParent(padre); //asocio el objeto al personaje
                    temporal.transform.position = transform.position; //el objeto se colocara en las manos del personaje                    
                    temporal.transform.rotation = transform.rotation; //el obj se coloque en la rotacion de las manos
                    original_scale = temporal.transform.localScale;
                    temporal.transform.localScale = transform.localScale; 
                    Rigidbody rb = temporal.GetComponent<Rigidbody>();
                    rb.isKinematic = true; //obj se vuelve kinematico 
                    rb.useGravity = false;
                }
                else if(tomado!=null){                                         
                    tomado = null;                    
                    temporal.transform.SetParent(null);                    
                    Rigidbody rb = temporal.GetComponent<Rigidbody>();
                    rb.useGravity = true;
                    rb.isKinematic = false;                    
                    temporal.transform.localScale = original_scale;   
                    //Debug.Log("AAA");                 
                }            
        }
        Debug.Log(other.gameObject.name);
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("ObjetoTomable")){
            estaElObjetoCerca = false;
        }
        Debug.Log(other.gameObject.name);
    }
}