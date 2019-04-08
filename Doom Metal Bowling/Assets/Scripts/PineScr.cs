using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamespace
{
    public class PineScr : MonoBehaviour
    {
        void Update()
        {
            //if (transform.rotation.eulerAngles.x > 70 || transform.rotation.eulerAngles.x < -70)
            //{
            //    Destroy(this.gameObject);
            //}

            if (transform.rotation.eulerAngles.z > 90 || transform.rotation.eulerAngles.z < -90)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
