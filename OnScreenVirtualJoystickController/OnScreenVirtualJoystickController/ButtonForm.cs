using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vJoyInterfaceWrap;

namespace OnScreenVirtualJoystickController
{
    public partial class ButtonForm : Form
    {
        [System.Runtime.InteropServices.DllImport("user32", EntryPoint = "SetActiveWindow", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        public static extern long SetActiveWindow(long hwnd);

        private const int WS_EX_TOOLWINDOW = 0x00000080;
        private const int WS_EX_NOACTIVATE = 0x08000000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= (WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW);
                cp.Parent = IntPtr.Zero; // Keep this line only if you used UserControl
                return cp;
                //return base.CreateParams;
            }
        }

        public enum COMPONENTMODE
        {
            EDIT_MODE,
            RUN_MODE
        }

        COMPONENTMODE mMode;

        EditBoxForm mEditBox;
        vJoy mJoystickHandler;
        uint mJoystickId;

        double mOpacity = 0.5f;
        Color mBackColor = Color.FromArgb(120, 120, 120);
        Color mForeColor = Color.FromArgb(160, 160, 160);
        int mButtonWidth = 350;
        int mButtonHeight = 350;
        int mButtonX = 0;
        int mButtonY = 0;
        string mText = "";
        float mTextSize = 30.0f;
        uint mJoystickBtnID = 0;
        uint mJoystickBtnIndex = 0;

        public int OpacityValue
        {
            get
            {
                return (int)(mOpacity * 100);
            }
            set
            {
                mOpacity = (float)value / 100.0f;
                this.Opacity = mOpacity;
            }
        }

        public Color BackColorValue
        {
            get
            {
                return mBackColor;
            }
            set
            {
                mBackColor = value;
                this.ButtonBtn.BackColor = mBackColor;
            }
        }

        public Color ForeColorValue
        {
            get
            {
                return mForeColor;
            }
            set
            {
                mForeColor = value;
                this.ButtonBtn.ForeColor = mForeColor;
            }
        }
        
        public int XValue
        {
            get
            {
                return this.Left + 10;
            }
            set
            {
                this.Left = value - 10;
                this.Refresh();
            }
        }

        public int YValue
        {
            get
            {
                return this.Top + 10;
            }
            set
            {
                this.Top = value - 10;
                this.Refresh();
            }
        }
        
        public int HeightValue
        {
            get
            {
                return this.ButtonBtn.Height;
            }
            set
            {
                this.ButtonBtn.Height = value;
                adjustResizeController();
            }
        }

        public int WidthValue
        {
            get
            {
                return this.ButtonBtn.Width;
            }
            set
            {
                this.ButtonBtn.Width = value;
                adjustResizeController();
            }
        }

        public string TextValue
        {
            get
            {
                return mText;
            }
            set
            {
                mText = value;
                this.ButtonBtn.Text = mText;
            }
        }

        public float TextSizeValue
        {
            get
            {
                return this.ButtonBtn.Font.Size;
            }
            set
            {
                mTextSize = value;
                this.ButtonBtn.Font = new Font(ButtonBtn.Font.FontFamily, mTextSize);
            }
        }

        public uint JoystickBtnID
        {
            get
            {
                return mJoystickBtnID;
            }
            set
            {
                mJoystickBtnID = value;
            }
        }

        public uint JoystickBtnIndex
        {
            get
            {
                return mJoystickBtnIndex;
            }
            set
            {
                mJoystickBtnIndex = value;
            }
        }

        public bool Sizeable
        {
            get
            {
                return ResizeTopLeft.Visible;
            }
            set
            {
                setVisibleController(value);
            }
        }

        public ButtonForm(COMPONENTMODE mode)
        {
            InitializeComponent();
            this.Opacity = mOpacity;
            this.ButtonBtn.BackColor = mBackColor;
            this.ButtonBtn.ForeColor = mForeColor;
            this.ButtonBtn.Height = mButtonHeight;
            this.ButtonBtn.Width = mButtonWidth;
            this.ButtonBtn.Font = new Font(ButtonBtn.Font.FontFamily, mTextSize);
            this.ButtonBtn.Text = mText;
            this.setVisibleController(false);
            mMode = mode;
        }

        public void setEditBox(EditBoxForm editbox)
        {
            if (mMode == COMPONENTMODE.EDIT_MODE)
                mEditBox = editbox;
        }

        public void setJoystick(vJoy joystickHandler, uint joystickId, long maxvalX, long maxvalY)
        {
            if (mMode == COMPONENTMODE.RUN_MODE)
            {
                mJoystickHandler = joystickHandler;
                mJoystickId = joystickId;
            }
        }

        Point mPrevLocation;
        string mResizeName = "";
        Panel mSelectedController = null;

        private void setVisibleController(bool visible)
        {
            ResizeTopLeft.Visible = visible;
            ResizeTopCenter.Visible = visible;
            ResizeTopRight.Visible = visible;
            ResizeMiddleLeft.Visible = visible;
            ResizeMiddleRight.Visible = visible;
            ResizeBottomLeft.Visible = visible;
            ResizeBottomCenter.Visible = visible;
            ResizeBottomRight.Visible = visible;
        }

        private void adjustResizeController()
        {
            ResizeTopLeft.Left = 0;
            ResizeTopLeft.Top = 0;

            ResizeTopCenter.Left = 5 + ButtonBtn.Width / 2;
            ResizeTopCenter.Top = 0;

            ResizeTopRight.Left = 10 + ButtonBtn.Width;
            ResizeTopRight.Top = 0;

            ResizeMiddleLeft.Left = 0;
            ResizeMiddleLeft.Top = 5 + ButtonBtn.Height / 2;

            ResizeMiddleRight.Left = 10 + ButtonBtn.Width;
            ResizeMiddleRight.Top = 5 + ButtonBtn.Height / 2;

            ResizeBottomLeft.Left = 0;
            ResizeBottomLeft.Top = 10 + ButtonBtn.Height;

            ResizeBottomCenter.Left = 5 + ButtonBtn.Width / 2;
            ResizeBottomCenter.Top = 10 + ButtonBtn.Height;

            ResizeBottomRight.Left = 10 + ButtonBtn.Width;
            ResizeBottomRight.Top = 10 + ButtonBtn.Height;
        }

        private void resetPropertyWindows()
        {
            mEditBox.resetProperties();
        }

        private void Resize_MouseDown(object sender, MouseEventArgs e)
        {
            Panel _resizeController = (Panel)sender;

            mResizeName = _resizeController.Name;
            mPrevLocation = _resizeController.PointToScreen(e.Location);
        }

        private void Resize_MouseMove(object sender, MouseEventArgs e)
        {
            if (mResizeName == "")
                return;
            Panel _resizeController = (Panel)sender;

            Point _curLocation = _resizeController.PointToScreen(e.Location);
            int _diffX = (_curLocation.X - mPrevLocation.X);
            int _diffY = (_curLocation.Y - mPrevLocation.Y);

            switch (mResizeName)
            {
                case "ResizeTopLeft":
                    this.Left += _diffX;
                    ButtonBtn.Width -= _diffX;
                    this.Top += _diffY;
                    ButtonBtn.Height -= _diffY;
                    break;
                case "ResizeTopCenter":
                    this.Top += _diffY;
                    ButtonBtn.Height -= _diffY;
                    break;
                case "ResizeTopRight":
                    ButtonBtn.Width += _diffX;
                    this.Top += _diffY;
                    ButtonBtn.Height -= _diffY;
                    break;
                case "ResizeMiddleLeft":
                    this.Left += _diffX;
                    ButtonBtn.Width -= _diffX;
                    break;
                case "ResizeMiddleRight":
                    ButtonBtn.Width += _diffX;
                    break;
                case "ResizeBottomLeft":
                    //ButtonBtn.Left += _diffX;
                    this.Left += _diffX;
                    ButtonBtn.Width -= _diffX;
                    ButtonBtn.Height += _diffY;
                    break;
                case "ResizeBottomCenter":
                    ButtonBtn.Height += _diffY;
                    break;
                case "ResizeBottomRight":
                    ButtonBtn.Width += _diffX;
                    ButtonBtn.Height += _diffY;
                    break;
            }

            adjustResizeController();
            resetPropertyWindows();
            mPrevLocation = _curLocation;
        }

        private void Resize_MouseUp(object sender, MouseEventArgs e)
        {
            Panel _resizeController = (Panel)sender;
            switch (mResizeName)
            {
                case "ResizeTopLeft":
                    break;
                case "ResizeTopCenter":
                    break;
                case "ResizeTopRight":
                    break;
                case "ResizeMiddleLeft":
                    break;
                case "ResizeMiddleRight":
                    break;
                case "ResizeBottomLeft":
                    break;
                case "ResizeBottomCenter":
                    break;
                case "ResizeBottomRight":
                    break;
            }
            mResizeName = "";
        }

        Point mBtnPrevLocation;
        bool mStartMove = false;
        private void ButtonBtn_MouseDown(object sender, MouseEventArgs e)
        {
            bool _res;
            switch (mMode)
            {
                case COMPONENTMODE.EDIT_MODE:
                    mEditBox.setCurrentComponent(this);
                    setVisibleController(true);
                    mBtnPrevLocation = ButtonBtn.PointToScreen(e.Location);
                    mStartMove = true;
                    break;
                case COMPONENTMODE.RUN_MODE:
                    _res = mJoystickHandler.SetBtn(true, mJoystickId, mJoystickBtnID);
                    break;
            }
        }

        private void ButtonBtn_MouseMove(object sender, MouseEventArgs e)
        {
            bool _res;
            switch (mMode)
            {
                case COMPONENTMODE.EDIT_MODE:
                    if (mStartMove == false)
                        return;
                    Point _curLocation = ButtonBtn.PointToScreen(e.Location);
                    this.Left += (_curLocation.X - mBtnPrevLocation.X);
                    this.Top += (_curLocation.Y - mBtnPrevLocation.Y);
                    resetPropertyWindows();
                    mBtnPrevLocation = _curLocation;
                    break;
                case COMPONENTMODE.RUN_MODE:
                    break;
            }
            
        }

        private void ButtonBtn_MouseUp(object sender, MouseEventArgs e)
        {
            bool _res;
            switch (mMode)
            {
                case COMPONENTMODE.EDIT_MODE:
                    mStartMove = false;
                    break;
                case COMPONENTMODE.RUN_MODE:
                    _res = mJoystickHandler.SetBtn(false, mJoystickId, mJoystickBtnID);
                    break;
            }
        }

        private void ButtonForm_Activated(object sender, EventArgs e)
        {
            if(mMode == COMPONENTMODE.EDIT_MODE)
                setVisibleController(true);
        }

        private void ButtonForm_Deactivate(object sender, EventArgs e)
        {
            if (mMode == COMPONENTMODE.EDIT_MODE)
                setVisibleController(false);
        }
    }
}
