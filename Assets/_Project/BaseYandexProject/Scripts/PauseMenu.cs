using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Image _panel;
    [SerializeField] Button _button;
    [SerializeField] Button _homeButton;
    private void Start()
    {
        _button.onClick.AddListener(PanelActive);
        _homeButton.onClick.AddListener(Home);
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
    }
}
