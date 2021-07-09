using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour 
{
	[SerializeField] private Text _nameField;
	[SerializeField] private Image _iconField;
	[SerializeField] private GameObject _target;
	public void Render(IItem item)
	{
		_nameField.text = item.Name;
		_iconField.sprite =  item.UIIcon;
		_target = GameObject.Find(item.Target.name);
	}

	public void OnMouseDown()
	{
		Debug.Log(_target.name);
		_target.GetComponent<ObjectController>().canBeClicked = true;
		Destroy(gameObject);
	}
}
