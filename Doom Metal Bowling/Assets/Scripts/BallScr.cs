using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace gamespace
{
    public class BallScr : MonoBehaviour
    {
        private bool mode;
        private float initialForce;
        private float xAxis;
        private Transform initial;

        public float rotationSpeed;
        public float rightLimit;
        public float leftLimit;
        public float forceLimit;
        public float transSpeed;
        public float modifier;
        public int lives;

        public GameObject explosion;

        void Start()
        {
            mode = false;
            xAxis = transform.position.z;
            initialForce = 0;
        }

        void Update()
        {
            switch (mode)
            {
                case true:
                    transform.GetComponent<Rigidbody>().useGravity = true;
                    transform.Rotate(new Vector3(0, 0, -initialForce));
                    transform.GetComponent<Rigidbody>().AddForce(new Vector3(initialForce*modifier,0,0));
                    break;

                case false:
                    transform.GetComponent<Rigidbody>().useGravity = false;
                    transform.Rotate(new Vector3(0, 0, -initialForce));
                    if (Input.GetKey(KeyCode.Space))
                    {
                        mode = true;
                    }
                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        if (xAxis>leftLimit)
                        {
                            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + transSpeed * Time.deltaTime);
                            xAxis -= transSpeed * Time.deltaTime;
                        }
                    }
                    if (Input.GetKey(KeyCode.RightArrow))
                    {
                        if (xAxis<rightLimit)
                        {
                            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - transSpeed * Time.deltaTime);
                            xAxis += transSpeed * Time.deltaTime;
                        }
                    }
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        if (initialForce < forceLimit)
                        {
                            initialForce += rotationSpeed * Time.deltaTime;
                        }
                    }
                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        if (initialForce >0)
                        {
                            initialForce -= rotationSpeed * Time.deltaTime;
                        }
                    }
                    break;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == "Wall")
            {
                Instantiate(explosion);
                gameObject.SetActive(false);
            }
        }
    }
}