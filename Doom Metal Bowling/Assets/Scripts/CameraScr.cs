using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamespace
{
    public class CameraScr : MonoBehaviour
    {
        public Transform ball, wall;

        private Transform initial;
        private bool mode;
        void Start()
        {
            initial = transform;

        }

        void Update()
        {
            switch (mode)
            {
                case true:
                    transform.position = new Vector3(ball.transform.position.x - 8.3f, ball.transform.position.y + 6.17f, ball.transform.position.z);
                    if (transform.position.y < 5)
                    {
                        mode = false;
                    }
                    break;

                case false:
                    transform.position = new Vector3(wall.transform.position.x - 17, wall.transform.position.y + 6.17f, wall.transform.position.z);
                    if (ball.transform.position.y >=0)
                    {
                        mode = true;
                    }
                    break;
            }
            
        }
    }
}