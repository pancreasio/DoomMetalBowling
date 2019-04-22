using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace gamespace
{
    public class GameManager : MonoBehaviour
    {
        enum state
        {
            menu, game
        };

        static GameObject managerInstance;

        public AudioSource[] trackArray;
        public GameObject[] pineArray;

        private bool loop;
        private bool noPines;
        private int pineCount;
        private state gamestate;

        void Awake()
        {
            if (this.gameObject != managerInstance && managerInstance != null)
            {
                Destroy(this.gameObject);
            }
        }

        public void loadMenu()
        {
            SceneManager.LoadScene("menu", LoadSceneMode.Single);
        }
        public void loadGame()
        {
            SceneManager.LoadScene("game", LoadSceneMode.Single);
        }

        public void exitGame()
        {
            Application.Quit();
        }

        void Start()
        {
            managerInstance = this.gameObject;

            if (SceneManager.GetActiveScene().name == "game")
            {
                gamestate = state.game;
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

            if (SceneManager.GetActiveScene().name == "menu")
            {
                gamestate = state.menu;
            }
        }
        void Update()
        {
            if (gamestate == state.game)
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
                    if (!pineArray[i].gameObject.activeSelf)
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
}