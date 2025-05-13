using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothSpeed = 0.125f;
    [SerializeField] private float _distance = 0.125f;
    [SerializeField] private float _height = 0.125f;

    private float _currentAngle = 0f;  // Текущий угол вращения
    void Update()
    {
        if (_target == null) return;
        float mouseX = Input.GetAxis("Mouse X");
        _currentAngle += mouseX * _smoothSpeed;
        Quaternion rotation = Quaternion.Euler(0, _currentAngle, 0);
        Vector3 direction = rotation * Vector3.back;
        Vector3 desiredPosition = _target.position + direction * _distance + Vector3.up * _height;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(_target);
    }
}