using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] private Sprite[] _characterPhoto;
    [SerializeField] private Image[] _portraitPlaces;
    [SerializeField] private string[] _nameRu;
    [SerializeField] private string[] _nameEn;
    [SerializeField] private string[] _nameTr;
    [SerializeField] private Text[] _namePlaces;
    [SerializeField] private Sprite _unknownImage;
    [SerializeField] GameObject _mainMenu;

    public void OnEnable()
    {
        bool[] chars = YandexGame.savesData.OpenCharacters;

        if (YandexGame.lang == "ru")
        {
            for (int i = 0; i < _nameRu.Length; i++)
            {
                if (chars[i])
                {
                    _namePlaces[i].text = _nameRu[i];
                    _portraitPlaces[i].sprite = _characterPhoto[i];
                }
                else
                {
                    _namePlaces[i].text = "???";
                    _portraitPlaces[i].sprite = _unknownImage;
                }
            }
        }
        else if (YandexGame.lang == "en")
        {
            for (int i = 0; i < _nameEn.Length; i++)
            {
                if (chars[i])
                {
                    _namePlaces[i].text = _nameEn[i];
                    _portraitPlaces[i].sprite = _characterPhoto[i];
                }
                else
                {
                    _namePlaces[i].text = "???";
                    _portraitPlaces[i].sprite = _unknownImage;
                }
            }
        }
        else if (YandexGame.lang == "tr")
        {
            for (int i = 0; i < _nameTr.Length; i++)
            {
                if (chars[i])
                {
                    _namePlaces[i].text = _nameTr[i];
                    _portraitPlaces[i].sprite = _characterPhoto[i];
                }
                else
                {
                    _namePlaces[i].text = "???";
                    _portraitPlaces[i].sprite = _unknownImage;
                }
            }
        }
    }

    public void Return()
    {
        _mainMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
