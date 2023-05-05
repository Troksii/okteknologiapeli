using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killenemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D info)
    {
        Debug.Log(info.name);

        if (info.gameObject.CompareTag("Enemy"))
        {
            Destroy (info.gameObject);
            Destroy(gameObject);
        }
}

}