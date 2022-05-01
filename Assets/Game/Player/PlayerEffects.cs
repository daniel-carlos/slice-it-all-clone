using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    [Header("Trail")]
    public List<GameObject> trailObjects;
    public float trailLifetime = 1f; //Time in seconds to disable trail after a knife move
    
    public void EnableTrail(){
        trailObjects.ForEach(t => {
            t.SetActive(true);
        });
    }
    public void DisableTrail(){
        trailObjects.ForEach(t => {
            t.SetActive(false);
        });
    }


    public void OnKnifeMove(){
        EnableTrail();
        CancelInvoke("DisableTrail");
        Invoke("DisableTrail", trailLifetime);
    }
}
