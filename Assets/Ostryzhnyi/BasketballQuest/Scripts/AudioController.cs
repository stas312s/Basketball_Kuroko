using UnityEngine;
using UnityEngine.UI;

namespace Ostryzhnyi.BasketballQuest.Scripts
{
    public class AudioController : MonoBehaviour
    {
        public Sprite audioOn;
        public Sprite audioOff;
        public GameObject buttonAudio;
    
        public Slider slider;
    
        public AudioClip clip;
    
        void Start()
        {
            slider.value = BackgroundSound.instance.Audio.volume;
            slider.onValueChanged.AddListener(ChangeVolume);  
        }
    
        private void OnDestroy()
        {
            slider.onValueChanged.RemoveListener(ChangeVolume);
        }
    
        void ChangeVolume(float value)
        {
            BackgroundSound.instance.Audio.volume = value;
            SliderSound();
        }
    
        private void SliderSound()
        {
            if (slider.value == 0)
            {
                buttonAudio.GetComponent<Image>().sprite = audioOff;
                AudioListener.volume = 0;
            }
            else if (slider.value > 0)
            {
                buttonAudio.GetComponent<Image>().sprite = audioOn;
                AudioListener.volume = slider.value;
            }
        }
    
        public void OnOffAudio()
        {
            if (AudioListener.volume == 1)
            {
                AudioListener.volume = 0;
                buttonAudio.GetComponent<Image>().sprite = audioOff;
            }
            else
            {
                AudioListener.volume = 1;
                buttonAudio.GetComponent<Image>().sprite = audioOn;
            }
        }
    
        public void PlaySound()
        {
            BackgroundSound.instance.Audio.PlayOneShot(clip);
        }
    }
}


