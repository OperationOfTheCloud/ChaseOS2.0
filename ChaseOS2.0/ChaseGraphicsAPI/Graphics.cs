﻿using Sys = Cosmos.System;
using Cosmos.System;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Cosmos.Core;
using Cosmos.HAL;

namespace ChaseOS2._0.ChaseGraphicsAPI
{
    public class Graphics
    {
        public static Byte[] defaultFontData = new Byte[] { 0x03, 0x00, 0xC0, 0x01, 0xC0, 0x01, 0xC0, 0x03, 0xC0, 0x06, 0x40, 0x04, 0x40, 0x8C, 0x40, 0xC8, 0x46, 0x78, 0x4C, 0x1F, 0xF8, 0x31, 0xC0, 0x20, 0x20, 0x60, 0x20, 0x40, 0x20, 0xC0, 0x38, 0x80, 0x0C, 0xFF, 0x00, 0x81, 0xE0, 0x80, 0x30, 0x80, 0x18, 0x80, 0x08, 0x80, 0x08, 0x80, 0x18, 0x80, 0x10, 0x80, 0x70, 0xBF, 0xF8, 0x80, 0x0C, 0x80, 0x04, 0x80, 0x0C, 0x80, 0x18, 0x80, 0x30, 0xFF, 0xE0, 0x0F, 0xF0, 0x38, 0x00, 0x20, 0x00, 0x40, 0x00, 0xC0, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0xC0, 0x00, 0x60, 0x00, 0x3F, 0xF8, 0xFF, 0x00, 0x81, 0xC0, 0x80, 0x60, 0x80, 0x20, 0x80, 0x20, 0x80, 0x20, 0x80, 0x20, 0x80, 0x20, 0x80, 0x20, 0x80, 0x20, 0x80, 0x20, 0x80, 0xE0, 0x81, 0x80, 0x83, 0x00, 0x9E, 0x00, 0xF0, 0x00, 0xFF, 0xF0, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0xFF, 0x80, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0xFF, 0xF0, 0xFF, 0xF8, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0xFE, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x03, 0xFC, 0x06, 0x00, 0x0C, 0x00, 0x18, 0x00, 0x10, 0x00, 0x30, 0x00, 0x20, 0x00, 0x20, 0x00, 0x60, 0xFE, 0x40, 0x18, 0x40, 0x08, 0x40, 0x08, 0x60, 0x18, 0x20, 0x30, 0x3D, 0xE0, 0x07, 0x00, 0x40, 0x20, 0x40, 0x20, 0x40, 0x20, 0x40, 0x20, 0x40, 0x20, 0x40, 0x20, 0x40, 0x20, 0x40, 0x20, 0x40, 0x20, 0x7F, 0xE0, 0x40, 0x20, 0x40, 0x20, 0x40, 0x20, 0x40, 0x20, 0x40, 0x20, 0x40, 0x20, 0x3F, 0xF0, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x3F, 0xE0, 0x3F, 0xFC, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x10, 0x80, 0x10, 0x80, 0x18, 0x80, 0x0F, 0x80, 0x08, 0x00, 0x08, 0x10, 0x08, 0x30, 0x08, 0x60, 0x08, 0xC0, 0x09, 0x80, 0x09, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x09, 0x80, 0x08, 0xC0, 0x08, 0x40, 0x08, 0x60, 0x08, 0x20, 0x08, 0x30, 0x08, 0x10, 0x20, 0x00, 0x20, 0x00, 0x20, 0x00, 0x20, 0x00, 0x20, 0x00, 0x20, 0x00, 0x20, 0x00, 0x20, 0x00, 0x20, 0x00, 0x20, 0x00, 0x20, 0x00, 0x20, 0x00, 0x20, 0x00, 0x20, 0x00, 0x20, 0x00, 0x3F, 0xE0, 0x00, 0x00, 0x00, 0x30, 0x06, 0x30, 0x06, 0x70, 0x0A, 0x50, 0x0A, 0x50, 0x1B, 0x50, 0x11, 0xD8, 0x11, 0x88, 0x30, 0x08, 0x20, 0x08, 0x20, 0x08, 0x40, 0x08, 0x40, 0x08, 0xC0, 0x08, 0x80, 0x08, 0x30, 0x04, 0x38, 0x04, 0x28, 0x04, 0x2C, 0x04, 0x24, 0x04, 0x26, 0x04, 0x23, 0x04, 0x21, 0x04, 0x21, 0x84, 0x20, 0xC4, 0x20, 0x64, 0x20, 0x24, 0x20, 0x34, 0x20, 0x1C, 0x20, 0x0C, 0x20, 0x04, 0x07, 0xF8, 0x1C, 0x0C, 0x10, 0x06, 0x30, 0x03, 0x20, 0x01, 0x20, 0x01, 0x20, 0x01, 0x20, 0x01, 0x20, 0x01, 0x20, 0x03, 0x20, 0x02, 0x20, 0x06, 0x20, 0x0C, 0x30, 0x08, 0x18, 0x18, 0x0F, 0xF0, 0x07, 0xE0, 0x04, 0x30, 0x04, 0x18, 0x04, 0x08, 0x04, 0x08, 0x04, 0x08, 0x04, 0x18, 0x07, 0x70, 0x05, 0xC0, 0x04, 0x00, 0x04, 0x00, 0x04, 0x00, 0x04, 0x00, 0x04, 0x00, 0x04, 0x00, 0x04, 0x00, 0x03, 0xC0, 0x0E, 0x60, 0x18, 0x30, 0x30, 0x10, 0x20, 0x10, 0x60, 0x18, 0x40, 0x08, 0x20, 0x08, 0x20, 0x98, 0x20, 0xF0, 0x30, 0x30, 0x18, 0x38, 0x0F, 0xEC, 0x00, 0x06, 0x00, 0x02, 0x00, 0x00, 0x3F, 0x80, 0x20, 0xE0, 0x20, 0x30, 0x20, 0x10, 0x20, 0x10, 0x20, 0x30, 0x20, 0x60, 0x3F, 0xC0, 0x20, 0x70, 0x20, 0x10, 0x20, 0x08, 0x20, 0x08, 0x20, 0x08, 0x20, 0x0C, 0x20, 0x04, 0x20, 0x04, 0x03, 0xE0, 0x06, 0x00, 0x0C, 0x00, 0x08, 0x00, 0x0C, 0x00, 0x06, 0x00, 0x03, 0x80, 0x00, 0xE0, 0x00, 0x30, 0x20, 0x18, 0x20, 0x08, 0x20, 0x18, 0x38, 0x30, 0x0F, 0xE0, 0x00, 0x00, 0x00, 0x00, 0x7F, 0xFE, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x40, 0x08, 0x40, 0x08, 0x40, 0x08, 0x40, 0x08, 0x60, 0x08, 0x20, 0x0C, 0x20, 0x04, 0x20, 0x04, 0x20, 0x04, 0x30, 0x04, 0x10, 0x04, 0x18, 0x04, 0x0C, 0x04, 0x06, 0x0C, 0x03, 0x98, 0x00, 0xF0, 0x20, 0x04, 0x30, 0x0C, 0x10, 0x08, 0x08, 0x08, 0x0C, 0x08, 0x04, 0x18, 0x04, 0x10, 0x06, 0x10, 0x02, 0x10, 0x03, 0x10, 0x01, 0x10, 0x01, 0x30, 0x01, 0xA0, 0x00, 0xA0, 0x00, 0xC0, 0x00, 0xC0, 0x20, 0x01, 0x20, 0x01, 0x20, 0x03, 0x30, 0x02, 0x10, 0x02, 0x10, 0x02, 0x18, 0x02, 0x08, 0x22, 0x08, 0x22, 0x08, 0x36, 0x06, 0x74, 0x02, 0x54, 0x03, 0x54, 0x01, 0xDC, 0x00, 0xCC, 0x00, 0x88, 0x00, 0x30, 0x40, 0x60, 0x70, 0xC0, 0x18, 0x80, 0x0D, 0x80, 0x07, 0x00, 0x03, 0x00, 0x07, 0x00, 0x05, 0x80, 0x0C, 0x80, 0x18, 0x40, 0x10, 0x60, 0x30, 0x20, 0x60, 0x30, 0x40, 0x10, 0xC0, 0x10, 0x08, 0x30, 0x08, 0x60, 0x0C, 0x40, 0x04, 0xC0, 0x06, 0x80, 0x02, 0x80, 0x03, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0xFF, 0xC0, 0x00, 0x7C, 0x00, 0x0C, 0x00, 0x18, 0x00, 0x70, 0x00, 0xC0, 0x01, 0x80, 0x03, 0x00, 0x06, 0x00, 0x0C, 0x00, 0x38, 0x00, 0x60, 0x00, 0x40, 0x00, 0xC0, 0x00, 0xC1, 0xFE, 0x7F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0xC0, 0x0E, 0x40, 0x18, 0x40, 0x30, 0x40, 0x60, 0x40, 0x40, 0xC0, 0x40, 0xC0, 0x40, 0xC0, 0x41, 0xE0, 0x43, 0x20, 0x46, 0x30, 0x7C, 0x18, 0x00, 0x00, 0x00, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x1F, 0x80, 0x18, 0xC0, 0x10, 0x40, 0x10, 0x40, 0x10, 0x40, 0x10, 0xC0, 0x1F, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x38, 0x00, 0x60, 0x00, 0x40, 0x00, 0xC0, 0x00, 0x80, 0x00, 0x80, 0x00, 0xC0, 0x00, 0x40, 0x00, 0x61, 0x80, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x0E, 0x80, 0x39, 0x80, 0x21, 0x80, 0x41, 0x00, 0x41, 0x80, 0x41, 0x80, 0x43, 0x80, 0x7E, 0xC0, 0x00, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1F, 0xC0, 0x30, 0x40, 0x60, 0xC0, 0x5F, 0x80, 0x60, 0x00, 0x30, 0x00, 0x1C, 0x60, 0x07, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x07, 0x80, 0x04, 0x80, 0x04, 0x00, 0x08, 0x00, 0x0C, 0x00, 0x04, 0x00, 0x04, 0x00, 0x04, 0x00, 0x3F, 0xC0, 0x04, 0x00, 0x04, 0x00, 0x04, 0x00, 0x0C, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x80, 0x0C, 0x40, 0x18, 0x40, 0x10, 0xE0, 0x11, 0xA0, 0x1F, 0x20, 0x00, 0x20, 0x00, 0x20, 0x00, 0x20, 0x20, 0x20, 0x3F, 0xE0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x04, 0x00, 0x04, 0x00, 0x04, 0x00, 0x04, 0x00, 0x0C, 0x00, 0x0F, 0x80, 0x0C, 0x80, 0x0C, 0xC0, 0x0C, 0x40, 0x08, 0x40, 0x08, 0x40, 0x08, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00, 0x00, 0x40, 0x00, 0x40, 0x00, 0x40, 0x00, 0x40, 0x00, 0x40, 0x00, 0x40, 0x18, 0x40, 0x18, 0x40, 0x08, 0x40, 0x0C, 0xC0, 0x07, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x04, 0x00, 0x04, 0x00, 0x04, 0x40, 0x04, 0x40, 0x04, 0xC0, 0x04, 0x80, 0x07, 0x80, 0x07, 0x00, 0x05, 0x80, 0x04, 0xC0, 0x04, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x0D, 0xE0, 0x0F, 0x20, 0x13, 0x20, 0x12, 0x20, 0x10, 0x30, 0x10, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x00, 0x0D, 0x80, 0x08, 0x80, 0x08, 0x80, 0x18, 0x80, 0x10, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x80, 0x1C, 0xC0, 0x10, 0x40, 0x10, 0x40, 0x10, 0xC0, 0x11, 0x80, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x80, 0x02, 0xC0, 0x02, 0x40, 0x02, 0x40, 0x02, 0xC0, 0x03, 0x80, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x09, 0x00, 0x09, 0x00, 0x0F, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x40, 0x01, 0x80, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x80, 0x08, 0x40, 0x08, 0x40, 0x08, 0x40, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x80, 0x07, 0x00, 0x0C, 0x00, 0x0C, 0x00, 0x04, 0x00, 0x07, 0x00, 0x01, 0xC0, 0x0C, 0x60, 0x07, 0xE0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x07, 0xE0, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x08, 0x01, 0x18, 0x01, 0xF0, 0x00, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x0C, 0x00, 0x08, 0x40, 0x08, 0x40, 0x0C, 0x40, 0x04, 0x40, 0x06, 0xC0, 0x03, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0x20, 0x0C, 0x60, 0x06, 0x40, 0x02, 0x40, 0x03, 0xC0, 0x01, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x0C, 0x10, 0x18, 0x10, 0x10, 0x1B, 0x30, 0x0B, 0x60, 0x0F, 0xC0, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x18, 0xC0, 0x0D, 0x80, 0x07, 0x00, 0x0F, 0x00, 0x19, 0x80, 0x30, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x02, 0x40, 0x03, 0xC0, 0x01, 0x80, 0x03, 0x00, 0x06, 0x00, 0x0C, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0xC0, 0x00, 0x80, 0x03, 0x00, 0x06, 0x00, 0x1C, 0x00, 0x30, 0x00, 0x3F, 0xC0, 0x01, 0xE0, 0x03, 0x30, 0x06, 0x10, 0x08, 0x38, 0x18, 0x28, 0x10, 0x6C, 0x10, 0x44, 0x30, 0xC4, 0x21, 0x84, 0x21, 0x04, 0x23, 0x04, 0x22, 0x0C, 0x36, 0x08, 0x1C, 0x18, 0x0C, 0x30, 0x07, 0xE0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x01, 0x80, 0x03, 0x80, 0x02, 0x80, 0x06, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x07, 0xF0, 0x00, 0x00, 0x00, 0x00, 0x07, 0x80, 0x0C, 0x80, 0x08, 0xC0, 0x00, 0x40, 0x00, 0x40, 0x00, 0xC0, 0x00, 0x80, 0x01, 0x80, 0x03, 0x00, 0x06, 0x00, 0x0C, 0x00, 0x1F, 0xC0, 0x30, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x00, 0x61, 0xC0, 0x00, 0x40, 0x00, 0xC0, 0x03, 0x80, 0x03, 0x80, 0x00, 0xE0, 0x00, 0x20, 0x00, 0x20, 0x00, 0x20, 0x40, 0x60, 0x78, 0xC0, 0x0F, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x80, 0x03, 0x80, 0x02, 0x80, 0x06, 0x80, 0x04, 0xF8, 0x0F, 0x80, 0x08, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0xFC, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x03, 0xE0, 0x03, 0x30, 0x00, 0x18, 0x08, 0x08, 0x0C, 0x04, 0x07, 0x0C, 0x01, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x20, 0x01, 0xE0, 0x03, 0x00, 0x06, 0x00, 0x04, 0x00, 0x0C, 0x00, 0x08, 0x00, 0x09, 0xC0, 0x0B, 0x30, 0x0A, 0x10, 0x0C, 0x30, 0x07, 0x60, 0x01, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0xE0, 0x0C, 0x20, 0x00, 0x60, 0x00, 0x40, 0x01, 0xE0, 0x00, 0x80, 0x01, 0x80, 0x01, 0x00, 0x03, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x7D, 0xC0, 0x70, 0x40, 0x1C, 0x40, 0x07, 0x80, 0x07, 0xE0, 0x0C, 0x30, 0x18, 0x10, 0x10, 0x70, 0x1F, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0xE0, 0x0E, 0x40, 0x18, 0xC0, 0x10, 0xC0, 0x11, 0xC0, 0x1F, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0xC0, 0x18, 0x40, 0x30, 0x00, 0x63, 0x00, 0x47, 0x80, 0x4D, 0xC0, 0x4D, 0x60, 0x47, 0x20, 0x60, 0x60, 0x20, 0xC0, 0x19, 0x80, 0x0F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x20, 0x00, 0x60, 0x0C, 0xC8, 0x07, 0x98, 0x03, 0x90, 0x46, 0xF0, 0x6C, 0x70, 0x38, 0xD8, 0x3C, 0x8C, 0x67, 0x84, 0xC3, 0x80, 0x86, 0xE0, 0x0C, 0x20, 0x08, 0x00, 0x00, 0x00, 0x02, 0x00, 0x07, 0xE0, 0x0E, 0x20, 0x0A, 0x00, 0x0E, 0x00, 0x07, 0x80, 0x02, 0xC0, 0x02, 0x60, 0x42, 0x30, 0x42, 0x10, 0x42, 0x10, 0x62, 0x20, 0x22, 0x60, 0x1B, 0xC0, 0x0F, 0x00, 0x02, 0x00, 0x18, 0x00, 0x38, 0x20, 0x68, 0x60, 0xD8, 0xC0, 0x91, 0x80, 0xF1, 0x00, 0x03, 0x00, 0x06, 0x00, 0x0C, 0x78, 0x18, 0xCC, 0x10, 0x84, 0x30, 0x84, 0x60, 0xC4, 0xC0, 0x78, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x07, 0x80, 0x0C, 0x80, 0x08, 0xC0, 0x18, 0x40, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x3F, 0xFC, 0x1C, 0x80, 0x06, 0xC0, 0x02, 0x40, 0x03, 0xC0, 0x01, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x30, 0x04, 0x60, 0x26, 0xC0, 0x3B, 0x80, 0x0F, 0xF8, 0x7F, 0x80, 0x0E, 0xC0, 0x1A, 0x60, 0x32, 0x30, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x0E, 0x00, 0x18, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x10, 0x00, 0x18, 0x00, 0x0C, 0x00, 0x07, 0x00, 0x00, 0xF0, 0x00, 0x18, 0x00, 0x08, 0x00, 0x0C, 0x00, 0x04, 0x00, 0x04, 0x00, 0x04, 0x00, 0x0C, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0x18, 0x00, 0x30, 0x00, 0xE0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7F, 0xFE, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1F, 0xF0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1F, 0xF0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x07, 0xF0, 0x00, 0x80, 0x00, 0x80, 0x00, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0xC0, 0x03, 0x00, 0x06, 0x00, 0x04, 0x00, 0x0C, 0x00, 0x70, 0x00, 0x80, 0x00, 0x70, 0x00, 0x0C, 0x00, 0x04, 0x00, 0x06, 0x00, 0x03, 0x00, 0x01, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0xF0, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0x06, 0x00, 0x01, 0x00, 0x06, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0x08, 0x00, 0xF0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x20, 0x04, 0x20, 0x04, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x02, 0x00, 0x0E, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xE0, 0x03, 0x80, 0x0E, 0x00, 0x38, 0x00, 0x60, 0x00, 0x78, 0x00, 0x0F, 0xC0, 0x00, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x01, 0x00, 0x01, 0xE0, 0x00, 0x18, 0x00, 0x18, 0x00, 0x30, 0x00, 0x60, 0x00, 0xC0, 0x01, 0x80, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x18, 0x00, 0x30, 0x00, 0x60, 0x00, 0xC0, 0x01, 0x80, 0x03, 0x00, 0x06, 0x00, 0x0C, 0x00, 0x08, 0x00, 0x18, 0x00, 0x30, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0xC0, 0x1E, 0x60, 0x10, 0x20, 0x00, 0x60, 0x00, 0x40, 0x00, 0xC0, 0x00, 0x80, 0x01, 0x80, 0x03, 0x00, 0x02, 0x00, 0x02, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x20, 0x00, 0x20, 0x00, 0x10, 0x00, 0x18, 0x00, 0x0C, 0x00, 0x04, 0x00, 0x02, 0x00, 0x03, 0x00, 0x01, 0x80, 0x00, 0x80, 0x00, 0xC0, 0x00, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x10, 0x00, 0x1C, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x3E, 0x18, 0x63, 0x10, 0xC1, 0xB0, 0x80, 0xE0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        public static bool THE;
        public Canvas canvas;
        private Pen pen;
        private int Cache;
        private TabHandler tabHandler;
        private WindowComponent window;
        private MouseState mouseState;
        public static MouseState prevmouseState;
        private UInt32 px, py;
        private List<Tuple<Sys.Graphics.Point, Color>> savedPixels;
        public static bool ART;
        public int usage = 0;
        public Graphics()
        {


            canvas = FullScreenCanvas.GetFullScreenCanvas();
            
            int aX = 220;
            int aY = 290;
            int bX = 320;
            int bY = 340;
            int cX = 420;
            int cY = 290;
            int dX = 320;
            int dY = 240;
            int eX = aX;
            int eY = aY - 100;
            int fX = bX;
            int fY = bY - 100;
            int gX = cX;
            int gY = cY - 100;
            int hX = dX;
            int hY = dY - 100;
            Pen pen = new Pen(Color.Red);

            for (int i = 0; i < 200; i++)
            {
                if (i < 100)
                {
                    canvas.Clear(Color.Black);
                    aX++;
                    bX++;
                    cX--;
                    dX--;
                    if (i % 2 == 0)
                    {
                        aY++;
                        bY--;
                        cY--;
                        dY++;
                    }

                    eY = aY - 100;
                    fY = bY - 100;
                    gY = cY - 100;
                    hY = dY - 100;
                    eX = aX;
                    fX = bX;
                    gX = cX;
                    hX = dX;

                    canvas.DrawLine(pen, eX, eY, aX, aY);
                    canvas.DrawLine(pen, fX, fY, bX, bY);
                    canvas.DrawLine(pen, gX, gY, cX, cY);
                    canvas.DrawLine(pen, hX, hY, dX, dY);

                    canvas.DrawLine(pen, eX, eY, fX, fY);
                    canvas.DrawLine(pen, fX, fY, gX, gY);
                    canvas.DrawLine(pen, gX, gY, hX, hY);
                    canvas.DrawLine(pen, hX, hY, eX, eY);

                    canvas.DrawLine(pen, bX, bY, aX, aY);
                    canvas.DrawLine(pen, cX, cY, bX, bY);
                    canvas.DrawLine(pen, dX, dY, cX, cY);
                    canvas.DrawLine(pen, aX, aY, dX, dY);
                }

                else if (i >= 100)
                {
                    canvas.Clear(Color.Black);
                    aX--;
                    bX--;
                    cX++;
                    dX++;
                    if (i % 2 == 0)
                    {
                        aY--;
                        bY++;
                        cY++;
                        dY--;
                    }

                    eY = aY - 100;
                    fY = bY - 100;
                    gY = cY - 100;
                    hY = dY - 100;
                    eX = aX;
                    fX = bX;
                    gX = cX;
                    hX = dX;

                    canvas.DrawLine(pen, eX, eY, aX, aY);
                    canvas.DrawLine(pen, fX, fY, bX, bY);
                    canvas.DrawLine(pen, gX, gY, cX, cY);
                    canvas.DrawLine(pen, hX, hY, dX, dY);

                    canvas.DrawLine(pen, eX, eY, fX, fY);
                    canvas.DrawLine(pen, fX, fY, gX, gY);
                    canvas.DrawLine(pen, gX, gY, hX, hY);
                    canvas.DrawLine(pen, hX, hY, eX, eY);

                    canvas.DrawLine(pen, bX, bY, aX, aY);
                    canvas.DrawLine(pen, cX, cY, bX, bY);
                    canvas.DrawLine(pen, dX, dY, cX, cY);
                    canvas.DrawLine(pen, aX, aY, dX, dY);
                }
                
                
                pen = new Pen(Color.White);
                mouseState = MouseState.None;
                px = 3;
                py = 3;
                savedPixels = new List<Tuple<Sys.Graphics.Point, Color>>();
                
                MouseManager.ScreenHeight = (UInt32)canvas.Mode.Rows;
                MouseManager.ScreenWidth = (UInt32)canvas.Mode.Columns;

                if (THE == true)
                {
                    for (int i2 = 0; i <= 350; i2++)
                    {
                        canvas.DrawRectangle(pen, i2, i2, i2, i2);
                        pen.Color = Color.Blue;
                    }
                }
                pen.Color = Color.White;

            }
            tabHandler = new TabHandler(canvas);
            canvas.Clear(Color.Gray);
        }
        public void Button(int size, int x, int y, Pen draw)
        {
            for (int i = 0; i <= size; i++)
            {
                canvas.DrawRectangle(draw, x, y, i, i);
            }
        }

        public void MouseHandler()
        {

            px = MouseManager.X;
            py = MouseManager.Y;
            mouseState = MouseManager.MouseState;
            Sys.Graphics.Point[] points = new Sys.Graphics.Point[]
            {
                    new Sys.Graphics.Point((int)MouseManager.X+1, (int)MouseManager.Y+1),
                    new Sys.Graphics.Point((int)MouseManager.X+1, (int)MouseManager.Y+2),
                    new Sys.Graphics.Point((int)MouseManager.X+2, (int)MouseManager.Y+1),
                    new Sys.Graphics.Point((int)MouseManager.X+2, (int)MouseManager.Y+2),
            };
            foreach (Tuple<Sys.Graphics.Point, Color> pixelData in savedPixels)
            {
                canvas.DrawPoint(new Pen(pixelData.Item2), pixelData.Item1);
            }
            foreach (Sys.Graphics.Point p in points)
            {
                savedPixels.Add(new Tuple<Sys.Graphics.Point, Color>(p, canvas.GetPointColor(p.X, p.Y)));
                canvas.DrawPoint(pen, p);
                usage += 1;
                if (usage >= CPU.GetAmountOfRAM() * 5)
                {
                    canvas.Clear(Color.Gray);
                    savedPixels.Clear();
                    pen = new Pen(Color.White);
                    int rows = canvas.Mode.Rows;
                    int columns = canvas.Mode.Columns;
                    canvas.DrawRectangle(pen, 0, rows - 100, columns - 2, 99);
                    canvas.DrawRectangle(pen, 0, rows - 100, 100, 99);
                    canvas.DrawLine(pen, 25, rows - 90, 75, rows - 10);
                    foreach (Window window in Window.windows)
                    {
                        window.draw(canvas);
                    }
                    usage = 0;

                }
            }
            if (mouseState == MouseState.Left && prevmouseState == MouseState.Left)
            {
                Window.tryProcessTabLBDown((Int32)MouseManager.X, (Int32)MouseManager.Y, canvas);
                TabHandler.ProcessTabBar((Int32)MouseManager.X, (Int32)MouseManager.Y, canvas);
            }
            else if (mouseState == MouseState.None && prevmouseState == MouseState.Left)
            {
                Window.tryProcessTabLBUp((Int32)MouseManager.X, (Int32)MouseManager.Y, canvas);
            }

            pen.Color = Color.White;
            prevmouseState = mouseState;
        }
        public void ArtHandler()
        {
            px = MouseManager.X;
            py = MouseManager.Y;
            mouseState = MouseManager.MouseState;
            Sys.Graphics.Point[] points = new Sys.Graphics.Point[]
            {
                    new Sys.Graphics.Point((int)MouseManager.X+1, (int)MouseManager.Y+1),
                    new Sys.Graphics.Point((int)MouseManager.X+1, (int)MouseManager.Y+2),
                    new Sys.Graphics.Point((int)MouseManager.X+2, (int)MouseManager.Y+1),
                    new Sys.Graphics.Point((int)MouseManager.X+2, (int)MouseManager.Y+2),
            };
            foreach (Tuple<Sys.Graphics.Point, Color> pixelData in savedPixels)
            {
                canvas.DrawPoint(new Pen(pixelData.Item2), pixelData.Item1);
            }
            foreach (Sys.Graphics.Point p in points)
            {
                savedPixels.Add(new Tuple<Sys.Graphics.Point, Color>(p, canvas.GetPointColor(p.X, p.Y)));
                canvas.DrawPoint(pen, p);
            }
            if (mouseState == MouseState.Left && prevmouseState == MouseState.Left)
            {
                Window.tryProcessTabLBDown((Int32)MouseManager.X, (Int32)MouseManager.Y, canvas);
                TabHandler.ProcessTabBar((Int32)MouseManager.X, (Int32)MouseManager.Y, canvas);
            }
            else if (mouseState == MouseState.None && prevmouseState == MouseState.Left)
            {
                Window.tryProcessTabLBUp((Int32)MouseManager.X, (Int32)MouseManager.Y, canvas);
            }
            savedPixels.Clear();
            pen.Color = Color.White;
            prevmouseState = mouseState;
        }

        }

    }

