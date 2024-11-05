using TMPro;
using UnityEngine;
using YG;

public class GameManager : MonoBehaviour
{
    public float Timer;
    private bool _stop = true;
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private float _updateInterval = 1.0f;
    private float _lastUpdateTime = 0.0f;

    void Start()
    {
        Timer = YandexGame.savesData.PlayTime;
    }

    void Update()
    {
        if (!_stop)
            DisplayTimer();
    }

    public void SwicherTimer(bool _bool)
    {
        _stop = _bool;
    }

    private void DisplayTimer()
    {
        Timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(Timer / 60);
        int seconds = Mathf.FloorToInt(Timer % 60);
        _textMeshPro.text = $"{minutes:D2}:{seconds:D2}";

        if (Time.time >= _lastUpdateTime + _updateInterval)
        {
            YandexGame.savesData.PlayTime = Timer;
            YandexGame.SaveProgress();
            _lastUpdateTime = Time.time;
        }
    }
}
