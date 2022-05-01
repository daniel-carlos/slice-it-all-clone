using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuttable : MonoBehaviour
{
    [Header("Value")]
    public int value = 10;

    [Header("Slice")]
    public GameObject entireObject;
    public GameObject slicedPrefab;
    public float sliceSpeed = 1f;

    void SliceObject()
    {
        entireObject.SetActive(false);
        Instantiate(slicedPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerScore pScore = other.GetComponentInParent<PlayerScore>();
        pScore?.AddScore(value);
        if (pScore)
        {
            SliceObject();
        }
    }
}
