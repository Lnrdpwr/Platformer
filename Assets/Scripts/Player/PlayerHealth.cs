using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("GUI")]
    [SerializeField] private Image _healthBar;
    [SerializeField] private ResultingPanel _resultingPanel;

    [Header("Параметры здоровья")]
    [SerializeField] private GameObject _damageEffect;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _invincibleTime;

    private SpriteRenderer _playerRenderer;//Для изменения цвета
    private float _currentHealth;
    private bool _canGetDamage = true;

    private void Start()
    {
        _playerRenderer = GetComponent<SpriteRenderer>();//Получаем рендерер игрока для смены цвета
        _currentHealth = _maxHealth;
    }

    public void StopGame()//Функция для остановки игры
    {
        _resultingPanel.gameObject.SetActive(true);
        _resultingPanel.GetResults(false);//Игрок провалил уровень
        gameObject.SetActive(false);//Выключаем игрока
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Spike") && _canGetDamage)
        {
            _canGetDamage = false;//Отключаем получение урона на время
            StartCoroutine(GetDamage());
        }
    }

    IEnumerator GetDamage()
    {
        _currentHealth--;
        _healthBar.fillAmount = _currentHealth / _maxHealth;//Изменяем вид полосы здоровья

        Instantiate(_damageEffect, transform.position, Quaternion.identity);//Создаём эффект урона

        if (_currentHealth <= 0)
            StopGame();

        else 
        {

            for (float i = 0; i < _invincibleTime; i += Time.deltaTime)
            {
                _playerRenderer.color = new Color(1, i / _invincibleTime, i / _invincibleTime);//Из красного в обычный цвет

                yield return new WaitForEndOfFrame();//Ждёт окончания кадра
            }

            _playerRenderer.color = Color.white;//Стандартный цвет
            _canGetDamage = true; 
        }
    }
}
