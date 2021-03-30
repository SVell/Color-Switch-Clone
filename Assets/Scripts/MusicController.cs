using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorSwitch.Audio 
{
    public class MusicController : MonoBehaviour
    {
        public static MusicController Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
