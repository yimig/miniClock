using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace miniClockT2.Utils
{
    class LocationSettings
    {
        public LocationSettings()
        {
            
        }

        public LocationSettings(int horizontal, int vertical, int size)
        {
            this.Horizontal = horizontal;
            this.Vertical = vertical;
            this.Size = size;
        }

        [JsonProperty("horizontal")] public int Horizontal;

        [JsonProperty("vertical")] public int Vertical;

        [JsonProperty("size")] public int Size;

    }

    class StyleSettings
    {
        public StyleSettings()
        {

        }

        public StyleSettings(int opacity, Font font, Color nowColor, BreakQueue<Color> bq)
        {
            this.Opacity = opacity;
            SetFont(font);
            this.NowColor=new JsonColor(nowColor);
            SetCacheColors(bq);
        }

        public void SetFont(Font font)
        {
            this.FontFamilyName = font.FontFamily.Name;
            this.FontSize = (int) font.Size;
        }

        public void SetCacheColors(BreakQueue<Color> bq)
        {
            CacheColors=new List<JsonColor>();
            for (int i = bq.Length - 1; i >= 0; i--)
            {
                CacheColors.Add(new JsonColor(bq[i]));
            }
        }

        public Font GetFont()
        {
            return new Font(new FontFamily(FontFamilyName),FontSize);
        }

        public BreakQueue<Color> GetCacheColors()
        {
            var bq=new BreakQueue<Color>(5);
            foreach (var jsonColor in CacheColors)
            {
                bq.Enqueue(jsonColor.GetColor());
            }

            return bq;
        }

        [JsonProperty("fontSize")] public int FontSize;

        [JsonProperty("opacity")] public int Opacity;

        [JsonProperty("font")] public string FontFamilyName;

        [JsonProperty("color")] public JsonColor NowColor;

        [JsonProperty("cacheColors")] public List<JsonColor> CacheColors;

    }

    class CommonSettings
    {
        public CommonSettings()
        {

        }

        public CommonSettings(bool bootWithWindows)
        {
            BootWithWindows = bootWithWindows;
        }


        [JsonProperty("bootWithWindows")] public bool BootWithWindows;

    }

    class JsonColor
    {
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

        [JsonProperty("a")] public int A;

        [JsonProperty("r")] public int R;

        [JsonProperty("g")] public int G;

        [JsonProperty("b")] public int B;

    }

    class Settings
    {
        public Settings()
        {

        }

        public Settings(LocationSettings location, StyleSettings style,CommonSettings common)
        {
            Location = location;
            Style = style;
            Common = common;
        }

        [JsonProperty("location")] public LocationSettings Location;

        [JsonProperty("style")] public StyleSettings Style;

        [JsonProperty("common")] public CommonSettings Common;


    }
}
