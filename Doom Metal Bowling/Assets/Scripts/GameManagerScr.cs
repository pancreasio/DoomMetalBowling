using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamespace
{
    public class GameManagerScr : MonoBehaviour
    {
        public AudioSource[] trackArray;
        public GameObject[] pineArray;

        private bool loop;
        private bool noPines;
        private int pineCount;
        void Start()
        {
            trackArray[0].loop = true;
            trackArray[1].loop = false;
            trackArray[2].loop = false;
            trackArray[1].Stop();
            trackArray[2].Stop();
            trackArray[0].Play();
            loop = true;
            noPines = false;
            pineCount = pineArray.Length;
        }
        void Update()
        {
            if (pineCount == 0)
            {
                trackArray[0].Stop();
                if (!trackArray[1].isPlaying && loop)
                {
                    trackArray[1].Play();
                    loop = false;
                }
            }
            if (!noPines)
            {
                pineCount = pineArray.Length;
            }
            for (int i = 0; i < pineArray.Length; i++)
            {
                if (pineArray[i] == null)
                {
                    pineCount--;
                }
                if (pineCount <= 0)
                {
                    noPines = true;
                }
            }

        }
    }
}