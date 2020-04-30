using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Valve.VR.InteractionSystem
{
    public class SimpleShoot : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public GameObject casingPrefab;
        public GameObject muzzleFlashPrefab;
        public Transform barrelLocation;
        public Transform casingExitLocation;
        private GameObject bullet;

        public SteamVR_Action_Boolean fire = SteamVR_Input.GetBooleanAction("default", "Grab Pinch");
        public SteamVR_Action_Boolean reload = SteamVR_Input.GetBooleanAction("default", "Reload");
        private SteamVR_Input_Sources hand;
        private Interactable interactable;

        public MoveScript ms;
        public LockToPoint ltp;

        private float defShotPower = 2400f;
        public float shotPower = 2400f;

        public int magazine = 13;
        public int magSize = 12;

        void Start()
        {
            if (barrelLocation == null)
                barrelLocation = transform;

            interactable = GetComponent<Interactable>();
        }

        void Update()
        {
            if (interactable.attachedToHand)
            {
                ltp.enabled = false;
                hand = interactable.attachedToHand.handType;

                if (fire.GetStateDown(hand) && magazine > 0)
                {
                    Shoot();
                    CasingRelease();
                }
                if (reload.GetStateDown(SteamVR_Input_Sources.RightHand))
                {
                    magazine = magSize;
                }
            }
            else
            {
                ltp.enabled = true;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                GetComponent<Animator>().SetTrigger("Fire");
            }
        }

        void Shoot()
        {
            //  GameObject bullet;
            //  bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
            // bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

            if (ms.timeSlowEnabled == true)
            {
                shotPower = shotPower / ms.slowTimeScale;
            }
            else
            {
                shotPower = defShotPower;
            }

            GameObject tempFlash;
            bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            magazine--;

            Destroy(bullet, 2.0f);
            Destroy(tempFlash, 2.0f);

            // Destroy(tempFlash, 0.5f);
            //  Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation).GetComponent<Rigidbody>().AddForce(casingExitLocation.right * 100f);

        }

        void CasingRelease()
        {
            GameObject casing;
            casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
            casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
            casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
            casing.GetComponent<Rigidbody>().useGravity = true;

            Destroy(casing, 2.0f);
        }
    }
}
