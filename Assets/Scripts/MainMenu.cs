using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private Image _soundButton;
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;
    [SerializeField] private AudioSource _source;

    [Header("Panels")]
    [SerializeField] private GameObject _characterPanel;
    [SerializeField] private GameObject _gamePanel;


    [SerializeField] private Text _langText;
    private bool _hasSound = true;
    [SerializeField] private string[] _languages;
    private int _currentLanguageInt;
    [SerializeField] private string _currentLanguage;

    private void Start()
    {
        YandexGame.GameReadyAPI();
        _hasSound = YandexGame.savesData.HasSound;
        _source.mute = !_hasSound;
        _soundButton.sprite = (_hasSound ? _soundOn : _soundOff);

        _currentLanguage = YandexGame.savesData.language;

    }

    public void ChangeSound()
    {
        if (_hasSound)
        {
            _hasSound = false;
            _soundButton.sprite = _soundOff;
        }
        else
        {
            _hasSound = true;
            _soundButton.sprite = _soundOn;
        }
        _source.mute = !_hasSound;

        YandexGame.savesData.HasSound = _hasSound;
        YandexGame.SaveProgress();
    }

    public void ChangeLanguage()
    {
        if (_currentLanguageInt == _languages.Length - 1)
        {
            _currentLanguageInt = 0;
        }
        else
        {
            _currentLanguageInt++;
        }
        LangFromInt();
    }

    public void CharacterPanel()
    {
        if (_characterPanel.activeInHierarchy)
        {
            _characterPanel.SetActive(false);
        } 
        else 
        { 
            _characterPanel.SetActive(true); 
        }
    }

    public void DeleteSaveData()
    {
        YandexGame.ResetSaveProgress();
    }

    public void StartGame()
    {
        _gamePanel.SetActive(true);
        gameObject.SetActive(false);
    }

    private void LangFromInt()
    {
        _currentLanguage = _languages[_currentLanguageInt];
        YandexGame.savesData.language = _currentLanguage;
        YandexGame.SaveProgress();
        YandexGame.SwitchLanguage(_currentLanguage);
        _langText.text = _currentLanguage;
    }


}
