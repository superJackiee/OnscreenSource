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
    public partial class TouchForm : Form
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
        Color mBackColor = Color.FromArgb(120, 120, 120);
        Color mForeColor = Color.FromArgb(160, 160 ,160);
        int mCircleWidth = 350;
        int mCircleHeight = 350;
        int mButtonX = 0;
        int mButtonY = 0;
        Dictionary<string, uint> mGestureIDs = new Dictionary<string, uint>();

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
                mTrackBrush = new SolidBrush(mForeColor);
                this.CircleBtn.Refresh();
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
        
        public Dictionary<string, uint> GestureIDs
        {
            get
            {
                return mGestureIDs;
            }
            set
            {
                mGestureIDs = value;
            }
        }

        public string Gesture
        {
            get
            {
                return mGestureResult;
            }
            set
            {
                mGestureResult = value;
                this.Refresh();
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

        public TouchForm(COMPONENTMODE mode)
        {
            InitializeComponent();
            this.Opacity = mOpacity;
            //this.CircleBtn.BackColor = mBackColor;
            //this.CircleBtn.ForeColor = mForeColor;
            //this.MovingPart.BackColor = mMovingColor;
            //this.CircleUp.Height = mCircleHeight / 2;
            //this.CircleDown.Height = mCircleHeight / 2;
            //this.CircleUp.Width = mCircleWidth;

            mTopLeft = new RectangleF(85, 85, 15, 15);
            mTopCenter = new RectangleF(165, 85, 15, 15);
            mTopRight = new RectangleF(245, 85, 15, 15);

            mMiddleLeft = new RectangleF(85, 165, 15, 15);
            mMiddleCenter = new RectangleF(165, 165, 15, 15);
            mMiddleRight = new RectangleF(245, 165, 15, 15);

            mBottomLeft = new RectangleF(85, 245, 15, 15);
            mBottomCenter = new RectangleF(165, 245, 15, 15);
            mBottomRight = new RectangleF(245, 245, 15, 15);

            mGestureRectList.Add(mTopLeft);
            mGestureRectList.Add(mTopCenter);
            mGestureRectList.Add(mTopRight);

            mGestureRectList.Add(mMiddleLeft);
            mGestureRectList.Add(mMiddleCenter);
            mGestureRectList.Add(mMiddleRight);

            mGestureRectList.Add(mBottomLeft);
            mGestureRectList.Add(mBottomCenter);
            mGestureRectList.Add(mBottomRight);

            mCurrectTrackPoint = new Point(0, 0);
            mCurrentGestureRect = new RectangleF(0, 0, 0, 0);

            mTrackLineWidth = 7;

            mTrackBrush = new SolidBrush(mForeColor);
            mTrackPen = new Pen(Color.White, mTrackLineWidth);
            mTrackPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Outset;

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
            }
        }

        private void CircleBtn_Click(object sender, EventArgs e)
        {

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

            mTopLeft = new RectangleF(85 * CircleBtn.Width / 350, 85 * CircleBtn.Height / 350, 15, 15);
            mTopCenter = new RectangleF(165 * CircleBtn.Width / 350, 85 * CircleBtn.Height / 350, 15, 15);
            mTopRight = new RectangleF(245 * CircleBtn.Width / 350, 85 * CircleBtn.Height / 350, 15, 15);

            mMiddleLeft = new RectangleF(85 * CircleBtn.Width / 350, 165 * CircleBtn.Height / 350, 15, 15);
            mMiddleCenter = new RectangleF(165 * CircleBtn.Width / 350, 165 * CircleBtn.Height / 350, 15, 15);
            mMiddleRight = new RectangleF(245 * CircleBtn.Width / 350, 165 * CircleBtn.Height / 350, 15, 15);

            mBottomLeft = new RectangleF(85 * CircleBtn.Width / 350, 245 * CircleBtn.Height / 350, 15, 15);
            mBottomCenter = new RectangleF(165 * CircleBtn.Width / 350, 245 * CircleBtn.Height / 350, 15, 15);
            mBottomRight = new RectangleF(245 * CircleBtn.Width / 350, 245 * CircleBtn.Height / 350, 15, 15);
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
                    //CircleBtn.Left += _diffX;
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

        public void GestureToTrackList()
        {
            mTrackPointList.Clear();
            foreach (char _ch in mGestureResult.ToArray())
            {
                int _index = Convert.ToInt32(_ch) - Convert.ToInt32('1');
                RectangleF _rect = mGestureRectList[_index];
                mTrackPointList.Add(new PointF(_rect.X + _rect.Width / 2, _rect.Y + _rect.Height / 2));
            }
            CircleBtn.Refresh();
        }

        private void CircleBtn_MouseDown(object sender, MouseEventArgs e)
        {
            switch (mMode)
            {
                case COMPONENTMODE.EDIT_MODE:
                    mEditBox.setCurrentComponent(this);
                    setVisibleController(true);
                    mBtnPrevLocation = CircleBtn.PointToScreen(e.Location);
                    
                    if (e.Button == MouseButtons.Left)
                    {
                        mGestureResult = "";
                        mTrackPointList.Clear();

                        int i = 0;
                        foreach (RectangleF _rect in mGestureRectList)
                        {
                            i++;
                            if (_rect.Contains(e.Location))
                            {
                                //mTrackPointList.Add(new PointF(_rect.X + _rect.Width / 2, _rect.Y + _rect.Height / 2));
                                mGestureResult += i;
                                mCurrentGestureRect = _rect;
                                break;
                            }
                        }
                        if (i == mGestureRectList.Count)
                            mStartMove = true;

                    }
                    break;
                case COMPONENTMODE.RUN_MODE:
                    if (e.Button == MouseButtons.Left)
                    {
                        int i = 0;
                        foreach (RectangleF _rect in mGestureRectList)
                        {
                            i++;
                            if (_rect.Contains(e.Location))
                            {
                                mTrackPointList.Add(new PointF(_rect.X + _rect.Width / 2, _rect.Y + _rect.Height / 2));
                                mGestureResult += i;
                                mCurrentGestureRect = _rect;

                                resetPropertyWindows();
                                break;
                            }
                        }
                    }
                    break;
            }
        }

        private void CircleBtn_MouseMove(object sender, MouseEventArgs e)
        {
            switch (mMode)
            {
                case COMPONENTMODE.EDIT_MODE:
                    if (mStartMove)
                    {
                        Point _curLocation = CircleBtn.PointToScreen(e.Location);
                        this.Left += (_curLocation.X - mBtnPrevLocation.X);
                        this.Top += (_curLocation.Y - mBtnPrevLocation.Y);
                        resetPropertyWindows();
                        mBtnPrevLocation = _curLocation;
                    }
                    else
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            int i = 0;
                            foreach (RectangleF _rect in mGestureRectList)
                            {
                                i++;
                                if (!mCurrentGestureRect.Equals(_rect) && _rect.Contains(e.Location))
                                {
                                    //mTrackPointList.Add(new PointF(_rect.X + _rect.Width / 2, _rect.Y + _rect.Height / 2));
                                    mGestureResult += i;
                                    mCurrentGestureRect = _rect;

                                    resetPropertyWindows();
                                    break;
                                }
                            }
                            mCurrectTrackPoint = e.Location;
                            CircleBtn.Refresh();
                        }
                    }
                    break;
                case COMPONENTMODE.RUN_MODE:
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
                        CircleBtn.Refresh();
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
                    if (mStartMove)
                    {
                        mStartMove = false;
                    }
                    else
                    {
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
                                resetPropertyWindows();
                                //mGestureResult;
                                //if (mJoystickBtnId.ContainsKey(_gesture))
                                //{
                                //    _res = mJoystickHandler.SetBtn(mJoystickBtnState[btnId], mJoystickId, buttonInfo[0]);
                                //    System.Threading.Thread.Sleep(10);
                                //    _res = mJoystickHandler.SetBtn(mJoystickBtnState[btnId], mJoystickId, buttonInfo[0]);
                                //}
                            }
                            mCurrectTrackPoint.X = 0;
                            mCurrectTrackPoint.Y = 0;

                            mCurrentGestureRect = new RectangleF(0, 0, 0, 0);

                            Console.WriteLine(mGestureResult);

                            
                            CircleBtn.Refresh();
                        }
                    }
                    break;
                case COMPONENTMODE.RUN_MODE:
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
                            //if (mJoystickBtnId.ContainsKey(_gesture))
                            //{
                            //    _res = mJoystickHandler.SetBtn(mJoystickBtnState[btnId], mJoystickId, buttonInfo[0]);
                            //    System.Threading.Thread.Sleep(10);
                            //    _res = mJoystickHandler.SetBtn(mJoystickBtnState[btnId], mJoystickId, buttonInfo[0]);
                            //}
                            resetPropertyWindows();
                        }
                        mCurrectTrackPoint.X = 0;
                        mCurrectTrackPoint.Y = 0;

                        mCurrentGestureRect = new RectangleF(0, 0, 0, 0);

                        Console.WriteLine(mGestureResult);

                        mGestureResult = "";
                        mTrackPointList.Clear();
                        CircleBtn.Refresh();
                    }
                    break;
            }
        }

        private void TouchForm_Activated(object sender, EventArgs e)
        {
            if (mMode == COMPONENTMODE.EDIT_MODE)
                setVisibleController(true);
        }

        private void TouchForm_Deactivate(object sender, EventArgs e)
        {
            if (mMode == COMPONENTMODE.EDIT_MODE)
                setVisibleController(false);
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

        private void CircleBtn_Paint(object sender, PaintEventArgs e)
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

            if (mTrackPointList.Count > 1)
            {
                g.DrawLines(mTrackPen, mTrackPointList.ToArray());
                if (mCurrectTrackPoint.X != 0 && mCurrectTrackPoint.Y != 0)
                    g.DrawLine(mTrackPen, mTrackPointList.Last(), mCurrectTrackPoint);
            }
            
        }
    }
}
