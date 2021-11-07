using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropManager : MonoBehaviour
{
    public GameObject physicable;
    Rigidbody rigidBody;
    public bool falling;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = physicable.GetComponent<Rigidbody>();
        rigidBody.isKinematic = true;
        falling = false;
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void EnableRigidBody()
    {
        rigidBody.isKinematic = false;
        falling = true;
    }

    
}
