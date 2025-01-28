using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class SavesManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    [ContextMenu("Record Leaderboard")]
    public void RecordLeaderboard()
    {
        //_gameManager.SwicherTimer(true);
        YandexGame.NewLBScoreTimeConvert("LB", _gameManager.Timer);
        Debug.Log("Лидерборд записан");
    }

    public void DeleteSaves()
    {
        YandexGame.ResetSaveProgress();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Сохранения удалены");
    }
}
