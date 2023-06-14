using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultingPanel : MonoBehaviour
{
    [Header("GUI")]
    [SerializeField] private TMP_Text _result;//Текст с надписью "уровень пройден" или "попробуйте ещё раз"
    [SerializeField] private Button _nextLevelButton;

    [Header("Настройки уровня")]
    [SerializeField] private int _levelIndex;//Номер уровня

    public void GetResults(bool passedLevel)//Получает результат(пройден уровень или нет)
    {
        if (passedLevel)
        {
            _result.text = "Уровень пройден";
            if (_levelIndex == PlayerPrefs.GetInt("CurrentLevel", 1))//Если проходим последний открытый уровень
                PlayerPrefs.SetInt("CurrentLevel", _levelIndex + 1);

            if (_levelIndex == 3)//Если прошли финальный уровень
                _nextLevelButton.gameObject.SetActive(false);//Выключаем эту кнопку, что бы не было ошибки
                PlayerPrefs.SetInt("CurrentLevel", 3);
        }
        else
        {
            _result.text = "Попробуйте ещё раз";
            _nextLevelButton.gameObject.SetActive(false);//Выключаем кнопку перехода на следующий уровень
        }
    }

    public void ToTheMap()
    {
        SceneManager.LoadScene("Map");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//Загружаем текущую сцену
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Level" + (_levelIndex + 1).ToString());//Загружаем следующий уровень
    }
}
