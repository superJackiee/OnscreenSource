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
    public partial class MoveForm : Form
    {
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
        Color mBackColor = Color.FromArgb(200, 200, 200);
        Color mForeColor = Color.FromArgb(120, 120, 120);
        Color mMovingColor = Color.FromArgb(160, 160, 160);
        int mCircleWidth = 350;
        int mCircleHeight = 350;
        int mButtonX = 0;
        int mButtonY = 0;

        uint mHorizontalAxisID = 0;
        uint mHorizontalAxisIndex = 0;
        uint mVerticalAxisID = 0;
        uint mVerticalAxisIndex = 0;

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
                this.CircleBtn.BackColor = mBackColor;
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
                this.CircleBtn.BorderColor = mForeColor;
            }
        }

        public Color MovingColorValue
        {
            get
            {
                return mMovingColor;
            }
            set
            {
                mMovingColor = value;
                this.MovingPart.BackColor = mMovingColor;
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
            }
        }

        public int HeightValue
        {
            get
            {
                return this.CircleBtn.Height;
            }
            set
            {
                this.CircleBtn.Height = value;
                adjustResizeController();
            }
        }

        public int WidthValue
        {
            get
            {
                return this.CircleBtn.Width;
            }
            set
            {
                this.CircleBtn.Width = value;
                adjustResizeController();
            }
        }

        public uint HorizontalAxisIndex
        {
            get
            {
                return mHorizontalAxisIndex;
            }
            set
            {
                this.mHorizontalAxisIndex = value;
            }
        }

        public uint VerticalAxisIndex
        {
            get
            {
                return mVerticalAxisIndex;
            }
            set
            {
                this.mVerticalAxisIndex = value;
            }
        }

        public uint HorizontalAxisID
        {
            get
            {
                return mHorizontalAxisID;
            }
            set
            {
                this.mHorizontalAxisID = value;
            }
        }

        public uint VerticalAxisID
        {
            get
            {
                return mVerticalAxisID;
            }
            set
            {
                this.mVerticalAxisID = value;
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

        public MoveForm(COMPONENTMODE mode)
        {
            InitializeComponent();
            this.Opacity = mOpacity;
            this.CircleBtn.BackColor = mBackColor;
            this.CircleBtn.ForeColor = mForeColor;
            this.MovingPart.BackColor = mMovingColor;
            this.CircleBtn.Height = mCircleHeight;
            this.CircleBtn.Width = mCircleWidth;

            this.setVisibleController(false);
            mMode = mode;
        }

        public void setEditBox(EditBoxForm editbox)
        {
            mEditBox = editbox;
        }

        public void setJoystick(vJoy joystickHandler, uint joystickId, long maxvalX, long maxvalY)
        {
            if (mMode == COMPONENTMODE.RUN_MODE)
            {
                mJoystickHandler = joystickHandler;
                mJoystickId = joystickId;
                this.maxvalX = maxvalX;
                this.maxvalY = maxvalY;
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

            ResizeTopCenter.Left = 5 + CircleBtn.Width / 2;
            ResizeTopCenter.Top = 0;

            ResizeTopRight.Left = 10 + CircleBtn.Width;
            ResizeTopRight.Top = 0;

            ResizeMiddleLeft.Left = 0;
            ResizeMiddleLeft.Top = 5 + CircleBtn.Height / 2;

            ResizeMiddleRight.Left = 10 + CircleBtn.Width;
            ResizeMiddleRight.Top = 5 + CircleBtn.Height / 2;

            ResizeBottomLeft.Left = 0;
            ResizeBottomLeft.Top = 10 + CircleBtn.Height;

            ResizeBottomCenter.Left = 5 + CircleBtn.Width / 2;
            ResizeBottomCenter.Top = 10 + CircleBtn.Height;

            ResizeBottomRight.Left = 10 + CircleBtn.Width;
            ResizeBottomRight.Top = 10 + CircleBtn.Height;

            this.MovingPart.Width = Convert.ToInt32(CircleBtn.Width * (50.0 / 350.0));
            this.MovingPart.Height = Convert.ToInt32(CircleBtn.Height * (50.0 / 350.0));
            this.MovingPart.Top = (CircleBtn.Height / 2) - (MovingPart.Height / 2) + 10;
            this.MovingPart.Left = (CircleBtn.Width / 2) - (MovingPart.Width / 2) + 10;

            mMinXAxis = -CircleBtn.Width / 2 + MovingPart.Width / 2 + CircleBtn.BorderWidth;
            mMaxXAxis = CircleBtn.Width / 2 - MovingPart.Width / 2- CircleBtn.BorderWidth;
            mMinYAxis = -CircleBtn.Height / 2 + MovingPart.Height / 2 + CircleBtn.BorderWidth;
            mMaxYAxis = CircleBtn.Height / 2 - MovingPart.Height / 2 - CircleBtn.BorderWidth;

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
                    CircleBtn.Width -= _diffX;
                    this.Top += _diffY;
                    CircleBtn.Height -= _diffY;
                    break;
                case "ResizeTopCenter":
                    this.Top += _diffY;
                    CircleBtn.Height -= _diffY;
                    break;
                case "ResizeTopRight":
                    CircleBtn.Width += _diffX;
                    this.Top += _diffY;
                    CircleBtn.Height -= _diffY;
                    break;
                case "ResizeMiddleLeft":
                    this.Left += _diffX;
                    CircleBtn.Width -= _diffX;
                    break;
                case "ResizeMiddleRight":
                    CircleBtn.Width += _diffX;
                    break;
                case "ResizeBottomLeft":
                    //ButtonBtn.Left += _diffX;
                    this.Left += _diffX;
                    CircleBtn.Width -= _diffX;
                    CircleBtn.Height += _diffY;
                    break;
                case "ResizeBottomCenter":
                    CircleBtn.Height += _diffY;
                    break;
                case "ResizeBottomRight":
                    CircleBtn.Width += _diffX;
                    CircleBtn.Height += _diffY;
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

        double hypotenuse, angle;
        int cursorOriginX, cursorOriginY;
        int movingPartX, movingPartY;
        int X, Y;
        int mMinXAxis, mMaxXAxis, mMinYAxis, mMaxYAxis;
        long maxvalX, maxvalY;

        private void CircleBtn_MouseDown(object sender, MouseEventArgs e)
        {
            bool _res;
            switch (mMode)
            {
                case COMPONENTMODE.EDIT_MODE:
                    mEditBox.setCurrentComponent(this);
                    setVisibleController(true);
                    mBtnPrevLocation = CircleBtn.PointToScreen(e.Location);
                    mStartMove = true;
                    break;
                case COMPONENTMODE.RUN_MODE:
                    if (e.Button == MouseButtons.Left)
                    {
                        movingPartX = e.X - (MovingPart.Width / 2) + 10;
                        movingPartY = e.Y - (MovingPart.Height / 2) + 10;
                        cursorOriginX = e.X - (CircleBtn.Width / 2);
                        cursorOriginY = e.Y - (CircleBtn.Height / 2);

                        hypotenuse = Math.Sqrt(cursorOriginX * cursorOriginX + cursorOriginY * cursorOriginY);
                        double _maxHypotenuse = Math.Sqrt(mMaxXAxis * mMaxXAxis + mMaxYAxis * mMaxYAxis);

                        if (hypotenuse < mMaxXAxis)
                        {
                            if (cursorOriginX < mMaxXAxis && cursorOriginX > mMinXAxis)//x 
                            {
                                MovingPart.Left = movingPartX;
                            }
                            if (cursorOriginY < mMaxYAxis && cursorOriginY > mMinYAxis)//y 
                            {
                                MovingPart.Top = movingPartY;
                            }
                        }
                        // Set position of 4 axes
                        this.X = Convert.ToInt32((cursorOriginX + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                        this.Y = Convert.ToInt32((cursorOriginY + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                        //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                        //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                        //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);
                        Console.WriteLine("X:{0}.Y:{1}\n", cursorOriginX, cursorOriginY);
                        _res = mJoystickHandler.SetAxis(this.X, mJoystickId, (HID_USAGES)mHorizontalAxisID);
                        _res = mJoystickHandler.SetAxis(this.Y, mJoystickId, (HID_USAGES)mVerticalAxisID);
                    }
                    break;
            }
            
        }

        private void CircleBtn_MouseMove(object sender, MouseEventArgs e)
        {
            bool _res;

            switch (mMode)
            {
                case COMPONENTMODE.EDIT_MODE:
                    if (mStartMove == false)
                        return;
                    Point _curLocation = CircleBtn.PointToScreen(e.Location);
                    this.Left += (_curLocation.X - mBtnPrevLocation.X);
                    this.Top += (_curLocation.Y - mBtnPrevLocation.Y);
                    resetPropertyWindows();
                    mBtnPrevLocation = _curLocation;
                    break;
                case COMPONENTMODE.RUN_MODE:
                    if (e.Button == MouseButtons.Left)
                    {
                        movingPartX = e.X - (MovingPart.Width / 2) + 10;
                        movingPartY = e.Y - (MovingPart.Height / 2) + 10;
                        cursorOriginX = e.X - (CircleBtn.Width / 2);
                        cursorOriginY = e.Y - (CircleBtn.Height / 2);

                        hypotenuse = Math.Sqrt(cursorOriginX * cursorOriginX + cursorOriginY * cursorOriginY);
                        double _maxHypotenuse = Math.Sqrt(mMaxXAxis * mMaxXAxis + mMaxYAxis * mMaxYAxis);

                        if (hypotenuse < mMaxXAxis)
                        {
                            if (cursorOriginX < mMaxXAxis && cursorOriginX > mMinXAxis)//x 
                            {
                                MovingPart.Left = movingPartX;
                            }
                            if (cursorOriginY < mMaxYAxis && cursorOriginY > mMinYAxis)//y 
                            {
                                MovingPart.Top = movingPartY;
                            }
                        }
                        // Set position of 4 axes
                        this.X = Convert.ToInt32((cursorOriginX + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                        this.Y = Convert.ToInt32((cursorOriginY + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                        //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                        //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                        //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);
                        Console.WriteLine("X:{0}.Y:{1}\n", cursorOriginX, cursorOriginY);
                        _res = mJoystickHandler.SetAxis(this.X, mJoystickId, (HID_USAGES)mHorizontalAxisID);
                        _res = mJoystickHandler.SetAxis(this.Y, mJoystickId, (HID_USAGES)mVerticalAxisID);
                    }
                    break;
            }
            
        }

        private void CircleBtn_MouseUp(object sender, MouseEventArgs e)
        {
            bool _res;
            switch (mMode)
            {
                case COMPONENTMODE.EDIT_MODE:
                    mStartMove = false;
                    break;
                case COMPONENTMODE.RUN_MODE:
                    if (e.Button == MouseButtons.Left)
                    {
                        MovingPart.Left = CircleBtn.Width / 2 - MovingPart.Width / 2 + 10;
                        MovingPart.Top = CircleBtn.Height / 2 - MovingPart.Height / 2 + 10;

                        cursorOriginX = 0;
                        cursorOriginY = 0;

                        // Set position of 4 axes
                        this.X = Convert.ToInt32((cursorOriginX + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                        this.Y = Convert.ToInt32((cursorOriginY + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                        //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                        //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                        //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);
                        //Console.WriteLine("X:{0}.Y:{1}\n", e.X, e.Y);
                        _res = mJoystickHandler.SetAxis(this.X, mJoystickId, (HID_USAGES)mHorizontalAxisID);
                        _res = mJoystickHandler.SetAxis(this.Y, mJoystickId, (HID_USAGES)mVerticalAxisID);
                    }
                    
                    break;
            }
        }

        private void MoveForm_Activated(object sender, EventArgs e)
        {
            if (mMode == COMPONENTMODE.EDIT_MODE)
                setVisibleController(true);
        }

        private void MoveForm_Deactivate(object sender, EventArgs e)
        {
            if (mMode == COMPONENTMODE.EDIT_MODE)
                setVisibleController(false);
        }
    }
}
