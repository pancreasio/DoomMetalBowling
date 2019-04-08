using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamespace
{
    public class PineScr : MonoBehaviour
    {
        public Transform pineObject;
        public AudioSource explosion;

        private void Update()
        {
            if (transform.position.y <= 0)
            {
                Instantiate(explosion);
                explosion.transform.SetParent(null);
                pineObject.gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Wall" || other.tag == "Floor")
            {
                Instantiate(explosion);
                explosion.transform.SetParent(null);
                pineObject.gameObject.SetActive(false);
            }
        }
    }
}
