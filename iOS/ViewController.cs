using System;
using CustomPickerView.iOS.CustomPicker;
using Foundation;
using UIKit;

namespace CustomPickerView.iOS
{
    public partial class ViewController : UIViewController, IMyPickerContainer
    {

        MyPicker picker;

        public ViewController(IntPtr handle) : base(handle)
        {
        }



        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Code to start the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
            Xamarin.Calabash.Start();
#endif
            //this.View.BackgroundColor = UIColor.Blue;
            if (picker == null)
            {
                //Init Picker
                picker = MyPicker.create();
                picker.delegt = this;
            }

            // Perform any additional setup after loading the view, typically from a nib.
            Button.AccessibilityIdentifier = "myButton";
            Button.TouchUpInside += delegate
            {
                showPicker();
            };
        }

        private void showPicker()
        {
            picker.pickerOpen();
        }

        #region IMyPicker

        public void onSelectItem(int indexNo, string title)
        {
            this.ResultLabel.Text = title;
        }

        #endregion

    }
}
