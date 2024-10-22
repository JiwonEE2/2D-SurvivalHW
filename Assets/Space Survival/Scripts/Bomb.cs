using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Item
{
	private void Start()
	{
		GameManager.Instance.items.Add(this);
	}

	override protected void Contact()
	{
		// ���� �Ŵ������� ��� ������ ���ִ޶�� ��Ź����
		// enemies�� �ִ� ��� enemy�� die
		for (int i = GameManager.Instance.enemies.Count - 1; i >= 0; i--)
		{
			GameManager.Instance.enemies[i].TakeDamage(GameManager.Instance.enemies[i].hp);
		}
	}
}
