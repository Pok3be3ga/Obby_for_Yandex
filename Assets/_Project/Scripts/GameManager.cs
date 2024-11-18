using TMPro;
using UnityEngine;
using YG;

public class GameManager : MonoBehaviour
{
    public float Timer;
    private bool _active = false;
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    PlatformChecker platformChecker;

    private float _lastUpdateTime = 0.0f;

    void Start()
    {
        YandexGame.GameplayStart();
        Timer = YandexGame.savesData.PlayTime;
        SwicherTimer(true);
        platformChecker = FindObjectOfType<PlatformChecker>();
        platformChecker.CheckPlatform();
    }

    void Update()
    {
        if (_active == true)
            DisplayTimer();
    }

    public void SwicherTimer(bool _bool)
    {
        _active = _bool;
    }

    private void DisplayTimer()
    {
        Timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(Timer / 60);
        int seconds = Mathf.FloorToInt(Timer % 60);
        _textMeshPro.text = $"{minutes:D2}:{seconds:D2}";

        //if (Time.time >= _lastUpdateTime + 1.2f)
        //{
        //    YandexGame.savesData.PlayTime = Timer;
        //    YandexGame.NewLBScoreTimeConvert("LB", Timer);
        //    YandexGame.SaveProgress();
        //    _lastUpdateTime = Time.time;
        //}
    }
}
