using System;
using System.Collections.Generic;
using System.Text;

namespace StreamProgress
{
    public class StreamProgressInfo
    {
        private IProgressable progressable;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IProgressable progressable)
        {
            this.progressable = progressable;
        }

        public int CalculateCurrentPercent()
        {
            return progressable.BytesSent * 100 / progressable.Length;
        }
    }
}
