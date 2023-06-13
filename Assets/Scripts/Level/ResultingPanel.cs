using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultingPanel : MonoBehaviour
{
    [Header("GUI")]
    [SerializeField] private TMP_Text _result;
    [SerializeField] private Button _nextLevelButton;

    [Header("Настройки уровня")]
    [SerializeField] private int _levelIndex;

    public void GetResults(bool passedLevel)
    {
        if (passedLevel)
        {
            _result.text = "Уровень пройден";
            if (_levelIndex == PlayerPrefs.GetInt("CurrentLevel", 1))
                PlayerPrefs.SetInt("CurrentLevel", _levelIndex + 1);

            if (_levelIndex == 3)
                _nextLevelButton.gameObject.SetActive(false);
                PlayerPrefs.SetInt("CurrentLevel", 3);
        }
        else
        {
            _result.text = "Попробуйте ещё раз";
            _nextLevelButton.gameObject.SetActive(false);
        }
    }

    public void ToTheMap()
    {
        SceneManager.LoadScene("Map");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Level" + (_levelIndex + 1).ToString());
    }
}
