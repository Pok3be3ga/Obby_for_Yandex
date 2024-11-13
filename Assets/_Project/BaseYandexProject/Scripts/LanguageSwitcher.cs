using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LanguageSwitcher : MonoBehaviour
{
    [SerializeField] private Button _switchButton;
    [SerializeField] private Image _flagImage;
    [SerializeField] private List<Language> _languagelist;

    private int _currentLanguageNumber = 0;

    private void OnEnable()
    {
        _switchButton.onClick.AddListener(SwitchLanguage);
        YandexGame.GetDataEvent += GetStartLanguage;
    }

    private void GetStartLanguage()
    {
        string startLanguage = YandexGame.savesData.language;
        if (!string.IsNullOrEmpty(startLanguage))
        {
            for (int i = 0; i < _languagelist.Count; i++)
            {
                if (_languagelist[i].Name.ToString() == startLanguage)
                {
                    _currentLanguageNumber = i;
                    SelectLanguageFromList(_currentLanguageNumber);
                    break;
                }
            }
        }
    }

    private void SwitchLanguage()
    {
        if (_currentLanguageNumber + 1 >= _languagelist.Count)
            _currentLanguageNumber = 0;
        else
            _currentLanguageNumber++;

        SelectLanguageFromList(_currentLanguageNumber);
    }

    private void SelectLanguageFromList(int languageNumber)
    {
        _flagImage.sprite = _languagelist[languageNumber].Flag;
        YandexGame.SwitchLanguage(_languagelist[languageNumber].Name.ToString());
    }

    private void OnDisable()
    {
        _switchButton.onClick.RemoveListener(SwitchLanguage);
        YandexGame.GetDataEvent -= GetStartLanguage;
    }
}

[System.Serializable]
public class Language
{
    public LanguageName Name;
    public Sprite Flag;
}

public enum LanguageName
{
    ru, en, tr
}