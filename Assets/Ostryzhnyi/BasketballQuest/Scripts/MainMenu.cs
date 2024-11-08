using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ostryzhnyi.BasketballQuest.Scripts
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _settingsPanel;
        [SerializeField] private GameObject _mainMenuPanel;


        public void PlayGame()
        {
            SceneManager.LoadScene(1);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void SettingsPanel()
        {
            _mainMenuPanel.SetActive(false);
            _settingsPanel.SetActive(true);
        }

        public void Exit()
        {
            _mainMenuPanel.SetActive(true);
            _settingsPanel.SetActive(false);
        }

    }
}
