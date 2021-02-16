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
    public partial class CompactControllerForm : Form
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
        bool mEnableShowBorder = false;
        bool mEnableCaptureController = false;
        bool mEnableGotoNeutral = false;
        bool mEnableFixedMouse = false;
        bool mEnableTabletAxis = false;

        float mOpacityValue = 0.05f;

        int mBorderPnlLeft, mBorderPnlTop, mBorderPnlWidth, mBorderPnlHeight;
        int mControllerPnlLeft, mControllerPnlTop, mControllerPnlWidth, mControllerPnlHeight;
        int mCircleBtnLeft, mCircleBtnTop, mCircleBtnWidth, mCircleBtnHeight;
        int mMovingPartLeft, mMovingPartTop, mMovingPartWidth, mMovingPartHeight;
        int mDangerBtnLeft, mDangerBtnTop, mDangerBtnWidth, mDangerBtnHeight;
        int mGreenBtnLeft, mGreenBtnTop, mGreenBtnWidth, mGreenBtnHeight;
        int mIndigoBtnLeft, mIndigoBtnTop, mIndigoBtnWidth, mIndigoBtnHeight;
        int mBlueBtnLeft, mBlueBtnTop, mBlueBtnWidth, mBlueBtnHeight;
        
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
        
        bool mCustomSize =false;

        int mFixedMouseX, mFixedMouseY;

        private void CompactControllerBorderPnl_Click(object sender, EventArgs e)
        {
            if (!mEnableCaptureController)
            {
                mEnableCaptureController = true;
                CompactControllerBorderPnl.BorderColor = Color.Red;
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
                CompactControllerBorderPnl.BorderColor = Color.Gray;
                Application.RemoveMessageFilter(gmh);
                MousePositionTimer.Stop();
            }
        }

        private void CompactControllerForm_VisibleChanged(object sender, EventArgs e)
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

                int _centerX = this.Bounds.Left + this.Bounds.Width / 2;
                int _centerY = this.Bounds.Top + this.Bounds.Height / 2;
                double _diameter = Math.Sqrt((_centerX - cur_pos.X) * (_centerX - cur_pos.X) + (_centerY - cur_pos.Y) * (_centerY - cur_pos.Y));


                bool _capture = _diameter < this.Bounds.Width / 2;

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

        public void setEnableFollowingMouse(bool enableFollow)
        {
            mEnableFollowMouse = enableFollow;
        }

        public void setEnableShowingBorder(bool enableShow, bool enableFixedMouse)
        {
            mEnableShowBorder = enableShow;
            mEnableFixedMouse = enableFixedMouse;

            CompactControllerBorderPnl.BorderColor = enableShow ? Color.Gray : Color.Transparent;
        }
        
        public void setEnableGotoNeutral(bool enableNeutral)
        {
            mEnableGotoNeutral = enableNeutral;
        }

        public void setOpacityValue(int value)
        {
            mOpacityValue = value / 100.0f;
            this.Opacity = mOpacityValue;
        }

        void setSizeController()
        {
            float _ratio = mRatio / 100.0f;

            CompactControllerBorderPnl.Left = (int)(mBorderPnlLeft * _ratio);
            CompactControllerBorderPnl.Top = (int)(mBorderPnlTop * _ratio);
            CompactControllerBorderPnl.Width = (int)(mBorderPnlWidth * _ratio);
            CompactControllerBorderPnl.Height = (int)(mBorderPnlHeight * _ratio);
            
            CompactControllerPnl.Left = (int)(mControllerPnlLeft * _ratio);
            CompactControllerPnl.Top = (int)(mControllerPnlTop * _ratio);
            CompactControllerPnl.Width = (int)(mControllerPnlWidth * _ratio);
            CompactControllerPnl.Height = (int)(mControllerPnlHeight * _ratio);

            CompactCircleBtn.Left = (int)(mCircleBtnLeft * _ratio);
            CompactCircleBtn.Top = (int)(mCircleBtnTop * _ratio);
            CompactCircleBtn.Width = (int)(mCircleBtnWidth * _ratio);
            CompactCircleBtn.Height = (int)(mCircleBtnHeight * _ratio);

            CompactMovingPart.Left = (int)(mMovingPartLeft * _ratio);
            CompactMovingPart.Top = (int)(mMovingPartTop * _ratio);
            CompactMovingPart.Width = (int)(mMovingPartWidth * _ratio);
            CompactMovingPart.Height = (int)(mMovingPartHeight * _ratio);

            CompactDangerBtn.Left = (int)(mDangerBtnLeft * _ratio);
            CompactDangerBtn.Top = (int)(mDangerBtnTop * _ratio);
            CompactDangerBtn.Width = (int)(mDangerBtnWidth * _ratio);
            CompactDangerBtn.Height = (int)(mDangerBtnHeight * _ratio);

            CompactGreenBtn.Left = (int)(mGreenBtnLeft * _ratio);
            CompactGreenBtn.Top = (int)(mGreenBtnTop * _ratio);
            CompactGreenBtn.Width = (int)(mGreenBtnWidth * _ratio);
            CompactGreenBtn.Height = (int)(mGreenBtnHeight * _ratio);

            CompactIndigoBtn.Left = (int)(mIndigoBtnLeft * _ratio);
            CompactIndigoBtn.Top = (int)(mIndigoBtnTop * _ratio);
            CompactIndigoBtn.Width = (int)(mIndigoBtnWidth * _ratio);
            CompactIndigoBtn.Height = (int)(mIndigoBtnHeight * _ratio);

            CompactBlueBtn.Left = (int)(mBlueBtnLeft * _ratio);
            CompactBlueBtn.Top = (int)(mBlueBtnTop * _ratio);
            CompactBlueBtn.Width = (int)(mBlueBtnWidth * _ratio);
            CompactBlueBtn.Height = (int)(mBlueBtnHeight * _ratio);

            mMinXAxis = -CompactCircleBtn.Width / 2 + CompactMovingPart.Width / 2;
            mMaxXAxis = CompactCircleBtn.Width / 2 - CompactMovingPart.Width / 2;
            mMinYAxis = -CompactCircleBtn.Height / 2 + CompactMovingPart.Height / 2;
            mMaxYAxis = CompactCircleBtn.Height / 2 - CompactMovingPart.Height / 2;

            CompactControllerBorderPnl.BorderWidth = (int)(10.0f * _ratio);

        }
        private void CompactControllerForm_Load(object sender, EventArgs e)
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

        public CompactControllerForm(MainController.TABLET_CONTROLLER_SIDE side)
        {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
            this.Opacity = mOpacityValue;
            this.TopMost = true;
            mSide = side;

            mBorderPnlLeft = CompactControllerBorderPnl.Left; mBorderPnlTop = CompactControllerBorderPnl.Top; mBorderPnlWidth = CompactControllerBorderPnl.Width; mBorderPnlHeight = CompactControllerBorderPnl.Height;
            mControllerPnlLeft = CompactControllerPnl.Left; mControllerPnlTop = CompactControllerPnl.Top; mControllerPnlWidth = CompactControllerPnl.Width; mControllerPnlHeight = CompactControllerPnl.Height;
            mCircleBtnLeft = CompactCircleBtn.Left; mCircleBtnTop = CompactCircleBtn.Top; mCircleBtnWidth = CompactCircleBtn.Width; mCircleBtnHeight = CompactCircleBtn.Height;
            mMovingPartLeft = CompactMovingPart.Left; mMovingPartTop = CompactMovingPart.Top; mMovingPartWidth = CompactMovingPart.Width; mMovingPartHeight = CompactMovingPart.Height;
            mDangerBtnLeft = CompactDangerBtn.Left; mDangerBtnTop = CompactDangerBtn.Top; mDangerBtnWidth = CompactDangerBtn.Width; mDangerBtnHeight = CompactDangerBtn.Height;
            mGreenBtnLeft = CompactGreenBtn.Left; mGreenBtnTop = CompactGreenBtn.Top; mGreenBtnWidth = CompactGreenBtn.Width; mGreenBtnHeight = CompactGreenBtn.Height;
            mIndigoBtnLeft = CompactIndigoBtn.Left; mIndigoBtnTop = CompactIndigoBtn.Top; mIndigoBtnWidth = CompactIndigoBtn.Width; mIndigoBtnHeight = CompactIndigoBtn.Height;
            mBlueBtnLeft = CompactBlueBtn.Left; mBlueBtnTop = CompactBlueBtn.Top; mBlueBtnWidth = CompactBlueBtn.Width; mBlueBtnHeight = CompactBlueBtn.Height;
            mMinXAxis = -mCircleBtnWidth / 2 + mMovingPartWidth/2;
            mMaxXAxis = mCircleBtnWidth / 2 - mMovingPartWidth/2;
            mMinYAxis = -mCircleBtnHeight / 2 + mMovingPartHeight/2;
            mMaxYAxis = mCircleBtnHeight / 2 - mMovingPartHeight/2;

            mDefaultWidth = 350;
            mDefaultHeight = 350;

            CompactControllerBorderPnl.BorderColor = Color.Transparent;
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
            this.CompactDangerBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(DangerBtn_MouseDown);
            this.CompactDangerBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.CompactIndigoBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(IndigoBtn_MouseDown);
            this.CompactIndigoBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.CompactGreenBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(GreenBtn_MouseDown);
            this.CompactGreenBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.CompactBlueBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(BlueBtn_MouseDown);
            this.CompactBlueBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.CompactCircleBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(CircleBtn_MouseDown);
            this.CompactCircleBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(CircleBtn_MouseUp);
            this.CompactCircleBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(CircleBtn_MouseMove);
            this.CompactCircleBtn.MouseLeave += new System.EventHandler(CircleBtn_MouseLeave);
        }



        uint[] mCurrentBtnInfo = null;
        int X, Y;
        long mMaxX, mMaxY;

        Dictionary<string, uint[]> mJoystickBtnId;
        Dictionary<uint, bool> mJoystickBtnState = new Dictionary<uint, bool>();

        public void setJoystickBtnId(Dictionary<string, uint[]> joystickbtnid, string vaxis, string haxis)
        {
            mJoystickBtnId = joystickbtnid;
            switch(vaxis)
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

        double hypotenuse, angleX, angleY;
        int cursorOriginX, cursorOriginY;
        int movingPartX, movingPartY;
        public HID_USAGES mVerticalAxis, mHorizontalAxis;
        public HID_USAGES mTabletVerticalAxis, mTabletHorizontalAxis;


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
                    movingPartX = e.X - (CompactMovingPart.Width / 2);
                    movingPartY = e.Y - (CompactMovingPart.Height / 2);
                    cursorOriginX = e.X - (CompactCircleBtn.Width / 2);
                    cursorOriginY = e.Y - (CompactCircleBtn.Height / 2);

                    hypotenuse = Math.Sqrt(cursorOriginX * cursorOriginX + cursorOriginY * cursorOriginY);

                    angleX = Math.Acos(cursorOriginX / hypotenuse);
                    angleY = Math.Asin(cursorOriginY / hypotenuse);

                    movingPartX = (int)((mMaxXAxis - (5 * mRatio / 100.0f)) * Math.Cos(angleX) + mMaxXAxis);
                    movingPartY = (int)((mMaxYAxis - (5 * mRatio / 100.0f)) * Math.Sin(angleY) + mMaxYAxis);

                    Console.WriteLine("movingPartX:{0}.movingPartY:{1}\n", this.movingPartX, this.movingPartY);

                    if (hypotenuse < CompactCircleBtn.Width / 2)
                    {
                        CompactMovingPart.Left = movingPartX;
                        CompactMovingPart.Top = movingPartY;
                    }
                    // Set position of 4 axes
                    this.X = Convert.ToInt32((cursorOriginX + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                    this.Y = Convert.ToInt32((cursorOriginY + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                    //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                    //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                    //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);
                    //Console.WriteLine("X:{0}.Y:{1}\n", this.X, this.Y);
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
                    break;
                case MouseButtons.Right:
                    if (mEnableMoveController && mSelectionMouseButton.Equals("MouseRight"))
                        break;
                    _label = "R";
                    mCurrentBtnInfo = mJoystickBtnId["Circle_R_Id"];
                    pressControllerBtn(mCurrentBtnInfo);

                    MouseButtonlbl.Location = CompactControllerPnl.PointToClient(_control.PointToScreen(e.Location));
                    MouseButtonlbl.Text = _label;
                    break;
                case MouseButtons.Middle:
                    if (mEnableMoveController && mSelectionMouseButton.Equals("MouseMid"))
                        break;
                    _label = "M";
                    mCurrentBtnInfo = mJoystickBtnId["Circle_M_Id"];
                    pressControllerBtn(mCurrentBtnInfo);

                    MouseButtonlbl.Location = CompactControllerPnl.PointToClient(_control.PointToScreen(e.Location));
                    MouseButtonlbl.Text = _label;
                    break;
            }


            //if (e.Button == MouseButtons.Left)
            //{
            //    mouseDownLocation = e.Location;
            //    movingPart.Left = movingPartX;
            //    movingPart.Top = movingPartY;
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
                    movingPartX = e.X - (CompactMovingPart.Width / 2);
                    movingPartY = e.Y - (CompactMovingPart.Height / 2);
                    cursorOriginX = e.X - (CompactCircleBtn.Width / 2);
                    cursorOriginY = e.Y - (CompactCircleBtn.Height / 2);

                    hypotenuse = Math.Sqrt(cursorOriginX * cursorOriginX + cursorOriginY * cursorOriginY);

                    angleX = Math.Acos(cursorOriginX / hypotenuse);
                    angleY = Math.Asin(cursorOriginY / hypotenuse);

                    movingPartX = (int)((mMaxXAxis - (5 * mRatio / 100.0f)) * Math.Cos(angleX) + mMaxXAxis);
                    movingPartY = (int)((mMaxYAxis - (5 * mRatio / 100.0f)) * Math.Sin(angleY) + mMaxYAxis);

                    Console.WriteLine("movingPartX:{0}.movingPartY:{1}\n", this.movingPartX, this.movingPartY);

                    if (hypotenuse < CompactCircleBtn.Width / 2)
                    {
                        CompactMovingPart.Left = movingPartX;
                        CompactMovingPart.Top = movingPartY;
                    }
                    // Set position of 4 axes
                    this.X = Convert.ToInt32((cursorOriginX + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                    this.Y = Convert.ToInt32((cursorOriginY + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                    //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                    //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                    //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);
                    //Console.WriteLine("X:{0}.Y:{1}\n", this.X, this.Y);
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
                    break;
                case MouseButtons.Right:
                    if (mEnableMoveController && mSelectionMouseButton.Equals("MouseRight"))
                    {
                        this.Location = Cursor.Position;
                    }
                    break;
                case MouseButtons.Middle:
                    if (mEnableMoveController && mSelectionMouseButton.Equals("MouseMid"))
                    {
                        this.Location = Cursor.Position;
                    }
                    break;
                default:
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

            switch (e.Button)
            {
                case MouseButtons.Left:
                    break;
                default:
                    releaseControllerBtn(mCurrentBtnInfo);
                    break;
            }

            MouseButtonlbl.Text = "";
        }

        public void CircleBtn_MouseLeave(object sender, EventArgs e)
        {
            bool _res;

            if (mEnableGotoNeutral)
            {
                // Set position of 4 axes
                this.X = Convert.ToInt32((0 + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                this.Y = Convert.ToInt32((0 + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);
                //Console.WriteLine("X:{0}.Y:{1}\n", this.X, this.Y);
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

            MouseButtonlbl.Location = CompactControllerPnl.PointToClient(_control.PointToScreen(e.Location));
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

            MouseButtonlbl.Location = CompactControllerPnl.PointToClient(_control.PointToScreen(e.Location));
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

            MouseButtonlbl.Location = CompactControllerPnl.PointToClient(_control.PointToScreen(e.Location));
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

            MouseButtonlbl.Location = CompactControllerPnl.PointToClient(_control.PointToScreen(e.Location));
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
