using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CoreGraphics;
using Foundation;
using UIKit;

namespace CustomPickerView.iOS.CustomPicker
{
    [Register("MyPickerContainer")]
    public partial class MyPicker : UIView, IUITableViewDataSource, IUITableViewDelegate
    {

        #region Properties

        const double animtionDuration = 0.35;

        public IMyPickerContainer delegt; //Set for callback

        List<string> pickerItems = new List<string> { "First", "Second", "Third" };

        #endregion



        #region Init

        //Init methods
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            initView();
        }

        protected internal MyPicker(IntPtr handle) : base(handle) { }

        protected MyPicker(NSObjectFlag t) : base(t) { }

        public static MyPicker create()
        {
            var arr = NSBundle.MainBundle.LoadNib("MyPickerContainer", null, null);
            return arr.GetItem<MyPicker>(0);
        }

        #endregion


        #region Private

        //UI init
        private void initView()
        {
            //addBlurEffect();

            tableViewPrepare();

            // border
            itemTableView.Layer.BorderColor = UIColor.LightGray.CGColor;
            itemTableView.Layer.BorderWidth = 1.5f;

            // drop shadow
            itemTableView.Layer.ShadowColor = UIColor.Black.CGColor;
            itemTableView.Layer.ShadowOpacity = 0.8f;
            itemTableView.Layer.ShadowRadius = (nfloat)3.0;
            itemTableView.Layer.ShadowOffset = new CGSize(2.0, 2.0);

        }

        private void addBlurEffect()
        {
            BackgroundColor = UIColor.Clear;

            var darkBlur = UIBlurEffect.FromStyle(UIBlurEffectStyle.ExtraLight);
            var blueViewEffect = new UIVisualEffectView(darkBlur);
            blueViewEffect.Frame = this.Frame;
            this.InsertSubview(blueViewEffect, 0);
        }

        private void tableViewPrepare()
        {
            if (itemTableView != null)
                itemTableView.RegisterNibForCellReuse(PickerRowCell.Nib, PickerRowCell.Key);

            //For tableView cell autoHeight
            itemTableView.RowHeight = UITableView.AutomaticDimension;
            itemTableView.EstimatedRowHeight = 44;

            itemTableView.Layer.CornerRadius = 16.0f;
            itemTableView.Layer.MasksToBounds = true;
            itemTableView.TableFooterView = new UIView();
        }

        #endregion




        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);
            pickerClose();
        }



        #region TableView methods

        [Export("tableView:cellForRowAtIndexPath:")]
        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(PickerRowCell.Key, indexPath) as PickerRowCell;
            cell.setTitleText(pickerItems[indexPath.Row]);

            //Set tableview height
            tableHeightConstraint.Constant = (tableHeightConstraint.Constant > this.Frame.Height / 2) ? this.Frame.Height / 2 : tableView.ContentSize.Height;
            return cell;
        }

        [Export("tableView:numberOfRowsInSection:")]
        public nint RowsInSection(UITableView tableView, nint section)
        {
            return pickerItems.Count;
        }

        [Export("tableView:didSelectRowAtIndexPath:")]
        public void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            if (delegt != null)
            {
                delegt.onSelectItem(indexPath.Row, pickerItems[indexPath.Row]);
            }
            pickerClose();
        }

        #endregion



        #region Public

        public void setPickerItemWith(List<string> items)
        {
            pickerItems.Clear();
            pickerItems = items;
        }

        //public methods
        public void pickerOpen()
        {
            itemTableView.ReloadData();
            Frame = UIApplication.SharedApplication.KeyWindow.Frame;
            UIApplication.SharedApplication.KeyWindow.AddSubview(this);
            this.Alpha = 0;
            UIView.Animate(animtionDuration, () => this.Alpha = 1);
        }

        public void pickerClose()
        {
            UIView.Animate(animtionDuration, 0.2, UIViewAnimationOptions.CurveEaseOut, () => this.Alpha = 0, () => this.RemoveFromSuperview());
        }

        #endregion


    }

    #region Callback Interface

    public interface IMyPickerContainer
    {
        void onSelectItem(int indexNo, string title);
    }

    #endregion


}
