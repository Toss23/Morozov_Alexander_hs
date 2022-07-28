using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private GameObject _basePrefab;
    [SerializeField] private Map _map;
    private Point _basePoint;

    public Vector2 Position { get { return _basePoint.Position; } }

    private void Awake()
    {
        _basePoint = new Point();
        _basePoint.RandomPosition(_map.Size);
        GameObject baseObject = Instantiate(_basePrefab);
        baseObject.transform.position = new Vector3(_basePoint.Position.x, baseObject.transform.position.y, _basePoint.Position.y);
        baseObject.transform.SetParent(transform);
        baseObject.name = "Base";
    }
}
