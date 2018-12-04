using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public ParticleSystem SmokeParticle;

    // Use this for initialization
    void Start()
    {
        SmokeParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            SmokeParticle.Play();
        }
    }
}
