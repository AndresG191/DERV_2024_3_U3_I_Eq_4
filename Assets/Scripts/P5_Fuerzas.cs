using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P5_Fuerzas : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;
    [SerializeField] float fuerza;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //continuas
        //  Ignora a la masa
        rb.AddForce(transform.right* fuerza, ForceMode.Acceleration);

        //  Considera a la masa

        //instantaneas
        //  ignora a la masa
        //considera a la masa
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
