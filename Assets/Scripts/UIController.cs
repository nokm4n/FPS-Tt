using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	public static UIController instance;

	//[SerializeField, NotNull] private Image _hpbar;
	[SerializeField, NotNull] private TextMeshProUGUI _bulletstext;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.Log("More than 1 UIController in scene");
		}
		instance = this;
	}

	/*public void SetHp(float hp)
	{
		_hpbar.fillAmount = hp/100;
	}*/

	public void SetBullets(int bullets)
	{
		_bulletstext.text = bullets.ToString();
	}
}
