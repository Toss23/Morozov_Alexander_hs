using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private GameObject _basePrefab;
    [SerializeField] private Map _map;
    private Vector2 _basePosition;

    private void Awake()
    {
        _basePosition = RandomPosition();
        GameObject baseObject = Instantiate(_basePrefab);
        baseObject.transform.position = new Vector3(_basePosition.x, baseObject.transform.position.y, _basePosition.y);
        baseObject.transform.SetParent(transform);
        baseObject.name = "Base";
    }

    private Vector2 RandomPosition()
    {
        float x = Random.Range(0, _map.Size.x);
        float y = Random.Range(0, _map.Size.y);
        Vector2 point = new Vector2(x, y);
        return point;
    }
}
