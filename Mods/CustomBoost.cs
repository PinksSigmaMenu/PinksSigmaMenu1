using UnityEngine;

namespace PinkMenu.Mods
{
    internal class CustomBoost : MonoBehaviour
    {
        private static readonly float boostIncrement = 2f; 
        private static readonly float initialBoost = 15f;  

        public static float CurrentMaxJumpSpeed { get; private set; } = initialBoost;
        public static float CurrentJumpMultiplier { get; private set; } = initialBoost;

        private void Start()
        {
            GorillaLocomotion.Player.Instance.maxJumpSpeed = initialBoost;
            GorillaLocomotion.Player.Instance.jumpMultiplier = initialBoost;
        }

        private void Update()
        {
            GripSpeedBoost();
        }

        public static void SetCustomBoost(float customBoostValue)
        {
            CurrentMaxJumpSpeed = customBoostValue;
            CurrentJumpMultiplier = customBoostValue;
            UpdatePlayerBoost();
        }

        public static void GripSpeedBoost()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                CurrentMaxJumpSpeed += boostIncrement * Time.deltaTime;
                CurrentJumpMultiplier += boostIncrement * Time.deltaTime;
            }
            else if (ControllerInputPoller.instance.leftGrab)
            {
                CurrentMaxJumpSpeed -= boostIncrement * Time.deltaTime;
                CurrentJumpMultiplier -= boostIncrement * Time.deltaTime;
            }

            UpdatePlayerBoost();
        }

        private static void UpdatePlayerBoost()
        {
            GorillaLocomotion.Player.Instance.maxJumpSpeed = CurrentMaxJumpSpeed;
            GorillaLocomotion.Player.Instance.jumpMultiplier = CurrentJumpMultiplier;
        }
    }
}
