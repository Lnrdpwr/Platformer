using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("GUI")]
    [SerializeField] private Image _healthBar;
    [SerializeField] private ResultingPanel _resultingPanel;

    [Header("Параметры здровья")]
    [SerializeField] private GameObject _damageEffect;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _invincibleTime;

    private SpriteRenderer _playerRenderer;//Для изменения цвета
    private float _currentHealth;
    private bool _canGetDamage = true;

    private void Start()
    {
        _playerRenderer = GetComponent<SpriteRenderer>();
        _currentHealth = _maxHealth;
    }

    public void StopGame()
    {
        _resultingPanel.gameObject.SetActive(true);
        _resultingPanel.GetResults(false);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spike") && _canGetDamage)
        {
            _canGetDamage = false;
            StartCoroutine(GetDamage());
        }
    }

    IEnumerator GetDamage()
    {
        _currentHealth--;
        _healthBar.fillAmount = _currentHealth / _maxHealth;

        Instantiate(_damageEffect, transform.position, Quaternion.identity);

        if (_currentHealth <= 0)
            StopGame();

        else 
        {

            for (float i = 0; i < _invincibleTime; i += Time.deltaTime)
            {
                _playerRenderer.color = new Color(1, i / _invincibleTime, i / _invincibleTime);

                yield return new WaitForEndOfFrame();
            }

            _playerRenderer.color = Color.white;
            _canGetDamage = true; 
        }
    }
}
