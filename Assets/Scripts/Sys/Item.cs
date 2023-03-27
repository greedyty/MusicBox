using System.Collections.Generic;

namespace Oville.Items
{
	public class Item : Oville.Core.ItemBase, IItem
	{
		//public string AssetBundleId; // this is where the Item icons are located
		public int Qty = 0;
		public System.DateTime DateTime;
		


		//public virtual Item FromState(InventoryItemState state)
		//{
		//	this.Qty = state.Qty;
		//	this.DateTime = TimeTools.UnixTimeStampToDateTimeUtc(state.TS);
		//	return this;
		//}

		public void CopyBaseItemValues(Item baseItem)
		{
			MusicName = baseItem.MusicName;
			Icon = baseItem.Icon;
			//Category = baseItem.Category;
			//AssetBundleId = baseItem.AssetBundleId;
			//Id = baseItem.Id;
			//Consumption = baseItem.Consumption;
			//Title = baseItem.Title;
			//ShortDesc = baseItem.ShortDesc;
			//Description = baseItem.Description;
			//IconSrc = baseItem.IconSrc;
			//MedIconSrc = baseItem.MedIconSrc;
			//ImageSrc = baseItem.ImageSrc;
   //         AudioId = baseItem.AudioId;
		}
	}

	public interface IItem : Oville.Core.IItem { }
}