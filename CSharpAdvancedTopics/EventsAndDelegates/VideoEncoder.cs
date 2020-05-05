using System;
using System.Threading;

namespace EventsAndDelegates
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }
    public class VideoEncoder
    {
        // 1- Define a delegate
        // 2- Define an event based on that delagete
        // 3- Raise the event

        // 1- Define a delegate
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args); // convention in .net, first parameter of the event handl to be an obj, also the name to end with EventHandler

        // 2- Define an event based on that delagete
        public event VideoEncodedEventHandler VideoEncoded; // convention the tense of the verb speaks about the timeframe the event happened, or is happening "Video encoding"

        // we can use the inbuild EventHandler instead of the above 2 lines
        // public event EventHandler<VideoEventArgs> VideoEncoded;
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        // 3- Raise the event
        protected virtual void OnVideoEncoded(Video video) // convention is that your event publisher methods are protected virtual void and their name starts with On + "the name of the event"
        {
            if (VideoEncoded != null)
            {
                VideoEncoded(this, new VideoEventArgs() { Video = video });
            }
        }
    }
}
