using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using Color = System.Windows.Media.Color;

namespace miniClock.Utils
{
    internal class LocationSettings
    {
        [JsonProperty("horizontal")] public int Horizontal;

        [JsonProperty("size")] public int Size;

        [JsonProperty("vertical")] public int Vertical;

        public LocationSettings()
        {
        }

        public LocationSettings(int horizontal, int vertical, int size)
        {
            Horizontal = horizontal;
            Vertical = vertical;
            Size = size;
        }
    }

    internal class StyleSettings
    {
        [JsonProperty("cacheColors")] public List<JsonColor> CacheColors;

        [JsonProperty("font")] public string FontFamilyName;

        [JsonProperty("fontSize")] public int FontSize;

        [JsonProperty("color")] public JsonColor NowColor;

        [JsonProperty("opacity")] public int Opacity;

        public StyleSettings()
        {
        }

        public StyleSettings(int opacity, Font font, Color nowColor, BreakQueue<Color> bq)
        {
            Opacity = opacity;
            SetFont(font);
            NowColor = new JsonColor(nowColor);
            SetCacheColors(bq);
        }

        public void SetFont(Font font)
        {
            FontFamilyName = font.FontFamily.Name;
            FontSize = (int) font.Size;
        }

        public void SetCacheColors(BreakQueue<Color> bq)
        {
            CacheColors = new List<JsonColor>();
            for (var i = bq.Length - 1; i >= 0; i--) CacheColors.Add(new JsonColor(bq[i]));
        }

        public Font GetFont()
        {
            return new Font(new FontFamily(FontFamilyName), FontSize);
        }

        public BreakQueue<Color> GetCacheColors()
        {
            var bq = new BreakQueue<Color>(5);
            foreach (var jsonColor in CacheColors) bq.Enqueue(jsonColor.GetColor());

            return bq;
        }
    }

    internal class CommonSettings
    {
        [JsonProperty("bootWithWindows")] public bool BootWithWindows;

        public CommonSettings()
        {
        }

        public CommonSettings(bool bootWithWindows)
        {
            BootWithWindows = bootWithWindows;
        }
    }

    internal class JsonColor
    {
        [JsonProperty("a")] public byte A;

        [JsonProperty("b")] public byte B;

        [JsonProperty("g")] public byte G;

        [JsonProperty("r")] public byte R;

        public JsonColor()
        {
        }

        public JsonColor(Color color)
        {
            A = color.A;
            R = color.R;
            G = color.G;
            B = color.B;
        }

        public Color GetColor()
        {
            return Color.FromArgb(A, R, G, B);
        }
    }

    internal class Settings
    {
        [JsonProperty("common")] public CommonSettings Common;

        [JsonProperty("location")] public LocationSettings Location;

        [JsonProperty("style")] public StyleSettings Style;

        public Settings()
        {
        }

        public Settings(LocationSettings location, StyleSettings style, CommonSettings common)
        {
            Location = location;
            Style = style;
            Common = common;
        }
    }
}