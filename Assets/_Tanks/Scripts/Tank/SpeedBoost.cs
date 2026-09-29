using Tanks.Complete;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Tanks.Scripts.Tank
{
    public class SpeedBoost : MonoBehaviour
    {
    
        public int boostAmount = 2;
        public float boostDuration = 3;
        public float boostRecover = 3;
        private bool canBoost = true;
        private TankMovement tankMovement;
    
        private InputAction boostAction;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            tankMovement = GetComponent<TankMovement>();
        
            boostAction = tankMovement.m_InputUser.ActionAsset.FindAction("SpeedBoost");
            boostAction.Enable();
        }

        // Update is called once per frame
        void Update()
        {
            if (canBoost && boostAction.IsPressed())
            {
                Boost();
            }
        }
    
        void Boost()
        {
            canBoost = false;
            tankMovement.m_Speed *= boostAmount;
            Invoke(nameof(StopBoost), boostDuration);
        }
    
        void  StopBoost()
        {
            tankMovement.m_Speed /= boostAmount;
            Invoke(nameof(RecoverBoost), boostRecover);
        }
    
        void RecoverBoost()
        {
            canBoost = true;
        }
    }
}
