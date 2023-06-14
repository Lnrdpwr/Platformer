using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Настройки камеры")]
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothTime;

    private Vector3 _offset = new Vector3(0, 0, -10);//Чтобы камера не уехала вперёд
    private Vector3 _velocity = Vector3.zero;//Передвижение камеры

    private void Update()
    {
        Vector3 targetPosition = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);//Плавно перемещает камеру к игроку, меняя _velocity
    }
}
