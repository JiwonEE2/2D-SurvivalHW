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
		// 게임 매니저에게 모든 적들을 없애달라고 부탁하자
		// enemies에 있는 모든 enemy들 die
		for (int i = GameManager.Instance.enemies.Count - 1; i >= 0; i--)
		{
			GameManager.Instance.enemies[i].TakeDamage(GameManager.Instance.enemies[i].hp);
		}
	}
}
