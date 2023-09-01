using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	public LayerMask igonreLayer;

	[SerializeField] private float _damage = 10f;
	[SerializeField] private float _fireRate = 10f;
	[SerializeField] private float _range = 100f;


	[SerializeField, NotNull] private Camera _camera;
	[SerializeField, NotNull] private ParticleSystem _muzzleFlash;
	[SerializeField, NotNull] private ParticleSystem _impactEffect;

	private int _bulletsInMag = 30;
	private float _nextTimeToFire = 0f;
	private void Update()
	{
		if( Input.GetButton("Fire1") && Time.time >= _nextTimeToFire && _bulletsInMag>0)
		{
			_bulletsInMag--;
			_nextTimeToFire = Time.time + 1f / _fireRate;
			Shoot();
			UIController.instance.SetBullets(_bulletsInMag);
		}
		if(Input.GetKeyDown(KeyCode.R))
		{
			_bulletsInMag = 30;
			UIController.instance.SetBullets(_bulletsInMag);
		}
	}

	private void Shoot()
	{
		
		_muzzleFlash.Play();

		RaycastHit hit;
		if(Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _range, ~igonreLayer))
		{
			Debug.Log(hit.transform.name);

			if(hit.transform.TryGetComponent<HP>(out var enemy))
			{
				enemy.GetHit(_damage);
			}

			var impactEffect = Instantiate(_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy(impactEffect.gameObject, 2f);
		}


	}

	public int GetBullets()
	{
		return _bulletsInMag;
	}
}
