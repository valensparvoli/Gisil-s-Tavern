using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEffectManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] effects;
    private void PlayAt(string effect, Vector3 position, Quaternion rotation)
    {
        ParticleSystem e = System.Array.Find(effects, _e => _e.name.ToLower() == effect.ToLower());
        e.transform.SetPositionAndRotation(position, rotation);
        e.Play();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                PlayAt("ring", new Vector3(0,0,2.5f), Quaternion.identity);
            if (Input.GetKeyDown(KeyCode.Alpha2))
                PlayAt("ring", new Vector3(0,0,-2.5f), Quaternion.identity);
            if (Input.GetKeyDown(KeyCode.Alpha3))
                PlayAt("ring", new Vector3(0,2.5f, 0), Quaternion.identity);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                PlayAt("aura", new Vector3(0,0,2.5f), Quaternion.identity);
            if (Input.GetKeyDown(KeyCode.Alpha2))
                PlayAt("aura", new Vector3(0,0,-2.5f), Quaternion.identity);
            if (Input.GetKeyDown(KeyCode.Alpha3))
                PlayAt("aura", new Vector3(0,2.5f, 0), Quaternion.identity);
        }
    }
}
