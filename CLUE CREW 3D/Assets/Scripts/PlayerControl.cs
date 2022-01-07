using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 playerVelocity;
    public float playerSpeed = 6f;
    Vector3 move = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horMove = Input.GetAxis("Horizontal");
        float verMove = Input.GetAxis("Vertical");

        Vector3 forward = gameObject.transform.forward;

        if (forward.z > 0f)
        {
            move = new Vector3(horMove, 0f, verMove);
        }
        else if (forward.z < 0f)
        {
            move = new Vector3(horMove, 0f, verMove * -1);
        }
        else if (forward.x > 0f)
        {
            move = new Vector3(verMove, 0f, horMove);
        }
        

        if(forward.z != 0f)
        {
            move = new Vector3(horMove, 0.0f, verMove);
        }
        else if (forward.x != 0f)
        {
            move = new Vector3(verMove, 0.0f, horMove);
        }

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }
}
