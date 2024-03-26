using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parchoc : MonoBehaviour
{

    private bool speed;

    [SerializeField] CameraShake shaking;
    [SerializeField] Vector2 cameraShakeValue;
    [SerializeField] GameObject explosion;


    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = true;
        }
        else
        {
            speed = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (speed)
        {
        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        shaking.Shaker(cameraShakeValue.x, cameraShakeValue.y);
        }
    }
}
