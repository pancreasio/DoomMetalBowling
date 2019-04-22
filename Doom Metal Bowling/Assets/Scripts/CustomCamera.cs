using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamespace
{
    public class CustomCamera : MonoBehaviour
    {
        public Transform ball, wall;
        public float followX, followY, finalX, finalY;


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
                    transform.position = new Vector3(ball.transform.position.x + followX, ball.transform.position.y + followY, ball.transform.position.z);
                    if (transform.position.y < 5)
                    {
                        mode = false;
                    }
                    if (!ball.gameObject.activeSelf)
                    {
                        mode = false;
                    }

                    break;

                case false:
                    transform.position = new Vector3(wall.transform.position.x + finalX, wall.transform.position.y + finalY, wall.transform.position.z);
                    if (ball.transform.position.y >=0 && ball.gameObject.activeSelf)
                    {
                        mode = true;
                    }
                    break;
            }
            
        }
    }
}