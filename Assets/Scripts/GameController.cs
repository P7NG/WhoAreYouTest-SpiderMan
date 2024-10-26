using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class GameController : MonoBehaviour
{
    [SerializeField] private Text _questionsCount;
    [SerializeField] private Sprite[] _characterPhoto;
    [SerializeField] private string[] _nameRu;
    [SerializeField] private string[] _nameEn;
    [SerializeField] private string[] _nameTr;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private Image _photo;
    [SerializeField] private Text _name;
    [SerializeField] private Sprite[] _emoji;
    [SerializeField] private Image _leftImage;
    [SerializeField] private Image _rightImage;

    [SerializeField] GameObject MainMenu;

    private int _currentQuestion = 1;

    private void Start()
    {
        _currentQuestion = 1;
        _questionsCount.text = _currentQuestion + " / 10";
        CreateQuestion();
    }

    private void CreateQuestion()
    {
        _leftImage.sprite = _emoji[Random.Range(0, _emoji.Length - 1)];
        _rightImage.sprite = _emoji[Random.Range(0, _emoji.Length - 1)];
    }

    public void GetAnswer()
    {
        _currentQuestion++;
        _questionsCount.text = _currentQuestion + " / 10";

        if(_currentQuestion == 11)
        {
            YandexGame.FullscreenShow();
            End();
        }
        else
        {
            CreateQuestion();
        }
    }

    private void End()
    {
        _endScreen.SetActive(true);

        int _character = Random.RandomRange(0, 6);

        if (!YandexGame.savesData.OpenCharacters[_character])
        {
            YandexGame.savesData.OpenCharacters[_character] = true;
            YandexGame.SaveProgress();
        }

        _photo.sprite = _characterPhoto[_character];
        _name.text = NameToLanguage(_character);
        _currentQuestion = 1;
        _questionsCount.text = _currentQuestion + " / 10";
        CreateQuestion();
    }

    public void ReturnToMainMenu()
    {
        _endScreen.SetActive(false);
        MainMenu.SetActive(true);

        this.gameObject.SetActive(false);
    }

    private string NameToLanguage(int charNumber)
    {
        if (YandexGame.lang == "ru")
        {
            return _nameRu[charNumber];
        }
        else if (YandexGame.lang == "en")
        {
            return _nameEn[charNumber];
        }
        else if (YandexGame.lang == "tr")
        {
            return _nameTr[charNumber];
        }
        else
        {
            return null;
        }
    }
}
