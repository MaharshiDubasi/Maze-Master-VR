using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace Valve.VR.InteractionSystem
{
    public class MoveScript : MonoBehaviour
    {
        Player player;
        private float _mMoveSpeed = 3.5f;
        private float _mJumpSpeed = 6.0f;
        private float _mHorizontalTurnSpeed = 180f;
        private float _mVerticalTurnSpeed = 2.5f;
        private bool _mInverted = false;
        private const float VERTICAL_LIMIT = 60f;
        private Rigidbody playerRB;

        public bool m_IsGrounded;
        private float m_GroundCheckDistance = 0.4f;

        public SteamVR_Action_Vector2 moveForward = SteamVR_Input.GetVector2Action("default", "MoveForward");
        public SteamVR_Action_Boolean jump = SteamVR_Input.GetBooleanAction("default", "Jump");
        public SteamVR_Action_Boolean slowTime = SteamVR_Input.GetBooleanAction("default", "SlowTime");

        private Collider playerCollider;

        public bool timeSlowEnabled = false;

        public float slowTimeScale = .2f;

        private void Start()
        {
            player = Player.instance;
            if (!player)
            {
                return;
            }
            else
            {
                playerRB = player.GetComponent<Rigidbody>();
            }

            playerCollider = GameObject.FindGameObjectWithTag("Player Collider").GetComponent<Collider>();
        }

        // Update is called once per frame
        void Update()
        {
            if (null != player.leftHand)
            {
                Quaternion orientation = Camera.main.transform.rotation;
                var touchPadVector = moveForward.GetAxis(SteamVR_Input_Sources.LeftHand);

                Vector3 moveDirection = orientation * Vector3.forward * touchPadVector.y + orientation * Vector3.right * touchPadVector.x;
                Vector3 pos = player.transform.position;
                pos.x += moveDirection.x * _mMoveSpeed * Time.deltaTime;
                pos.z += moveDirection.z * _mMoveSpeed * Time.deltaTime;

                // && CheckGroundStatus()

                if (jump.GetStateDown(SteamVR_Input_Sources.LeftHand))
                {

                    playerRB.velocity = new Vector3(playerRB.velocity.x, _mJumpSpeed, playerRB.velocity.z);
                }

                player.transform.position = pos;
            }

            if (slowTime.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                if(timeSlowEnabled == false)
                {
                    Time.timeScale = slowTimeScale;
                    Time.fixedDeltaTime = Time.fixedDeltaTime * slowTimeScale;
                    timeSlowEnabled = true;
                }

                else if(timeSlowEnabled == true)
                {
                    Time.timeScale = 1f;
                    //Time.fixedDeltaTime = 0.02f;
                    timeSlowEnabled = false;
                }
            }
        }

        bool CheckGroundStatus()
        {
            RaycastHit hitInfo;
            var testPosition = transform.position;

            return Physics.Raycast(testPosition, Vector3.down, out hitInfo, m_GroundCheckDistance);
        }
    }
}

