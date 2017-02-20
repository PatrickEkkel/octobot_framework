using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// Author: https://github.com/jasonpang/Interceptor
namespace Interceptor
{
    public class MousePressedEventArgs : EventArgs
    {
        public MouseState State { get; set; }
        public bool Handled { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public short Rolling { get; set; }
    }
}
