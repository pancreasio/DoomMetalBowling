using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamespace
{
    public class Pine : MonoBehaviour
    {
        public Transform pineObject;
        public GameObject explosion;

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
