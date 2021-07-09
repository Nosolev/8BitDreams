﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
	[SerializeField] private List<AssetItem> Items;
	[SerializeField] private InventoryCell _inventoryCellTemplate;
	[SerializeField] private Transform _container;

	public void OnEnable()
	{
		Render(Items);
		PickableObject.clickOnObject += AddItem;
	}

	public void AddItem(AssetItem item)
	{
		Items.Add(item);
		Render(Items);
	}

	public void Render(List<AssetItem> items)
	{
		foreach(Transform child in _container)
			Destroy(child.gameObject);

		items.ForEach(item => {
			var cell= Instantiate(_inventoryCellTemplate, _container);
			cell.Render(item);
		});
	}
	void OnDisable()
	{
		PickableObject.clickOnObject -= AddItem;
	}
}
