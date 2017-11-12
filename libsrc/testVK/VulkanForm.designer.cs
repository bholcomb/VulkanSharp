namespace VulkanTest
{
    partial class VulkanForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // VulkanForm
            // 
            this.ClientSize = new System.Drawing.Size(799, 521);
            this.Name = "VulkanForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VulkanForm_FormClosing);
            this.Load += new System.EventHandler(this.VulkanForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VulkanForm_Paint);
            this.ResumeLayout(false);

        }
        #endregion
    }
}