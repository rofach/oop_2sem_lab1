using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_2sem_lab1
{


    class Timer
    {

        private Thread _thread;
        private bool _isStarted = false;
        private int _time;

        public Timer(int time = 1000)
        {
            _time = time;
        }
        public int Time
        {
            get { return _time; }
            set { _time = value; }           
        }
        public void Start(dlgStringOp dlg, string str)
        {
            if (_isStarted == false)
            {
                _isStarted = true;
                _thread = new(() => Run(dlg, str));
                _thread.Start();
            }
            else
            {
                Console.WriteLine("The timer has already started");
            }
        }
        public void Stop()
        {
            _isStarted = false;
        }
        private void Run(dlgStringOp dlg, string str)
        {
            while (_isStarted)
            {
                dlg(str);
                Thread.Sleep(_time);
            }
        }
    }
}
