using System;
using System.Collections.Generic;
using System.Windows.Forms;
using vJoyInterfaceWrap;
using System.Management;
using System.Drawing;
using System.ComponentModel;
using System.IO;
using System.Xml;

namespace OnScreenVirtualJoystickController
{
    public partial class MainController : Form
    {
        public enum TABLET_CONTROLLER_SIDE
        {
            NONE = 0,
            LEFT,
            RIGHT
        };

        public enum CONTROLLER
        {
            NONE_CONTROLLER = -1,
            NORMAL_CONTROLLER,
            COMPACT_CONTROLLER,
            COMPLEX_CONTROLLER,
            TOUCH_CONTROLLER
        };

        public enum BUTTON_TYPE
        {
            PRESS = 0,
            RELEASE,
            CLICK,
            TOGGLE
        }

        public Dictionary<string, uint> JoystickButtonMapping
        {
            get
            {
                return mComboToJoystickButtonMapping;
            }
        }

        public Dictionary<string, uint> JoystickAxisMapping
        {
            get
            {
                return mComboToJoystickAxisMapping;
            }
        }

        public List<string> CustomControllerList
        {
            get
            {
                return mCustomControllerList;
            }
        }
        // Create one joystick object and a position structure.
        vJoy mJoystickHandler;
        bool mVirtualJoystickState = false;
        vJoy.JoystickState  iReport;
        uint mJoystickId;
        Dictionary<string, uint> mComboToJoystickButtonMapping = new Dictionary<string, uint>();
        Dictionary<string, uint> mComboToJoystickAxisMapping = new Dictionary<string, uint>();


        bool mVoiceState = false;
        bool mJoystickState = false;

        //Controller Form
        List<string> mCustomControllerList = new List<string>();
        NormalControllerForm mNormalControllerForm = new NormalControllerForm(TABLET_CONTROLLER_SIDE.NONE);
        CompactControllerForm mCompactControllerForm = new CompactControllerForm(TABLET_CONTROLLER_SIDE.NONE);
        ComplexControllerForm mComplexControllerForm = new ComplexControllerForm(TABLET_CONTROLLER_SIDE.NONE);
        TouchControllerForm mTouchControllerForm = new TouchControllerForm(TABLET_CONTROLLER_SIDE.NONE);
        VoiceController mVoiceController = new VoiceController();
        List<Form> mCustomController = new List<Form>();

        EditBoxForm mEditBoxForm;

        Form mTabletLeftControllerForm=null, mTabletRightControllerForm=null;
        bool mEnableTabletLeftController = false, mEnableTabletRightController = false;

        OptionForm mOptionForm;

        //Controller Configuration form
        NormalJoystickCfgForm mNormalJoystickCfgForm;
        CompactJoystickCfgFrom mCompactJoystickCfgForm;
        ComplexJoystickCfgForm mComplexJoystickCfgForm;
        TouchJoystickCfgForm mTouchJoystickCfgForm;
        VoiceJoystickCfgForm mVoiceJoystickCfgForm;


        bool Exist_AxisX;
        bool Exist_AxisY;
        bool Exist_AxisZ;
        bool Exist_AxisRX;
        bool Exist_AxisRZ;
        long maxvalX, maxvalY, maxvalZ, maxvalRX, maxvalRY;

        private void PopulateSource()
        {
            ToolStripMenuItem sm = new ToolStripMenuItem("Source");

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_SoundDevice");
            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {
                foreach (PropertyData property in obj.Properties)
                {
                    // Console.Out.WriteLine(String.Format("{0}:{1}", property.Name, property.Value));
                    if(property.Name.Equals("Caption"))
                    {
                        ToolStripMenuItem sm1 = new ToolStripMenuItem((string)property.Value, null);
                        sm.DropDownItems.Add(sm1);
                    }
                }
            }


            if (sm.DropDownItems.Count > 0)
                (sm.DropDownItems[0] as ToolStripMenuItem).Checked = true;

            MainMenu.Items.RemoveAt(0);
            MainMenu.Items.Insert(0, sm);
            
        }

        private void initVJoyStick()
        {
            mJoystickHandler = new vJoy();
            iReport = new vJoy.JoystickState();
            mJoystickId = 1;

            Exist_AxisX = false;
            Exist_AxisY = false;
            Exist_AxisZ = false;
            Exist_AxisRX = false;
            Exist_AxisRZ = false;

            // Get the driver attributes (Vendor ID, Product ID, Version Number)
            if (!mJoystickHandler.vJoyEnabled())
            {
                Console.WriteLine("vJoy driver not enabled: Failed Getting vJoy attributes.\n");
                return;
            }
            else
                Console.WriteLine("Vendor: {0}\nProduct :{1}\nVersion Number:{2}\n", mJoystickHandler.GetvJoyManufacturerString(), mJoystickHandler.GetvJoyProductString(), mJoystickHandler.GetvJoySerialNumberString());
            // Get the state of the requested device
            VjdStat status = mJoystickHandler.GetVJDStatus(mJoystickId);
            switch (status)
            {
                case VjdStat.VJD_STAT_OWN:
                    Console.WriteLine("vJoy Device {0} is already owned by this feeder\n", mJoystickId);
                    break;
                case VjdStat.VJD_STAT_FREE:
                    Console.WriteLine("vJoy Device {0} is free\n", mJoystickId);
                    break;
                case VjdStat.VJD_STAT_BUSY:
                    Console.WriteLine("vJoy Device {0} is already owned by another feeder\nCannot continue\n", mJoystickId);
                    return;
                case VjdStat.VJD_STAT_MISS:
                    Console.WriteLine("vJoy Device {0} is not installed or disabled\nCannot continue\n", mJoystickId);
                    return;
                default:
                    Console.WriteLine("vJoy Device {0} general error\nCannot continue\n", mJoystickId);
                    return;
            };
            // Check which axes are supported
            Exist_AxisX = mJoystickHandler.GetVJDAxisExist(mJoystickId, HID_USAGES.HID_USAGE_X);
            Exist_AxisY = mJoystickHandler.GetVJDAxisExist(mJoystickId, HID_USAGES.HID_USAGE_Y);
            Exist_AxisZ = mJoystickHandler.GetVJDAxisExist(mJoystickId, HID_USAGES.HID_USAGE_Z);
            Exist_AxisRX = mJoystickHandler.GetVJDAxisExist(mJoystickId, HID_USAGES.HID_USAGE_RX);
            Exist_AxisRZ = mJoystickHandler.GetVJDAxisExist(mJoystickId, HID_USAGES.HID_USAGE_RZ);

            Console.WriteLine("Axis X\t\t{0}\n", Exist_AxisX ? "Yes" : "No");
            Console.WriteLine("Axis Y\t\t{0}\n", Exist_AxisY ? "Yes" : "No");
            Console.WriteLine("Axis Z\t\t{0}\n", Exist_AxisZ ? "Yes" : "No");
            Console.WriteLine("Axis Rx\t\t{0}\n", Exist_AxisRX ? "Yes" : "No");
            Console.WriteLine("Axis Rz\t\t{0}\n", Exist_AxisRZ ? "Yes" : "No");

            // Test if DLL matches the driver
            UInt32 DllVer = 0, DrvVer = 0;
            bool match = mJoystickHandler.DriverMatch(ref DllVer, ref DrvVer);
            if (match)
                Console.WriteLine("Version of Driver Matches DLL Version ({0:X})\n", DllVer);
            else
                Console.WriteLine("Version of Driver ({0:X}) does NOT match DLL Version ({1:X})\n", DrvVer, DllVer);

            // Acquire the target
            if ((status == VjdStat.VJD_STAT_OWN) || ((status == VjdStat.VJD_STAT_FREE) && (!mJoystickHandler.AcquireVJD(mJoystickId))))
            {
                Console.WriteLine("Failed to acquire vJoy device number {0}.\n", mJoystickId);
                return;
            }
            else
                Console.WriteLine("Acquired: vJoy device number {0}.\n", mJoystickId);

            mJoystickHandler.GetVJDAxisMax(mJoystickId, HID_USAGES.HID_USAGE_X, ref maxvalX);
            mJoystickHandler.GetVJDAxisMax(mJoystickId, HID_USAGES.HID_USAGE_Y, ref maxvalY);
            mJoystickHandler.GetVJDAxisMax(mJoystickId, HID_USAGES.HID_USAGE_Z, ref maxvalZ);
            mJoystickHandler.GetVJDAxisMax(mJoystickId, HID_USAGES.HID_USAGE_RX, ref maxvalRX);
            mJoystickHandler.GetVJDAxisMax(mJoystickId, HID_USAGES.HID_USAGE_RY, ref maxvalRY);

            // Reset this device to default values
            mJoystickHandler.ResetVJD(mJoystickId);

            mJoystickState = true;

            mComboToJoystickButtonMapping.Add("None", 0);
            for (uint i = 1; i < 44; i++)
            {
                mComboToJoystickButtonMapping.Add("Button" + i, i);
            }

            mComboToJoystickAxisMapping.Add("None", (uint)0);
            mComboToJoystickAxisMapping.Add("AXIS 1", (uint)HID_USAGES.HID_USAGE_X);
            mComboToJoystickAxisMapping.Add("AXIS 2", (uint)HID_USAGES.HID_USAGE_Y);
            mComboToJoystickAxisMapping.Add("AXIS 3", (uint)HID_USAGES.HID_USAGE_Z);
            mComboToJoystickAxisMapping.Add("AXIS 4", (uint)HID_USAGES.HID_USAGE_RX);
            mComboToJoystickAxisMapping.Add("AXIS 5", (uint)HID_USAGES.HID_USAGE_RY);
            mComboToJoystickAxisMapping.Add("AXIS 6", (uint)HID_USAGES.HID_USAGE_RZ);
            mComboToJoystickAxisMapping.Add("AXIS 7", (uint)HID_USAGES.HID_USAGE_SL0);
            mComboToJoystickAxisMapping.Add("AXIS 8", (uint)HID_USAGES.HID_USAGE_SL1);
        }

        private void voiceControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuStart = ((ToolStripMenuItem)sender);

            if (menuStart.Checked)
            {
                menuStart.Checked = false;
                mVoiceController.StopController();
            }
            else
            {
                menuStart.Checked = true;
                mVoiceController.StartController();
            }
        }

        private void HideAllController()
        {
            mNormalControllerForm.Hide();
            mCompactControllerForm.Hide();
            mComplexControllerForm.Hide();
            mTouchControllerForm.Hide();

            if(mCustomController.Count > 0)
            {
                foreach (Form _component in mCustomController)
                    _component.Close();
                mCustomController.Clear();
            }
        }

        private void NormalControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAllController();

            mNormalControllerForm.setTabletControllerSide(TABLET_CONTROLLER_SIDE.NONE);
            mNormalControllerForm.Show();
            NormalJoyStickToolStripMenuItem.Checked = true;

            CompactJoyStickToolStripMenuItem.Checked = false;
            ComplexJoyStickToolStripMenuItem.Checked = false;
            TouchControllerToolStripMenuItem.Checked = false;
            this.Refresh();
        }
        private void CompactControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAllController();

            mCompactControllerForm.setTabletControllerSide(TABLET_CONTROLLER_SIDE.NONE);
            mCompactControllerForm.Show();
            CompactJoyStickToolStripMenuItem.Checked = true;

            NormalJoyStickToolStripMenuItem.Checked = false;
            ComplexJoyStickToolStripMenuItem.Checked = false;
            TouchControllerToolStripMenuItem.Checked = false;
            this.Refresh();
        }
        private void ComplexControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAllController();

            mComplexControllerForm.setTabletControllerSide(TABLET_CONTROLLER_SIDE.NONE);
            mComplexControllerForm.Show();
            ComplexJoyStickToolStripMenuItem.Checked = true;

            NormalJoyStickToolStripMenuItem.Checked = false;
            CompactJoyStickToolStripMenuItem.Checked = false;
            TouchControllerToolStripMenuItem.Checked = false;
            this.Refresh();
        }
        private void TouchControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAllController();

            mTouchControllerForm.setTabletControllerSide(TABLET_CONTROLLER_SIDE.NONE);
            mTouchControllerForm.Show();
            TouchControllerToolStripMenuItem.Checked = true;

            NormalJoyStickToolStripMenuItem.Checked = false;
            CompactJoyStickToolStripMenuItem.Checked = false;
            ComplexJoyStickToolStripMenuItem.Checked = false;
            this.Refresh();
        }
        private void TabletControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CONTROLLER _controller;

            HideAllController();

            mTabletLeftControllerForm = null;
            mTabletRightControllerForm = null;

            if(mEnableTabletLeftController)
            {
                _controller = mOptionForm.mTabletLeftController;
                switch (_controller)
                {
                    case CONTROLLER.NORMAL_CONTROLLER:
                        mNormalControllerForm.setTabletControllerSide(TABLET_CONTROLLER_SIDE.LEFT);
                        mTabletLeftControllerForm = mNormalControllerForm;
                        break;
                    case CONTROLLER.COMPACT_CONTROLLER:
                        mCompactControllerForm.setTabletControllerSide(TABLET_CONTROLLER_SIDE.LEFT);
                        mTabletLeftControllerForm = mCompactControllerForm;
                        break;
                    case CONTROLLER.COMPLEX_CONTROLLER:
                        mComplexControllerForm.setTabletControllerSide(TABLET_CONTROLLER_SIDE.LEFT);
                        mTabletLeftControllerForm = mComplexControllerForm;
                        break;
                    case CONTROLLER.TOUCH_CONTROLLER:
                        mTouchControllerForm.setTabletControllerSide(TABLET_CONTROLLER_SIDE.LEFT);
                        mTabletLeftControllerForm = mTouchControllerForm;
                        break;
                }
                mTabletLeftControllerForm.Show();
            }
            
            if(mEnableTabletRightController)
            {
                _controller = mOptionForm.mTabletRightController;
                switch (_controller)
                {
                    case CONTROLLER.NORMAL_CONTROLLER:
                        mNormalControllerForm.setTabletControllerSide(TABLET_CONTROLLER_SIDE.RIGHT);
                        mTabletRightControllerForm = mNormalControllerForm;
                        break;
                    case CONTROLLER.COMPACT_CONTROLLER:
                        mCompactControllerForm.setTabletControllerSide(TABLET_CONTROLLER_SIDE.RIGHT);
                        mTabletRightControllerForm = mCompactControllerForm;
                        break;
                    case CONTROLLER.COMPLEX_CONTROLLER:
                        mComplexControllerForm.setTabletControllerSide(TABLET_CONTROLLER_SIDE.RIGHT);
                        mTabletRightControllerForm = mComplexControllerForm;
                        break;
                    case CONTROLLER.TOUCH_CONTROLLER:
                        mTouchControllerForm.setTabletControllerSide(TABLET_CONTROLLER_SIDE.RIGHT);
                        mTabletRightControllerForm = mTouchControllerForm;
                        break;
                }
                mTabletRightControllerForm.Show();
            }

            this.Refresh();
        }
        
        private void VoiceJoyStickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mVoiceJoystickCfgForm.ShowDialog();
        }
        private void NormalJoyStickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mNormalJoystickCfgForm.ShowDialog();
        }
        private void CompactJoyStickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCompactJoystickCfgForm.ShowDialog();
        }
        private void ComplexJoyStickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mComplexJoystickCfgForm.ShowDialog();
        }
        private void TouchJoyStickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mTouchJoystickCfgForm.ShowDialog();
        }

        private void OptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mOptionForm.Show();
        }

        public void setOptionConfigForController()
        {
            mNormalControllerForm.setEnableMoveController(mOptionForm.mNormalMouseMoveEnable, mOptionForm.mNormalMouseButtonSelection);
            mNormalControllerForm.setSizeParameter(mOptionForm.mNormalCustomSize, mOptionForm.mNormalRatio);
            mNormalControllerForm.setEnableFollowingMouse(mOptionForm.mNormalFollowMouseEnable, mOptionForm.mNormalFollowMouseDelayEnable);
            mNormalControllerForm.setEnableShowingBorder(mOptionForm.mNormalShowBorderEnable, mOptionForm.mNormalFixedMouse);
            mNormalControllerForm.setOpacityValue(mOptionForm.mNormalOpacityValue);
            mNormalControllerForm.setMouseControlHook(mOptionForm.mNormalMouseControlHook);

            mCompactControllerForm.setEnableMoveController(mOptionForm.mCompactMouseMoveEnable, mOptionForm.mCompactMouseButtonSelection);
            mCompactControllerForm.setSizeParameter(mOptionForm.mCompactCustomSize, mOptionForm.mCompactRatio);
            mCompactControllerForm.setEnableShowingBorder(mOptionForm.mCompactShowBorderEnable, mOptionForm.mCompactFixedMouse);
            mCompactControllerForm.setEnableGotoNeutral(mOptionForm.mCompactGotoNeutralEnable);
            mCompactControllerForm.setOpacityValue(mOptionForm.mCompactOpacityValue);

            mComplexControllerForm.setEnableMoveController(mOptionForm.mComplexMouseMoveEnable, mOptionForm.mComplexMouseButtonSelection);
            mComplexControllerForm.setSizeParameter(mOptionForm.mComplexCustomSize, mOptionForm.mComplexRatio);
            mComplexControllerForm.setEnableFollowingMouse(mOptionForm.mComplexFollowMouseEnable, mOptionForm.mComplexFollowMouseDelayEnable);
            mComplexControllerForm.setEnableShowingBorder(mOptionForm.mComplexShowBorderEnable, mOptionForm.mComplexFixedMouse);
            mComplexControllerForm.setOpacityValue(mOptionForm.mComplexOpacityValue);

            mTouchControllerForm.setEnableMoveController(mOptionForm.mTouchMouseMoveEnable, mOptionForm.mTouchMouseButtonSelection);
            mTouchControllerForm.setSizeParameter(mOptionForm.mTouchCustomSize, mOptionForm.mTouchtRatio);
            mTouchControllerForm.setEnableShowingBorder(mOptionForm.mTouchShowBorderEnable, mOptionForm.mTouchFixedMouse);
            mTouchControllerForm.setEnableGotoNeutral(mOptionForm.mTouchGotoNeutralEnable);
            mTouchControllerForm.setOpacityValue(mOptionForm.mTouchOpacityValue);

            mEnableTabletLeftController = mOptionForm.mEnableTabletLeftController;
            mEnableTabletRightController = mOptionForm.mEnableTabletRightController;
            
            HID_USAGES _hAxis=0, _vAxis=0;
            CONTROLLER _mcontroller = CONTROLLER.NONE_CONTROLLER;
            CONTROLLER _scontroller = CONTROLLER.NONE_CONTROLLER;

            if (mOptionForm.mEnableTabletLeftControllerAsDefault)
            {
                _mcontroller = mOptionForm.mTabletLeftController;
                _scontroller = mOptionForm.mTabletRightController;
            }
            else if(mOptionForm.mEnableTabletRightControllerAsDefault)
            {
                _mcontroller = mOptionForm.mTabletRightController;
                _scontroller = mOptionForm.mTabletLeftController;
            }
            else
            {
                mNormalControllerForm.setTabletAxis(false);
                mCompactControllerForm.setTabletAxis(false);
                mComplexControllerForm.setTabletAxis(false);
                mTouchControllerForm.setTabletAxis(false);
            }

            if (_mcontroller != CONTROLLER.NONE_CONTROLLER)
            {
                switch (_mcontroller)
                {
                    case CONTROLLER.NORMAL_CONTROLLER:
                        _hAxis = mNormalControllerForm.mHorizontalAxis;
                        _vAxis = mNormalControllerForm.mVerticalAxis;
                        break;
                    case CONTROLLER.COMPACT_CONTROLLER:
                        _hAxis = mCompactControllerForm.mHorizontalAxis;
                        _vAxis = mCompactControllerForm.mVerticalAxis;
                        break;
                    case CONTROLLER.COMPLEX_CONTROLLER:
                        _hAxis = mComplexControllerForm.mHorizontalAxis;
                        _vAxis = mComplexControllerForm.mVerticalAxis;
                        break;
                    case CONTROLLER.TOUCH_CONTROLLER:
                        _hAxis = mTouchControllerForm.mHorizontalAxis;
                        _vAxis = mTouchControllerForm.mVerticalAxis;
                        break;
                }
            }

            if (_scontroller != CONTROLLER.NONE_CONTROLLER)
            {
                switch (_scontroller)
                {
                    case CONTROLLER.NORMAL_CONTROLLER:
                        mNormalControllerForm.setTabletAxis(true, _hAxis, _vAxis);
                        break;
                    case CONTROLLER.COMPACT_CONTROLLER:
                        mCompactControllerForm.setTabletAxis(true, _hAxis, _vAxis); 
                        break;
                    case CONTROLLER.COMPLEX_CONTROLLER:
                        mComplexControllerForm.setTabletAxis(true, _hAxis, _vAxis); 
                        break;
                    case CONTROLLER.TOUCH_CONTROLLER:
                        mTouchControllerForm.setTabletAxis(true, _hAxis, _vAxis);
                        break;
                }
            }
        }

        private void editControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAllController();
            mEditBoxForm.Show();
        }

        void initializeVoiceController()
        {
            mVoiceController.setJoystick(mJoystickHandler, mJoystickId);
            mVoiceController.setJoystickParameter(maxvalX, maxvalY, maxvalZ, maxvalRX, maxvalRY);
            mVoiceController.initializeController();
        }
        void initializeNormalController()
        {
            mNormalControllerForm.setJoystick(mJoystickHandler, mJoystickId);
            mNormalControllerForm.setJoystickParameter(maxvalX, maxvalY, maxvalZ, maxvalRX, maxvalRY);
            //mNormalControllerForm.setInputSimulator(mInputSimulator);
            mNormalControllerForm.initializeController();
        }
        void initializeCompactController()
        {
            mCompactControllerForm.setJoystick(mJoystickHandler, mJoystickId);
            mCompactControllerForm.setJoystickParameter(maxvalX, maxvalY, maxvalZ, maxvalRX, maxvalRY);
            //mCompactControllerForm.setInputSimulator(mInputSimulator);
            mCompactControllerForm.initializeController();
        }
        void initializeComplexController()
        {
            mComplexControllerForm.setJoystick(mJoystickHandler, mJoystickId);
            mComplexControllerForm.setJoystickParameter(maxvalX, maxvalY, maxvalZ, maxvalRX, maxvalRY);
            //mComplexControllerForm.setInputSimulator(mInputSimulator);
            mComplexControllerForm.initializeController();
        }
        void initializeTouchController()
        {
            mTouchControllerForm.setJoystick(mJoystickHandler, mJoystickId);
            mTouchControllerForm.setJoystickParameter(maxvalX, maxvalY, maxvalZ, maxvalRX, maxvalRY);
            //mTouchControllerForm.setInputSimulator(mInputSimulator);
            mTouchControllerForm.initializeController();
        }

        private void reloadControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadCustomControllerMenu();
        }

        private void loadButtonComponent(XmlTextReader xmlReader)
        {
            ButtonForm _component = new ButtonForm(ButtonForm.COMPONENTMODE.RUN_MODE);
            mCustomController.Add(_component);
            _component.Show();
            _component.TopMost = true;

            string _currentTagName = "";
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        _currentTagName = xmlReader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (_currentTagName == "XValue")
                        {
                            _component.XValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "YValue")
                        {
                            _component.YValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "WidthValue")
                        {
                            _component.WidthValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HeightValue")
                        {
                            _component.HeightValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "TextValue")
                        {
                            _component.TextValue = xmlReader.Value;
                        }
                        else if (_currentTagName == "BackColorValue")
                        {
                            _component.BackColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "ForeColorValue")
                        {
                            _component.ForeColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "JoystickBtnIndex")
                        {
                            _component.JoystickBtnIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "JoystickBtnID")
                        {
                            _component.JoystickBtnID = Convert.ToUInt32(xmlReader.Value);
                        }
                        break;
                    case XmlNodeType.EndElement:
                        _currentTagName = "";
                        if (xmlReader.Name == "Button")
                        {
                            _component.setJoystick(mJoystickHandler, mJoystickId, maxvalX, maxvalY);
                            return;
                        }
                        break;
                }
            }

            
        }

        private void loadMoveComponent(XmlTextReader xmlReader)
        {
            MoveForm _component = new MoveForm(MoveForm.COMPONENTMODE.RUN_MODE);
            mCustomController.Add(_component);
            _component.Show();
            _component.TopMost = true;

            string _currentTagName = "";
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        _currentTagName = xmlReader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (_currentTagName == "XValue")
                        {
                            _component.XValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "YValue")
                        {
                            _component.YValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "WidthValue")
                        {
                            _component.WidthValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HeightValue")
                        {
                            _component.HeightValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "BackColorValue")
                        {
                            _component.BackColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "ForeColorValue")
                        {
                            _component.ForeColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "MovingColorValue")
                        {
                            _component.MovingColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "HorizontalAxisName")
                        {
                            _component.HorizontalAxisIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HorizontalAxisID")
                        {
                            _component.HorizontalAxisID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "VerticalAxisName")
                        {
                            _component.VerticalAxisIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "VerticalAxisID")
                        {
                            _component.VerticalAxisID = Convert.ToUInt32(xmlReader.Value);
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (xmlReader.Name == "Move")
                        {
                            _component.setJoystick(mJoystickHandler, mJoystickId, maxvalX, maxvalY);
                            return;
                        }
                        break;
                }
            }
        }

        private void loadDirectionComponent(XmlTextReader xmlReader)
        {
            DirectionForm _component = new DirectionForm(DirectionForm.COMPONENTMODE.RUN_MODE);
            mCustomController.Add(_component);
            _component.Show();
            _component.TopMost = true;

            string _currentTagName = "";
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        _currentTagName = xmlReader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (_currentTagName == "XValue")
                        {
                            _component.XValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "YValue")
                        {
                            _component.YValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "WidthValue")
                        {
                            _component.WidthValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HeightValue")
                        {
                            _component.HeightValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "BackColorValue")
                        {
                            _component.BackColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "MovingColorValue")
                        {
                            _component.MovingColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "HorizontalAxisName")
                        {
                            _component.HorizontalAxisIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HorizontalAxisID")
                        {
                            _component.HorizontalAxisID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "VerticalAxisName")
                        {
                            _component.VerticalAxisIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "VerticalAxisID")
                        {
                            _component.VerticalAxisID = Convert.ToUInt32(xmlReader.Value);
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (xmlReader.Name == "Direction")
                        {
                            _component.setJoystick(mJoystickHandler, mJoystickId, maxvalX, maxvalY);
                            return;
                        }
                        break;
                }
            }
        }

        private void loadTouchComponent(XmlTextReader xmlReader)
        {
            TouchForm _component = new TouchForm(TouchForm.COMPONENTMODE.RUN_MODE);
            mCustomController.Add(_component);
            _component.Show();
            _component.TopMost = true;

            string _currentTagName = "";
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        _currentTagName = xmlReader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (_currentTagName == "XValue")
                        {
                            _component.XValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "YValue")
                        {
                            _component.YValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "WidthValue")
                        {
                            _component.WidthValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HeightValue")
                        {
                            _component.HeightValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "BackColorValue")
                        {
                            _component.BackColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "ForeColorValue")
                        {
                            _component.ForeColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "GestureIDs")
                        {
                            Dictionary<string, uint> _gestureIDs = new Dictionary<string, uint>();
                            string[] _pairs = xmlReader.Value.Split(':');
                            foreach (string _pair in _pairs)
                            {
                                string[] _gesture = _pair.Split(',');
                                _gestureIDs.Add(_gesture[0], Convert.ToUInt32(_gesture[1]));
                            }
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (xmlReader.Name == "Touch")
                        {
                            _component.setJoystick(mJoystickHandler, mJoystickId, maxvalX, maxvalY);
                            return;
                        }
                        break;
                }
            }
        }

        private void ControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAllController();

            ToolStripMenuItem _controllersMenu = (ToolStripMenuItem)sender;
            string _controllerName = _controllersMenu.Text;

            XmlTextReader _xmlReader = new XmlTextReader("./controllers/" + _controllerName + ".xml");

            string _currentTagName = "";
            while (_xmlReader.Read())
            {
                switch (_xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (_xmlReader.Name == "Button")
                        {
                            loadButtonComponent(_xmlReader);
                        }
                        else if (_xmlReader.Name == "Move")
                        {
                            loadMoveComponent(_xmlReader);
                        }
                        else if (_xmlReader.Name == "Direction")
                        {
                            loadDirectionComponent(_xmlReader);
                        }
                        else if (_xmlReader.Name == "Touch")
                        {
                            loadTouchComponent(_xmlReader);
                        }
                        _currentTagName = _xmlReader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (_currentTagName == "Name" && _xmlReader.Value != _controllerName)
                        {
                            MessageBox.Show("Loading controller failed.", "error");
                            return;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        _currentTagName = "";
                        break;
                }
            }
        }

        public void loadCustomControllerMenu()
        {
            ToolStripMenuItem _controllersMenu = new ToolStripMenuItem("Custom Controllers");

            mCustomControllerList.Clear();

            foreach (string _filename in Directory.EnumerateFiles("./controllers/", "*.xml", SearchOption.TopDirectoryOnly))
            {
                string _menuName = _filename.Substring(_filename.LastIndexOf("/") + 1, _filename.Length - _filename.LastIndexOf("/") - 5);
                ToolStripMenuItem _controllerMenu = new ToolStripMenuItem(_menuName, null);
                mCustomControllerList.Add(_menuName);

                _controllerMenu.Click += new EventHandler(ControllerToolStripMenuItem_Click);
                _controllersMenu.DropDownItems.Add(_controllerMenu);
            }

            MainMenu.Items.RemoveAt(3);
            MainMenu.Items.Insert(3, _controllersMenu);
        }

        public MainController()
        {
            InitializeComponent();

            PopulateSource();

            initVJoyStick();
            
            initializeNormalController();
            initializeCompactController();
            initializeComplexController();
            initializeTouchController();
            initializeVoiceController();

            mNormalJoystickCfgForm = new NormalJoystickCfgForm(mNormalControllerForm);
            mNormalJoystickCfgForm.loadConfigFromFile();
            mNormalJoystickCfgForm.setConfigToButtons();
            mCompactJoystickCfgForm = new CompactJoystickCfgFrom(mCompactControllerForm);
            mCompactJoystickCfgForm.loadConfigFromFile();
            mCompactJoystickCfgForm.setConfigToButtons();
            mComplexJoystickCfgForm = new ComplexJoystickCfgForm(mComplexControllerForm);
            mComplexJoystickCfgForm.loadConfigFromFile();
            mComplexJoystickCfgForm.setConfigToButtons();
            mTouchJoystickCfgForm = new TouchJoystickCfgForm(mTouchControllerForm);
            mTouchJoystickCfgForm.loadConfigFromFile();
            mTouchJoystickCfgForm.setConfigToButtons();
            mVoiceJoystickCfgForm = new VoiceJoystickCfgForm(mVoiceController);
            mVoiceJoystickCfgForm.loadConfigFromFile();
            mVoiceJoystickCfgForm.setConfigToButtons();

            mOptionForm = new OptionForm(this);
            mEditBoxForm = new EditBoxForm(this);

            loadCustomControllerMenu();

            this.Icon = Properties.Resources.windows;

            notifyIcon1.Icon = Properties.Resources.windows;
            notifyIcon1.Visible = true;
            //this.Hide();
            //notifyIcon1.ContextMenu = this.ContextMenu;

        }
    }
}
