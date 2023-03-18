using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _Force = 50f;
    public Rigidbody rb;
    public ParticleSystem ImpactParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * _Force, ForceMode.Impulse);
        Destroy(gameObject, 2f);
    }

    void OnCollisionEnter(Collision col)
    {
        //if (col.gameObject.name != "PlayerCapsule" && col.gameObject.name != "Capsule")
        //{
        Debug.Log(col.transform.position);
        Debug.Log(col.gameObject.name);
            Instantiate(ImpactParticleSystem, col.transform.position, col.transform.rotation);
            ImpactParticleSystem.Play();
            Destroy(gameObject);
        //}
    }

}
