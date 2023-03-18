using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] 
    public GameObject _BallSpwanPoint;
    [SerializeField] 
    public GameObject _Ball;
    [SerializeField]
    public int _MaxAmmo;
    [SerializeField]
    public float _ReloadTimer = 2f;
    [SerializeField]
    public int _initAmmo = 10;


    private float _StartTimeReload;
    private bool _CanShot = true;
    private int _CurrentAmmo;

    void start()
    {
        _CurrentAmmo = _initAmmo;
    }

    // Update is called once per frame
    void Update()
    {

        if (_CurrentAmmo > 0 && _CanShot)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                _CanShot = false;
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(_Ball, _BallSpwanPoint.transform.position, _BallSpwanPoint.transform.rotation);
                _CurrentAmmo--;
            }
        }
        else
        {
            if (_StartTimeReload >= _ReloadTimer)
            {
                _CanShot = true;
                _StartTimeReload = 0;
                _CurrentAmmo = _initAmmo;
            }
            else
            {
                _CanShot = false;
                _StartTimeReload += Time.deltaTime;
            }
        }
    }
}
