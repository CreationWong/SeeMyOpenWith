using System;

namespace SeeMyOpenWith
{
    partial class Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage = new System.Windows.Forms.TabPage();
            this.listViewReg = new System.Windows.Forms.ListView();
            this.NameReg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExplainReg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CommandReg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripRegList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemRevise = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDel = new System.Windows.Forms.ToolStripMenuItem();
            this.panel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage.SuspendLayout();
            this.contextMenuStripRegList.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.tabControl);
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1618, 790);
            this.panel.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage);
            this.tabControl.ItemSize = new System.Drawing.Size(80, 25);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1602, 786);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.listViewReg);
            this.tabPage.Location = new System.Drawing.Point(4, 29);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(1594, 753);
            this.tabPage.TabIndex = 0;
            this.tabPage.Text = "编辑";
            this.tabPage.UseVisualStyleBackColor = true;
            // 
            // listViewReg
            // 
            this.listViewReg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewReg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameReg,
            this.ExplainReg,
            this.CommandReg});
            this.listViewReg.ContextMenuStrip = this.contextMenuStripRegList;
            this.listViewReg.HideSelection = false;
            this.listViewReg.Location = new System.Drawing.Point(3, 3);
            this.listViewReg.Name = "listViewReg";
            this.listViewReg.Size = new System.Drawing.Size(1585, 744);
            this.listViewReg.TabIndex = 0;
            this.listViewReg.UseCompatibleStateImageBehavior = false;
            this.listViewReg.View = System.Windows.Forms.View.Details;
            // 
            // NameReg
            // 
            this.NameReg.Text = "程序";
            this.NameReg.Width = 200;
            // 
            // ExplainReg
            // 
            this.ExplainReg.Text = "说明";
            this.ExplainReg.Width = 200;
            // 
            // CommandReg
            // 
            this.CommandReg.Text = "命令";
            this.CommandReg.Width = 350;
            // 
            // contextMenuStripRegList
            // 
            this.contextMenuStripRegList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripRegList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemRevise,
            this.ToolStripMenuItemDel});
            this.contextMenuStripRegList.Name = "contextMenuStripRegList";
            this.contextMenuStripRegList.Size = new System.Drawing.Size(211, 80);
            // 
            // ToolStripMenuItemRevise
            // 
            this.ToolStripMenuItemRevise.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemCommand});
            this.ToolStripMenuItemRevise.Enabled = false;
            this.ToolStripMenuItemRevise.Name = "ToolStripMenuItemRevise";
            this.ToolStripMenuItemRevise.Size = new System.Drawing.Size(210, 24);
            this.ToolStripMenuItemRevise.Text = "修改";
            // 
            // ToolStripMenuItemCommand
            // 
            this.ToolStripMenuItemCommand.Name = "ToolStripMenuItemCommand";
            this.ToolStripMenuItemCommand.Size = new System.Drawing.Size(122, 26);
            this.ToolStripMenuItemCommand.Text = "命令";
            // 
            // ToolStripMenuItemDel
            // 
            this.ToolStripMenuItemDel.Name = "ToolStripMenuItemDel";
            this.ToolStripMenuItemDel.Size = new System.Drawing.Size(210, 24);
            this.ToolStripMenuItemDel.Text = "删除";
            this.ToolStripMenuItemDel.Click += new System.EventHandler(this.ToolStripMenuItemDel_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1642, 814);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form";
            this.Text = "SeeMyOpenWith";
            this.Load += new System.EventHandler(this.Form_Load);
            this.panel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage.ResumeLayout(false);
            this.contextMenuStripRegList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRegList;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemRevise;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCommand;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage;
        private System.Windows.Forms.ListView listViewReg;
        private System.Windows.Forms.ColumnHeader NameReg;
        private System.Windows.Forms.ColumnHeader ExplainReg;
        private System.Windows.Forms.ColumnHeader CommandReg;
    }
}

