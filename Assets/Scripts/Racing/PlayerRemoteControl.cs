using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRemoteControl : MonoBehaviour
{
    [Header("Input variables")]
    public float forwards;
    public float turn;
    CarController myCarController;
    // Start is called before the first frame update
    void Awake()
    {
        myCarController = GetComponent<CarController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            forwards = Input.GetAxis("Vertical");
        if (Input.GetAxis("Horizontal") != 0)
        {
            turn = Input.GetAxis("Horizontal");
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            turn = 0;
        }

        myCarController.ChangeSpeed(forwards);
        myCarController.Turn(turn);
    }
}
