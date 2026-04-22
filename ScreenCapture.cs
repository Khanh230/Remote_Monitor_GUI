using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Encoder = System.Drawing.Imaging.Encoder;

namespace RemoteMonitor_GUI;

public static class ScreenCapture
{
    [DllImport("user32.dll")]
    private static extern int GetSystemMetrics(int nIndex);

    public static byte[] CaptureScreen(int quality = 60)
    {
        int width = GetSystemMetrics(0);
        int height = GetSystemMetrics(1);
        using var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
        using var graphics = Graphics.FromImage(bitmap);
        graphics.CopyFromScreen(0, 0, 0, 0, new Size(width, height));
        using var ms = new MemoryStream();
        var encoderParams = new EncoderParameters(1);
        encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, (long)quality);
        var jpegCodec = ImageCodecInfo.GetImageEncoders()
            .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
        bitmap.Save(ms, jpegCodec, encoderParams);
        return ms.ToArray();
    }
}