using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public void PlaySoundAnim()
    {
        AudioSource.PlayClipAtPoint(AudioManager.Instance.ExplosionSfx, transform.position);
    }
    public void DestroyAnim()
    {
        Destroy(gameObject);
    }
}
