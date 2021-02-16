using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;


namespace OnScreenVirtualJoystickController
{
    public partial class EditBoxForm : Form
    {
        List<Form> mComponentList = new List<Form>();
        Form mCurrentComponent = null;
        int mCurrentController = -1;
        TOOLTYPE mCurrentTool;
        MainController mMain;

        enum TOOLTYPE
        {
            BUTTON,
            MOVE,
            DIRECTION,
            TOUCH
        }

        Dictionary<string, uint> mComboToJoystickButtonMapping;
        Dictionary<string, uint> mComboToJoystickAxisMapping;

        public EditBoxForm(MainController main)
        {
            InitializeComponent();
            ButtonXNum.Maximum = Screen.PrimaryScreen.WorkingArea.Width;
            ButtonYNum.Maximum = Screen.PrimaryScreen.WorkingArea.Height;
            ButtonWidthNum.Maximum = Screen.PrimaryScreen.WorkingArea.Width;
            ButtonHeightNum.Maximum = Screen.PrimaryScreen.WorkingArea.Height;

            MoveXNum.Maximum = Screen.PrimaryScreen.WorkingArea.Width;
            MoveYNum.Maximum = Screen.PrimaryScreen.WorkingArea.Height;
            MoveWidthNum.Maximum = Screen.PrimaryScreen.WorkingArea.Width;
            MoveHeightNum.Maximum = Screen.PrimaryScreen.WorkingArea.Height;

            DirectionXNum.Maximum = Screen.PrimaryScreen.WorkingArea.Width;
            DirectionYNum.Maximum = Screen.PrimaryScreen.WorkingArea.Height;
            DirectionWidthNum.Maximum = Screen.PrimaryScreen.WorkingArea.Width;
            DirectionHeightNum.Maximum = Screen.PrimaryScreen.WorkingArea.Height;

            TouchXNum.Maximum = Screen.PrimaryScreen.WorkingArea.Width;
            TouchYNum.Maximum = Screen.PrimaryScreen.WorkingArea.Height;
            TouchWidthNum.Maximum = Screen.PrimaryScreen.WorkingArea.Width;
            TouchHeightNum.Maximum = Screen.PrimaryScreen.WorkingArea.Height;

            mMain = main;

            ButtonJoyStickButtonCmb.DataSource = new BindingSource(mMain.JoystickButtonMapping, null);
            ButtonJoyStickButtonCmb.DisplayMember = "Key";
            ButtonJoyStickButtonCmb.ValueMember = "Value";

            MoveHorizontalAxisCmb.DataSource = new BindingSource(mMain.JoystickAxisMapping, null);
            MoveHorizontalAxisCmb.DisplayMember = "Key";
            MoveHorizontalAxisCmb.ValueMember = "Value";
            MoveVerticalAxisCmb.DataSource = new BindingSource(mMain.JoystickAxisMapping, null);
            MoveVerticalAxisCmb.DisplayMember = "Key";
            MoveVerticalAxisCmb.ValueMember = "Value";

            DirectionHorizontalAxisCmb.DataSource = new BindingSource(mMain.JoystickAxisMapping, null);
            DirectionHorizontalAxisCmb.DisplayMember = "Key";
            DirectionHorizontalAxisCmb.ValueMember = "Value";
            DirectionVerticalAxisCmb.DataSource = new BindingSource(mMain.JoystickAxisMapping, null);
            DirectionVerticalAxisCmb.DisplayMember = "Key";
            DirectionVerticalAxisCmb.ValueMember = "Value";

            TouchJoyStickButtonCmb.DataSource = new BindingSource(mMain.JoystickButtonMapping, null);
            TouchJoyStickButtonCmb.DisplayMember = "Key";
            TouchJoyStickButtonCmb.ValueMember = "Value";

            ButtonPropertyPnl.Visible = true;
            MovePropertyPnl.Visible = false;
            DirectionPropertyPnl.Visible = false;
            TouchPropertyPnl.Visible = false;
        }

        private void EditBoxForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saveController())
            {
                closeAllComponent();
                this.Hide();
            }
            e.Cancel = true;


        }

        public void setCurrentComponent(Form component)
        {
            mCurrentComponent = component;

            switch (mCurrentComponent.Name)
            {
                case "ButtonForm":
                    ((ButtonForm)mCurrentComponent).Sizeable = true;
                    toolButtonReset(TOOLTYPE.BUTTON);
                    break;
                case "MoveForm":
                    ((MoveForm)mCurrentComponent).Sizeable = true;
                    toolButtonReset(TOOLTYPE.MOVE);
                    break;
                case "DirectionForm":
                    ((DirectionForm)mCurrentComponent).Sizeable = true;
                    toolButtonReset(TOOLTYPE.DIRECTION);
                    break;
                case "TouchForm":
                    ((TouchForm)mCurrentComponent).Sizeable = true;

                    Dictionary<string, uint> _ids = ((TouchForm)mCurrentComponent).GestureIDs;
                    if (_ids.Count > 0)
                    {
                        TouchGestureIDCmb.DataSource = new BindingSource(_ids, null);
                        TouchGestureIDCmb.DisplayMember = "Key";
                        TouchGestureIDCmb.ValueMember = "Value";
                        TouchGestureIDCmb.Text = "";
                    }
                    TouchGestureIDCmb.Text = ((TouchForm)mCurrentComponent).Gesture;
                    toolButtonReset(TOOLTYPE.TOUCH);
                    break;
            }

            RemoveBtn.Enabled = true;
            
            resetProperties();
        }

        public void resetProperties()
        {
            if (mCurrentComponent == null)
                return;

            switch (mCurrentComponent.Name)
            {
                case "ButtonForm":
                    ButtonForm _button = (ButtonForm)mCurrentComponent;
                    ButtonXNum.Value = _button.XValue;
                    ButtonYNum.Value = _button.YValue;
                    ButtonWidthNum.Value = _button.WidthValue;
                    ButtonHeightNum.Value = _button.HeightValue;
                    ButtonTextTxt.Text = _button.TextValue;
                    ButtonBackColor.BackColor = _button.BackColorValue;
                    ButtonForeColor.BackColor = _button.ForeColorValue;
                    ButtonJoyStickButtonCmb.SelectedIndex = (int)_button.JoystickBtnIndex;
                    break;
                case "MoveForm":
                    MoveForm _move = (MoveForm)mCurrentComponent;
                    MoveXNum.Value = _move.XValue;
                    MoveYNum.Value = _move.YValue;
                    MoveWidthNum.Value = _move.WidthValue;
                    MoveHeightNum.Value = _move.HeightValue;
                    MoveBackColor.BackColor = _move.BackColorValue;
                    MoveForeColor.BackColor = _move.ForeColorValue;
                    MoveMovingColor.BackColor = _move.MovingColorValue;
                    MoveHorizontalAxisCmb.SelectedIndex = (int)_move.HorizontalAxisIndex;
                    MoveVerticalAxisCmb.SelectedIndex = (int)_move.VerticalAxisIndex;
                    break;
                case "DirectionForm":
                    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    DirectionXNum.Value = _direction.XValue;
                    DirectionYNum.Value = _direction.YValue;
                    DirectionWidthNum.Value = _direction.WidthValue;
                    DirectionHeightNum.Value = _direction.HeightValue;
                    DirectionBackColor.BackColor = _direction.BackColorValue;
                    DirectionForeColor.BackColor = _direction.MovingColorValue;
                    DirectionHorizontalAxisCmb.SelectedIndex = (int)_direction.HorizontalAxisIndex;
                    DirectionVerticalAxisCmb.SelectedIndex = (int)_direction.VerticalAxisIndex;
                    break;
                case "TouchForm":
                    TouchForm _touch = (TouchForm)mCurrentComponent;
                    TouchXNum.Value = _touch.XValue;
                    TouchYNum.Value = _touch.YValue;
                    TouchWidthNum.Value = _touch.WidthValue;
                    TouchHeightNum.Value = _touch.HeightValue;
                    TouchBackColor.BackColor = _touch.BackColorValue;
                    TouchForeColor.BackColor = _touch.ForeColorValue;
                    TouchGestureIDCmb.Text = _touch.Gesture;
                    if (_touch.GestureIDs.ContainsKey(_touch.Gesture))
                    {
                        TouchJoyStickButtonCmb.SelectedIndex = (int)_touch.GestureIDs[_touch.Gesture];
                    }
                    else
                    {
                        TouchJoyStickButtonCmb.SelectedIndex = 0;
                    }
                    break;
            }

        }

        #region Button Property code

        private void ButtonTextTxt_TextChanged(object sender, EventArgs e)
        {
            if (mCurrentComponent == null)
                return;
            if (mCurrentComponent.Name == "ButtonForm")
            {
                ButtonForm _button = (ButtonForm)mCurrentComponent;
                _button.TextValue = ButtonTextTxt.Text;
            }
        }

        private void XNum_ValueChanged(object sender, EventArgs e)
        {
            if (mCurrentComponent == null)
                return;
            switch(mCurrentComponent.Name)
            {
                case "ButtonForm":
                    ButtonForm _button = (ButtonForm)mCurrentComponent;
                    _button.XValue = Convert.ToInt32(ButtonXNum.Value);
                    break;
                case "MoveForm":
                    MoveForm _move = (MoveForm)mCurrentComponent;
                    _move.XValue = Convert.ToInt32(MoveXNum.Value);
                    break;
                case "DirectionForm":
                    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    _direction.XValue = Convert.ToInt32(DirectionXNum.Value);
                    break;
                case "TouchForm":
                    TouchForm _touch = (TouchForm)mCurrentComponent;
                    _touch.XValue = Convert.ToInt32(TouchXNum.Value);
                    break;
            }
        }

        private void YNum_ValueChanged(object sender, EventArgs e)
        {
            if (mCurrentComponent == null)
                return;
            switch (mCurrentComponent.Name)
            {
                case "ButtonForm":
                    ButtonForm _button = (ButtonForm)mCurrentComponent;
                    _button.YValue = Convert.ToInt32(ButtonYNum.Value);
                    break;
                case "MoveForm":
                    MoveForm _move = (MoveForm)mCurrentComponent;
                    _move.YValue = Convert.ToInt32(MoveYNum.Value);
                    break;
                case "DirectionForm":
                    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    _direction.YValue = Convert.ToInt32(DirectionYNum.Value);
                    break;
                case "TouchForm":
                    TouchForm _touch = (TouchForm)mCurrentComponent;
                    _touch.YValue = Convert.ToInt32(TouchYNum.Value);
                    break;
            }
        }

        private void WidthNum_ValueChanged(object sender, EventArgs e)
        {
            if (mCurrentComponent == null)
                return;
            switch (mCurrentComponent.Name)
            {
                case "ButtonForm":
                    ButtonForm _button = (ButtonForm)mCurrentComponent;
                    _button.WidthValue = Convert.ToInt32(ButtonWidthNum.Value);
                    break;
                case "MoveForm":
                    MoveForm _move = (MoveForm)mCurrentComponent;
                    _move.WidthValue = Convert.ToInt32(MoveWidthNum.Value);
                    break;
                case "DirectionForm":
                    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    _direction.WidthValue = Convert.ToInt32(DirectionWidthNum.Value);
                    break;
                case "TouchForm":
                    TouchForm _touch = (TouchForm)mCurrentComponent;
                    _touch.WidthValue = Convert.ToInt32(TouchWidthNum.Value);
                    break;
            }
        }

        private void HeightNum_ValueChanged(object sender, EventArgs e)
        {
            if (mCurrentComponent == null)
                return;
            switch (mCurrentComponent.Name)
            {
                case "ButtonForm":
                    ButtonForm _button = (ButtonForm)mCurrentComponent;
                    _button.WidthValue = Convert.ToInt32(ButtonHeightNum.Value);
                    break;
                case "MoveForm":
                    MoveForm _move = (MoveForm)mCurrentComponent;
                    _move.WidthValue = Convert.ToInt32(MoveHeightNum.Value);
                    break;
                case "DirectionForm":
                    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    _direction.WidthValue = Convert.ToInt32(DirectionHeightNum.Value);
                    break;
                case "TouchForm":
                    TouchForm _touch = (TouchForm)mCurrentComponent;
                    _touch.HeightValue = Convert.ToInt32(TouchHeightNum.Value);
                    break;
            }
        }

        private void ForeColorBtn_Click(object sender, EventArgs e)
        {
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                switch (mCurrentComponent.Name)
                {
                    case "ButtonForm":
                        ButtonForeColor.BackColor = colorDlg.Color;
                        ButtonForm _button = (ButtonForm)mCurrentComponent;
                        _button.ForeColorValue = colorDlg.Color;
                        break;
                    case "MoveForm":
                        MoveForeColor.BackColor = colorDlg.Color;
                        MoveForm _move = (MoveForm)mCurrentComponent;
                        _move.ForeColorValue = colorDlg.Color;
                        break;
                    case "DirectionForm":
                        DirectionForeColor.BackColor = colorDlg.Color;
                        DirectionForm _direction = (DirectionForm)mCurrentComponent;
                        _direction.MovingColorValue = colorDlg.Color;
                        break;
                    case "TouchForm":
                        TouchForeColor.BackColor = colorDlg.Color;
                        TouchForm _touch = (TouchForm)mCurrentComponent;
                        _touch.ForeColorValue = colorDlg.Color;
                        break;

                }
            }
        }

        private void BackColorBtn_Click(object sender, EventArgs e)
        {
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                switch (mCurrentComponent.Name)
                {
                    case "ButtonForm":
                        ButtonBackColor.BackColor = colorDlg.Color;
                        ButtonForm _button = (ButtonForm)mCurrentComponent;
                        _button.BackColorValue = colorDlg.Color;
                        break;
                    case "MoveForm":
                        MoveBackColor.BackColor = colorDlg.Color;
                        MoveForm _move = (MoveForm)mCurrentComponent;
                        _move.BackColorValue = colorDlg.Color;
                        break;
                    case "DirectionForm":
                        DirectionBackColor.BackColor = colorDlg.Color;
                        DirectionForm _direction = (DirectionForm)mCurrentComponent;
                        _direction.BackColorValue = colorDlg.Color;
                        break;
                    case "TouchForm":
                        TouchBackColor.BackColor = colorDlg.Color;
                        TouchForm _touch = (TouchForm)mCurrentComponent;
                        _touch.BackColorValue = colorDlg.Color;
                        break;
                }
            }
        }

        private void MovingColorBtn_Click(object sender, EventArgs e)
        {
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                switch (mCurrentComponent.Name)
                {
                    case "MoveForm":
                        MoveMovingColor.BackColor = colorDlg.Color;
                        MoveForm _move = (MoveForm)mCurrentComponent;
                        _move.MovingColorValue = colorDlg.Color;
                        break;
                }
            }
        }

        private void JoyStickCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox _combo;

            switch (mCurrentComponent.Name)
            {
                case "ButtonForm":
                    ButtonForm _button = (ButtonForm)mCurrentComponent;
                    _button.JoystickBtnIndex = (uint)ButtonJoyStickButtonCmb.SelectedIndex;
                    _button.JoystickBtnID = (uint)ButtonJoyStickButtonCmb.SelectedValue;
                    break;
                case "MoveForm":
                    MoveForm _move = (MoveForm)mCurrentComponent;
                    _combo = (ComboBox)sender;

                    switch (_combo.Name)
                    {
                        case "MoveHorizontalAxisCmb":
                            _move.HorizontalAxisIndex = (uint)MoveHorizontalAxisCmb.SelectedIndex;
                            _move.HorizontalAxisID = (uint)MoveHorizontalAxisCmb.SelectedValue;
                            break;
                        case "MoveVerticalAxisCmb":
                            _move.VerticalAxisIndex = (uint)MoveVerticalAxisCmb.SelectedIndex;
                            _move.VerticalAxisID = (uint)MoveVerticalAxisCmb.SelectedValue;
                            break;
                    }
                    break;
                case "DirectionForm":
                    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    _combo = (ComboBox)sender;

                    switch(_combo.Name)
                    {
                        case "DirectionHorizontalAxisCmb":
                            _direction.HorizontalAxisIndex = (uint)DirectionHorizontalAxisCmb.SelectedIndex;
                            _direction.HorizontalAxisID = (uint)DirectionHorizontalAxisCmb.SelectedValue;
                            break;
                        case "DirectionVerticalAxisCmb":
                            _direction.VerticalAxisIndex = (uint)DirectionVerticalAxisCmb.SelectedIndex;
                            _direction.VerticalAxisID = (uint)DirectionVerticalAxisCmb.SelectedValue;
                            break;
                    }
                    break;
            }
        }
        #endregion

        #region ToolBox code
        private void ButtonToolBtn_Click(object sender, EventArgs e)
        {
            toolButtonReset(TOOLTYPE.BUTTON);
        }

        private void ButtonToolBtn_DoubleClick(object sender, EventArgs e)
        {
            toolButtonReset(TOOLTYPE.BUTTON);

            ButtonForm _component = new ButtonForm(ButtonForm.COMPONENTMODE.EDIT_MODE);
            _component.setEditBox(this);
            setCurrentComponent(_component);
            mComponentList.Add(_component);
            _component.Location = new Point(0, 0);
            _component.Show();
        }

        private void MoveToolBtn_Click(object sender, EventArgs e)
        {
            toolButtonReset(TOOLTYPE.MOVE); 
        }

        private void MoveToolBtn_DoubleClick(object sender, EventArgs e)
        {
            toolButtonReset(TOOLTYPE.MOVE);

            MoveForm _component = new MoveForm(MoveForm.COMPONENTMODE.EDIT_MODE);
            _component.setEditBox(this);
            setCurrentComponent(_component);
            mComponentList.Add(_component);
            _component.Location = new Point(0, 0);
            _component.Show();
        }

        private void DirectionToolBtn_Click(object sender, EventArgs e)
        {
            toolButtonReset(TOOLTYPE.DIRECTION); 
        }

        private void DirectionToolBtn_DoubleClick(object sender, EventArgs e)
        {
            toolButtonReset(TOOLTYPE.DIRECTION);

            DirectionForm _component = new DirectionForm(DirectionForm.COMPONENTMODE.EDIT_MODE);
            _component.setEditBox(this);
            setCurrentComponent(_component);
            mComponentList.Add(_component);
            _component.Location = new Point(0, 0);
            _component.Show();
        }

        private void TouchToolBtn_Click(object sender, EventArgs e)
        {
            toolButtonReset(TOOLTYPE.TOUCH); 
        }

        private void TouchToolBtn_DoubleClick(object sender, EventArgs e)
        {
            toolButtonReset(TOOLTYPE.TOUCH);

            TouchForm _component = new TouchForm(TouchForm.COMPONENTMODE.EDIT_MODE);
            _component.setEditBox(this);
            setCurrentComponent(_component);
            mComponentList.Add(_component);
            _component.Location = new Point(0, 0);
            _component.Show();
        }

        private void toolButtonReset(TOOLTYPE mTool)
        {
            mCurrentTool = mTool;

            ButtonToolBtn.BackColor     = System.Drawing.SystemColors.Control;
            MoveToolBtn.BackColor       = System.Drawing.SystemColors.Control;
            DirectionToolBtn.BackColor  = System.Drawing.SystemColors.Control;
            TouchToolBtn.BackColor      = System.Drawing.SystemColors.Control;

            ButtonPropertyPnl.Visible = false;
            MovePropertyPnl.Visible = false;
            DirectionPropertyPnl.Visible = false;
            TouchPropertyPnl.Visible = false;

            switch (mTool)
            {
                case TOOLTYPE.BUTTON:
                    ButtonToolBtn.BackColor = System.Drawing.SystemColors.ControlDark;
                    ButtonPropertyPnl.Visible = true;
                    break;
                case TOOLTYPE.MOVE:
                    MoveToolBtn.BackColor = System.Drawing.SystemColors.ControlDark;
                    MovePropertyPnl.Visible = true;
                    break;
                case TOOLTYPE.DIRECTION:
                    DirectionToolBtn.BackColor = System.Drawing.SystemColors.ControlDark;
                    DirectionPropertyPnl.Visible = true;
                    break;
                case TOOLTYPE.TOUCH:
                    TouchToolBtn.BackColor = System.Drawing.SystemColors.ControlDark;
                    TouchPropertyPnl.Visible = true;
                    break;
            }
        }
        
        private void AddBtn_Click(object sender, EventArgs e)
        {
            Form _component = null;
            switch (mCurrentTool)
            {
                case TOOLTYPE.BUTTON:
                    _component = new ButtonForm(ButtonForm.COMPONENTMODE.EDIT_MODE);
                    ((ButtonForm)_component).setEditBox(this);
                    setCurrentComponent(_component);
                    break;
                case TOOLTYPE.MOVE:
                    _component = new MoveForm(MoveForm.COMPONENTMODE.EDIT_MODE);
                    ((MoveForm)_component).setEditBox(this);
                    setCurrentComponent(_component);
                    break;
                case TOOLTYPE.DIRECTION:
                    _component = new DirectionForm(DirectionForm.COMPONENTMODE.EDIT_MODE);
                    ((DirectionForm)_component).setEditBox(this);
                    setCurrentComponent(_component);
                    break;
                case TOOLTYPE.TOUCH:
                    _component = new TouchForm(TouchForm.COMPONENTMODE.EDIT_MODE);
                    ((TouchForm)_component).setEditBox(this);
                    setCurrentComponent(_component);
                    break;
            }
            
            mComponentList.Add(_component);

            _component.Location = new Point(0, 0);
            _component.Show();

        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (mCurrentComponent == null)
                return;

            for (int i=0;i<mComponentList.Count();i++)
            {
                if(mComponentList[i].Equals(mCurrentComponent))
                {
                    mCurrentComponent.Close();
                    if (i == 0)
                    {
                        if(mComponentList.Count > 0)
                        {
                            mComponentList.RemoveAt(i);
                            if (mComponentList.Count() == 0)
                            {
                                mCurrentComponent = null;
                                RemoveBtn.Enabled = false;
                            }
                            else
                                setCurrentComponent(mComponentList[0]);
                        }
                    }
                    else
                    {
                        setCurrentComponent(mComponentList[i - 1]);
                        mComponentList.RemoveAt(i);
                    }
                    break;
                }
            }

        }


        #endregion



        private bool saveController()
        {
            if (mComponentList.Count == 0)
                return true;

            if (ControllerNameCmb.Text.Trim() == "")
            {
                MessageBox.Show("Please insert controller name.", "warning");
                return false;
            }
            

            XmlTextWriter _xmlWriter = new XmlTextWriter("./controllers/" + ControllerNameCmb.Text + ".xml", System.Text.Encoding.UTF8);
            _xmlWriter.WriteStartDocument(true);
            _xmlWriter.Formatting = Formatting.Indented;
            _xmlWriter.Indentation = 2;
            _xmlWriter.WriteStartElement("Controller");
            _xmlWriter.WriteStartElement("Name");
            _xmlWriter.WriteString(ControllerNameCmb.Text);
            _xmlWriter.WriteEndElement();
            foreach (Form _component in mComponentList)
            {
                switch (_component.Name)
                {
                    case "ButtonForm":
                        ButtonForm _button = (ButtonForm)_component;
                        _xmlWriter.WriteStartElement("Button");
                        _xmlWriter.WriteStartElement("XValue"); _xmlWriter.WriteString(_button.XValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("YValue"); _xmlWriter.WriteString(_button.YValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("WidthValue"); _xmlWriter.WriteString(_button.WidthValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("HeightValue"); _xmlWriter.WriteString(_button.HeightValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("TextValue"); _xmlWriter.WriteString(_button.TextValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("BackColorValue"); _xmlWriter.WriteValue(_button.BackColorValue.ToArgb()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("ForeColorValue"); _xmlWriter.WriteValue(_button.ForeColorValue.ToArgb()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("JoystickBtnName"); _xmlWriter.WriteValue(_button.JoystickBtnIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("JoystickBtnID"); _xmlWriter.WriteValue(_button.JoystickBtnID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteEndElement();

                        //ButtonJoyStickButtonCmb.SelectedIndex = (int)_button.JoyStickBtnID;
                        break;
                    case "MoveForm":
                        MoveForm _move = (MoveForm)_component;
                        _xmlWriter.WriteStartElement("Move");
                        _xmlWriter.WriteStartElement("XValue"); _xmlWriter.WriteString(_move.XValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("YValue"); _xmlWriter.WriteString(_move.YValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("WidthValue"); _xmlWriter.WriteString(_move.WidthValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("HeightValue"); _xmlWriter.WriteString(_move.HeightValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("BackColorValue"); _xmlWriter.WriteValue(_move.BackColorValue.ToArgb()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("ForeColorValue"); _xmlWriter.WriteValue(_move.ForeColorValue.ToArgb()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("MovingColorValue"); _xmlWriter.WriteValue(_move.MovingColorValue.ToArgb()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("HorizontalAxisName"); _xmlWriter.WriteValue(_move.HorizontalAxisIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("HorizontalAxisID"); _xmlWriter.WriteValue(_move.HorizontalAxisID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("VerticalAxisName"); _xmlWriter.WriteValue(_move.VerticalAxisIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("VerticalAxisID"); _xmlWriter.WriteValue(_move.VerticalAxisID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteEndElement();
                        //ButtonJoyStickButtonCmb.SelectedIndex = (int)_button.JoyStickBtnID;
                        break;
                    case "DirectionForm":
                        DirectionForm _direction = (DirectionForm)_component;
                        _xmlWriter.WriteStartElement("Direction");
                        _xmlWriter.WriteStartElement("XValue"); _xmlWriter.WriteString(_direction.XValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("YValue"); _xmlWriter.WriteString(_direction.YValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("WidthValue"); _xmlWriter.WriteString(_direction.WidthValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("HeightValue"); _xmlWriter.WriteString(_direction.HeightValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("BackColorValue"); _xmlWriter.WriteValue(_direction.BackColorValue.ToArgb()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("MovingColorValue"); _xmlWriter.WriteValue(_direction.MovingColorValue.ToArgb()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("HorizontalAxisName"); _xmlWriter.WriteValue(_direction.HorizontalAxisIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("HorizontalAxisID"); _xmlWriter.WriteValue(_direction.HorizontalAxisID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("VerticalAxisName"); _xmlWriter.WriteValue(_direction.VerticalAxisIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("VerticalAxisID"); _xmlWriter.WriteValue(_direction.VerticalAxisID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteEndElement();
                        //ButtonJoyStickButtonCmb.SelectedIndex = (int)_button.JoyStickBtnID;
                        break;
                    case "TouchForm":
                        TouchForm _touch = (TouchForm)_component;
                        _xmlWriter.WriteStartElement("Touch");
                        _xmlWriter.WriteStartElement("XValue"); _xmlWriter.WriteString(_touch.XValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("YValue"); _xmlWriter.WriteString(_touch.YValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("WidthValue"); _xmlWriter.WriteString(_touch.WidthValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("HeightValue"); _xmlWriter.WriteString(_touch.HeightValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("BackColorValue"); _xmlWriter.WriteValue(_touch.BackColorValue.ToArgb()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("ForeColorValue"); _xmlWriter.WriteValue(_touch.ForeColorValue.ToArgb()); _xmlWriter.WriteEndElement();

                        string _gestureIDs = "";
                        foreach (string _key in _touch.GestureIDs.Keys)
                        {
                            _gestureIDs += (_key + "," + _touch.GestureIDs[_key]) + ":";
                        }
                        _xmlWriter.WriteStartElement("GestureIDs"); _xmlWriter.WriteValue(_gestureIDs); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteEndElement();
                        //TouchJoyStickButtonCmb.SelectedIndex = (int)_touch.JoyStickBtnID;
                        break;
                }
            }

            _xmlWriter.WriteEndElement();
            _xmlWriter.WriteEndDocument();
            _xmlWriter.Close();

            MessageBox.Show("successful saved.", "information");

            foreach (Form _component in mComponentList)
                _component.Close();
            mComponentList.Clear();

            ControllerNameCmb.Text = "";

            return true;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            saveController();
        }

        private void loadButtonComponent(XmlTextReader xmlReader)
        {
            ButtonForm _component = new ButtonForm(ButtonForm.COMPONENTMODE.EDIT_MODE);
            _component.setEditBox(this);
            _component.Show();

            mComponentList.Add(_component);

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
                        else if (_currentTagName == "JoystickBtnName")
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
                            //_component.setJoystick(mJoystickHandler, mJoystickId);
                            return;
                        }
                        break;
                }
            }


        }

        private void loadMoveComponent(XmlTextReader xmlReader)
        {
            MoveForm _component = new MoveForm(MoveForm.COMPONENTMODE.EDIT_MODE);
            _component.setEditBox(this);
            _component.Show();

            mComponentList.Add(_component);

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
                            //_component.setJoystick(mJoystickHandler, mJoystickId);
                            return;
                        }
                        break;
                }
            }
        }

        private void loadDirectionComponent(XmlTextReader xmlReader)
        {
            DirectionForm _component = new DirectionForm(DirectionForm.COMPONENTMODE.EDIT_MODE);
            _component.setEditBox(this);
            _component.Show();

            mComponentList.Add(_component);

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
                            //_component.setJoystick(mJoystickHandler, mJoystickId);
                            return;
                        }
                        break;
                }
            }
        }

        private void loadTouchComponent(XmlTextReader xmlReader)
        {
            TouchForm _component = new TouchForm(TouchForm.COMPONENTMODE.EDIT_MODE);
            _component.setEditBox(this);
            _component.Show();

            mComponentList.Add(_component);

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
                            foreach(string _pair in _pairs)
                            {
                                string[] _gesture = _pair.Split(',');
                                _gestureIDs.Add(_gesture[0], Convert.ToUInt32(_gesture[1]));
                            }
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (xmlReader.Name == "Touch")
                        {
                            //_component.setJoystick(mJoystickHandler, mJoystickId);
                            return;
                        }
                        break;
                }
            }
        }

        private void closeAllComponent()
        {
            foreach (Form _component in mComponentList)
                _component.Close();
        }
        private void ControllerNameCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (ControllerNameCmb.Text.Trim() == "")
            {
                MessageBox.Show("Please select controller.", "warning");
                ControllerNameCmb.SelectedIndex = mCurrentController;
                return;
            }


            closeAllComponent();
            mComponentList.Clear();

            XmlTextReader _xmlReader = new XmlTextReader("./controllers/" + ControllerNameCmb.Text + ".xml");
            
            while (_xmlReader.Read())
            {
                switch (_xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if(_xmlReader.Name == "Button")
                        {
                            loadButtonComponent(_xmlReader);
                        }
                        else if(_xmlReader.Name == "Move")
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
                        break;
                    case XmlNodeType.Text:
                        if (_xmlReader.Name=="Name" && _xmlReader.Value != ControllerNameCmb.Text)
                        {
                            MessageBox.Show("Loading controller failed.", "error");
                            return;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        break;
                }
            }

            _xmlReader.Close();
            if(mComponentList.Count > 0)
                setCurrentComponent(mComponentList[0]);

        }
        
        private void TouchJoyStickButtonCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _gestureID = TouchGestureIDCmb.Text;

            TouchForm _touch = (TouchForm)mCurrentComponent;
            Dictionary<string, uint> _gestureIDs = _touch.GestureIDs;

            BindingSource _bt = (BindingSource)TouchGestureIDCmb.DataSource;

            uint _joystickButtonID = (uint)TouchJoyStickButtonCmb.SelectedValue;

            if (_gestureIDs.ContainsKey(_gestureID))
            {
                if (_joystickButtonID == 0)
                    _gestureIDs.Remove(_gestureID);
                else
                    _gestureIDs[_gestureID] = (uint)_joystickButtonID;
            }
            else
            {
                if (_joystickButtonID > 0)
                {
                    _gestureIDs.Add(_gestureID, _joystickButtonID);
                    
                }
                    
            }

            _bt = (BindingSource)TouchGestureIDCmb.DataSource;
            if (_bt == null)
            {
                TouchGestureIDCmb.DataSource = new BindingSource(_gestureIDs, null);
                TouchGestureIDCmb.DisplayMember = "Key";
                TouchGestureIDCmb.ValueMember = "Value";
            }
            else
            {
                _bt.ResetBindings(false);
                TouchGestureIDCmb.Refresh();
            }
        }

        private void TouchGestureIDCmb_TextChanged(object sender, EventArgs e)
        {
            TouchForm _touch = (TouchForm)mCurrentComponent;
            _touch.Gesture = TouchGestureIDCmb.Text;
            _touch.GestureToTrackList();
        }
        
        private void EditBoxForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                mCurrentTool = TOOLTYPE.BUTTON;
                ButtonToolBtn.BackColor = System.Drawing.SystemColors.ControlDark;

                AddBtn.Enabled = true;
                mMain.loadCustomControllerMenu();

                this.ControllerNameCmb.Items.Clear();
                this.ControllerNameCmb.Items.AddRange(mMain.CustomControllerList.ToArray());
            }
        }

        private void TouchGestureIDCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int _item = (int)TouchGestureIDCmb.SelectedValue;
            ////int _index = Convert.ToInt32(_item.ToString());

            //TouchJoyStickButtonCmb.SelectedIndex = _item;
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            saveController();
            closeAllComponent();
            mComponentList.Clear();

            ControllerNameCmb.Text = "";
        }
    }
}
