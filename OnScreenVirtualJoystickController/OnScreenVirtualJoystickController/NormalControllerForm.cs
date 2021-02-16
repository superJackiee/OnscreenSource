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

using LowLevelInput.Converters;
using LowLevelInput.Hooks;
using System.Threading;

namespace OnScreenVirtualJoystickController
{
    public partial class NormalControllerForm : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        //[System.Runtime.InteropServices.DllImport("user32", EntryPoint = "SetActiveWindow", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
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
        vJoy                mJoystickHandler;
        vJoy.JoystickState  iReport;
        uint                mJoystickId;

        bool mEnableMoveController = false;
        string mSelectionMouseButton = "";

        bool mEnableFollowMouse = false;
        bool mEnableFollowDelay = false;
        bool mStartFollowMouse = false;
        bool mEnableShowBorder = false;
        bool mEnableCaptureController = false;
        bool mEnableFixedMouse = false;
        bool mEnableTabletAxis = false;
        bool mMouseControlHook = false;

        float mOpacityValue = 0.50f;

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

        InputManager mInputManager = new InputManager();
        Thread mMouseSimulateThread;

        private void NormalControllerBorderPnl_Click(object sender, EventArgs e)
        {
            if (!mEnableCaptureController)
            {
                mEnableCaptureController = true;
                NormalControllerBorderPnl.BorderColor = Color.Red;
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
                NormalControllerBorderPnl.BorderColor = Color.Gray;
                Application.RemoveMessageFilter(gmh);
                MousePositionTimer.Stop();
            }
        }

        private void MouseSimulateProc()
        {
            mInputManager.OnMouseEvent += InputManager_OnMouseEvent;
            mInputManager.Initialize();

            mInputManager.WaitForEvent(VirtualKeyCode.Escape, KeyState.Down);

            mInputManager.Dispose();
        }

        private void NormalControllerForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && mMouseControlHook)
            {
                VirtualMouse.Location = new Point(100, 100);
                VirtualMouse.Visible = true;
                mMouseSimulateThread = new Thread(new ThreadStart(MouseSimulateProc));
                mMouseSimulateThread.Start();
            }

            if (mEnableCaptureController)
            {
                if (this.Visible)
                {
                    //Application.AddMessageFilter(gmh);
                    MousePositionTimer.Start();
                }
                else
                {
                    //Application.RemoveMessageFilter(gmh);
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

        int mRatio =100;

        public void setEnableMoveController(bool enableMove, string selectbutton)
        {
            mEnableMoveController = enableMove;
            mSelectionMouseButton = selectbutton;
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

            NormalControllerBorderPnl.BorderColor = enableShow ? Color.Gray:Color.Transparent;
        }

        public void setOpacityValue(int value)
        {
            mOpacityValue = value / 100.0f;
            this.Opacity = mOpacityValue;
        }

        public void setMouseControlHook(bool enableMouseControlHook)
        {
            mMouseControlHook = enableMouseControlHook;
        }

        void setSizeController()
        {
            float _ratio = mRatio / 100.0f;

            NormalControllerBorderPnl.Left = (int)(mBorderPnlLeft * _ratio);
            NormalControllerBorderPnl.Top = (int)(mBorderPnlTop * _ratio);
            NormalControllerBorderPnl.Width = (int)(mBorderPnlWidth * _ratio);
            NormalControllerBorderPnl.Height = (int)(mBorderPnlHeight * _ratio);

            NormalControllerPnl.Left = (int)(mControllerPnlLeft * _ratio);
            NormalControllerPnl.Top = (int)(mControllerPnlTop * _ratio);
            NormalControllerPnl.Width = (int)(mControllerPnlWidth * _ratio);
            NormalControllerPnl.Height = (int)(mControllerPnlHeight * _ratio);

            NormalCircleBtn.Left = (int)(mCircleBtnLeft * _ratio);
            NormalCircleBtn.Top = (int)(mCircleBtnTop * _ratio);
            NormalCircleBtn.Width = (int)(mCircleBtnWidth * _ratio);
            NormalCircleBtn.Height = (int)(mCircleBtnHeight * _ratio);

            NormalMovingPart.Left = (int)(mMovingPartLeft * _ratio);
            NormalMovingPart.Top = (int)(mMovingPartTop * _ratio);
            NormalMovingPart.Width = (int)(mMovingPartWidth * _ratio);
            NormalMovingPart.Height = (int)(mMovingPartHeight * _ratio);

            NormalDangerBtn.Left = (int)(mDangerBtnLeft * _ratio);
            NormalDangerBtn.Top = (int)(mDangerBtnTop * _ratio);
            NormalDangerBtn.Width = (int)(mDangerBtnWidth * _ratio);
            NormalDangerBtn.Height = (int)(mDangerBtnHeight * _ratio);

            NormalGreenBtn.Left = (int)(mGreenBtnLeft * _ratio);
            NormalGreenBtn.Top = (int)(mGreenBtnTop * _ratio);
            NormalGreenBtn.Width = (int)(mGreenBtnWidth * _ratio);
            NormalGreenBtn.Height = (int)(mGreenBtnHeight * _ratio);

            NormalIndigoBtn.Left = (int)(mIndigoBtnLeft * _ratio);
            NormalIndigoBtn.Top = (int)(mIndigoBtnTop * _ratio);
            NormalIndigoBtn.Width = (int)(mIndigoBtnWidth * _ratio);
            NormalIndigoBtn.Height = (int)(mIndigoBtnHeight * _ratio);

            NormalBlueBtn.Left = (int)(mBlueBtnLeft * _ratio);
            NormalBlueBtn.Top = (int)(mBlueBtnTop * _ratio);
            NormalBlueBtn.Width = (int)(mBlueBtnWidth * _ratio);
            NormalBlueBtn.Height = (int)(mBlueBtnHeight * _ratio);

            mMinXAxis = -NormalCircleBtn.Width / 2 + NormalMovingPart.Width;
            mMaxXAxis = NormalCircleBtn.Width / 2 - NormalMovingPart.Width;
            mMinYAxis = -NormalCircleBtn.Height / 2 + NormalMovingPart.Height;
            mMaxYAxis = NormalCircleBtn.Height / 2 - NormalMovingPart.Height;

            NormalControllerBorderPnl.BorderWidth = (int)(10.0f * _ratio);
        }

        private void NormalControllerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mInputManager.Dispose();
        }

        private void NormalControllerForm_Load(object sender, EventArgs e)
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

        public NormalControllerForm(MainController.TABLET_CONTROLLER_SIDE side)
        {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
            this.Opacity = mOpacityValue;
            this.TopMost = true;
            mSide = side;

            mBorderPnlLeft = NormalControllerBorderPnl.Left; mBorderPnlTop = NormalControllerBorderPnl.Top; mBorderPnlWidth = NormalControllerBorderPnl.Width; mBorderPnlHeight = NormalControllerBorderPnl.Height;
            mControllerPnlLeft = NormalControllerPnl.Left; mControllerPnlTop = NormalControllerPnl.Top; mControllerPnlWidth = NormalControllerPnl.Width; mControllerPnlHeight = NormalControllerPnl.Height;
            mCircleBtnLeft = NormalCircleBtn.Left; mCircleBtnTop = NormalCircleBtn.Top; mCircleBtnWidth = NormalCircleBtn.Width; mCircleBtnHeight = NormalCircleBtn.Height;
            mMovingPartLeft = NormalMovingPart.Left; mMovingPartTop = NormalMovingPart.Top; mMovingPartWidth = NormalMovingPart.Width; mMovingPartHeight = NormalMovingPart.Height;
            mDangerBtnLeft = NormalDangerBtn.Left; mDangerBtnTop = NormalDangerBtn.Top; mDangerBtnWidth = NormalDangerBtn.Width; mDangerBtnHeight = NormalDangerBtn.Height;
            mGreenBtnLeft = NormalGreenBtn.Left; mGreenBtnTop = NormalGreenBtn.Top; mGreenBtnWidth = NormalGreenBtn.Width; mGreenBtnHeight = NormalGreenBtn.Height;
            mIndigoBtnLeft = NormalIndigoBtn.Left; mIndigoBtnTop = NormalIndigoBtn.Top; mIndigoBtnWidth = NormalIndigoBtn.Width; mIndigoBtnHeight = NormalIndigoBtn.Height;
            mBlueBtnLeft = NormalBlueBtn.Left; mBlueBtnTop = NormalBlueBtn.Top; mBlueBtnWidth = NormalBlueBtn.Width; mBlueBtnHeight = NormalBlueBtn.Height;
            mMinXAxis = -mCircleBtnWidth / 2 + mMovingPartWidth;
            mMaxXAxis = mCircleBtnWidth / 2 - mMovingPartWidth;
            mMinYAxis = -mCircleBtnHeight / 2 + mMovingPartHeight;
            mMaxYAxis = mCircleBtnHeight / 2 - mMovingPartHeight;

            mDefaultWidth = 430;
            mDefaultHeight = 350;

            NormalControllerBorderPnl.BorderColor = Color.Transparent;
            //gmh.TheMouseMoved += new MouseMovedEvent(gmh_TheMouseMoved);
            MousePositionTimer.Interval = 25;
        }

        void moveVirtualMouse()
        {
            VirtualMouse.Left = mArg.X;
            VirtualMouse.Top = mArg.Y;
            Console.WriteLine("{0}--{1}", mArg.X, mArg.Y);
            VirtualMouse.Refresh();
        }
        

        public event MouseEventHandler ManualMouseDown;
        public event MouseEventHandler ManualMouseMove;
        public event MouseEventHandler ManualMouseUp;
        MouseEventArgs mArg;
        public delegate void InvokeDelegate();

        private void InputManager_OnMouseEvent(VirtualKeyCode key, KeyState state, int x, int y)
        {


            switch (key)
            {
                case VirtualKeyCode.Invalid:
                    mArg = new MouseEventArgs(MouseButtons.None, 0, x, y, 0);
                    this.BeginInvoke(new InvokeDelegate(moveVirtualMouse));
                    break;
                case VirtualKeyCode.Lbutton:
                    mArg = new MouseEventArgs(MouseButtons.Left, 1, x, y, 0);
                    if (state == KeyState.Down)
                        ManualMouseDown?.Invoke(null, mArg);
                    else
                        ManualMouseUp?.Invoke(null, mArg);
                    break;
                case VirtualKeyCode.Rbutton:
                    mArg = new MouseEventArgs(MouseButtons.Right, 1, x, y, 0);
                    if (state == KeyState.Down)
                        ManualMouseDown?.Invoke(null, mArg);
                    else
                        ManualMouseUp?.Invoke(null, mArg);
                    break;
                case VirtualKeyCode.Mbutton:
                    mArg = new MouseEventArgs(MouseButtons.Middle, 1, x, y, 0);
                    if (state == KeyState.Down)
                        ManualMouseDown?.Invoke(null, mArg);
                    else
                        ManualMouseUp?.Invoke(null, mArg);
                    break;
                case VirtualKeyCode.Xbutton1:
                    mArg = new MouseEventArgs(MouseButtons.XButton1, 1, x, y, 0);
                    if (state == KeyState.Down)
                        ManualMouseDown?.Invoke(null, mArg);
                    else
                        ManualMouseUp?.Invoke(null, mArg);
                    break;
                case VirtualKeyCode.Xbutton2:
                    mArg = new MouseEventArgs(MouseButtons.XButton2, 1, x, y, 0);
                    if (state == KeyState.Down)
                        ManualMouseDown?.Invoke(null, mArg);
                    else
                        ManualMouseUp?.Invoke(null, mArg);
                    break;
            }

            //MouseDown?.Invoke();
            //Point _pt = VirtualMouse.PointToClient(new Point(x, y));
            //VirtualMouse.Left = 150;
            //VirtualMouse.Top = 150;

            Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y);
            Cursor.Clip = new Rectangle(Cursor.Position.X, Cursor.Position.Y, 1, 1);
            Cursor.Hide();

            Console.WriteLine("-{0}-{1}-", x, y);
            Console.WriteLine("--{0}--", VirtualMouse.Location);
        }

        void gmh_TheMouseMoved()
        {
            Point cur_pos = Cursor.Position;
            mOffsetXMoving = this.PointToClient(cur_pos).X;
            mOffsetYMoving = this.PointToClient(cur_pos).Y;

            if (mEnableFixedMouse)
            {
                int _X = cur_pos.X - mFixedMouseX;
                int _Y = cur_pos.Y - mFixedMouseY;

                Console.WriteLine("-{0}-{1}-", _X, _Y);
                if (_X != 0 || _Y != 0)
                {
                    this.Location = new Point(this.Location.X - _X, this.Location.Y - _Y);
                    
                    Screen _currentScreen = Screen.PrimaryScreen;
                    int _screenWidth = _currentScreen.Bounds.Width;
                    int _screenHeight = _currentScreen.Bounds.Height;
                    //uint _flag = (uint)(InteropMouse.MouseEventFlags.Absolute | InteropMouse.MouseEventFlags.Movement);
                    int _absX = (int)(65535 * (float)mFixedMouseX / _screenWidth);
                    int _absY = (int)(65535 * (float)mFixedMouseY / _screenHeight);
                    //InteropMouse.mouse_event(_flag, _absX, _absY, 0, 0);

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
            this.NormalDangerBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(DangerBtn_MouseDown);
            this.NormalDangerBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.NormalIndigoBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(IndigoBtn_MouseDown);
            this.NormalIndigoBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.NormalGreenBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(GreenBtn_MouseDown);
            this.NormalGreenBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.NormalBlueBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(BlueBtn_MouseDown);
            this.NormalBlueBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.NormalCircleBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(CircleBtn_MouseDown);
            this.NormalCircleBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(CircleBtn_MouseUp);
            this.NormalCircleBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(CircleBtn_MouseMove);
            this.NormalCircleBtn.MouseEnter += new System.EventHandler(CircleBtn_MouseEnter);
            this.NormalCircleBtn.MouseLeave += new System.EventHandler(CircleBtn_MouseLeave);

            this.ManualMouseDown += new System.Windows.Forms.MouseEventHandler(CircleBtn_MouseDown);
            this.ManualMouseUp += new System.Windows.Forms.MouseEventHandler(CircleBtn_MouseUp);
            this.ManualMouseMove += new System.Windows.Forms.MouseEventHandler(CircleBtn_MouseMove);

            //to initialize joystick driver
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

                    if(mEnableFollowMouse)
                    {
                        _label = "L";
                        mCurrentBtnInfo = mJoystickBtnId["Circle_L_Id"];
                        pressControllerBtn(mCurrentBtnInfo);

                        MouseButtonlbl.Location = NormalControllerPnl.PointToClient(_control.PointToScreen(e.Location));
                        MouseButtonlbl.Text = _label;
                    }
                    else
                    {
                        if(mStartFollowMouse)
                        {
                            movingPartX = e.X - (NormalMovingPart.Width / 2);
                            movingPartY = e.Y - (NormalMovingPart.Height / 2);
                            cursorOriginX = e.X - (NormalCircleBtn.Width / 2);
                            cursorOriginY = e.Y - (NormalCircleBtn.Height / 2);

                            hypotenuse = Math.Sqrt(cursorOriginX * cursorOriginX + cursorOriginY * cursorOriginY);
                            double _maxHypotenuse = Math.Sqrt(mMaxXAxis * mMaxXAxis + mMaxYAxis * mMaxYAxis);
                            if (hypotenuse < mMaxXAxis)
                            {
                                if (cursorOriginX < mMaxXAxis && cursorOriginX > mMinXAxis)//x 
                                {
                                    NormalMovingPart.Left = movingPartX;
                                }
                                if (cursorOriginY < mMaxYAxis && cursorOriginY > mMinYAxis)//y 
                                {
                                    NormalMovingPart.Top = movingPartY;
                                }
                            }
                            // Set position of 4 axes
                            this.X = Convert.ToInt32((cursorOriginX + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                            this.Y = Convert.ToInt32((cursorOriginY + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                            //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                            //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                            //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);
                            //Console.WriteLine("X:{0}.Y:{1}\n", e.X, e.Y);
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

                    MouseButtonlbl.Location = NormalControllerPnl.PointToClient(_control.PointToScreen(e.Location));
                    MouseButtonlbl.Text = _label;
                    break;
                case MouseButtons.Middle:
                    if (mEnableMoveController && mSelectionMouseButton.Equals("MouseMid"))
                        break;
                    _label = "M";
                    mCurrentBtnInfo = mJoystickBtnId["Circle_M_Id"];
                    pressControllerBtn(mCurrentBtnInfo);

                    MouseButtonlbl.Location = NormalControllerPnl.PointToClient(_control.PointToScreen(e.Location));
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

                    if (!mEnableFollowMouse)
                    {
                        movingPartX = e.X - (NormalMovingPart.Width / 2);
                        movingPartY = e.Y - (NormalMovingPart.Height / 2);
                        cursorOriginX = e.X - (NormalCircleBtn.Width / 2);
                        cursorOriginY = e.Y - (NormalCircleBtn.Height / 2);

                        hypotenuse = Math.Sqrt(cursorOriginX * cursorOriginX + cursorOriginY * cursorOriginY);
                        double _maxHypotenuse = Math.Sqrt(mMaxXAxis * mMaxXAxis + mMaxYAxis * mMaxYAxis);
                        if (hypotenuse < mMaxXAxis)
                        {
                            if (cursorOriginX < mMaxXAxis && cursorOriginX > mMinXAxis)//x 
                            {
                                NormalMovingPart.Left = movingPartX;
                            }
                            if (cursorOriginY < mMaxYAxis && cursorOriginY > mMinYAxis)//y 
                            {
                                NormalMovingPart.Top = movingPartY;
                            }
                        }
                        // Set position of 4 axes
                        this.X = Convert.ToInt32((cursorOriginX + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                        this.Y = Convert.ToInt32((cursorOriginY + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                        //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                        //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                        //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);
                        //Console.WriteLine("X:{0}.Y:{1}\n", e.X, e.Y);
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
                    if(mStartFollowMouse)
                    {
                        movingPartX = e.X - (NormalMovingPart.Width / 2);
                        movingPartY = e.Y - (NormalMovingPart.Height / 2);
                        cursorOriginX = e.X - (NormalCircleBtn.Width / 2);
                        cursorOriginY = e.Y - (NormalCircleBtn.Height / 2);

                        hypotenuse = Math.Sqrt(cursorOriginX * cursorOriginX + cursorOriginY * cursorOriginY);
                        double _maxHypotenuse = Math.Sqrt(mMaxXAxis * mMaxXAxis + mMaxYAxis * mMaxYAxis);
                        if (hypotenuse < mMaxXAxis)
                        {
                            if (cursorOriginX < mMaxXAxis && cursorOriginX > mMinXAxis)//x 
                            {
                                NormalMovingPart.Left = movingPartX;
                            }
                            if (cursorOriginY < mMaxYAxis && cursorOriginY > mMinYAxis)//y 
                            {
                                NormalMovingPart.Top = movingPartY;
                            }
                        }
                        // Set position of 4 axes
                        this.X = Convert.ToInt32((0 + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                        this.Y = Convert.ToInt32((0 + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                        //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                        //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                        //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);
                        //Console.WriteLine("X:{0}.Y:{1}\n", e.X, e.Y);
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
                NormalMovingPart.Left = NormalCircleBtn.Width / 2 - NormalMovingPart.Width / 2;
                NormalMovingPart.Top = NormalCircleBtn.Height / 2 - NormalMovingPart.Height / 2;
            }
            
            switch (e.Button)
            {
                case MouseButtons.Left:

                    if(!mEnableFollowMouse)
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
                    else
                    {
                        releaseControllerBtn(mCurrentBtnInfo);
                    }
                    break;
                case MouseButtons.Right:
                case MouseButtons.Middle:
                    releaseControllerBtn(mCurrentBtnInfo);
                    break;
                default:
                    break;

            }
            
            MouseButtonlbl.Text = "";
            mCurrentBtnInfo = null;
        }

        private void CircleBtn_MouseEnter(object sender, EventArgs e)
        {
            if(mEnableFollowMouse)
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

            if (mStartFollowMouse)
            {
                NormalMovingPart.Left = NormalCircleBtn.Width / 2 - NormalMovingPart.Width / 2;
                NormalMovingPart.Top = NormalCircleBtn.Height / 2 - NormalMovingPart.Height / 2;

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

            MouseButtonlbl.Location = NormalControllerPnl.PointToClient(_control.PointToScreen(e.Location));
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

            MouseButtonlbl.Location = NormalControllerPnl.PointToClient(_control.PointToScreen(e.Location));
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

            MouseButtonlbl.Location = NormalControllerPnl.PointToClient(_control.PointToScreen(e.Location));
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

            MouseButtonlbl.Location = NormalControllerPnl.PointToClient(_control.PointToScreen(e.Location));
            MouseButtonlbl.Text = _label;
        }

        public void JoystickBtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (e == null || mCurrentBtnInfo == null || mCurrentBtnInfo[0]==0)
                return;
            Control _control = (Control)sender;

            releaseControllerBtn(mCurrentBtnInfo);

            MouseButtonlbl.Text = "";
            mCurrentBtnInfo = null;
        }
    }

}
