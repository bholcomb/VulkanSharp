using System;
using System.Timers;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace VulkanTest
{
	public partial class VulkanForm : Form
	{
		VulkanApp vulkanApp;
      System.Timers.Timer timer;

		public VulkanForm()
		{
			InitializeComponent();
         timer = new System.Timers.Timer(10.0);
         timer.Elapsed += timerElapsed;
         timer.Start();

			vulkanApp = new VulkanApp();
		}

      private void timerElapsed(object sender, ElapsedEventArgs e)
      {
         this.Invalidate();
      }


      private void VulkanForm_Load(object sender, EventArgs e)
      {
         vulkanApp.init(Util.GetModuleHandle(null), this.Handle);
      }

		private void VulkanForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			vulkanApp.cleanup();
		}

		private void VulkanForm_Paint(object sender, PaintEventArgs e)
		{
			vulkanApp.drawFrame();
		}
    }

    public static class Util
	{
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

      [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
      public static extern IntPtr memcpy(IntPtr dest, IntPtr src, int count);
   }

}
