
using OpenCvSharp.Modules.video;
using OpenCvSharp.Tests.Tracking;
using Xunit;

namespace OpenCvSharp.Tests.Tracking;
public class TrackerNanoTest : TrackerTestBase
{
    [Fact]
    public void Init()
    {
        using var tracker = TrackerNano.Create("D:\\code\\opencvsharp\\test\\OpenCvSharp.Tests\\_data\\model\\nanotrack_backbone_sim.onnx", "D:\\code\\opencvsharp\\test\\OpenCvSharp.Tests\\_data\\model\\nanotrack_head_sim.onnx");
        InitBase(tracker);
    }

    [Fact]
    public void Update()
    {
        using var tracker = TrackerNano.Create("./_data/model/nanotrack_backbone_sim.onnx", "./_data/model/nanotrack_head_sim.onnx");
        UpdateBase(tracker);
    }
}
