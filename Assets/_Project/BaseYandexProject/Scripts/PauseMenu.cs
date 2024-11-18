using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Image _panel;
    [SerializeField] GameObject _mobileUI;
    [SerializeField] Button _button;
    [SerializeField] Button _homeButton;
    [SerializeField] Button _MobileButton;
    [SerializeField] Button _resetSceneButton;
    [SerializeField] GameManager _gameManager;
    private void Start()
    {
        _button.onClick.AddListener(PanelActive);
        _homeButton.onClick.AddListener(Home);
        _MobileButton.onClick.AddListener(() => 
        { _mobileUI.SetActive(!_mobileUI.active); });
        _resetSceneButton.onClick.AddListener(ResetScene);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PanelActive();
        }
    }
    private void PanelActive()
    {
        _panel.gameObject.SetActive(!_panel.gameObject.active);

        if(_panel.gameObject.active == false)
            Time.timeScale = 1.0f;
        else
            Time.timeScale = 0.0f;
    }
    private void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    private void ResetScene()
    {
        YandexGame.ResetSaveProgress();

        string sceneName = SceneManager.GetActiveScene().name;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneName);
    }
}
