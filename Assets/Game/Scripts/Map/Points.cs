using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private GameObject _pointPrefab;
    [SerializeField] private Map _map;
    [SerializeField] private int _pointsCount;
    [SerializeField] private float _distanceMin;
    private List<Vector2> _pointsPosition;

    private void Awake()
    {
        if (_pointsCount > 0)
        {
            _pointsPosition = new List<Vector2>();
            _pointsPosition.Add(RandomPosition());
            for (int i = 1; i < _pointsCount; i++)
            {
                int iteration = 0;
                Vector2 point;
                do
                {
                    point = RandomPosition();
                    iteration++;
                    if (iteration >= 1000)
                    {
                        Debug.LogError("Point cant be found. Created: " + i);
                        break;
                    }
                }
                while (CheckDistanceWithPoints(point, _distanceMin) == false);

                if (iteration >= 1000)
                    break;

                _pointsPosition.Add(point);
            }

            foreach (Vector2 position in _pointsPosition)
            {
                GameObject pointObject = Instantiate(_pointPrefab);
                pointObject.transform.position = new Vector3(position.x, pointObject.transform.position.y, position.y);
                pointObject.transform.SetParent(transform);
                pointObject.name = "Point";
            }
        }
    }

    private Vector2 RandomPosition()
    {
        float x = Random.Range(0, _map.Size.x);
        float y = Random.Range(0, _map.Size.y);
        Vector2 point = new Vector2(x, y);
        return point;
    }

    private bool CheckDistanceWithPoints(Vector2 point, float distanceMin)
    {
        foreach (Vector2 vector in _pointsPosition)
        {
            if (Vector2.Distance(vector, point) < distanceMin)
                return false;
        }
        return true;
    }
}