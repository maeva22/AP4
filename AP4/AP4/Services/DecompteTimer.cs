using AP4.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AP4.Services
{
    public class DecompteTimer : IDecompteTimer
    {
        #region Private Variable
        private bool _Stoppe = false;
        private TimeSpan _Second = new TimeSpan(0, 0, 1);

        private readonly TimeSpan _Interval;
        private TimeSpan _TempsRestant;

        private EventHandler<TimerEventArgs> _TictacEvent;
        private EventHandler _CompletEvent;
        private EventHandler _AvorteEvent;

        public TimeSpan TempsRestant { get => _TempsRestant; set => _TempsRestant = value; }
        public EventHandler<TimerEventArgs> TictacEvent { get => _TictacEvent; set => _TictacEvent = value; }
        public bool Stoppe { get => _Stoppe; set => _Stoppe = value; }
        public EventHandler CompletEvent { get => _CompletEvent; set => _CompletEvent = value; }
        #endregion

        #region constructeurs
        public DecompteTimer()
        {
            _Interval = _Second;
        }
        #endregion

        #region methodes



        event EventHandler IDecompteTimer.Complet
        {
            add { CompletEvent += value; }
            remove { CompletEvent -= value; }
        }

        event EventHandler IDecompteTimer.Avorte
        {
            add { _AvorteEvent += value; }
            remove { _AvorteEvent -= value; }
        }


        event EventHandler<TimerEventArgs> IDecompteTimer.TicTac
        {

            add { TictacEvent += value; }
            remove { TictacEvent -= value; }

        }

        public void Start(TimeSpan CountdownTime)
        {
            TempsRestant = CountdownTime;
            Stoppe = false;

            Device.StartTimer(_Interval, () =>
            {
                if (this.Stoppe)
                {
                    _AvorteEvent?.Invoke(this, EventArgs.Empty);
                    return false;
                }

                TempsRestant -= _Second;
                TictacEvent?.Invoke(this, new TimerEventArgs { TempsRestant = TempsRestant });

                Stoppe = TempsRestant.Duration() == TimeSpan.Zero;

                if (Stoppe)
                    CompletEvent?.Invoke(this, EventArgs.Empty);

                return !Stoppe;
            });
        }

        public void Stop()
        {
            Stoppe = true;
        }

        void IDecompteTimer.Start(TimeSpan CountdownTime)
        {
            throw new NotImplementedException();
        }

        void IDecompteTimer.Stop()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
