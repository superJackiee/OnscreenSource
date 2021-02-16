/*******************************************************************************

INTEL CORPORATION PROPRIETARY INFORMATION
This software is supplied under the terms of a license agreement or nondisclosure
agreement with Intel Corporation and may not be copied or disclosed except in
accordance with the terms of that agreement
Copyright(c) 2013-2014 Intel Corporation. All Rights Reserved.

*******************************************************************************/
using System;
using vJoyInterfaceWrap;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Windows;
using System.Threading;
using System.Collections.Generic;

namespace OnScreenVirtualJoystickController
{
    public class VoiceController
    {
        Dictionary<string, uint> mJoystickBtnId;

        vJoy mJoystickHandler;
        vJoy.JoystickState iReport;
        uint mJoystickId;

        // Create a new SpeechRecognitionEngine instance.
        SpeechRecognitionEngine mRecognizer;
        bool mEnable = false;
        public bool Enable
        {
            get
            {
                return mEnable;
            }
            set
            {
                mEnable = value;
            }
        }

        long maxvalX, maxvalY, maxvalZ, maxvalRX, maxvalRY;

        public VoiceController()
        {
            mRecognizer = new SpeechRecognitionEngine();
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
            mRecognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(recognizer_SpeechDetected);
            mRecognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
            mRecognizer.RecognizeCompleted += new EventHandler<RecognizeCompletedEventArgs>(recognizer_RecognizeCompleted);
        }

        public void setJoystickBtnId(Dictionary<string, uint> joystickbtnid)
        {
            mJoystickBtnId = joystickbtnid;

            // Create a simple grammar.
            Choices commands = new Choices();

            Dictionary<string, uint>.KeyCollection _keys = joystickbtnid.Keys;
            List<string> _commandList = new List<string>();
            foreach (string _key in _keys)
            {
                _commandList.Add(_key);
            }
            commands.Add(_commandList.ToArray());
            // Create a GrammarBuilder object and append the Choices object.
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(commands);
            // Create the Grammar instance and load it into the speech recognition engine.
            Grammar g_Comamnds = new Grammar(gb);

            mRecognizer.LoadGrammarAsync(g_Comamnds);
        }

        public void StartController()
        {
            // Configure input to the speech recognizer.  
            this.mRecognizer.SetInputToDefaultAudioDevice();
            // Start asynchronous, continuous speech recognition.
            this.mRecognizer.RecognizeAsync(RecognizeMode.Multiple);

            mRecognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(recognizer_SpeechDetected);
            mRecognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
            mRecognizer.RecognizeCompleted += new EventHandler<RecognizeCompletedEventArgs>(recognizer_RecognizeCompleted);
        }
        
        public void StopController()
        {
            mRecognizer.SpeechDetected -= recognizer_SpeechDetected;
            mRecognizer.SpeechRecognized -= recognizer_SpeechRecognized;
            mRecognizer.RecognizeCompleted -= recognizer_RecognizeCompleted;
        }

        private void recognizer_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            // MessageBox.Show("Recognizing voice command...");
        }

        // Create a simple handler for the SpeechRecognized event.
        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // add code 
            float confidence = e.Result.Confidence;
            if (confidence < 0.3)
                return;

            string CommandHeard = e.Result.Text.ToLower();

            if (mJoystickBtnId.ContainsKey(CommandHeard))
            {
                uint btnid = mJoystickBtnId[CommandHeard];
                mJoystickHandler.SetBtn(true, mJoystickId, btnid);
                System.Threading.Thread.Sleep(10);
                mJoystickHandler.SetBtn(false, mJoystickId, btnid);
            }
        }

        private void recognizer_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            mRecognizer.RecognizeAsync();
        }
    }
}
