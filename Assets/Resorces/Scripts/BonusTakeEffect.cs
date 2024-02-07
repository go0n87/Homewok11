using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusTakeEffect : MonoBehaviour
{
    public ParticleSystem BonusEffect;
    private GameObject _parentObject;
    public void PlayBonusEffect()
    {
        BonusEffect.Play();
        _parentObject = transform.parent.gameObject;
        StartCoroutine(WaitBurstEffect(_parentObject));
    }
    private IEnumerator WaitBurstEffect(GameObject _destroyingObject)
    { 
        yield return new WaitForSeconds(3);

        Destroy(_destroyingObject);
    }
}
