using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Photon.Pun;
using Photon.Realtime;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {

        //public CarController controller;
        private CarController m_Car; // the car controller we want to use
        PhotonView view;
        
        private void Start()
        {
            view = GetComponent<PhotonView>();

        }

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }
       

        private void FixedUpdate()
        {
            if (view.IsMine)
            {
                    // pass the input to the car!
                    float h = CrossPlatformInputManager.GetAxis("Horizontal");
                    float v = CrossPlatformInputManager.GetAxis("Vertical");
                    float handbrake = CrossPlatformInputManager.GetAxis("Jump");
                    m_Car.Move(h, v, v, handbrake);

                    m_Car.Move(h, v, v, 0f);              
            }else
            {
                Destroy (m_Car);

            }
        }

    }
}
