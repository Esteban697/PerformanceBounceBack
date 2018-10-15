using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour {

    // Disable the ball every half a second if not touched by player
    void OnEnable()
    {
        InvokeRepeating("DisableBall", 10f, 0.5f);
    }
    // Disable the untouched ball is it goes out of valid floor area
    void DisableBall()
    {
        if (gameObject.transform.position.z < -10.0f 
            || gameObject.transform.position.z > 10.0f
            || gameObject.transform.position.x < -10.0f
            || gameObject.transform.position.x > 10.0f)
        {
            gameObject.SetActive(false);
            CancelInvoke();
        }
    }

    //if the ball is touched by controllers a different disbabling criteria is applied
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "Controller (left)" || col.gameObject.name == "Controller (right)")
        {
            CancelInvoke();
            InvokeRepeating("DisableThrownBall", 1f, 5f);
        }
    }
    //Disabling the thrown balls that goes out of bounds every 5 seconds
    void DisableThrownBall()
    {
        if (gameObject.transform.position.z < -30.0f
            || gameObject.transform.position.z > 20.0f
            || gameObject.transform.position.x < -30.0f
            || gameObject.transform.position.x > 20.0f)
        {
            gameObject.SetActive(false);
            CancelInvoke();
            Debug.Log("Thrown Ball returned to Pool");
        }
    }
}
