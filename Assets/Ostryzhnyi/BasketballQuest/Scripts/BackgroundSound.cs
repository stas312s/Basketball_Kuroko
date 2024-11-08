using UnityEngine;

namespace Ostryzhnyi.BasketballQuest.Scripts
{
    public class BackgroundSound : MonoBehaviour
    {
        public static BackgroundSound instance;
        public AudioSource audio;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
    }
}


