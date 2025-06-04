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
            components = new System.ComponentModel.Container();
            panel = new System.Windows.Forms.Panel();
            tabControl = new System.Windows.Forms.TabControl();
            tabPage = new System.Windows.Forms.TabPage();
            listViewReg = new System.Windows.Forms.ListView();
            NameReg = new System.Windows.Forms.ColumnHeader();
            ExplainReg = new System.Windows.Forms.ColumnHeader();
            CommandReg = new System.Windows.Forms.ColumnHeader();
            contextMenuStripRegList = new System.Windows.Forms.ContextMenuStrip(components);
            ToolStripMenuItemRevise = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItemCommand = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItemDel = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemSearch = new System.Windows.Forms.ToolStripMenuItem();
            panel.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage.SuspendLayout();
            contextMenuStripRegList.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel.Controls.Add(tabControl);
            panel.Location = new System.Drawing.Point(5, 1);
            panel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel.Name = "panel";
            panel.Size = new System.Drawing.Size(1214, 781);
            panel.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControl.Controls.Add(tabPage);
            tabControl.ItemSize = new System.Drawing.Size(80, 25);
            tabControl.Location = new System.Drawing.Point(7, 4);
            tabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(1189, 772);
            tabControl.TabIndex = 0;
            // 
            // tabPage
            // 
            tabPage.Controls.Add(listViewReg);
            tabPage.Location = new System.Drawing.Point(4, 29);
            tabPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabPage.Name = "tabPage";
            tabPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabPage.Size = new System.Drawing.Size(1181, 739);
            tabPage.TabIndex = 0;
            tabPage.Text = "编辑";
            tabPage.UseVisualStyleBackColor = true;
            // 
            // listViewReg
            // 
            listViewReg.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listViewReg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { NameReg, ExplainReg, CommandReg });
            listViewReg.ContextMenuStrip = contextMenuStripRegList;
            listViewReg.Location = new System.Drawing.Point(3, 4);
            listViewReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            listViewReg.Name = "listViewReg";
            listViewReg.Size = new System.Drawing.Size(1170, 731);
            listViewReg.TabIndex = 0;
            listViewReg.UseCompatibleStateImageBehavior = false;
            listViewReg.View = System.Windows.Forms.View.Details;
            // 
            // NameReg
            // 
            NameReg.Text = "程序";
            NameReg.Width = 200;
            // 
            // ExplainReg
            // 
            ExplainReg.Text = "说明";
            ExplainReg.Width = 200;
            // 
            // CommandReg
            // 
            CommandReg.Text = "命令";
            CommandReg.Width = 450;
            // 
            // contextMenuStripRegList
            // 
            contextMenuStripRegList.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStripRegList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ToolStripMenuItemRevise, toolStripMenuItemSearch, ToolStripMenuItemDel });
            contextMenuStripRegList.Name = "contextMenuStripRegList";
            contextMenuStripRegList.Size = new System.Drawing.Size(211, 104);
            // 
            // ToolStripMenuItemRevise
            // 
            ToolStripMenuItemRevise.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { ToolStripMenuItemCommand });
            ToolStripMenuItemRevise.Enabled = false;
            ToolStripMenuItemRevise.Name = "ToolStripMenuItemRevise";
            ToolStripMenuItemRevise.Size = new System.Drawing.Size(210, 24);
            ToolStripMenuItemRevise.Text = "修改";
            // 
            // ToolStripMenuItemCommand
            // 
            ToolStripMenuItemCommand.Name = "ToolStripMenuItemCommand";
            ToolStripMenuItemCommand.Size = new System.Drawing.Size(122, 26);
            ToolStripMenuItemCommand.Text = "命令";
            // 
            // ToolStripMenuItemDel
            // 
            ToolStripMenuItemDel.Name = "ToolStripMenuItemDel";
            ToolStripMenuItemDel.Size = new System.Drawing.Size(210, 24);
            ToolStripMenuItemDel.Text = "删除";
            ToolStripMenuItemDel.Click += ToolStripMenuItemDel_Click;
            // 
            // toolStripMenuItemSearch
            // 
            toolStripMenuItemSearch.Name = "toolStripMenuItemSearch";
            toolStripMenuItemSearch.Size = new System.Drawing.Size(210, 24);
            toolStripMenuItemSearch.Text = "使用 Bing 搜索";
            toolStripMenuItemSearch.Click += toolStripMenuItemSearch_Click;
            // 
            // Form
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1220, 782);
            Controls.Add(panel);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MinimumSize = new System.Drawing.Size(1238, 829);
            Name = "Form";
            Text = "SeeMyOpenWith";
            Load += Form_Load;
            panel.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabPage.ResumeLayout(false);
            contextMenuStripRegList.ResumeLayout(false);
            ResumeLayout(false);

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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSearch;
    }
}

