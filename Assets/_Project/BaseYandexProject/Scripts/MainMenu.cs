using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Slider _loadSlider;
    // Start is called before the first frame update
    void Start()
    {
        _playButton.onClick.AddListener(StartGame);

    }
    private void StartGame()
    {
        StartCoroutine(LoadYourAsyncScene());
    }
    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        _loadSlider.gameObject.SetActive(true);
        while (!asyncLoad.isDone)
        {
            _loadSlider.value = asyncLoad.progress;
            yield return null;
        }
    }
}
