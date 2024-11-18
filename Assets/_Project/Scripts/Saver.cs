using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Saver : PersistentSingleton<Saver>
{
    [SerializeField] private GameManager _gameManager;
    
    public void RecordLeaderboard()
    {
        _gameManager.SwicherTimer(true);
        YandexGame.NewLBScoreTimeConvert("LB", YandexGame.savesData.PlayTime);
        Debug.Log("��������� �������");
    }

    public void DeleteSaves()
    {
        YandexGame.ResetSaveProgress();
        Debug.Log("���������� �������");
    }
}
