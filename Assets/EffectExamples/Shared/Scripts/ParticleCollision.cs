using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script demonstrate how to use the particle system collision callback.
/// The sample using it is the "Extinguish" prefab. It use a second, non displayed
/// particle system to lighten the load of collision detection.
/// </summary>
public class ParticleCollision : MonoBehaviour
{




    private void OnParticleCollision(GameObject other)
    {
        Destroy(this.gameObject);
    }
}
