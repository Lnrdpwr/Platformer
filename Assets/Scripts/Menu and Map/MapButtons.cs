using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapButtons : MonoBehaviour
{
    [Header("GUI")]
    [SerializeField] private Image[] _buttonsImages;//Список с изображением кнопок для смены их цвета

    private int _currentLevel;

    private void Start()
    {
        _currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

        //Если уровень открыт, то делаем его кнопку светлой
        for(int i = 0; i < _currentLevel; i++)
        {
            _buttonsImages[i].color = Color.white;
        }
    }

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex <= _currentLevel)//Если уровень открыт, то загружаем его
            SceneManager.LoadScene("Level" + levelIndex.ToString());
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
