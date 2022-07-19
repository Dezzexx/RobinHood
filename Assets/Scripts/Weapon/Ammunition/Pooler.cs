using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _poolSize;
    [SerializeField] private bool _expandable;

    private List<GameObject> _freeList;
    private List<GameObject> _usedList;

    private void Awake()
    {
        _freeList = new List<GameObject>();
        _usedList = new List<GameObject>();

        for (int i = 0; i < _poolSize; ++i)
        {
            CreateNewObject();
        }
    }

    public GameObject GetObject()
    {
        int totalFree = _freeList.Count;

        if (totalFree == 0 && !_expandable) return null;
        else if (totalFree == 0) CreateNewObject();

        GameObject g = _freeList[totalFree - 1];
        _freeList.RemoveAt(totalFree - 1);
        _usedList.Add(g);
        return g;
    }

    public void ReturnObject(GameObject obj)
    {
        Debug.Assert(_usedList.Contains(obj));
        obj.SetActive(false);
        _usedList.Remove(obj);
        _freeList.Add(obj);
    }

    private void CreateNewObject()
    {
        GameObject g = Instantiate(_prefab);
        g.transform.parent = transform;
        g.SetActive(false);
        _freeList.Add(g);
    }
}
