using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class trainCollect : MonoBehaviour
{
    public Collectable collectablePrefab;

    public List<Collectable> SpawnedCollectables = new List<Collectable>();
    [SerializeField] private int _maxSpawnCount = 10;
    [SerializeField] private float _spawnRadius = 10;
    public Transform[] points;
    [SerializeField] private float _spawnPeriod = 2f;

    private float nextSpawnTime = 0;
    // Update is called once per frame
    void Update()
    {
        HandleNullElements();
        if (SpawnedCollectables.Count >= _maxSpawnCount)
        {
            return;
        }

        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + _spawnPeriod;
            Spawn();
        }

    }

    private void Spawn()
    {
        System.Random rand = new System.Random();

        // 0 ile 30 arasýnda rastgele bir sayý üretin
        int randomNumber = rand.Next(0, 30);
        Vector3 spawnPosition = points[randomNumber].position;
        spawnPosition += new Vector3(0, 2, 0);

        var collectable = Instantiate(collectablePrefab, null);
        collectable.transform.position = spawnPosition;
        SpawnedCollectables.Add(collectable);

        collectable.transform.localScale = Vector3.zero;

        collectable.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack, 2.5f);
        collectable.transform.DORotate(Vector3.up * 360f, 5f, RotateMode.LocalAxisAdd).SetLoops(-1);

    }

    private void HandleNullElements()
    {
        for (int i = SpawnedCollectables.Count - 1; i >= 0; i--)
        {
            if (SpawnedCollectables[i] == null)
            {
                SpawnedCollectables.RemoveAt(i);
            }
        }

    }
}
