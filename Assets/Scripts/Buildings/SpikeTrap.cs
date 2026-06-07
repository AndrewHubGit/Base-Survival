using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private List<Damagable> _enemies = new();
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDelay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var damagable = other.gameObject.GetComponent<Damagable>();
            _enemies.Add(damagable);
            StartCoroutine(DealDamage(damagable));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var damagable = other.gameObject.GetComponent<Damagable>();
            _enemies.Remove(damagable);
        }
    }
    public IEnumerator DealDamage(Damagable damagable)
    {
        while (_enemies.Contains(damagable))
        {
            damagable.TakeDamage(_damage);
            yield return new WaitForSeconds(_attackDelay);
        }
    }
}
