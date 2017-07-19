﻿using System;
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
	public static class Util
	{
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetModuleHandle(string lpModuleName);
	}

	public partial class VulkanForm : Form
	{
		VulkanApp vulkanApp;

		public VulkanForm()
		{
			InitializeComponent();

			vulkanApp = new VulkanApp();
		}

		private void VulkanForm_Load(object sender, EventArgs e)
		{
			vulkanApp.init(Util.GetModuleHandle(null), this.Handle);
		}

		private void VulkanForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			vulkanApp.shutdown();
		}
	}
}