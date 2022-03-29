using AP4.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AP4.Interfaces
{
    public interface IDecompteTimer
    {
        void Start(TimeSpan CountdownTime);
        void Stop();

        event EventHandler<TimerEventArgs> TicTac;
        event EventHandler Complet;
        event EventHandler Avorte;
    }
}
