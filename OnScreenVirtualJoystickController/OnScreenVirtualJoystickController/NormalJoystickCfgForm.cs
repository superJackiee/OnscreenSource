using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OnScreenVirtualJoystickController
{
    public partial class NormalJoystickCfgForm : Form
    {

        public NormalControllerForm mController;
        string mSelectedMouseBtn;
        string mVAxis, mHAxis;

        Dictionary<string, uint[]> mMouseToJoystickMapping = new Dictionary<string, uint[]>();
        Dictionary<string, uint[]> mMouseToJoystickTempMapping;
        Dictionary<uint, string> mComboToJoystickMapping = new Dictionary<uint, string>();

        public NormalJoystickCfgForm(NormalControllerForm controller)
        {
            InitializeComponent();

            this.mController = controller;

            mComboToJoystickMapping.Add(0, "None");
            for (uint i=1; i<24; i++)
            {
                mComboToJoystickMapping.Add(i, "Button" + i);
            }
            JoystickIDCmb.DataSource = new BindingSource(mComboToJoystickMapping, null);
            JoystickIDCmb.DisplayMember = "Value";
            JoystickIDCmb.ValueMember = "Key";

            this.JoystickIDCmb.SelectedIndexChanged += new System.EventHandler(this.JoystickIDCmb_SelectedIndexChanged);
            mSelectedMouseBtn = "";
        }

        public bool loadConfigFromFile()
        {
            if (!File.Exists("normal.list"))
            {
                mMouseToJoystickMapping.Add("Danger_L_Id", new uint[2] { 1, 2});
                mMouseToJoystickMapping.Add("Danger_R_Id", new uint[2] { 2, 2});
                mMouseToJoystickMapping.Add("Danger_M_Id", new uint[2] { 3, 2});
                mMouseToJoystickMapping.Add("Danger_X1_Id", new uint[2] { 4, 2});
                mMouseToJoystickMapping.Add("Danger_X2_Id", new uint[2] { 5, 2});

                mMouseToJoystickMapping.Add("Indigo_L_Id", new uint[2] { 6, 2});
                mMouseToJoystickMapping.Add("Indigo_R_Id", new uint[2] { 7, 2});
                mMouseToJoystickMapping.Add("Indigo_M_Id", new uint[2] { 8, 2});
                mMouseToJoystickMapping.Add("Indigo_X1_Id", new uint[2] { 9, 2});
                mMouseToJoystickMapping.Add("Indigo_X2_Id", new uint[2] { 10, 2});

                mMouseToJoystickMapping.Add("Green_L_Id", new uint[2] { 11, 2});
                mMouseToJoystickMapping.Add("Green_R_Id", new uint[2] { 12, 2});
                mMouseToJoystickMapping.Add("Green_M_Id", new uint[2] { 13, 2});
                mMouseToJoystickMapping.Add("Green_X1_Id", new uint[2] { 14, 2});
                mMouseToJoystickMapping.Add("Green_X2_Id", new uint[2] { 15, 2});

                mMouseToJoystickMapping.Add("Blue_L_Id", new uint[2] { 16, 2});
                mMouseToJoystickMapping.Add("Blue_R_Id", new uint[2] { 17, 2});
                mMouseToJoystickMapping.Add("Blue_M_Id", new uint[2] { 18, 2});
                mMouseToJoystickMapping.Add("Blue_X1_Id", new uint[2] { 19, 2});
                mMouseToJoystickMapping.Add("Blue_X2_Id", new uint[2] { 20, 2});

                mMouseToJoystickMapping.Add("Circle_L_Id", new uint[2] { 21, 2});
                mMouseToJoystickMapping.Add("Circle_R_Id", new uint[2] { 22, 2});
                mMouseToJoystickMapping.Add("Circle_M_Id", new uint[2] { 23, 2});

                mHAxis = "X";
                mVAxis = "Y";
                HAxisCmb.SelectedItem = mHAxis;
                VAxisCmb.SelectedItem = mVAxis;

                saveConfigFromFile();

                mMouseToJoystickTempMapping = new Dictionary<string, uint[]>(mMouseToJoystickMapping);
                return true;
            }
            StreamReader _readfile = new StreamReader("normal.list");

            try
            {
                string line;
                string _mouseBtn;

                while ((line = _readfile.ReadLine()) != null)
                {
                    if (line.Trim(' ').Equals(""))
                        continue;
                    _mouseBtn = line.Split('=')[0];
                    if (_mouseBtn.Equals("Axis_V"))
                    {
                        mVAxis = line.Split('=')[1];
                        VAxisCmb.SelectedItem = mVAxis;
                    }
                    else if (_mouseBtn.Equals("Axis_H"))
                    {
                        mHAxis = line.Split('=')[1];
                        HAxisCmb.SelectedItem = mHAxis;
                    }
                    else
                    {
                        string _valueString = line.Split('=')[1].Substring(0);
                        string[] _valueArray = _valueString.Split(',');

                        mMouseToJoystickMapping.Add(_mouseBtn, new uint[] { Convert.ToUInt32(_valueArray[0]), Convert.ToUInt32(_valueArray[1]) });
                    }
                }

                mMouseToJoystickTempMapping = new Dictionary<string, uint[]>(mMouseToJoystickMapping);

                _readfile.Close();
            }
            catch
            {
                // MessageBox.Show("Grammar file reading failed.");
                _readfile.Close();
                return false;
            }

            return true;
        }

        public bool saveConfigFromFile()
        {
            StreamWriter _file = new StreamWriter("normal.list");
            
            try
            {
                foreach (KeyValuePair<string, uint[]> kvp in mMouseToJoystickMapping)
                {
                    uint[] _valueArray = kvp.Value;
                    string _saveValue = "";
                    
                    _saveValue = _valueArray[0].ToString() + "," + _valueArray[1].ToString();
                    
                    _file.WriteLine("{0}={1}", kvp.Key, _saveValue);
                }
                _file.WriteLine("{0}={1}", "Axis_V", mVAxis);
                _file.WriteLine("{0}={1}", "Axis_H", mHAxis);
                _file.Close();
            }
            catch
            {
                _file.Close();
                return false;
            }
            return true;
        }

        public bool setConfigToButtons()
        {
            mController.setJoystickBtnId(mMouseToJoystickMapping, mVAxis, mHAxis);
            return true;
        }

        private void setActionRadio(uint radioselect)
        {
            ActionPressRdo.Checked = false;
            ActionReleaseRdo.Checked = false;
            ActionClickRdo.Checked = false;
            ActionToggleRdo.Checked = false;

            switch (radioselect)
            {
                case (uint)MainController.BUTTON_TYPE.PRESS:
                    ActionPressRdo.Checked = true;
                    break;
                case (uint)MainController.BUTTON_TYPE.RELEASE:
                    ActionReleaseRdo.Checked = true;
                    break;
                case (uint)MainController.BUTTON_TYPE.CLICK:
                    ActionClickRdo.Checked = true;
                    break;
                case (uint)MainController.BUTTON_TYPE.TOGGLE:
                    ActionToggleRdo.Checked = true;
                    break;

            }
        }

        private void DangerButton_MouseClick(object sender, MouseEventArgs e)
        {
            switch(e.Button)
            {
                case MouseButtons.Left:
                    SelectedButtonLbl1.Text = "Mouse Left";
                    SelectedButtonLbl2.Text = "For Danger Button";
                    mSelectedMouseBtn = "Danger_L_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Danger_L_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Danger_L_Id"][1]);
                    break;
                case MouseButtons.Right:
                    SelectedButtonLbl1.Text = "Mouse Right";
                    SelectedButtonLbl2.Text = "For Danger Button";
                    mSelectedMouseBtn = "Danger_R_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Danger_R_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Danger_R_Id"][1]);
                    break;
                case MouseButtons.Middle:
                    SelectedButtonLbl1.Text = "Mouse Middle";
                    SelectedButtonLbl2.Text = "For Danger Button";
                    mSelectedMouseBtn = "Danger_M_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Danger_M_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Danger_M_Id"][1]);
                    break;
                case MouseButtons.XButton1:
                    SelectedButtonLbl1.Text = "Mouse XButton1";
                    SelectedButtonLbl2.Text = "For Danger Button";
                    mSelectedMouseBtn = "Danger_X1_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Danger_X1_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Danger_X1_Id"][1]);
                    break;
                case MouseButtons.XButton2:
                    SelectedButtonLbl1.Text = "Mouse XButton2";
                    SelectedButtonLbl2.Text = "For Danger Button";
                    mSelectedMouseBtn = "Danger_X2_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Danger_X2_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Danger_X2_Id"][1]);
                    break;
                //default:
                //    SelectedButtonLbl.Text = "";
            }
        }

        private void IndigoButton_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    SelectedButtonLbl1.Text = "Mouse Left";
                    SelectedButtonLbl2.Text = "For Indigo Button";
                    mSelectedMouseBtn = "Indigo_L_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Indigo_L_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Indigo_L_Id"][1]);
                    break;
                case MouseButtons.Right:
                    SelectedButtonLbl1.Text = "Mouse Right";
                    SelectedButtonLbl2.Text = "For Indigo Button";
                    mSelectedMouseBtn = "Indigo_R_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Indigo_R_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Indigo_R_Id"][1]);
                    break;
                case MouseButtons.Middle:
                    SelectedButtonLbl1.Text = "Mouse Middle";
                    SelectedButtonLbl2.Text = "For Indigo Button";
                    mSelectedMouseBtn = "Indigo_M_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Indigo_M_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Indigo_M_Id"][1]);
                    break;
                case MouseButtons.XButton1:
                    SelectedButtonLbl1.Text = "Mouse XButton1";
                    SelectedButtonLbl2.Text = "For Indigo Button";
                    mSelectedMouseBtn = "Indigo_X1_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Indigo_X1_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Indigo_X1_Id"][1]);
                    break;
                case MouseButtons.XButton2:
                    SelectedButtonLbl1.Text = "Mouse XButton2";
                    SelectedButtonLbl2.Text = "For Indigo Button";
                    mSelectedMouseBtn = "Indigo_X2_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Indigo_X2_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Indigo_X2_Id"][1]);
                    break;
                    //default:
                    //    SelectedButtonLbl.Text = "";
            }
        }

        private void GreenButton_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    SelectedButtonLbl1.Text = "Mouse Left";
                    SelectedButtonLbl2.Text = "For Green Button";
                    mSelectedMouseBtn = "Green_L_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Green_L_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Green_L_Id"][1]);
                    break;
                case MouseButtons.Right:
                    SelectedButtonLbl1.Text = "Mouse Right";
                    SelectedButtonLbl2.Text = "For Green Button";
                    mSelectedMouseBtn = "Green_R_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Green_R_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Green_R_Id"][1]);
                    break;
                case MouseButtons.Middle:
                    SelectedButtonLbl1.Text = "Mouse Middle";
                    SelectedButtonLbl2.Text = "For Green Button";
                    mSelectedMouseBtn = "Green_M_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Green_M_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Green_M_Id"][1]);
                    break;
                case MouseButtons.XButton1:
                    SelectedButtonLbl1.Text = "Mouse XButton1";
                    SelectedButtonLbl2.Text = "For Green Button";
                    mSelectedMouseBtn = "Green_X1_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Green_X1_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Green_X1_Id"][1]);
                    break;
                case MouseButtons.XButton2:
                    SelectedButtonLbl1.Text = "Mouse XButton2";
                    SelectedButtonLbl2.Text = "For Green Button";
                    mSelectedMouseBtn = "Green_X2_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Green_X2_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Green_X2_Id"][1]);
                    break;
                    //default:
                    //    SelectedButtonLbl.Text = "";
            }
        }

        private void BlueButton_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    SelectedButtonLbl1.Text = "Mouse Left";
                    SelectedButtonLbl2.Text = "For Blue Button";
                    mSelectedMouseBtn = "Blue_L_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Blue_L_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Blue_L_Id"][1]);
                    break;
                case MouseButtons.Right:
                    SelectedButtonLbl1.Text = "Mouse Right";
                    SelectedButtonLbl2.Text = "For Blue Button";
                    mSelectedMouseBtn = "Blue_R_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Blue_R_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Blue_R_Id"][1]);
                    break;
                case MouseButtons.Middle:
                    SelectedButtonLbl1.Text = "Mouse Middle";
                    SelectedButtonLbl2.Text = "For Blue Button";
                    mSelectedMouseBtn = "Blue_M_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Blue_M_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Blue_M_Id"][1]);
                    break;
                case MouseButtons.XButton1:
                    SelectedButtonLbl1.Text = "Mouse XButton1";
                    SelectedButtonLbl2.Text = "For Blue Button";
                    mSelectedMouseBtn = "Blue_X1_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Blue_X1_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Blue_X1_Id"][1]);
                    break;
                case MouseButtons.XButton2:
                    SelectedButtonLbl1.Text = "Mouse XButton2";
                    SelectedButtonLbl2.Text = "For Blue Button";
                    mSelectedMouseBtn = "Blue_X2_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Blue_X2_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Blue_X2_Id"][1]);
                    break;
                    //default:
                    //    SelectedButtonLbl.Text = "";
            }
        }

        private void CircleButton_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    SelectedButtonLbl1.Text = "Mouse Left";
                    SelectedButtonLbl2.Text = "For Circle Button";
                    mSelectedMouseBtn = "Circle_L_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Circle_L_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Circle_L_Id"][1]);
                    break;
                case MouseButtons.Right:
                    SelectedButtonLbl1.Text = "Mouse Right";
                    SelectedButtonLbl2.Text = "For Circle Button";
                    mSelectedMouseBtn = "Circle_R_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Circle_R_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Circle_R_Id"][1]);
                    break;
                case MouseButtons.Middle:
                    SelectedButtonLbl1.Text = "Mouse Middle";
                    SelectedButtonLbl2.Text = "For Circle Button";
                    mSelectedMouseBtn = "Circle_M_Id";
                    JoystickIDCmb.SelectedValue = mMouseToJoystickTempMapping["Circle_M_Id"][0];
                    setActionRadio(mMouseToJoystickTempMapping["Circle_M_Id"][1]);
                    break;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            mMouseToJoystickMapping = new Dictionary<string, uint[]>(mMouseToJoystickTempMapping);
            setConfigToButtons();
            saveConfigFromFile();
            this.Hide();
        }

        private void HAxisCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            mHAxis = HAxisCmb.SelectedItem.ToString();
        }

        private void VAxisCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            mVAxis = VAxisCmb.SelectedItem.ToString();
        }

        private void ActionRdo_CheckedChanged(object sender, EventArgs e)
        {
            if (ActionPressRdo.Checked)
            {
                mMouseToJoystickTempMapping[mSelectedMouseBtn][1] = (uint)MainController.BUTTON_TYPE.PRESS;
            }
            else if(ActionReleaseRdo.Checked)
            {
                mMouseToJoystickTempMapping[mSelectedMouseBtn][1] = (uint)MainController.BUTTON_TYPE.RELEASE;
            }
            else if(ActionClickRdo.Checked)
            {
                mMouseToJoystickTempMapping[mSelectedMouseBtn][1] = (uint)MainController.BUTTON_TYPE.CLICK;
            }
            else if(ActionToggleRdo.Checked)
            {
                mMouseToJoystickTempMapping[mSelectedMouseBtn][1] = (uint)MainController.BUTTON_TYPE.TOGGLE;
            }
        }

        private void JoystickIDCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<uint, string> _selectItem = (KeyValuePair<uint, string>)JoystickIDCmb.SelectedItem;
            uint _key = _selectItem.Key;
            mMouseToJoystickTempMapping[mSelectedMouseBtn][0] = _selectItem.Key;
        }
    }
}
