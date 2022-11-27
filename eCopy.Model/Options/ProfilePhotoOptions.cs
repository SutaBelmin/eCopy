﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Model.Options
{
    public class ProfilePhotoOptions
    {
        public string Path { get; set; }
        public string[] SupportedContentTypes { get; set; }
        public string[] SupportedExtensions { get; set; }
        public int MaxSize { get; set; }
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }
    }
}