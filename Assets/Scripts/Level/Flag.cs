using UnityEngine;

public class Flag : MonoBehaviour
{
    [Header("GUI")]
    [SerializeField] private ResultingPanel _resultingPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerMovement player))//Если флаг задет, то получаем от игрока компонент передвижения
        {
            player.enabled = false;//Выключаем передвижение игрока
            collision.attachedRigidbody.velocity = new Vector2(0, collision.attachedRigidbody.velocity.y);//Останавливаем игрока

            _resultingPanel.gameObject.SetActive(true);
            _resultingPanel.GetResults(true);//Уровень пройден
        }
    }
}
