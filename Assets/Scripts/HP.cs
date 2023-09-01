using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    [SerializeField] private float _hp = 100f;
	[SerializeField, NotNull] private Image _hpbar;

	public void GetHit(float damage)
    {
        Debug.Log("hit");
        if (_hp >= damage)
        {
            _hp-=damage;
        }
        else
        {
            Die();
        }
        SetHp(_hp);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public float GetHp()
    {
        return _hp;
    }

	public void SetHp(float hp)
	{
		_hpbar.fillAmount = hp / 100;
	}
}
