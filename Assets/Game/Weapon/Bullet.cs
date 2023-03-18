using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] 
    public float _Force = 50f;
    public Rigidbody _Rb;
    public ParticleSystem _ImpactParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        _Rb = GetComponent<Rigidbody>();
        _Rb.AddForce(transform.forward * _Force, ForceMode.Impulse);
        Destroy(gameObject, 2f);
    }

    void OnCollisionEnter(Collision col)
    {
        ContactPoint contact = col.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        var clone = Instantiate(_ImpactParticleSystem, pos, rot);
        clone.transform.forward = col.transform.forward;
        clone.Play();
        Destroy(clone, 2f);
        Destroy(gameObject);
    }

}
