using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _Force = 50f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * _Force, ForceMode.Impulse);
        Destroy(gameObject, 2f);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name != "PlayerCapsule" && col.gameObject.name != "Capsule")
        {
            Destroy(gameObject);
        }
    }

}
