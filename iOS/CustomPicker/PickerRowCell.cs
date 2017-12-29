using System;

using Foundation;
using UIKit;

namespace CustomPickerView.iOS.CustomPicker
{
    public partial class PickerRowCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("PickerRowCell");
        public static readonly UINib Nib;

        static PickerRowCell()
        {
            Nib = UINib.FromName("PickerRowCell", NSBundle.MainBundle);
        }

        protected PickerRowCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void setTitleText(string titleString)
        {
            this.itemLabel.Text = titleString;
        }
    }
}
