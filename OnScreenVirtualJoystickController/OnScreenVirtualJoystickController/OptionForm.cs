using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnScreenVirtualJoystickController
{
    public partial class OptionForm : Form
    {
        public enum JoystickButtons
        {
            DANGER  = 0,
            INDIGO  = 1,
            GREEN   = 2,
            BLUE    = 3
        }
        public bool mNormalMouseMoveEnable, mNormalFollowMouseEnable, mNormalShowBorderEnable, mNormalFollowMouseDelayEnable, mNormalFixedMouse;
        public string mNormalMouseButtonSelection;
        public int mNormalOpacityValue;
        public bool mNormalMouseControlHook;

        public bool mCompactMouseMoveEnable, mCompactShowBorderEnable, mCompactGotoNeutralEnable, mCompactFixedMouse;
        public string mCompactMouseButtonSelection;
        public int mCompactOpacityValue;

        public bool mComplexMouseMoveEnable, mComplexShowBorderEnable, mComplexFollowMouseEnable, mComplexFollowMouseDelayEnable, mComplexFixedMouse;
        public string mComplexMouseButtonSelection;
        public int mComplexOpacityValue;

        public bool mTouchGotoNeutralEnable, mTouchShowBorderEnable, mTouchMouseMoveEnable, mTouchFixedMouse;
        public string mTouchMouseButtonSelection;
        public int mTouchOpacityValue;

        public MainController.CONTROLLER mTabletLeftController, mTabletRightController;
        public bool mEnableTabletLeftController, mEnableTabletRightController;
        public bool mEnableTabletLeftControllerAsDefault, mEnableTabletRightControllerAsDefault;

        private void NormalControllerFollowMouseChk_CheckedChanged(object sender, EventArgs e)
        {
            NormalControllerFollowMouseDelayChk.Enabled = NormalControllerFollowMouseChk.Checked;
        }
        private void ComplexControllerFollowMouseChk_CheckedChanged(object sender, EventArgs e)
        {
            ComplexControllerFollowMouseDelayChk.Enabled = ComplexControllerFollowMouseChk.Checked;
        }

        private void EnableTabletLeftControllerChk_CheckedChanged(object sender, EventArgs e)
        {
            LeftControllerList.Enabled = EnableTabletLeftControllerChk.Checked;
            TabletLeftControllerAsDefaultChk.Enabled = EnableTabletLeftControllerChk.Checked;
        }

        private void NormalControllerOpacityTBar_Scroll(object sender, EventArgs e)
        {
            NormalControllerOpacityTxt.Text = NormalControllerOpacityTBar.Value.ToString();
            mNormalOpacityValue = NormalControllerOpacityTBar.Value;
        }

        private void NormalControllerOpacityTxt_TextChanged(object sender, EventArgs e)
        {
            int _value;
            if (int.TryParse(NormalControllerOpacityTxt.Text, out _value) && _value < 101)
            {
                NormalControllerOpacityTBar.Value = _value;
            }
            else
            {
                NormalControllerOpacityTxt.Text = NormalControllerOpacityTBar.Value.ToString();
            }
            mNormalOpacityValue = NormalControllerOpacityTBar.Value;
        }

        private void CompactControllerOpacityTBar_Scroll(object sender, EventArgs e)
        {
            CompactControllerOpacityTxt.Text = CompactControllerOpacityTBar.Value.ToString();
            mCompactOpacityValue = CompactControllerOpacityTBar.Value;
        }

        private void CompactControllerOpacityTxt_TextChanged(object sender, EventArgs e)
        {
            int _value;
            if (int.TryParse(CompactControllerOpacityTxt.Text, out _value) && _value < 101)
            {
                CompactControllerOpacityTBar.Value = _value;
            }
            else
            {
                CompactControllerOpacityTxt.Text = CompactControllerOpacityTBar.Value.ToString();
            }
            mCompactOpacityValue = CompactControllerOpacityTBar.Value;
        }

        private void ComplexControllerOpacityTBar_Scroll(object sender, EventArgs e)
        {
            ComplexControllerOpacityTxt.Text = ComplexControllerOpacityTBar.Value.ToString();
            mComplexOpacityValue = ComplexControllerOpacityTBar.Value;
        }

        private void ComplexControllerOpacityTxt_TextChanged(object sender, EventArgs e)
        {
            int _value;
            if (int.TryParse(ComplexControllerOpacityTxt.Text, out _value) && _value < 101)
            {
                ComplexControllerOpacityTBar.Value = _value;
            }
            else
            {
                ComplexControllerOpacityTxt.Text = ComplexControllerOpacityTBar.Value.ToString();
            }
            mComplexOpacityValue = ComplexControllerOpacityTBar.Value;
        }

        private void TouchControllerOpacityTBar_Scroll(object sender, EventArgs e)
        {
            TouchControllerOpacityTxt.Text = TouchControllerOpacityTBar.Value.ToString();
            mTouchOpacityValue = TouchControllerOpacityTBar.Value;
        }

        private void TabletLeftControllerAsDefaultChk_CheckedChanged(object sender, EventArgs e)
        {
            if (TabletLeftControllerAsDefaultChk.Checked)
                TabletRightControllerAsDefaultChk.Checked = false;
        }

        private void TabletRightControllerAsDefaultChk_CheckedChanged(object sender, EventArgs e)
        {
            if (TabletRightControllerAsDefaultChk.Checked)
                TabletLeftControllerAsDefaultChk.Checked = false;
        }

        private void TouchControllerOpacityTxt_TextChanged(object sender, EventArgs e)
        {
            int _value;
            if (int.TryParse(TouchControllerOpacityTxt.Text, out _value) && _value < 101)
            {
                TouchControllerOpacityTBar.Value = _value;
            }
            else
            {
                TouchControllerOpacityTxt.Text = TouchControllerOpacityTBar.Value.ToString();
            }
            mTouchOpacityValue = TouchControllerOpacityTBar.Value;
        }

        private void NormalControllerShowBorderChk_CheckedChanged(object sender, EventArgs e)
        {
            NormalControllerFixedMouseChk.Enabled = NormalControllerShowBorderChk.Checked;
        }

        private void CompactControllerShowBorderChk_CheckedChanged(object sender, EventArgs e)
        {
            CompactControllerFixedMouseChk.Enabled = CompactControllerShowBorderChk.Checked;
        }

        private void ComplexControllerShowBorderChk_CheckedChanged(object sender, EventArgs e)
        {
            ComplexControllerFixedMouseChk.Enabled = ComplexControllerShowBorderChk.Checked;
        }

        private void TouchControllerShowBorderChk_CheckedChanged(object sender, EventArgs e)
        {
            TouchControllerFixedMouseChk.Enabled = TouchControllerShowBorderChk.Checked;
        }

        private void EnableTabletRightControllerChk_CheckedChanged(object sender, EventArgs e)
        {
            RightControllerList.Enabled = EnableTabletRightControllerChk.Checked;
            TabletRightControllerAsDefaultChk.Enabled = EnableTabletRightControllerChk.Checked;
        }

        public bool mNormalCustomSize, mCompactCustomSize, mComplexCustomSize, mTouchCustomSize;
        public int mNormalRatio = 100, mCompactRatio = 100, mComplexRatio = 100, mTouchtRatio = 100;

        private void OptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
                base.OnFormClosing(e);
        }

        MainController mMainController;
        public OptionForm(MainController mainController)
        {
            InitializeComponent();

            Dictionary<string, int> _cmbData = new Dictionary<string, int>();
            _cmbData.Add("25%", 25);
            _cmbData.Add("50%", 50);
            _cmbData.Add("75%", 75);
            _cmbData.Add("100%", 100);
            _cmbData.Add("125%", 125);
            _cmbData.Add("150%", 150);
            _cmbData.Add("175%", 175);
            _cmbData.Add("200%", 200);

            NormalControllerRatioResizeCmb.DataSource = new BindingSource(_cmbData, null);
            NormalControllerRatioResizeCmb.DisplayMember = "Key";
            NormalControllerRatioResizeCmb.ValueMember = "Value";
            NormalControllerRatioResizeCmb.SelectedIndex = 3;

            CompactControllerRatioResizeCmb.DataSource = new BindingSource(_cmbData, null);
            CompactControllerRatioResizeCmb.DisplayMember = "Key";
            CompactControllerRatioResizeCmb.ValueMember = "Value";
            CompactControllerRatioResizeCmb.SelectedIndex = 3;

            ComplexControllerRatioResizeCmb.DataSource = new BindingSource(_cmbData, null);
            ComplexControllerRatioResizeCmb.DisplayMember = "Key";
            ComplexControllerRatioResizeCmb.ValueMember = "Value";
            ComplexControllerRatioResizeCmb.SelectedIndex = 3;

            TouchControllerRatioResizeCmb.DataSource = new BindingSource(_cmbData, null);
            TouchControllerRatioResizeCmb.DisplayMember = "Key";
            TouchControllerRatioResizeCmb.ValueMember = "Value";
            TouchControllerRatioResizeCmb.SelectedIndex = 3;

            NormalControllerMouseButtonCmb.SelectedIndex = 0;
            CompactControllerMouseButtonCmb.SelectedIndex = 0;
            ComplexControllerMouseButtonCmb.SelectedIndex = 0;
            TouchControllerMouseButtonCmb.SelectedIndex = 0;
            //TabletRightControllerRatioResizeCmb.DataSource = new BindingSource(_cmbData, null);
            //TabletRightControllerRatioResizeCmb.DisplayMember = "Key";
            //TabletRightControllerRatioResizeCmb.ValueMember = "Value";
            //TabletRightControllerRatioResizeCmb.SelectedIndex = 3;

            NormalControllerOpacityTxt.Text = "50";
            CompactControllerOpacityTxt.Text = "50";
            ComplexControllerOpacityTxt.Text = "50";
            TouchControllerOpacityTxt.Text = "50";

            mMainController = mainController;

        }
        
        private void OkBtn_Click(object sender, EventArgs e)
        {
            mNormalMouseMoveEnable = NormalControllerMouseMoveChk.Checked;
            mNormalMouseButtonSelection = NormalControllerMouseButtonCmb.SelectedItem.ToString();
            mNormalFollowMouseEnable = NormalControllerFollowMouseChk.Checked;
            mNormalFollowMouseDelayEnable = NormalControllerFollowMouseDelayChk.Checked;
            mNormalShowBorderEnable = NormalControllerShowBorderChk.Checked;
            mNormalFixedMouse = NormalControllerFixedMouseChk.Checked;
            if (!mNormalCustomSize)
                mNormalRatio = ((KeyValuePair<string, int>)NormalControllerRatioResizeCmb.SelectedItem).Value;
            else
                mNormalRatio = (int)NormalControllerRatioNumUD.Value;
            mNormalMouseControlHook = NormalMouseControlHook.Checked;

            mCompactMouseMoveEnable = CompactControllerMouseMoveChk.Checked;
            mCompactMouseButtonSelection = CompactControllerMouseButtonCmb.SelectedItem.ToString();
            mCompactShowBorderEnable = CompactControllerShowBorderChk.Checked;
            mCompactFixedMouse = CompactControllerShowBorderChk.Checked;
            mCompactGotoNeutralEnable = CompactControllerGotoNeutralChk.Checked;
            if (!mCompactCustomSize)
                mCompactRatio = ((KeyValuePair<string, int>)CompactControllerRatioResizeCmb.SelectedItem).Value;
            else
                mCompactRatio = (int)CompactControllerRatioNumUD.Value;

            mComplexMouseMoveEnable = ComplexControllerMouseMoveChk.Checked;
            mComplexMouseButtonSelection = ComplexControllerMouseButtonCmb.SelectedItem.ToString();
            mComplexFollowMouseEnable = ComplexControllerFollowMouseChk.Checked;
            mComplexFollowMouseDelayEnable = ComplexControllerFollowMouseDelayChk.Checked;
            mComplexShowBorderEnable = ComplexControllerShowBorderChk.Checked;
            mComplexFixedMouse = ComplexControllerShowBorderChk.Checked;
            if (!mComplexCustomSize)
                mComplexRatio = ((KeyValuePair<string, int>)ComplexControllerRatioResizeCmb.SelectedItem).Value;
            else
                mComplexRatio = (int)CompactControllerRatioNumUD.Value;

            mTouchMouseMoveEnable = TabletControllerMouseMoveChk.Checked;
            mTouchMouseButtonSelection = TouchControllerMouseButtonCmb.SelectedItem.ToString();
            mTouchShowBorderEnable = TouchControllerShowBorderChk.Checked;
            mTouchFixedMouse = TouchControllerShowBorderChk.Checked;
            mTouchGotoNeutralEnable = TouchControllerGotoNeutralChk.Checked;
            if (!mTouchCustomSize)
                mTouchtRatio = ((KeyValuePair<string, int>)TouchControllerRatioResizeCmb.SelectedItem).Value;
            else
                mTouchtRatio = (int)TouchControllerRatioNumUD.Value;

            mEnableTabletLeftController = EnableTabletLeftControllerChk.Checked;
            mTabletLeftController = (MainController.CONTROLLER)LeftControllerList.SelectedIndex;
            mEnableTabletLeftControllerAsDefault = TabletLeftControllerAsDefaultChk.Checked;
            mEnableTabletRightController = EnableTabletRightControllerChk.Checked;
            mTabletRightController = (MainController.CONTROLLER)RightControllerList.SelectedIndex;
            mEnableTabletRightControllerAsDefault = TabletRightControllerAsDefaultChk.Checked;

            this.Hide();
            mMainController.setOptionConfigForController();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void NormalControllerCustomSizeChk_CheckedChanged(object sender, EventArgs e)
        {
            mNormalCustomSize = NormalControllerCustomSizeChk.Checked;

            if (mNormalCustomSize)
            {
                NormalControllerRatioNumUD.Enabled = true;
                NormalControllerRatioResizeCmb.Enabled = false;
            }
            else
            {
                NormalControllerRatioNumUD.Enabled = false;
                NormalControllerRatioResizeCmb.Enabled = true;
            }
        }

        private void CompactControllerCustomSizeChk_CheckedChanged(object sender, EventArgs e)
        {
            mCompactCustomSize = CompactControllerCustomSizeChk.Checked;

            if (mCompactCustomSize)
            {
                CompactControllerRatioNumUD.Enabled = true;
                CompactControllerRatioResizeCmb.Enabled = false;
            }
            else
            {
                CompactControllerRatioNumUD.Enabled = false;
                CompactControllerRatioResizeCmb.Enabled = true;
            }
        }

        private void ComplexControllerCustomSizeChk_CheckedChanged(object sender, EventArgs e)
        {
            mComplexCustomSize = ComplexControllerCustomSizeChk.Checked;

            if (mComplexCustomSize)
            {
                ComplexControllerRatioNumUD.Enabled = true;
                ComplexControllerRatioResizeCmb.Enabled = false;
            }
            else
            {
                ComplexControllerRatioNumUD.Enabled = false;
                ComplexControllerRatioResizeCmb.Enabled = true;
            }
        }

        private void TouchControllerCustomSizeChk_CheckedChanged(object sender, EventArgs e)
        {
            mTouchCustomSize = TouchControllerCustomSizeChk.Checked;

            if (mTouchCustomSize)
            {
                TouchControllerRatioNumUD.Enabled = true;
                TouchControllerRatioResizeCmb.Enabled = false;
            }
            else
            {
                TouchControllerRatioNumUD.Enabled = false;
                TouchControllerRatioResizeCmb.Enabled = true;
            }
        }


    }
}
