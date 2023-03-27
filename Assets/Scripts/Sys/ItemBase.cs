using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Oville.Core
{
	public abstract class ItemBase 
	{
		//public string Id;
		public Consumption Consumption = Consumption.None;

		//public string Title;
		//public string ShortDesc;
		//public string Description;

		//public string IconSrc;
		//public string MedIconSrc;
		//public string ImageSrc;
  //      public string AudioId;

		public string MusicName;
		public string Icon;

		//public abstract T GetItemCategory<T>();
		//public abstract T GetItemType<T>();
		//public abstract T GetItemGroup<T>();

		// Cost, Value, and Qty should be in the class that extends this base
		// All item specific properties should be in the class that extends this base
	}

	public enum Consumption { None = 0, Consumable = 5, NonConsumable = 10 }

	public interface IItem { }
}