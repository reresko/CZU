using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperWinFormsRefactored
{
    /// <summary>
    /// Handles game timing functionality using a <see cref="Stopwatch"/> and a <see cref="System.Windows.Forms.Timer"/>.
    /// </summary>
    internal class Timer
    {
        private Stopwatch _stopwatch;
        private System.Windows.Forms.Timer _timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Timer"/> class.
        /// </summary>
        /// <param name="stopwatch">A <see cref="Stopwatch"/> instance for precise timing.</param>
        /// <param name="timer">A <see cref="System.Windows.Forms.Timer"/> for UI updates.</param>
        public Timer(Stopwatch stopwatch, System.Windows.Forms.Timer timer)
        {
            _stopwatch = stopwatch;
            _timer = timer;
        }

        /// <summary>
        /// Starts the timer and resets the elapsed time.
        /// </summary>
        public void TimerStart()
        {
            _stopwatch.Reset();
            _stopwatch.Start();
            _timer.Start();
        }

        /// <summary>
        /// Stops the timer and pauses the elapsed time tracking.
        /// </summary>
        public void TimerStop()
        {
            _timer.Stop();
            _stopwatch.Stop();
        }

        /// <summary>
        /// Gets the elapsed time tracked by the stopwatch.
        /// </summary>
        /// <returns>A <see cref="TimeSpan"/> representing the elapsed time.</returns>
        public TimeSpan GetElapsedTime()
        {
            TimeSpan elapsed = _stopwatch.Elapsed;
            return elapsed;
        }

    }
}
