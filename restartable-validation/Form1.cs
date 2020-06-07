using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace async_delete_many_files
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buttonStartOrRestart.Click += ButtonStartOrRestart_Click;
            buttonCancel.Click += ButtonCancel_Click;
            Progress += TaskNotify_Progress;
            _progress = 0;
            textBoxRemaining.Text = "0%";
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            if(_cts != null) _cts.Cancel();
            _restart = false;
            MessageBox.Show("Cancelled");
            BeginInvoke((MethodInvoker)delegate
            {
                buttonCancel.Enabled = false;
            });
        }
        int _progress;
        bool _restart = false;
        private void ButtonStartOrRestart_Click(object sender, EventArgs e)
        {
            if (_cts != null) _cts.Cancel();
            try
            {
                ssBusy.Wait();
                switch(ssBusy.CurrentCount)
                {
                    case 1:
                        // Start 
                        buttonCancel.Enabled = true;
                        ExecValidityCheck();
                        break;
                    case 0:
                        // Restart
                        _restart = true;
                        break;
                }
            }
            finally
            {
                ssBusy.Release();
            }
        }
        CancellationTokenSource _cts = null;
        SemaphoreSlim ssBusy = new SemaphoreSlim(2);
        private void ExecValidityCheck()
        {
            ssBusy.Wait();
            Task.Run(() =>
            {
                try
                {
                    _cts = new CancellationTokenSource();
                    LongRunningValidation(_cts.Token);
                }
                finally
                {
                    ssBusy.Release();
                }
            })
            .GetAwaiter()
            .OnCompleted(CheckForRestart);
        }
        void CheckForRestart()
        {
            BeginInvoke((MethodInvoker)delegate
            {
                if (_restart)
                {
                    _restart = false;
                    ExecValidityCheck();
                }
                else
                {
                    buttonCancel.Enabled = false;
                }
            });
        }
        private void LongRunningValidation(CancellationToken ct)
        {
            _progress = 0;
            // Run some portion of validity code then check for cancellation.
            if (CheckForCancel(ct)) return;
            RunPartialValidityTest();   // i.e. some code {...}
            // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            if (CheckForCancel(ct)) return;
            RunPartialValidityTest();
            if (CheckForCancel(ct)) return;
            RunPartialValidityTest();
            if (CheckForCancel(ct)) return;
            RunPartialValidityTest();
            if (CheckForCancel(ct)) return;
            RunPartialValidityTest();
            if (CheckForCancel(ct)) return;
            RunPartialValidityTest();
            if (CheckForCancel(ct)) return;
            RunPartialValidityTest();
            if (CheckForCancel(ct)) return;
            RunPartialValidityTest();
            if (CheckForCancel(ct)) return;
            RunPartialValidityTest();
            if (CheckForCancel(ct)) return;
            RunPartialValidityTest();
        }

        private bool CheckForCancel(CancellationToken ct)
        {
            return ct.IsCancellationRequested;
        }

        // vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
        // SIMULATE "Running a portion of the validation code"
        private void RunPartialValidityTest()
        { 
            // Send progress notifications to UI thread
            if (_progress == 0) Progress?.Invoke(this, EventArgs.Empty);

            // Simulate running a chunk of validation code
            Task.Delay(500).Wait();
            // SIMULATE ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

            // Increment the progress count and notify UI
            _progress++;
            Progress?.Invoke(this, EventArgs.Empty);
        }
        // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

        event EventHandler Progress;

        private void TaskNotify_Progress(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate 
            {
                textBoxRemaining.Text = (_progress * 10).ToString() + "%"; 
            });
        }
    }
}
