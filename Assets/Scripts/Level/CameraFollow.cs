using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("��������� ������")]
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothTime;

    private Vector3 _offset = new Vector3(0, 0, -10);//����� ������ �� ������ �����
    private Vector3 _velocity = Vector3.zero;//������������ ������

    private void Update()
    {
        Vector3 targetPosition = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);//������ ���������� ������ � ������, ����� _velocity
    }
}
