
using System.Diagnostics;
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
        
        // ETHZ is Eidgenössische Technische Hochschule Zürich, in Deutsch
        // https://data.vision.ee.ethz.ch/cvl/aess/cvpr2008/seq03-img-left.tar.gz
        // This video could be research data and it may not allow to use commercial use. 
        // This test can not track person perfectly but it is enough to test whether unit test works.

        // This rect indicates person who be captured in first frame
        var bb = new Rect(286, 146, 70, 180);

        // If you want to save markers image, you must change the following values.
        const string path = @"_data/image/ETHZ/seq03-img-left";

        foreach (var i in Enumerable.Range(0, 21))
        {
            var file = $"image_{i:D8}_0.png";
            var dst_file = $"image_{i:D8}_1.png";

            using var mat = new Mat(Path.Combine(path, file));
            if (i == 0)
            {
                tracker.Init(mat, bb);
            } else
            {
                tracker.Update(mat, ref bb);
                //output test message

                 tracker.GetTrackingScore());
            }
        }
    }
}
