using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pour : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem myParticleSystem;
    void Start()
    {
        myParticleSystem = GetComponent<ParticleSystem>();
    }
    public void togglePour()
    {
        if (Vector3.Angle(Vector3.down, transform.forward) <= 90f)
        {
            myParticleSystem.Play();
        }
        else
        {
            toggleStop();
        }
    }
    public void toggleStop()
    {
        myParticleSystem.Stop();
    }
    //public void OnParticleCollision(GameObject collision)
    //{
        //Debug.LogWarning("Object: " + collision.gameObject.name);
    //}
}
