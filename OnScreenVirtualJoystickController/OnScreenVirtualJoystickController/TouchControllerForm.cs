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
    public partial class TouchControllerForm : Form
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
        vJoy                mJoystickHandler;
        vJoy.JoystickState  iReport;
        uint                mJoystickId;

        bool mEnableMoveController = false;
        string mSelectionMouseButton = "";
        bool mEnableFollowMouse = false;
        bool mEnableShowBorder = false;
        bool mEnableCaptureController = false;
        bool mEnableGotoNeutral = false;
        bool mEnableFixedMouse = false;
        bool mEnableTabletAxis = false;

        float mOpacityValue = 0.50f;

        int mBorderPnlLeft, mBorderPnlTop, mBorderPnlWidth, mBorderPnlHeight;
        int mControllerPnlLeft, mControllerPnlTop, mControllerPnlWidth, mControllerPnlHeight;
        int mTouchBoardPnlLeft, mTouchBoardPnlTop, mTouchBoardPnlWidth, mTouchBoardPnlHeight;
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

        bool mCustomSize = false;

        int mFixedMouseX, mFixedMouseY;

        private void TouchControllerBorderPnl_Click(object sender, EventArgs e)
        {
            if (!mEnableCaptureController)
            {
                mEnableCaptureController = true;
                TouchControllerBorderPnl.BorderColor = Color.Red;
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
                TouchControllerBorderPnl.BorderColor = Color.Gray;
                Application.RemoveMessageFilter(gmh);
                MousePositionTimer.Stop();
            }
        }

        private void TouchControllerForm_VisibleChanged(object sender, EventArgs e)
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

        public void setEnableShowingBorder(bool enableShow, bool enableFixedMouse)
        {
            mEnableShowBorder = enableShow;
            mEnableFixedMouse = enableFixedMouse;

            TouchControllerBorderPnl.BorderColor = enableShow ? Color.Gray : Color.Transparent;
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

            TouchControllerBorderPnl.Left = (int)(mBorderPnlLeft * _ratio);
            TouchControllerBorderPnl.Top = (int)(mBorderPnlTop * _ratio);
            TouchControllerBorderPnl.Width = (int)(mBorderPnlWidth * _ratio);
            TouchControllerBorderPnl.Height = (int)(mBorderPnlHeight * _ratio);

            TouchControllerPnl.Left = (int)(mControllerPnlLeft * _ratio);
            TouchControllerPnl.Top = (int)(mControllerPnlTop * _ratio);
            TouchControllerPnl.Width = (int)(mControllerPnlWidth * _ratio);
            TouchControllerPnl.Height = (int)(mControllerPnlHeight * _ratio);

            TouchTouchBoardPnl.Left = (int)(mTouchBoardPnlLeft * _ratio);
            TouchTouchBoardPnl.Top = (int)(mTouchBoardPnlTop * _ratio);
            TouchTouchBoardPnl.Width = (int)(mTouchBoardPnlWidth * _ratio);
            TouchTouchBoardPnl.Height = (int)(mTouchBoardPnlHeight * _ratio);

            TouchCircleBtn.Left = (int)(mCircleBtnLeft * _ratio);
            TouchCircleBtn.Top = (int)(mCircleBtnTop * _ratio);
            TouchCircleBtn.Width = (int)(mCircleBtnWidth * _ratio);
            TouchCircleBtn.Height = (int)(mCircleBtnHeight * _ratio);

            TouchMovingPart.Left = (int)(mMovingPartLeft * _ratio);
            TouchMovingPart.Top = (int)(mMovingPartTop * _ratio);
            TouchMovingPart.Width = (int)(mMovingPartWidth * _ratio);
            TouchMovingPart.Height = (int)(mMovingPartHeight * _ratio);

            TouchDangerBtn.Left = (int)(mDangerBtnLeft * _ratio);
            TouchDangerBtn.Top = (int)(mDangerBtnTop * _ratio);
            TouchDangerBtn.Width = (int)(mDangerBtnWidth * _ratio);
            TouchDangerBtn.Height = (int)(mDangerBtnHeight * _ratio);

            TouchGreenBtn.Left = (int)(mGreenBtnLeft * _ratio);
            TouchGreenBtn.Top = (int)(mGreenBtnTop * _ratio);
            TouchGreenBtn.Width = (int)(mGreenBtnWidth * _ratio);
            TouchGreenBtn.Height = (int)(mGreenBtnHeight * _ratio);

            TouchIndigoBtn.Left = (int)(mIndigoBtnLeft * _ratio);
            TouchIndigoBtn.Top = (int)(mIndigoBtnTop * _ratio);
            TouchIndigoBtn.Width = (int)(mIndigoBtnWidth * _ratio);
            TouchIndigoBtn.Height = (int)(mIndigoBtnHeight * _ratio);

            TouchBlueBtn.Left = (int)(mBlueBtnLeft * _ratio);
            TouchBlueBtn.Top = (int)(mBlueBtnTop * _ratio);
            TouchBlueBtn.Width = (int)(mBlueBtnWidth * _ratio);
            TouchBlueBtn.Height = (int)(mBlueBtnHeight * _ratio);

            mMinXAxis = -TouchCircleBtn.Width / 2 + TouchMovingPart.Width / 2;
            mMaxXAxis = TouchCircleBtn.Width / 2 - TouchMovingPart.Width / 2;
            mMinYAxis = -TouchCircleBtn.Height / 2 + TouchMovingPart.Height / 2;
            mMaxYAxis = TouchCircleBtn.Height / 2 - TouchMovingPart.Height / 2;

            mTopLeft =      new RectangleF(55 * _ratio, 55 * _ratio, 10 * _ratio, 10 * _ratio);
            mTopCenter =    new RectangleF(125 * _ratio, 55 * _ratio, 10 * _ratio, 10 * _ratio);
            mTopRight =     new RectangleF(193 * _ratio, 55 * _ratio, 10 * _ratio, 10 * _ratio);

            mMiddleLeft =   new RectangleF(55 * _ratio, 125 * _ratio, 10 * _ratio, 10 * _ratio);
            mMiddleCenter = new RectangleF(125 * _ratio, 125 * _ratio, 10 * _ratio, 10 * _ratio);
            mMiddleRight =  new RectangleF(193 * _ratio, 125 * _ratio, 10 * _ratio, 10 * _ratio);

            mBottomLeft =   new RectangleF(55 * _ratio, 193 * _ratio, 10 * _ratio, 10 * _ratio);
            mBottomCenter = new RectangleF(125 * _ratio, 193 * _ratio, 10 * _ratio, 10 * _ratio);
            mBottomRight =  new RectangleF(193 * _ratio, 193 * _ratio, 10 * _ratio, 10 * _ratio);

            mGestureRectList.Clear();
            mGestureRectList.Add(new RectangleF(50 * _ratio, 50 * _ratio, 20 * _ratio, 20 * _ratio));
            mGestureRectList.Add(new RectangleF(120 * _ratio, 50 * _ratio, 20 * _ratio, 20 * _ratio));
            mGestureRectList.Add(new RectangleF(188 * _ratio, 50 * _ratio, 20 * _ratio, 20 * _ratio));

            mGestureRectList.Add(new RectangleF(50 * _ratio, 120 * _ratio, 20 * _ratio, 20 * _ratio));
            mGestureRectList.Add(new RectangleF(120 * _ratio, 120 * _ratio, 20 * _ratio, 20 * _ratio));
            mGestureRectList.Add(new RectangleF(188 * _ratio, 120 * _ratio, 20 * _ratio, 20 * _ratio));

            mGestureRectList.Add(new RectangleF(50 * _ratio, 188 * _ratio, 20 * _ratio, 20 * _ratio));
            mGestureRectList.Add(new RectangleF(120 * _ratio, 188 * _ratio, 20 * _ratio, 20 * _ratio));
            mGestureRectList.Add(new RectangleF(188 * _ratio, 188 * _ratio, 20 * _ratio, 20 * _ratio));


            mTrackLineWidth = (int)(7.0f * _ratio);
            mTrackPen = new Pen(Color.White, mTrackLineWidth);
        }

        public TouchControllerForm(MainController.TABLET_CONTROLLER_SIDE side)
        {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
            this.Opacity = mOpacityValue;
            this.TopMost = true;
            mSide = side;

            mBorderPnlLeft = TouchControllerBorderPnl.Left; mBorderPnlTop = TouchControllerBorderPnl.Top; mBorderPnlWidth = TouchControllerBorderPnl.Width; mBorderPnlHeight = TouchControllerBorderPnl.Height;
            mControllerPnlLeft = TouchControllerPnl.Left; mControllerPnlTop = TouchControllerPnl.Top; mControllerPnlWidth = TouchControllerPnl.Width; mControllerPnlHeight = TouchControllerPnl.Height;
            mTouchBoardPnlLeft = TouchTouchBoardPnl.Left; mTouchBoardPnlTop = TouchTouchBoardPnl.Top; mTouchBoardPnlWidth = TouchTouchBoardPnl.Width; mTouchBoardPnlHeight = TouchTouchBoardPnl.Height;
            mCircleBtnLeft = TouchCircleBtn.Left; mCircleBtnTop = TouchCircleBtn.Top; mCircleBtnWidth = TouchCircleBtn.Width; mCircleBtnHeight = TouchCircleBtn.Height;
            mMovingPartLeft = TouchMovingPart.Left; mMovingPartTop = TouchMovingPart.Top; mMovingPartWidth = TouchMovingPart.Width; mMovingPartHeight = TouchMovingPart.Height;
            mDangerBtnLeft = TouchDangerBtn.Left; mDangerBtnTop = TouchDangerBtn.Top; mDangerBtnWidth = TouchDangerBtn.Width; mDangerBtnHeight = TouchDangerBtn.Height;
            mGreenBtnLeft = TouchGreenBtn.Left; mGreenBtnTop = TouchGreenBtn.Top; mGreenBtnWidth = TouchGreenBtn.Width; mGreenBtnHeight = TouchGreenBtn.Height;
            mIndigoBtnLeft = TouchIndigoBtn.Left; mIndigoBtnTop = TouchIndigoBtn.Top; mIndigoBtnWidth = TouchIndigoBtn.Width; mIndigoBtnHeight = TouchIndigoBtn.Height;
            mBlueBtnLeft = TouchBlueBtn.Left; mBlueBtnTop = TouchBlueBtn.Top; mBlueBtnWidth = TouchBlueBtn.Width; mBlueBtnHeight = TouchBlueBtn.Height;

            mMinXAxis = -mCircleBtnWidth / 2 + mMovingPartWidth / 2;
            mMaxXAxis = mCircleBtnWidth / 2 - mMovingPartWidth / 2;
            mMinYAxis = -mCircleBtnHeight / 2 + mMovingPartHeight / 2;
            mMaxYAxis = mCircleBtnHeight / 2 - mMovingPartHeight / 2;

            mDefaultWidth = 360;
            mDefaultHeight = 360;


            mTopLeft        =new RectangleF(55, 55, 10, 10);
            mTopCenter      =new RectangleF(125, 55, 10, 10);
            mTopRight       =new RectangleF(193, 55, 10, 10);
                                          
            mMiddleLeft     =new RectangleF(55, 125, 10, 10);
            mMiddleCenter   =new RectangleF(125, 125, 10, 10);
            mMiddleRight    =new RectangleF(193, 125, 10, 10);
                                          
            mBottomLeft     =new RectangleF(55, 193, 10, 10);
            mBottomCenter   =new RectangleF(125, 193, 10, 10);
            mBottomRight    =new RectangleF(193, 193, 10, 10);

            mGestureRectList.Add(new RectangleF(50, 50, 20, 20));
            mGestureRectList.Add(new RectangleF(120, 50, 20, 20));
            mGestureRectList.Add(new RectangleF(188, 50, 20, 20));

            mGestureRectList.Add(new RectangleF(50, 120, 20, 20));
            mGestureRectList.Add(new RectangleF(120, 120, 20, 20));
            mGestureRectList.Add(new RectangleF(188, 120, 20, 20));

            mGestureRectList.Add(new RectangleF(50, 188, 20, 20));
            mGestureRectList.Add(new RectangleF(120, 188, 20, 20));
            mGestureRectList.Add(new RectangleF(188, 188, 20, 20));

            mCurrectTrackPoint = new Point(0, 0);
            mCurrentGestureRect = new RectangleF(0, 0, 0, 0);

            mTrackLineWidth = 7;

            mTrackBrush = new SolidBrush(Color.White);
            mTrackPen = new Pen(Color.White, mTrackLineWidth);
            mTrackPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Outset;
            
            TouchControllerBorderPnl.BorderColor = Color.Transparent;
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

        RectangleF mTopLeft;
        RectangleF mTopCenter;
        RectangleF mTopRight;
                 
        RectangleF mMiddleLeft;
        RectangleF mMiddleCenter;
        RectangleF mMiddleRight;
                 
        RectangleF mBottomLeft;
        RectangleF mBottomCenter;
        RectangleF mBottomRight;

        List<RectangleF> mGestureRectList = new List<RectangleF>();
        List<PointF> mTrackPointList = new List<PointF>();
        PointF mCurrectTrackPoint;
        
        string mGestureResult = "";
        int mTrackLineWidth;
        SolidBrush mTrackBrush;
        Pen mTrackPen;
        RectangleF mCurrentGestureRect;

        private void TouchTouchBoardPnl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //RectangleF[] rectGesture = mGestureRectList.ToArray();
            //foreach (RectangleF _rect in rectGesture)
            //{
            //    g.DrawRectangle(mTrackPen, _rect.X, _rect.Y, _rect.Width, _rect.Height);
            //}
                // Draw a line in the PictureBox.
            g.FillEllipse(mTrackBrush, mTopLeft);
            g.FillEllipse(mTrackBrush, mTopCenter);
            g.FillEllipse(mTrackBrush, mTopRight);

            g.FillEllipse(mTrackBrush, mMiddleLeft);
            g.FillEllipse(mTrackBrush, mMiddleCenter);
            g.FillEllipse(mTrackBrush, mMiddleRight);

            g.FillEllipse(mTrackBrush, mBottomLeft);
            g.FillEllipse(mTrackBrush, mBottomCenter);
            g.FillEllipse(mTrackBrush, mBottomRight);

            if(mTrackPointList.Count > 1)
                g.DrawLines(mTrackPen, mTrackPointList.ToArray());
            if(mCurrectTrackPoint.X != 0 && mCurrectTrackPoint.Y != 0)
                g.DrawLine(mTrackPen, mTrackPointList.Last(), mCurrectTrackPoint);
        }

        private void TouchTouchBoardPnl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int i = 0;
                foreach(RectangleF _rect in mGestureRectList)
                {
                    i++;
                    if (_rect.Contains(e.Location))
                    {
                        mTrackPointList.Add(new PointF(_rect.X + _rect.Width / 2, _rect.Y + _rect.Height / 2));
                        mGestureResult += i;
                        mCurrentGestureRect = _rect;
                        break;
                    }
                }
            }
        }

        private void TouchTouchBoardPnl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int i = 0;
                foreach (RectangleF _rect in mGestureRectList)
                {
                    i++;
                    if (!mCurrentGestureRect.Equals(_rect) && _rect.Contains(e.Location))
                    {
                        mTrackPointList.Add(new PointF(_rect.X + _rect.Width / 2, _rect.Y + _rect.Height / 2));
                        mGestureResult += i;
                        mCurrentGestureRect = _rect;
                        break;
                    }
                }
                mCurrectTrackPoint = e.Location;
                TouchTouchBoardPnl.Refresh();
            }

        }

        private void TouchTouchBoardPnl_MouseUp(object sender, MouseEventArgs e)
        {
            bool _res;
            if (e.Button == MouseButtons.Left)
            {
                //int i = 0;
                
                //foreach (RectangleF _rect in mGestureRectList)
                //{
                //    i++;
                //    if (_rect.Contains(e.Location))
                //    {
                //        mTrackPointList.Add(new PointF(_rect.X + _rect.Width / 2, _rect.Y + _rect.Height / 2));
                //        mGestureResult += i;
                //        break;
                //    }
                //}
                if (mTrackPointList.Count > 1)
                {
                    string _gesture = "Gesture" + mGestureResult;
                    if (mJoystickBtnId.ContainsKey(_gesture))
                    {
                        pressControllerBtn(mJoystickBtnId[_gesture]);
                        System.Threading.Thread.Sleep(10);
                        releaseControllerBtn(mJoystickBtnId[_gesture]);
                    }
                }
                mCurrectTrackPoint.X = 0;
                mCurrectTrackPoint.Y = 0;

                mCurrentGestureRect = new RectangleF(0,0,0,0);

                Console.WriteLine(mGestureResult);

                mGestureResult = "";
                mTrackPointList.Clear();
                TouchTouchBoardPnl.Refresh();
            }
        }

        private void TouchControllerForm_Load(object sender, EventArgs e)
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
            this.TouchDangerBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(DangerBtn_MouseDown);
            this.TouchDangerBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.TouchIndigoBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(IndigoBtn_MouseDown);
            this.TouchIndigoBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.TouchGreenBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(GreenBtn_MouseDown);
            this.TouchGreenBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.TouchBlueBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(BlueBtn_MouseDown);
            this.TouchBlueBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(JoystickBtn_MouseUp);

            this.TouchCircleBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(CircleBtn_MouseDown);
            this.TouchCircleBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(CircleBtn_MouseUp);
            this.TouchCircleBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(CircleBtn_MouseMove);
            this.TouchCircleBtn.MouseLeave += new System.EventHandler(CircleBtn_MouseLeave);
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
                    movingPartX = e.X - (TouchMovingPart.Width / 2);
                    movingPartY = e.Y - (TouchMovingPart.Height / 2);
                    cursorOriginX = e.X - (TouchCircleBtn.Width / 2);
                    cursorOriginY = e.Y - (TouchCircleBtn.Height / 2);

                    hypotenuse = Math.Sqrt(cursorOriginX * cursorOriginX + cursorOriginY * cursorOriginY);

                    angleX = Math.Acos(cursorOriginX / hypotenuse);
                    angleY = Math.Asin(cursorOriginY / hypotenuse);

                    movingPartX = (int)((mMaxXAxis - (15 * mRatio / 100.0f)) * Math.Cos(angleX) + mMaxXAxis);
                    movingPartY = (int)((mMaxYAxis - (15 * mRatio / 100.0f)) * Math.Sin(angleY) + mMaxYAxis);

                    Console.WriteLine("movingPartX:{0}.movingPartY:{1}\n", this.movingPartX, this.movingPartY);

                    if (hypotenuse < TouchCircleBtn.Width / 2)
                    {
                        TouchMovingPart.Left = movingPartX;
                        TouchMovingPart.Top = movingPartY;
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
                    break;
                case MouseButtons.Right:
                    if (mEnableMoveController && mSelectionMouseButton.Equals("MouseRight"))
                        break;
                    _label = "R";
                    mCurrentBtnInfo = mJoystickBtnId["Circle_R_Id"];
                    pressControllerBtn(mCurrentBtnInfo);

                    MouseButtonlbl.Location = TouchControllerPnl.PointToClient(_control.PointToScreen(e.Location));
                    MouseButtonlbl.Text = _label;
                    break;
                case MouseButtons.Middle:
                    _label = "M";
                    mCurrentBtnInfo = mJoystickBtnId["Circle_M_Id"];
                    pressControllerBtn(mCurrentBtnInfo);

                    MouseButtonlbl.Location = TouchControllerPnl.PointToClient(_control.PointToScreen(e.Location));
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
                    movingPartX = e.X - (TouchMovingPart.Width / 2);
                    movingPartY = e.Y - (TouchMovingPart.Height / 2);
                    cursorOriginX = e.X - (TouchCircleBtn.Width / 2);
                    cursorOriginY = e.Y - (TouchCircleBtn.Height / 2);

                    hypotenuse = Math.Sqrt(cursorOriginX * cursorOriginX + cursorOriginY * cursorOriginY);

                    angleX = Math.Acos(cursorOriginX / hypotenuse);
                    angleY = Math.Asin(cursorOriginY / hypotenuse);

                    movingPartX = (int)((mMaxXAxis - (15 * mRatio / 100.0f)) * Math.Cos(angleX) + mMaxXAxis);
                    movingPartY = (int)((mMaxYAxis - (15 * mRatio / 100.0f)) * Math.Sin(angleY) + mMaxYAxis);

                    Console.WriteLine("movingPartX:{0}.movingPartY:{1}\n", this.movingPartX, this.movingPartY);

                    if (hypotenuse < TouchCircleBtn.Width / 2)
                    {
                        TouchMovingPart.Left = movingPartX;
                        TouchMovingPart.Top = movingPartY;
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
            if (e == null)
                return;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    break;
                default:
                    releaseControllerBtn(mCurrentBtnInfo);
                    break;
            }

            MouseButtonlbl.Text = "";
            mCurrentBtnInfo = null;
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
                    if (mJoystickBtnId.ContainsKey("Danger_L_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Danger_L_Id"];
                    break;
                case MouseButtons.Right:
                    _label = "R";
                    if (mJoystickBtnId.ContainsKey("Danger_R_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Danger_R_Id"];
                    break;
                case MouseButtons.Middle:
                    _label = "M";
                    if (mJoystickBtnId.ContainsKey("Danger_M_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Danger_M_Id"];
                    break;
                case MouseButtons.XButton1:
                    _label = "X1";
                    if (mJoystickBtnId.ContainsKey("Danger_X1_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Danger_X1_Id"];
                    break;
                case MouseButtons.XButton2:
                    _label = "X2";
                    if (mJoystickBtnId.ContainsKey("Danger_X2_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Danger_X2_Id"];
                    break;
                default:
                    break;
            }

            pressControllerBtn(mCurrentBtnInfo);

            MouseButtonlbl.Location = TouchControllerPnl.PointToClient(_control.PointToScreen(e.Location));
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
                    if (mJoystickBtnId.ContainsKey("Indigo_L_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Indigo_L_Id"];
                    break;
                case MouseButtons.Right:
                    _label = "R";
                    if (mJoystickBtnId.ContainsKey("Indigo_R_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Indigo_R_Id"];
                    break;
                case MouseButtons.Middle:
                    _label = "M";
                    if (mJoystickBtnId.ContainsKey("Indigo_M_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Indigo_M_Id"];
                    break;
                case MouseButtons.XButton1:
                    _label = "X1";
                    if (mJoystickBtnId.ContainsKey("Indigo_X1_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Indigo_X1_Id"];
                    break;
                case MouseButtons.XButton2:
                    _label = "X2";
                    if (mJoystickBtnId.ContainsKey("Indigo_X2_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Indigo_X2_Id"];
                    break;
                default:
                    break;
            }

            pressControllerBtn(mCurrentBtnInfo);

            MouseButtonlbl.Location = TouchControllerPnl.PointToClient(_control.PointToScreen(e.Location));
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
                    if (mJoystickBtnId.ContainsKey("Green_L_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Green_L_Id"];
                    break;
                case MouseButtons.Right:
                    _label = "R";
                    if (mJoystickBtnId.ContainsKey("Green_R_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Green_R_Id"];
                    break;
                case MouseButtons.Middle:
                    _label = "M";
                    if (mJoystickBtnId.ContainsKey("Green_M_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Green_M_Id"];
                    break;
                case MouseButtons.XButton1:
                    _label = "X1";
                    if (mJoystickBtnId.ContainsKey("Green_X1_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Green_X1_Id"];
                    break;
                case MouseButtons.XButton2:
                    _label = "X2";
                    if (mJoystickBtnId.ContainsKey("Green_X2_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Green_X2_Id"];
                    break;
                case MouseButtons.None:
                default:
                    break;
            }

            pressControllerBtn(mCurrentBtnInfo);

            MouseButtonlbl.Location = TouchControllerPnl.PointToClient(_control.PointToScreen(e.Location));
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
                    if (mJoystickBtnId.ContainsKey("Blue_L_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Blue_L_Id"];
                    break;
                case MouseButtons.Right:
                    _label = "R";
                    if (mJoystickBtnId.ContainsKey("Blue_R_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Blue_R_Id"];
                    break;
                case MouseButtons.Middle:
                    _label = "M";
                    if (mJoystickBtnId.ContainsKey("Blue_M_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Blue_M_Id"];
                    break;
                case MouseButtons.XButton1:
                    _label = "X1";
                    if (mJoystickBtnId.ContainsKey("Blue_X1_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Blue_X1_Id"];
                    break;
                case MouseButtons.XButton2:
                    _label = "X2";
                    if (mJoystickBtnId.ContainsKey("Blue_X2_Id") == false)
                        mCurrentBtnInfo = null;
                    else
                        mCurrentBtnInfo = mJoystickBtnId["Blue_X2_Id"];
                    break;
                case MouseButtons.None:
                default:
                    break;
            }

            pressControllerBtn(mCurrentBtnInfo);

            MouseButtonlbl.Location = TouchControllerPnl.PointToClient(_control.PointToScreen(e.Location));
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
