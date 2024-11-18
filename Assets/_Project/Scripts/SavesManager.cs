using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class SavesManager : PersistentSingleton<SavesManager>
{
    [SerializeField] private GameManager _gameManager;
    
    public void RecordLeaderboard()
    {
        _gameManager.SwicherTimer(true);
        YandexGame.NewLBScoreTimeConvert("LB", YandexGame.savesData.PlayTime);
        Debug.Log("Лидерборд записан");
    }

    public void DeleteSaves()
    {
        YandexGame.ResetSaveProgress();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Сохранения удалены");
    }
}
