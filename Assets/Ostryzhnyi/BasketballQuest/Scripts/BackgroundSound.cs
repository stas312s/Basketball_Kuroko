using UnityEngine;

namespace Ostryzhnyi.BasketballQuest.Scripts
{
    public class BackgroundSound : MonoBehaviour
    {
        public static BackgroundSound instance;
        public AudioSource Audio;

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


