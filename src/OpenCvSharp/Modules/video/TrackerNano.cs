using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Internal;

namespace OpenCvSharp;
/// <summary>
/// the Nano tracker is a super lightweight dnn-based general object tracking.
/// Nano tracker is much faster and extremely lightweight due to special model structure, 
/// the whole model size is about 1.9 MB.Nano tracker needs two models: one for feature extraction(backbone) and 
/// the another for localization(neckhead). 
/// Model download link: https://github.com/HonglinChu/SiamTrackers/tree/master/NanoTrack/models/nanotrackv2 
/// Original repo is here: https://github.com/HonglinChu/NanoTrack Author: HongLinChu, 1628464345@qq.com
/// </summary>
public class TrackerNano : Tracker
{
    /// <summary>
    /// protected constructor
    /// </summary>
    /// <param name="p"></param>
    protected TrackerNano(IntPtr p)
        : base(new Ptr(p))
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <returns></returns>
    public static TrackerNano Create(string backbone_onnx_path,string neckhead_onnx_path)
    {
        NativeMethods.HandleException(
            NativeMethods.video_TrackerNano_create(backbone_onnx_path,neckhead_onnx_path, out var p));
        return new TrackerNano(p);
    }

    /// <summary>
    /// get the tracking score
    /// </summary>
    /// <returns></returns>
    public float GetTrackingScore()
    {
        NativeMethods.HandleException(
            NativeMethods.video_TrackerNano_GetTrackingScore(ptr,out var score));
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
                NativeMethods.video_Ptr_TrackerNano_get(ptr, out var ret));
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

#pragma warning disable CA1034
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Params
    {
    }
}
