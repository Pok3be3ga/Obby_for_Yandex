using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float Timer;
    private bool _stop = true;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    void Start()
    {
        
    }
    void Update()
    {
        if (_stop != true)
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
    }
}
