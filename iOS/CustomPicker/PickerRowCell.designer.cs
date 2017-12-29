// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace CustomPickerView.iOS.CustomPicker
{
	[Register ("PickerRowCell")]
	partial class PickerRowCell
	{
		[Outlet]
		UIKit.UILabel itemLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (itemLabel != null) {
				itemLabel.Dispose ();
				itemLabel = null;
			}
		}
	}
}
