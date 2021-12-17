using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : MonoBehaviourPun
{
    public float speed;
    PhotonView view;

    //[SerializeField] CarController controller;
    Vector2 horizontalInput;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (view.IsMine)
        {
            //Vector3 = GetComponent<CarSwitch>
            //controller.Move(horizontalVelocity * Time.deltaTime);
            ////Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            ////Vector3 moveAmount = moveInput.normalized * speed * Time.deltaTime;
            ////transform.position += (Vector3)moveAmount;
        }
    }
}
