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
    public partial class VoiceJoystickCfgForm : Form
    {
        public VoiceController mController;

        Dictionary<string, uint> mVoiceToJoystickMapping = new Dictionary<string, uint>();
        Dictionary<string, uint> mVoiceToJoystickTempMapping;
        Dictionary<uint, string> mComboToJoystickMapping = new Dictionary<uint, string>();

        public VoiceJoystickCfgForm(VoiceController controller)
        {
            InitializeComponent();

            this.mController = controller;

            mComboToJoystickMapping.Add(0, "None");
            for (uint i = 1; i < 24; i++)
            {
                mComboToJoystickMapping.Add(i, "Button" + i);
            }
            JoystickIDCmb.DataSource = new BindingSource(mComboToJoystickMapping, null);
            JoystickIDCmb.DisplayMember = "Value";
            JoystickIDCmb.ValueMember = "Key";
        }

        public bool loadConfigFromFile()
        {
            if (!File.Exists("voice.list"))
            {
                saveConfigFromFile();

                return true;
            }
            StreamReader _readfile = new StreamReader("voice.list");

            try
            {
                string line;
                string _voiceBtn;
                uint _joystickBtn;

                while ((line = _readfile.ReadLine()) != null)
                {
                    if (line.Trim(' ').Equals(""))
                        continue;
                    _voiceBtn = line.Split('=')[0];
                    _joystickBtn = Convert.ToUInt32(line.Split('=')[1].Substring(0));

                    mVoiceToJoystickMapping.Add(_voiceBtn, _joystickBtn);

                    string[] _row = { _voiceBtn, "Button" + _joystickBtn };
                    VoiceConfigGridView.Rows.Add(_row);
                    
                }
                VoiceConfigGridView.Columns[0].DisplayIndex = 0;
                VoiceConfigGridView.Columns[1].DisplayIndex = 1;

                mVoiceToJoystickTempMapping = new Dictionary<string, uint>(mVoiceToJoystickMapping);

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
            StreamWriter _file = new StreamWriter("voice.list");

            try
            {
                foreach (KeyValuePair<string, uint> kvp in mVoiceToJoystickMapping)
                {
                    _file.WriteLine("{0}={1}", kvp.Key, kvp.Value);
                }
                _file.Close();
            }
            catch
            {
                _file.Close();
                return false;
            }
            return true;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            mVoiceToJoystickMapping = new Dictionary<string, uint>(mVoiceToJoystickTempMapping);
            setConfigToButtons();
            saveConfigFromFile();
            this.Hide();
        }

        public bool setConfigToButtons()
        {
            mController.setJoystickBtnId(mVoiceToJoystickMapping);
            return true;
        }

        string mCurrentVoiceCmd;
        private void VoiceConfigGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (VoiceConfigGridView.CurrentRow.IsNewRow)
            {
                VoiceCmdTxt.Text = "";
                JoystickIDCmb.SelectedValue = 0;
            }
            else
            {
                mCurrentVoiceCmd = VoiceConfigGridView.CurrentRow.Cells[0].Value.ToString();
                VoiceCmdTxt.Text = mCurrentVoiceCmd;
                JoystickIDCmb.SelectedValue = mVoiceToJoystickTempMapping[mCurrentVoiceCmd];
            }
        }

        private void VoiceCmdTxt_TextChanged(object sender, EventArgs e)
        {
            if (VoiceConfigGridView.CurrentRow == null || 
                mVoiceToJoystickTempMapping.ContainsKey(VoiceCmdTxt.Text) || 
                VoiceCmdTxt.Text == "")
                return;
            string _voicecmd;
            VoiceConfigGridView.NotifyCurrentCellDirty(false);

            if (VoiceConfigGridView.CurrentRow.IsNewRow)
            {
                _voicecmd = VoiceCmdTxt.Text;
                VoiceConfigGridView.CurrentRow.Cells[0].Value = _voicecmd;
                mVoiceToJoystickTempMapping.Add(_voicecmd, 0);
                VoiceConfigGridView.NotifyCurrentCellDirty(true);
            }
            else
            {
                _voicecmd = VoiceConfigGridView.CurrentRow.Cells[0].Value.ToString();
                uint _joystick = mVoiceToJoystickTempMapping[_voicecmd];

                mVoiceToJoystickTempMapping.Remove(_voicecmd);
                mVoiceToJoystickTempMapping.Add(VoiceCmdTxt.Text, _joystick);

                VoiceConfigGridView.CurrentRow.Cells[0].Value = VoiceCmdTxt.Text;
            }
        }

        private void JoystickIDCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VoiceConfigGridView.CurrentRow == null || 
                VoiceCmdTxt.Text=="" ||
                !mVoiceToJoystickTempMapping.ContainsKey(VoiceCmdTxt.Text))
                return;

            string _voicecmd = VoiceCmdTxt.Text;
            KeyValuePair<uint, string> _selectItem = (KeyValuePair<uint, string>)JoystickIDCmb.SelectedItem;
            uint _key = _selectItem.Key;

            mVoiceToJoystickTempMapping[_voicecmd] = _selectItem.Key;

            VoiceConfigGridView.CurrentRow.Cells[1].Value = _selectItem.Value;
        }

        private void VoiceConfigGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private void VoiceConfigGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if(mVoiceToJoystickTempMapping.ContainsKey(mCurrentVoiceCmd))
                mVoiceToJoystickTempMapping.Remove(mCurrentVoiceCmd);
        }
    }
}
