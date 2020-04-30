using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Valve.VR.InteractionSystem
{
    public class DoorControl : MonoBehaviour
    {
        public GameObject door;
        public GameObject gameMode;

        public TextMeshPro timeText;

        public bool countdown;
        public string currentTime;
        public string startTime;

        public bool doorClosed;

        // Start is called before the first frame update
        void Start()
        {
            doorClosed = false;
            countdown = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (countdown == true)
            {
                timeText.text = Time.time.ToString("f2");
            }

        }

        public void DoorActivator()
        {
            doorClosed = !doorClosed;

            startTime = Time.time.ToString("f2");
            countdown = !countdown;

            if (doorClosed)
            {
                door.SetActive(true);
                gameMode.SetActive(true);
            }
            else
            {
                door.SetActive(false);
                gameMode.SetActive(false);
            }
        }
    }
}
