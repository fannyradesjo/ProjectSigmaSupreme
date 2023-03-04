using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float startImpulseForce = 6f;
    [SerializeField] float directionImpulseForce = 4f;

    Vector3 direction;
    Vector3 car1Position;
    Vector3 car2Position;
    Vector3 egoPosition;
    GameObject car1;
    GameObject car2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        car1 = GameObject.Find("Car 1");
        car2 = GameObject.Find("Car 2");
        direction = new Vector3(1f, 0f, 0f);
        //rb.AddForce(startImpulseForce * direction, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        car1Position = car1.transform.position;
        car2Position = car2.transform.position;
        egoPosition = rb.transform.position;
        
        if((car1Position - egoPosition).magnitude < (car2Position - egoPosition).magnitude)
        {
            direction = (car1Position - egoPosition).normalized;
        }
        else
        {
            direction = (car2Position - egoPosition).normalized;
        }
        rb.AddForce(directionImpulseForce * direction, ForceMode.Force);
    }

}
