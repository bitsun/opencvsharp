using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp;
public class TrackerVit : Tracker
{
    protected TrackerVit(IntPtr p)
        : base(new Ptr(p))
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <returns></returns>
    public static TrackerVit Create(string onnx_file_path)
    {
        NativeMethods.HandleException(
            NativeMethods.video_TrackerVit_create(onnx_file_path, out var p));
        return new TrackerVit(p);
    }

    /// <summary>
    /// get the tracking score
    /// </summary>
    /// <returns></returns>
    public float GetTrackingScore()
    {
        NativeMethods.HandleException(
            NativeMethods.video_TrackerVit_GetTrackingScore(ptr, out var score));
        return score;
    }
    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.video_Ptr_TrackerVit_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.video_Ptr_TrackerNano_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
