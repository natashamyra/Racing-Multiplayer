using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam.Data
{
    [CreateAssetMenu(fileName = "CarData", menuName = "Game Jam/Car Data", order = 2)]
    public class CarScriptableObjects : ScriptableObject
    {
        public enum  EDriveTrain
        {
            FWD = 0,
            RWD = 1,
            AWD = 2
        }

        public enum  ETransmissionType
        {
            Manual = 0,
            Automatic = 1
        }
        
        [Header("Basic Information")]
        [SerializeField] private string _carModel;
        [SerializeField] private string _carMake;
        [SerializeField] private int _carYear;
        
        [Header("Technical Information")]
        [SerializeField] private EDriveTrain _driveTrain;
        [SerializeField] private int _carPower;
        [SerializeField] private int _transmissionSpeed;
        [SerializeField] private ETransmissionType _transmissionType;
        [SerializeField] private int _carWeight;
        [SerializeField] private int _engineCc;

        public string CarModel => _carModel;
        public string CarMake => _carMake;
        public int CarYear => _carYear;
        public EDriveTrain DriveTrain => _driveTrain;
        public int CarPower => _carPower;
        public int TranmissionSpeed => _transmissionSpeed;
        public ETransmissionType TransmissionType => _transmissionType;
        public int CarWeight => _carWeight;
        public int EngineCC => _engineCc;
    }
}