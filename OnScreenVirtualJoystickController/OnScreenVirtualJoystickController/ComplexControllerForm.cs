using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vJoyInterfaceWrap;
using System.Windows.Forms;

namespace OnScreenVirtualJoystickController
{
    public partial class ComplexControllerForm : Form
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

        long maxvalX, maxvalY, maxvalZ, maxvalRX, maxvalRY;
        vJoy mJoystickHandler;
        vJoy.JoystickState iReport;
        uint mJoystickId;

        bool mEnableMoveController = false;
        string mSelectionMouseButton = "";

        bool mEnableFollowMouse = false;
        bool mEnableFollowDelay = false;
        bool mStartFollowMouse = false;
        bool mEnableShowBorder = false;
        bool mEnableCaptureController = false;
        bool mEnableFixedMouse = false;
        bool mEnableTabletAxis = false;

        float mOpacityValue = 0.50f;

        int mBorderPnlLeft, mBorderPnlTop, mBorderPnlWidth, mBorderPnlHeight;
        int mControllerPnlLeft, mControllerPnlTop, mControllerPnlWidth, mControllerPnlHeight;
        int mCircleBtnLeft, mCircleBtnTop, mCircleBtnWidth, mCircleBtnHeight;
        int mMovingPartLeft, mMovingPartTop, mMovingPartWidth, mMovingPartHeight;
        int mDangerBtnLeft, mDangerBtnTop, mDangerBtnWidth, mDangerBtnHeight;
        int mGreenBtnLeft, mGreenBtnTop, mGreenBtnWidth, mGreenBtnHeight;
        int mIndigoBtnLeft, mIndigoBtnTop, mIndigoBtnWidth, mIndigoBtnHeight;
        int mBlueBtnLeft, mBlueBtnTop, mBlueBtnWidth, mBlueBtnHeight;
        int mUpBtnLeft, mUpBtnTop, mUpBtnWidth, mUpBtnHeight;
        int mDownBtnLeft, mDownBtnTop, mDownBtnWidth, mDownBtnHeight;
        int mLeftBtnLeft, mLeftBtnTop, mLeftBtnWidth, mLeftBtnHeight;
        int mRightBtnLeft, mRightBtnTop, mRightBtnWidth, mRightBtnHeight;
        
        int mDefaultWidth, mDefaultHeight;

        GlobalMouseHandler gmh = new GlobalMouseHandler();

        public int DefaultWidth
        {
            get => mDefaultWidth;
        }

        public int DefaultHeight
        {
            get => mDefaultHeight;
        }

        int mMinXAxis, mMaxXAxis, mMinYAxis, mMaxYAxis;

        int mOffsetXMoving, mOffsetYMoving;

        bool mCustomSize = false;

        int mFixedMouseX, mFixedMouseY;

        private void ComplexControllerBorderPnl_Click(object sender, EventArgs e)
        {
            if (!mEnableCaptureController)
            {
                mEnableCaptureController = true;
                ComplexControllerBorderPnl.BorderColor = Color.Red;
                Application.AddMessageFilter(gmh);
                MousePositionTimer.Start();
                Point _cursorPos = Cursor.Position;
                Console.WriteLine("Cursor Position:X--{0}   Y--{1}", _cursorPos.X, _cursorPos.Y);
                mFixedMouseX = _cursorPos.X;
                mFixedMouseY = _cursorPos.Y;
            }
            else
            {
                mEnableCaptureController = false;
                ComplexControllerBorderPnl.BorderColor = Color.Gray;
                Application.RemoveMessageFilter(gmh);
                MousePositionTimer.Stop();
            }
        }

        private void ComplexControllerForm_VisibleChanged(object sender, EventArgs e)
        {
            if (mEnableCaptureController)
            {
                if (this.Visible)
                {
                    Application.AddMessageFilter(gmh);
                    MousePositionTimer.Start();
                }
                else
                {
                    Application.RemoveMessageFilter(gmh);
                    MousePositionTimer.Stop();
                }

            }
        }

        private void MousePositionTimer_Tick(object sender, EventArgs e)
        {
            if (mSide == MainController.TABLET_CONTROLLER_SIDE.NONE)
            {
                Point cur_pos = System.Windows.Forms.Cursor.Position;
                bool _capture = this.Bounds.Contains(cur_pos);

                if (mEnableCaptureController && !_capture)
                {
                    this.Left = cur_pos.X - mOffsetXMoving;
                    this.Top = cur_pos.Y - mOffsetYMoving;
                }
            }
        }

        int mRatio = 100;

        public void setEnableMoveController(bool enableMove, string selectbuttion)
        {
            mEnableMoveController = enableMove;
            mSelectionMouseButton = selectbuttion;
        }

        public void setSizeParameter(bool customSize, int ratio)
        {
            mCustomSize = customSize;
            mRatio = ratio;
            setSizeController();
        }

        public void setEnableFollowingMouse(bool enableFollow, bool enableFollowDelay)
        {
            mEnableFollowMouse = enableFollow;
            mEnableFollowDelay = enableFollowDelay;
        }

        public void setEnableShowingBorder(bool enableShow, bool enableFixedMouse)
        {
            mEnableShowBorder = enableShow;
            mEnableFixedMouse = enableFixedMouse;

            ComplexControllerBorderPnl.BorderColor = enableShow ? Color.Gray : Color.Transparent;
        }

        public void setOpacityValue(int value)
        {
            mOpacityValue = value / 100.0f;
            this.Opacity = mOpacityValue;
        }

        void setSizeController()
        {
            float _ratio = mRatio / 100.0f;

            ComplexControllerBorderPnl.Left = (int)(mBorderPnlLeft * _ratio);
            ComplexControllerBorderPnl.Top = (int)(mBorderPnlTop * _ratio);
            ComplexControllerBorderPnl.Width = (int)(mBorderPnlWidth * _ratio);
            ComplexControllerBorderPnl.Height = (int)(mBorderPnlHeight * _ratio);

            ComplexControllerPnl.Left = (int)(mControllerPnlLeft * _ratio);
            ComplexControllerPnl.Top = (int)(mControllerPnlTop * _ratio);
            ComplexControllerPnl.Width = (int)(mControllerPnlWidth * _ratio);
            ComplexControllerPnl.Height = (int)(mControllerPnlHeight * _ratio);

            ComplexCircleBtn.Left = (int)(mCircleBtnLeft * _ratio);
            ComplexCircleBtn.Top = (int)(mCircleBtnTop * _ratio);
            ComplexCircleBtn.Width = (int)(mCircleBtnWidth * _ratio);
            ComplexCircleBtn.Height = (int)(mCircleBtnHeight * _ratio);

            ComplexMovingPart.Left = (int)(mMovingPartLeft * _ratio);
            ComplexMovingPart.Top = (int)(mMovingPartTop * _ratio);
            ComplexMovingPart.Width = (int)(mMovingPartWidth * _ratio);
            ComplexMovingPart.Height = (int)(mMovingPartHeight * _ratio);

            ComplexDangerBtn.Left = (int)(mDangerBtnLeft * _ratio);
            ComplexDangerBtn.Top = (int)(mDangerBtnTop * _ratio);
            ComplexDangerBtn.Width = (int)(mDangerBtnWidth * _ratio);
            ComplexDangerBtn.Height = (int)(mDangerBtnHeight * _ratio);

            ComplexGreenBtn.Left = (int)(mGreenBtnLeft * _ratio);
            ComplexGreenBtn.Top = (int)(mGreenBtnTop * _ratio);
            ComplexGreenBtn.Width = (int)(mGreenBtnWidth * _ratio);
            ComplexGreenBtn.Height = (int)(mGreenBtnHeight * _ratio);

            ComplexIndigoBtn.Left = (int)(mIndigoBtnLeft * _ratio);
            ComplexIndigoBtn.Top = (int)(mIndigoBtnTop * _ratio);
            ComplexIndigoBtn.Width = (int)(mIndigoBtnWidth * _ratio);
            ComplexIndigoBtn.Height = (int)(mIndigoBtnHeight * _ratio);

            ComplexBlueBtn.Left = (int)(mBlueBtnLeft * _ratio);
            ComplexBlueBtn.Top = (int)(mBlueBtnTop * _ratio);
            ComplexBlueBtn.Width = (int)(mBlueBtnWidth * _ratio);
            ComplexBlueBtn.Height = (int)(mBlueBtnHeight * _ratio);

            ComplexUpBtn.Left = (int)(mUpBtnLeft * _ratio);
            ComplexUpBtn.Top = (int)(mUpBtnTop * _ratio);
            ComplexUpBtn.Width = (int)(mUpBtnWidth * _ratio);
            ComplexUpBtn.Height = (int)(mUpBtnHeight * _ratio);

            ComplexDownBtn.Left = (int)(mDownBtnLeft * _ratio);
            ComplexDownBtn.Top = (int)(mDownBtnTop * _ratio);
            ComplexDownBtn.Width = (int)(mDownBtnWidth * _ratio);
            ComplexDownBtn.Height = (int)(mDownBtnHeight * _ratio);

            ComplexLeftBtn.Left = (int)(mLeftBtnLeft * _ratio);
            ComplexLeftBtn.Top = (int)(mLeftBtnTop * _ratio);
            ComplexLeftBtn.Width = (int)(mLeftBtnWidth * _ratio);
            ComplexLeftBtn.Height = (int)(mLeftBtnHeight * _ratio);

            ComplexRightBtn.Left = (int)(mRightBtnLeft * _ratio);
            ComplexRightBtn.Top = (int)(mRightBtnTop * _ratio);
            ComplexRightBtn.Width = (int)(mRightBtnWidth * _ratio);
            ComplexRightBtn.Height = (int)(mRightBtnHeight * _ratio);

            mMinXAxis = -ComplexCircleBtn.Width / 2 + ComplexMovingPart.Width;
            mMaxXAxis = ComplexCircleBtn.Width / 2 - ComplexMovingPart.Width;
            mMinYAxis = -ComplexCircleBtn.Height / 2 + ComplexMovingPart.Height;
            mMaxYAxis = ComplexCircleBtn.Height / 2 - ComplexMovingPart.Height;

            ComplexControllerBorderPnl.BorderWidth = (int)(10.0f * _ratio);

        }

        private void ComplexControllerForm_Load(object sender, EventArgs e)
        {
            Screen _currentScreen = Screen.PrimaryScreen;

            switch (mSide)
            {
                case MainController.TABLET_CONTROLLER_SIDE.LEFT:
                    this.Left = 0;
                    this.Top = _currentScreen.WorkingArea.Bottom - this.Height;
                    break;
                case MainController.TABLET_CONTROLLER_SIDE.NONE:
                case MainController.TABLET_CONTROLLER_SIDE.RIGHT:
                    this.Left = _currentScreen.WorkingArea.Right - this.Width;
                    this.Top = _currentScreen.WorkingArea.Bottom - this.Height;
                    break;
            }
        }

        public void setTabletControllerSide(MainController.TABLET_CONTROLLER_SIDE side)
        {
            mSide = side;
            Screen _currentScreen = Screen.PrimaryScreen;

            switch (mSide)
            {
                case MainController.TABLET_CONTROLLER_SIDE.LEFT:
                    this.Left = 0;
                    this.Top = _currentScreen.WorkingArea.Bottom - this.Height;
                    break;
                case MainController.TABLET_CONTROLLER_SIDE.NONE:
                case MainController.TABLET_CONTROLLER_SIDE.RIGHT:
                    this.Left = _currentScreen.WorkingArea.Right - this.Width;
                    this.Top = _currentScreen.WorkingArea.Bottom - this.Height;
                    break;
            }
        }

        MainController.TABLET_CONTROLLER_SIDE mSide;

        public ComplexControllerForm(MainController.TABLET_CONTROLLER_SIDE side)
        {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
            this.Opacity = mOpacityValue;
            this.TopMost = true;
            mSide = side;

            mBorderPnlLeft = ComplexControllerBorderPnl.Left; mBorderPnlTop = ComplexControllerBorderPnl.Top; mBorderPnlWidth = ComplexControllerBorderPnl.Width; mBorderPnlHeight = ComplexControllerBorderPnl.Height;
            mControllerPnlLeft = ComplexControllerPnl.Left; mControllerPnlTop = ComplexControllerPnl.Top; mControllerPnlWidth = ComplexControllerPnl.Width; mControllerPnlHeight = ComplexControllerPnl.Height;
            mCircleBtnLeft = ComplexCircleBtn.Left; mCircleBtnTop = ComplexCircleBtn.Top; mCircleBtnWidth = ComplexCircleBtn.Width; mCircleBtnHeight = ComplexCircleBtn.Height;
            mMovingPartLeft = ComplexMovingPart.Left; mMovingPartTop = ComplexMovingPart.Top; mMovingPartWidth = ComplexMovingPart.Width; mMovingPartHeight = ComplexMovingPart.Height;
            mDangerBtnLeft = ComplexDangerBtn.Left; mDangerBtnTop = ComplexDangerBtn.Top; mDangerBtnWidth = ComplexDangerBtn.Width; mDangerBtnHeight = ComplexDangerBtn.Height;
            mGreenBtnLeft = ComplexGreenBtn.Left; mGreenBtnTop = ComplexGreenBtn.Top; mGreenBtnWidth = ComplexGreenBtn.Width; mGreenBtnHeight = ComplexGreenBtn.Height;
            mIndigoBtnLeft = ComplexIndigoBtn.Left; mIndigoBtnTop = ComplexIndigoBtn.Top; mIndigoBtnWidth = ComplexIndigoBtn.Width; mIndigoBtnHeight = ComplexIndigoBtn.Height;
            mBlueBtnLeft = ComplexBlueBtn.Left; mBlueBtnTop = ComplexBlueBtn.Top; mBlueBtnWidth = ComplexBlueBtn.Width; mBlueBtnHeight = ComplexBlueBtn.Height;
            mUpBtnLeft = ComplexUpBtn.Left; mUpBtnTop = ComplexUpBtn.Top; mUpBtnWidth = ComplexUpBtn.Width; mUpBtnHeight = ComplexUpBtn.Height;
            mDownBtnLeft = ComplexDownBtn.Left; mDownBtnTop = ComplexDownBtn.Top; mDownBtnWidth = ComplexDownBtn.Width; mDownBtnHeight = ComplexDownBtn.Height;
            mLeftBtnLeft = ComplexLeftBtn.Left; mLeftBtnTop = ComplexLeftBtn.Top; mLeftBtnWidth = ComplexLeftBtn.Width; mLeftBtnHeight = ComplexLeftBtn.Height;
            mRightBtnLeft = ComplexRightBtn.Left; mRightBtnTop = ComplexRightBtn.Top; mRightBtnWidth = ComplexRightBtn.Width; mRightBtnHeight = ComplexRightBtn.Height;
            mMinXAxis = -mCircleBtnWidth / 2 + mMovingPartWidth;
            mMaxXAxis = mCircleBtnWidth / 2 - mMovingPartWidth;
            mMinYAxis = -mCircleBtnHeight / 2 + mMovingPartHeight;
            mMaxYAxis = mCircleBtnHeight / 2 - mMovingPartHeight;

            mDefaultWidth = 350;
            mDefaultHeight = 350;

            ComplexControllerBorderPnl.BorderColor = Color.Transparent;
            gmh.TheMouseMoved += new MouseMovedEvent(gmh_TheMouseMoved);
            MousePositionTimer.Interval = 25;
        }

        void gmh_TheMouseMoved()
        {
            Point cur_pos = System.Windows.Forms.Cursor.Position;
            mOffsetXMoving = this.PointToClient(cur_pos).X;
            mOffsetYMoving = this.PointToClient(cur_pos).Y;

            if (mEnableFixedMouse)
            {
                int _X = cur_pos.X - mFixedMouseX;
                int _Y = cur_pos.Y - mFixedMouseY;
                if (_X != 0 || _Y != 0)
                {
                    this.Location = new Point(this.Location.X - _X, this.Location.Y - _Y);
                    Cursor.Position = new Point(mFixedMouseX, mFixedMouseY);
                }
            }
        }

        public void setJoystick(vJoy joystick, uint joystickId)
        {
            mJoystickHandler = joystick;
            mJoystickId = joystickId;
        }
        public void setJoystickParameter(long mX, long mY, long mZ, long mRX, long mRY)
        {
            maxvalX = mX;
            maxvalY = mY;
            maxvalZ = mZ;
            maxvalRX = mRX;
            maxvalRY = mRY;
        }
        public void initializeController()
        {
            this.ComplexDangerBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(DangerBtn_MouseDown);
            this.ComplexDangerBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.ComplexIndigoBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(IndigoBtn_MouseDown);
            this.ComplexIndigoBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.ComplexGreenBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(GreenBtn_MouseDown);
            this.ComplexGreenBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.ComplexBlueBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(BlueBtn_MouseDown);
            this.ComplexBlueBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.ComplexUpBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(UpBtn_MouseDown);
            this.ComplexUpBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.ComplexDownBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(DownBtn_MouseDown);
            this.ComplexDownBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.ComplexLeftBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(LeftBtn_MouseDown);
            this.ComplexLeftBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.ComplexRightBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(RightBtn_MouseDown);
            this.ComplexRightBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.ComplexCircleBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(CircleBtn_MouseDown);
            this.ComplexCircleBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(CircleBtn_MouseUp);
            this.ComplexCircleBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(CircleBtn_MouseMove);
            this.ComplexCircleBtn.MouseEnter += new System.EventHandler(CircleBtn_MouseEnter);
            this.ComplexCircleBtn.MouseLeave += new System.EventHandler(CircleBtn_MouseLeave);
        }

        uint[] mCurrentBtnInfo = null;
        int X, Y;
        long mMaxX, mMaxY;

        Dictionary<string, uint[]> mJoystickBtnId;
        Dictionary<uint, bool> mJoystickBtnState = new Dictionary<uint, bool>();

        public void setJoystickBtnId(Dictionary<string, uint[]> joystickbtnid, string vaxis, string haxis)
        {
            mJoystickBtnId = joystickbtnid;
            switch (vaxis)
            {
                case "X":
                    mVerticalAxis = HID_USAGES.HID_USAGE_X;
                    break;
                case "Y":
                    mVerticalAxis = HID_USAGES.HID_USAGE_Y;
                    break;
                case "Z":
                    mVerticalAxis = HID_USAGES.HID_USAGE_Z;
                    break;
                case "RX":
                    mVerticalAxis = HID_USAGES.HID_USAGE_RX;
                    break;
                case "RY":
                    mVerticalAxis = HID_USAGES.HID_USAGE_RY;
                    break;
                case "SL0":
                    mVerticalAxis = HID_USAGES.HID_USAGE_SL0;
                    break;
                case "SL1":
                    mVerticalAxis = HID_USAGES.HID_USAGE_SL1;
                    break;
            }

            switch (haxis)
            {
                case "X":
                    mHorizontalAxis = HID_USAGES.HID_USAGE_X;
                    break;
                case "Y":
                    mHorizontalAxis = HID_USAGES.HID_USAGE_Y;
                    break;
                case "Z":
                    mHorizontalAxis = HID_USAGES.HID_USAGE_Z;
                    break;
                case "RX":
                    mHorizontalAxis = HID_USAGES.HID_USAGE_RX;
                    break;
                case "RY":
                    mHorizontalAxis = HID_USAGES.HID_USAGE_RY;
                    break;
                case "SL0":
                    mVerticalAxis = HID_USAGES.HID_USAGE_SL0;
                    break;
                case "SL1":
                    mVerticalAxis = HID_USAGES.HID_USAGE_SL1;
                    break;
            }
        }

        public void setTabletAxis(bool enableTableAxis, HID_USAGES hAxis = 0, HID_USAGES vAxis = 0)
        {
            mTabletHorizontalAxis = hAxis;
            mTabletVerticalAxis = vAxis;
            mEnableTabletAxis = enableTableAxis;
        }

        double hypotenuse, angle;
        int cursorOriginX, cursorOriginY;
        int movingPartX, movingPartY;
        public HID_USAGES mVerticalAxis, mHorizontalAxis;
        public HID_USAGES mTabletVerticalAxis, mTabletHorizontalAxis;

        private void MouseFollowDelayTimer_Tick(object sender, EventArgs e)
        {
            MouseFollowDelayTimer.Stop();
            mStartFollowMouse = true;
        }

        public void CircleBtn_MouseDown(object sender, MouseEventArgs e)
        {
            bool _res;
            string _label = "";
            Control _control = (Control)sender;

            

            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (mEnableMoveController && mSelectionMouseButton.Equals("MouseLeft"))
                        break;
                    if (mEnableFollowMouse)
                    {
                        _label = "L";
                        mCurrentBtnInfo = mJoystickBtnId["Circle_L_Id"];
                        pressControllerBtn(mCurrentBtnInfo);

                        MouseButtonlbl.Location = ComplexControllerPnl.PointToClient(_control.PointToScreen(e.Location));
                        MouseButtonlbl.Text = _label;
                    }
                    else
                    {
                        if (mStartFollowMouse)
                        {
                            movingPartX = e.X - (ComplexMovingPart.Width / 2);
                            movingPartY = e.Y - (ComplexMovingPart.Height / 2);
                            cursorOriginX = e.X - (ComplexCircleBtn.Width / 2);
                            cursorOriginY = e.Y - (ComplexCircleBtn.Height / 2);

                            hypotenuse = Math.Sqrt(cursorOriginX * cursorOriginX + cursorOriginY * cursorOriginY);
                            double _maxHypotenuse = Math.Sqrt(mMaxXAxis * mMaxXAxis + mMaxYAxis * mMaxYAxis);
                            if (hypotenuse < mMaxXAxis)
                            {
                                if (cursorOriginX < mMaxXAxis && cursorOriginX > mMinXAxis)//x 
                                {
                                    ComplexMovingPart.Left = movingPartX;
                                }
                                if (cursorOriginY < mMaxYAxis && cursorOriginY > mMinYAxis)//y 
                                {
                                    ComplexMovingPart.Top = movingPartY;
                                }
                            }
                            // Set position of 4 axes
                            this.X = Convert.ToInt32((cursorOriginX + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                            this.Y = Convert.ToInt32((cursorOriginY + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                            //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                            //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                            //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);
                            if (mSide != MainController.TABLET_CONTROLLER_SIDE.NONE && mEnableTabletAxis)
                            {
                                _res = mJoystickHandler.SetAxis(this.X, mJoystickId, mTabletVerticalAxis);
                                _res = mJoystickHandler.SetAxis(this.Y, mJoystickId, mTabletHorizontalAxis);
                            }
                            else
                            {
                                _res = mJoystickHandler.SetAxis(this.X, mJoystickId, mVerticalAxis);
                                _res = mJoystickHandler.SetAxis(this.Y, mJoystickId, mHorizontalAxis);
                            }
                            //res = mJoystickHandler.SetAxis(this.Z, mJoystickId, HID_USAGES.HID_USAGE_Z);
                            //res = mJoystickHandler.SetAxis(this.RX, mJoystickId, HID_USAGES.HID_USAGE_RX);
                            //res = mJoystickHandler.SetAxis(this.RY, mJoystickId, HID_USAGES.HID_USAGE_RY);
                        }

                    }
                    break;
                case MouseButtons.Right:
                    if (mEnableMoveController && mSelectionMouseButton.Equals("MouseRight"))
                        break;
                    _label = "R";
                    mCurrentBtnInfo = mJoystickBtnId["Circle_R_Id"];
                    pressControllerBtn(mCurrentBtnInfo);

                    MouseButtonlbl.Location = ComplexControllerPnl.PointToClient(_control.PointToScreen(e.Location));
                    MouseButtonlbl.Text = _label;
                    break;
                case MouseButtons.Middle:
                    if (mEnableMoveController && mSelectionMouseButton.Equals("MouseMid"))
                        break;
                    _label = "M";
                    mCurrentBtnInfo = mJoystickBtnId["Circle_M_Id"];
                    pressControllerBtn(mCurrentBtnInfo);

                    MouseButtonlbl.Location = ComplexControllerPnl.PointToClient(_control.PointToScreen(e.Location));
                    MouseButtonlbl.Text = _label;
                    break;
            }


            //if (e.Button == MouseButtons.Left)
            //{
            //    mouseDownLocation = e.Location;
            //    movingPart.Left = movingPartX;
            //    movingPart.Top = movingPartY;
            //    MainMenu.Hide();
            //}
            //if (e.Button == MouseButtons.Right)
            //    System.Windows.Forms.MainMenu.Show(this.Location.X + e.Location.X, this.Location.Y + e.Location.Y);
            //this.Opacity = 0.90;
        }
        public void CircleBtn_MouseMove(object sender, MouseEventArgs e)
        {
            bool _res;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (mEnableMoveController && mSelectionMouseButton.Equals("MouseLeft"))
                    {
                        this.Location = Cursor.Position;
                        break;
                    }
                    if (!mEnableFollowMouse)
                    {
                        movingPartX = e.X - (ComplexMovingPart.Width / 2);
                        movingPartY = e.Y - (ComplexMovingPart.Height / 2);
                        cursorOriginX = e.X - (ComplexCircleBtn.Width / 2);
                        cursorOriginY = e.Y - (ComplexCircleBtn.Height / 2);

                        hypotenuse = Math.Sqrt(cursorOriginX * cursorOriginX + cursorOriginY * cursorOriginY);
                        double _maxHypotenuse = Math.Sqrt(mMaxXAxis * mMaxXAxis + mMaxYAxis * mMaxYAxis);
                        if (hypotenuse < mMaxXAxis)
                        {
                            if (cursorOriginX < mMaxXAxis && cursorOriginX > mMinXAxis)//x 
                            {
                                ComplexMovingPart.Left = movingPartX;
                            }
                            if (cursorOriginY < mMaxYAxis && cursorOriginY > mMinYAxis)//y 
                            {
                                ComplexMovingPart.Top = movingPartY;
                            }
                        }
                        // Set position of 4 axes
                        this.X = Convert.ToInt32((cursorOriginX + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                        this.Y = Convert.ToInt32((cursorOriginY + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                        //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                        //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                        //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);
                        Console.WriteLine("X:{0}.Y:{1}\n", this.X, this.Y);
                        if (mSide != MainController.TABLET_CONTROLLER_SIDE.NONE && mEnableTabletAxis)
                        {
                            _res = mJoystickHandler.SetAxis(this.X, mJoystickId, mTabletVerticalAxis);
                            _res = mJoystickHandler.SetAxis(this.Y, mJoystickId, mTabletHorizontalAxis);
                        }
                        else
                        {
                            _res = mJoystickHandler.SetAxis(this.X, mJoystickId, mVerticalAxis);
                            _res = mJoystickHandler.SetAxis(this.Y, mJoystickId, mHorizontalAxis);
                        }
                        //res = mJoystickHandler.SetAxis(this.Z, mJoystickId, HID_USAGES.HID_USAGE_Z);
                        //res = mJoystickHandler.SetAxis(this.RX, mJoystickId, HID_USAGES.HID_USAGE_RX);
                        //res = mJoystickHandler.SetAxis(this.RY, mJoystickId, HID_USAGES.HID_USAGE_RY);
                    }
                    break;
                case MouseButtons.Middle:
                    if (mEnableMoveController && mSelectionMouseButton.Equals("MouseMid"))
                    {
                        this.Location = Cursor.Position;
                    }
                    break;
                case MouseButtons.Right:
                    if (mEnableMoveController && mSelectionMouseButton.Equals("MouseRight"))
                    {
                        this.Location = Cursor.Position;
                    }
                    break;
                default:
                    if (mStartFollowMouse)
                    {
                        movingPartX = e.X - (ComplexMovingPart.Width / 2);
                        movingPartY = e.Y - (ComplexMovingPart.Height / 2);
                        cursorOriginX = e.X - (ComplexCircleBtn.Width / 2);
                        cursorOriginY = e.Y - (ComplexCircleBtn.Height / 2);

                        hypotenuse = Math.Sqrt(cursorOriginX * cursorOriginX + cursorOriginY * cursorOriginY);
                        double _maxHypotenuse = Math.Sqrt(mMaxXAxis * mMaxXAxis + mMaxYAxis * mMaxYAxis);
                        if (hypotenuse < mMaxXAxis)
                        {
                            if (cursorOriginX < mMaxXAxis && cursorOriginX > mMinXAxis)//x 
                            {
                                ComplexMovingPart.Left = movingPartX;
                            }
                            if (cursorOriginY < mMaxYAxis && cursorOriginY > mMinYAxis)//y 
                            {
                                ComplexMovingPart.Top = movingPartY;
                            }
                        }
                        // Set position of 4 axes
                        this.X = Convert.ToInt32((cursorOriginX + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                        this.Y = Convert.ToInt32((cursorOriginY + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                        //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                        //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                        //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);
                        Console.WriteLine("X:{0}.Y:{1}\n", e.X, e.Y);
                        if (mSide != MainController.TABLET_CONTROLLER_SIDE.NONE && mEnableTabletAxis)
                        {
                            _res = mJoystickHandler.SetAxis(this.X, mJoystickId, mTabletVerticalAxis);
                            _res = mJoystickHandler.SetAxis(this.Y, mJoystickId, mTabletHorizontalAxis);
                        }
                        else
                        {
                            _res = mJoystickHandler.SetAxis(this.X, mJoystickId, mVerticalAxis);
                            _res = mJoystickHandler.SetAxis(this.Y, mJoystickId, mHorizontalAxis);
                        }
                        //res = mJoystickHandler.SetAxis(this.Z, mJoystickId, HID_USAGES.HID_USAGE_Z);
                        //res = mJoystickHandler.SetAxis(this.RX, mJoystickId, HID_USAGES.HID_USAGE_RX);
                        //res = mJoystickHandler.SetAxis(this.RY, mJoystickId, HID_USAGES.HID_USAGE_RY);
                    }
                    else
                        CircleBtn_MouseUp(null, null);
                    break;
            }
        }

        public void CircleBtn_MouseUp(object sender, MouseEventArgs e)
        {
            bool _res;

            if (e == null)
                return;

            Control _control = (Control)sender;

            if (!mStartFollowMouse)
            {
                ComplexMovingPart.Left = ComplexCircleBtn.Width / 2 - ComplexMovingPart.Width / 2;
                ComplexMovingPart.Top = ComplexCircleBtn.Height / 2 - ComplexMovingPart.Height / 2;
            }

            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (!mEnableFollowMouse)
                    {
                        // Set position of 4 axes
                        this.X = Convert.ToInt32((0 + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                        this.Y = Convert.ToInt32((0 + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                        //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                        //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                        //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);
                        Console.WriteLine("X:{0}.Y:{1}\n", this.X, this.Y);
                        if (mSide != MainController.TABLET_CONTROLLER_SIDE.NONE && mEnableTabletAxis)
                        {
                            _res = mJoystickHandler.SetAxis(this.X, mJoystickId, mTabletVerticalAxis);
                            _res = mJoystickHandler.SetAxis(this.Y, mJoystickId, mTabletHorizontalAxis);
                        }
                        else
                        {
                            _res = mJoystickHandler.SetAxis(this.X, mJoystickId, mVerticalAxis);
                            _res = mJoystickHandler.SetAxis(this.Y, mJoystickId, mHorizontalAxis);
                        }
                        //res = mJoystickHandler.SetAxis(this.Z, mJoystickId, HID_USAGES.HID_USAGE_Z);
                        //res = mJoystickHandler.SetAxis(this.RX, mJoystickId, HID_USAGES.HID_USAGE_RX);
                        //res = mJoystickHandler.SetAxis(this.RY, mJoystickId, HID_USAGES.HID_USAGE_RY);
                    }
                    break;
                default:
                    releaseControllerBtn(mCurrentBtnInfo);
                    break;
            }

            MouseButtonlbl.Text = "";
            mCurrentBtnInfo = null;
        }

        private void CircleBtn_MouseEnter(object sender, EventArgs e)
        {
            if (mEnableFollowMouse)
            {
                if (mEnableFollowDelay)
                {
                    MouseFollowDelayTimer.Start();
                }
                else
                {
                    mStartFollowMouse = true;
                }
            }
        }

        private void CircleBtn_MouseLeave(object sender, EventArgs e)
        {
            bool _res;

            if (mEnableFollowMouse)
            {
                ComplexMovingPart.Left = ComplexCircleBtn.Width / 2 - ComplexMovingPart.Width / 2;
                ComplexMovingPart.Top = ComplexCircleBtn.Height / 2 - ComplexMovingPart.Height / 2;

                this.X = Convert.ToInt32((0 + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                this.Y = Convert.ToInt32((0 + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                if (mSide != MainController.TABLET_CONTROLLER_SIDE.NONE && mEnableTabletAxis)
                {
                    _res = mJoystickHandler.SetAxis(this.X, mJoystickId, mTabletVerticalAxis);
                    _res = mJoystickHandler.SetAxis(this.Y, mJoystickId, mTabletHorizontalAxis);
                }
                else
                {
                    _res = mJoystickHandler.SetAxis(this.X, mJoystickId, mVerticalAxis);
                    _res = mJoystickHandler.SetAxis(this.Y, mJoystickId, mHorizontalAxis);
                }

                if (mEnableFollowDelay)
                {
                    mStartFollowMouse = false;
                }
            }
        }

        private void pressControllerBtn(uint[] buttonInfo)
        {
            bool _res;
            if (buttonInfo == null)
                return;
            uint btnId = buttonInfo[0];
            if (!mJoystickBtnState.ContainsKey(btnId))
            {
                mJoystickBtnState[btnId] = false;
            }

            switch (buttonInfo[1])
            {
                case (uint)MainController.BUTTON_TYPE.PRESS:
                    mJoystickBtnState[btnId] = true;
                    break;
                case (uint)MainController.BUTTON_TYPE.RELEASE:
                    mJoystickBtnState[btnId] = false;
                    break;
                case (uint)MainController.BUTTON_TYPE.CLICK:
                    mJoystickBtnState[btnId] = true;
                    break;
                case (uint)MainController.BUTTON_TYPE.TOGGLE:
                    mJoystickBtnState[btnId] = !mJoystickBtnState[btnId];
                    break;
            }

            _res = mJoystickHandler.SetBtn(mJoystickBtnState[btnId], mJoystickId, buttonInfo[0]);
        }

        private void releaseControllerBtn(uint[] buttonInfo)
        {
            bool _res;
            if (buttonInfo == null)
                return;
            uint btnId = buttonInfo[0];

            switch (buttonInfo[1])
            {
                case (uint)MainController.BUTTON_TYPE.PRESS:
                    break;
                case (uint)MainController.BUTTON_TYPE.RELEASE:
                    break;
                case (uint)MainController.BUTTON_TYPE.CLICK:
                    mJoystickBtnState[btnId] = false;
                    break;
                case (uint)MainController.BUTTON_TYPE.TOGGLE:
                    break;
            }
            _res = mJoystickHandler.SetBtn(mJoystickBtnState[btnId], mJoystickId, buttonInfo[0]);
        }

        public void UpBtn_MouseDown(object sender, MouseEventArgs e)
        {
            string _label = "";
            Control _control = (Control)sender;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    _label = "L";
                    mCurrentBtnInfo = mJoystickBtnId["Up_L_Id"];
                    break;
                case MouseButtons.Right:
                    _label = "R";
                    mCurrentBtnInfo = mJoystickBtnId["Up_R_Id"];
                    break;
                case MouseButtons.Middle:
                    _label = "M";
                    mCurrentBtnInfo = mJoystickBtnId["Up_M_Id"];
                    break;
                case MouseButtons.XButton1:
                    _label = "X1";
                    mCurrentBtnInfo = mJoystickBtnId["Up_X1_Id"];
                    break;
                case MouseButtons.XButton2:
                    _label = "X2";
                    mCurrentBtnInfo = mJoystickBtnId["Up_X2_Id"];
                    break;
                case MouseButtons.None:
                default:
                    break;
            }


            pressControllerBtn(mCurrentBtnInfo); 

            MouseButtonlbl.Location = ComplexControllerPnl.PointToClient(_control.PointToScreen(e.Location));
            MouseButtonlbl.Text = _label;
        }

        public void DownBtn_MouseDown(object sender, MouseEventArgs e)
        {
            string _label = "";
            Control _control = (Control)sender;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    _label = "L";
                    mCurrentBtnInfo = mJoystickBtnId["Down_L_Id"];
                    break;
                case MouseButtons.Right:
                    _label = "R";
                    mCurrentBtnInfo = mJoystickBtnId["Down_R_Id"];
                    break;
                case MouseButtons.Middle:
                    _label = "M";
                    mCurrentBtnInfo = mJoystickBtnId["Down_M_Id"];
                    break;
                case MouseButtons.XButton1:
                    _label = "X1";
                    mCurrentBtnInfo = mJoystickBtnId["Down_X1_Id"];
                    break;
                case MouseButtons.XButton2:
                    _label = "X2";
                    mCurrentBtnInfo = mJoystickBtnId["Down_X2_Id"];
                    break;
                case MouseButtons.None:
                default:
                    break;
            }

            pressControllerBtn(mCurrentBtnInfo);

            MouseButtonlbl.Location = ComplexControllerPnl.PointToClient(_control.PointToScreen(e.Location));
            MouseButtonlbl.Text = _label;
        }

        public void LeftBtn_MouseDown(object sender, MouseEventArgs e)
        {
            string _label = "";
            Control _control = (Control)sender;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    _label = "L";
                    mCurrentBtnInfo = mJoystickBtnId["Left_L_Id"];
                    break;
                case MouseButtons.Right:
                    _label = "R";
                    mCurrentBtnInfo = mJoystickBtnId["Left_R_Id"];
                    break;
                case MouseButtons.Middle:
                    _label = "M";
                    mCurrentBtnInfo = mJoystickBtnId["Left_M_Id"];
                    break;
                case MouseButtons.XButton1:
                    _label = "X1";
                    mCurrentBtnInfo = mJoystickBtnId["Left_X1_Id"];
                    break;
                case MouseButtons.XButton2:
                    _label = "X2";
                    mCurrentBtnInfo = mJoystickBtnId["Left_X2_Id"];
                    break;
                case MouseButtons.None:
                default:
                    break;
            }

            pressControllerBtn(mCurrentBtnInfo);

            MouseButtonlbl.Location = ComplexControllerPnl.PointToClient(_control.PointToScreen(e.Location));
            MouseButtonlbl.Text = _label;
        }

        public void RightBtn_MouseDown(object sender, MouseEventArgs e)
        {
            string _label = "";
            Control _control = (Control)sender;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    _label = "L";
                    mCurrentBtnInfo = mJoystickBtnId["Right_L_Id"];
                    break;
                case MouseButtons.Right:
                    _label = "R";
                    mCurrentBtnInfo = mJoystickBtnId["Right_R_Id"];
                    break;
                case MouseButtons.Middle:
                    _label = "M";
                    mCurrentBtnInfo = mJoystickBtnId["Right_M_Id"];
                    break;
                case MouseButtons.XButton1:
                    _label = "X1";
                    mCurrentBtnInfo = mJoystickBtnId["Right_X1_Id"];
                    break;
                case MouseButtons.XButton2:
                    _label = "X2";
                    mCurrentBtnInfo = mJoystickBtnId["Right_X2_Id"];
                    break;
                case MouseButtons.None:
                default:
                    break;
            }

            pressControllerBtn(mCurrentBtnInfo);

            MouseButtonlbl.Location = ComplexControllerPnl.PointToClient(_control.PointToScreen(e.Location));
            MouseButtonlbl.Text = _label;
        }

        public void DangerBtn_MouseDown(object sender, MouseEventArgs e)
        {
            string _label = "";
            Control _control = (Control)sender;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    _label = "L";
                    mCurrentBtnInfo = mJoystickBtnId["Danger_L_Id"];
                    break;
                case MouseButtons.Right:
                    _label = "R";
                    mCurrentBtnInfo = mJoystickBtnId["Danger_R_Id"];
                    break;
                case MouseButtons.Middle:
                    _label = "M";
                    mCurrentBtnInfo = mJoystickBtnId["Danger_M_Id"];
                    break;
                case MouseButtons.XButton1:
                    _label = "X1";
                    mCurrentBtnInfo = mJoystickBtnId["Danger_X1_Id"];
                    break;
                case MouseButtons.XButton2:
                    _label = "X2";
                    mCurrentBtnInfo = mJoystickBtnId["Danger_X2_Id"];
                    break;
                case MouseButtons.None:
                default:
                    break;
            }

            pressControllerBtn(mCurrentBtnInfo);

            MouseButtonlbl.Location = ComplexControllerPnl.PointToClient(_control.PointToScreen(e.Location));
            MouseButtonlbl.Text = _label;
        }

        public void IndigoBtn_MouseDown(object sender, MouseEventArgs e)
        {
            string _label = "";
            Control _control = (Control)sender;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    _label = "L";
                    mCurrentBtnInfo = mJoystickBtnId["Indigo_L_Id"];
                    break;
                case MouseButtons.Right:
                    _label = "R";
                    mCurrentBtnInfo = mJoystickBtnId["Indigo_R_Id"];
                    break;
                case MouseButtons.Middle:
                    _label = "M";
                    mCurrentBtnInfo = mJoystickBtnId["Indigo_M_Id"];
                    break;
                case MouseButtons.XButton1:
                    _label = "X1";
                    mCurrentBtnInfo = mJoystickBtnId["Indigo_X1_Id"];
                    break;
                case MouseButtons.XButton2:
                    _label = "X2";
                    mCurrentBtnInfo = mJoystickBtnId["Indigo_X2_Id"];
                    break;
                case MouseButtons.None:
                default:
                    break;
            }

            pressControllerBtn(mCurrentBtnInfo);

            MouseButtonlbl.Location = ComplexControllerPnl.PointToClient(_control.PointToScreen(e.Location));
            MouseButtonlbl.Text = _label;
        }

        public void GreenBtn_MouseDown(object sender, MouseEventArgs e)
        {
            string _label = "";
            Control _control = (Control)sender;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    _label = "L";
                    mCurrentBtnInfo = mJoystickBtnId["Green_L_Id"];
                    break;
                case MouseButtons.Right:
                    _label = "R";
                    mCurrentBtnInfo = mJoystickBtnId["Green_R_Id"];
                    break;
                case MouseButtons.Middle:
                    _label = "M";
                    mCurrentBtnInfo = mJoystickBtnId["Green_M_Id"];
                    break;
                case MouseButtons.XButton1:
                    _label = "X1";
                    mCurrentBtnInfo = mJoystickBtnId["Green_X1_Id"];
                    break;
                case MouseButtons.XButton2:
                    _label = "X2";
                    mCurrentBtnInfo = mJoystickBtnId["Green_X2_Id"];
                    break;
                case MouseButtons.None:
                default:
                    break;
            }

            pressControllerBtn(mCurrentBtnInfo);

            MouseButtonlbl.Location = ComplexControllerPnl.PointToClient(_control.PointToScreen(e.Location));
            MouseButtonlbl.Text = _label;
        }

        public void BlueBtn_MouseDown(object sender, MouseEventArgs e)
        {
            string _label = "";
            Control _control = (Control)sender;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    _label = "L";
                    mCurrentBtnInfo = mJoystickBtnId["Blue_L_Id"];
                    break;
                case MouseButtons.Right:
                    _label = "R";
                    mCurrentBtnInfo = mJoystickBtnId["Blue_R_Id"];
                    break;
                case MouseButtons.Middle:
                    _label = "M";
                    mCurrentBtnInfo = mJoystickBtnId["Blue_M_Id"];
                    break;
                case MouseButtons.XButton1:
                    _label = "X1";
                    mCurrentBtnInfo = mJoystickBtnId["Blue_X1_Id"];
                    break;
                case MouseButtons.XButton2:
                    _label = "X2";
                    mCurrentBtnInfo = mJoystickBtnId["Blue_X2_Id"];
                    break;
                case MouseButtons.None:
                default:
                    break;
            }

            pressControllerBtn(mCurrentBtnInfo);

            MouseButtonlbl.Location = ComplexControllerPnl.PointToClient(_control.PointToScreen(e.Location));
            MouseButtonlbl.Text = _label;
        }

        public void JoystickBtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (e == null || mCurrentBtnInfo == null || mCurrentBtnInfo[0] == 0)
                return;
            Control _control = (Control)sender;

            releaseControllerBtn(mCurrentBtnInfo);

            MouseButtonlbl.Text = "";
            mCurrentBtnInfo = null;
        }
    }
}
