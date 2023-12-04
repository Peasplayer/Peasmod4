﻿using System;
using System.IO;
using System.Reflection;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Reactor.Utilities.Extensions;
using UnityEngine;

namespace Peasmod4;

public class Utility
{
    public class StringColor
    {
        public const string Reset = "<color=#ffffffff>";
        public const string White = "<color=#ffffffff>";
        public const string Black = "<color=#000000ff>";
        public const string Red = "<color=#ff0000ff>";
        public const string Green = "<color=#169116ff>";
        public const string Blue = "<color=#0400ffff>";
        public const string Yellow = "<color=#f5e90cff>";
        public const string Purple = "<color=#a600ffff>";
        public const string Cyan = "<color=#00fff2ff>";
        public const string Pink = "<color=#e34dd4ff>";
        public const string Orange = "<color=#ff8c00ff>";
        public const string Brown = "<color=#8c5108ff>";
        public const string Lime = "<color=#1eff00ff>";
    }
    
    public static Sprite CreateSprite(string image, float pixelsPerUnit = 128f)
    {
        Texture2D tex = new Texture2D(0, 0, TextureFormat.RGBA32, false)
        {
            wrapMode = TextureWrapMode.Clamp
        };
        Stream myStream = Assembly.GetCallingAssembly().GetManifestResourceStream(image);
        byte[] data = myStream.ReadFully();
        ImageConversion.LoadImage(tex, data, false);
        var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f),
            pixelsPerUnit);
        sprite.DontDestroy();
        return sprite;
    }
}