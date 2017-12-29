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
	partial class MyPicker
	{
		[Outlet]
		UIKit.UITableView itemTableView { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint tableHeightConstraint { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (itemTableView != null) {
				itemTableView.Dispose ();
				itemTableView = null;
			}

			if (tableHeightConstraint != null) {
				tableHeightConstraint.Dispose ();
				tableHeightConstraint = null;
			}
		}
	}
}
