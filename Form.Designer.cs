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
            AppName = new System.Windows.Forms.ColumnHeader();
            ExplainReg = new System.Windows.Forms.ColumnHeader();
            CommandReg = new System.Windows.Forms.ColumnHeader();
            contextMenuStripRegList = new System.Windows.Forms.ContextMenuStrip(components);
            ToolStripMenuItemRevise = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItemCommand = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemSearch = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItemDel = new System.Windows.Forms.ToolStripMenuItem();
            tabPageAbout = new System.Windows.Forms.TabPage();
            labelAbout = new System.Windows.Forms.Label();
            panel.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage.SuspendLayout();
            contextMenuStripRegList.SuspendLayout();
            tabPageAbout.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel.Controls.Add(tabControl);
            panel.Location = new System.Drawing.Point(5, 1);
            panel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel.Name = "panel";
            panel.Size = new System.Drawing.Size(1476, 852);
            panel.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControl.Controls.Add(tabPage);
            tabControl.Controls.Add(tabPageAbout);
            tabControl.ItemSize = new System.Drawing.Size(80, 25);
            tabControl.Location = new System.Drawing.Point(7, 4);
            tabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(1451, 843);
            tabControl.TabIndex = 0;
            // 
            // tabPage
            // 
            tabPage.Controls.Add(listViewReg);
            tabPage.Location = new System.Drawing.Point(4, 29);
            tabPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabPage.Name = "tabPage";
            tabPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabPage.Size = new System.Drawing.Size(1443, 810);
            tabPage.TabIndex = 0;
            tabPage.Text = "编辑";
            tabPage.UseVisualStyleBackColor = true;
            // 
            // listViewReg
            // 
            listViewReg.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listViewReg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { NameReg, AppName, ExplainReg, CommandReg });
            listViewReg.ContextMenuStrip = contextMenuStripRegList;
            listViewReg.Location = new System.Drawing.Point(3, 4);
            listViewReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            listViewReg.Name = "listViewReg";
            listViewReg.Size = new System.Drawing.Size(1432, 802);
            listViewReg.TabIndex = 0;
            listViewReg.UseCompatibleStateImageBehavior = false;
            listViewReg.View = System.Windows.Forms.View.Details;
            // 
            // NameReg
            // 
            NameReg.Text = "程序";
            NameReg.Width = 200;
            // 
            // AppName
            // 
            AppName.Text = "名称";
            AppName.Width = 200;
            // 
            // ExplainReg
            // 
            ExplainReg.Text = "说明";
            ExplainReg.Width = 220;
            // 
            // CommandReg
            // 
            CommandReg.Text = "命令";
            CommandReg.Width = 500;
            // 
            // contextMenuStripRegList
            // 
            contextMenuStripRegList.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStripRegList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ToolStripMenuItemRevise, toolStripMenuItemSearch, ToolStripMenuItemDel });
            contextMenuStripRegList.Name = "contextMenuStripRegList";
            contextMenuStripRegList.Size = new System.Drawing.Size(179, 76);
            // 
            // ToolStripMenuItemRevise
            // 
            ToolStripMenuItemRevise.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { ToolStripMenuItemCommand });
            ToolStripMenuItemRevise.Enabled = false;
            ToolStripMenuItemRevise.Name = "ToolStripMenuItemRevise";
            ToolStripMenuItemRevise.Size = new System.Drawing.Size(178, 24);
            ToolStripMenuItemRevise.Text = "修改";
            // 
            // ToolStripMenuItemCommand
            // 
            ToolStripMenuItemCommand.Name = "ToolStripMenuItemCommand";
            ToolStripMenuItemCommand.Size = new System.Drawing.Size(122, 26);
            ToolStripMenuItemCommand.Text = "命令";
            // 
            // toolStripMenuItemSearch
            // 
            toolStripMenuItemSearch.Name = "toolStripMenuItemSearch";
            toolStripMenuItemSearch.Size = new System.Drawing.Size(178, 24);
            toolStripMenuItemSearch.Text = "使用 Bing 搜索";
            toolStripMenuItemSearch.Click += toolStripMenuItemSearch_Click;
            // 
            // ToolStripMenuItemDel
            // 
            ToolStripMenuItemDel.Name = "ToolStripMenuItemDel";
            ToolStripMenuItemDel.Size = new System.Drawing.Size(178, 24);
            ToolStripMenuItemDel.Text = "删除";
            ToolStripMenuItemDel.Click += ToolStripMenuItemDel_Click;
            // 
            // tabPageAbout
            // 
            tabPageAbout.Controls.Add(labelAbout);
            tabPageAbout.Location = new System.Drawing.Point(4, 29);
            tabPageAbout.Name = "tabPageAbout";
            tabPageAbout.Padding = new System.Windows.Forms.Padding(3);
            tabPageAbout.Size = new System.Drawing.Size(1443, 810);
            tabPageAbout.TabIndex = 1;
            tabPageAbout.Text = "关于";
            tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // labelAbout
            // 
            labelAbout.AutoSize = true;
            labelAbout.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            labelAbout.Location = new System.Drawing.Point(6, 3);
            labelAbout.Name = "labelAbout";
            labelAbout.Size = new System.Drawing.Size(372, 27);
            labelAbout.TabIndex = 0;
            labelAbout.Text = "See My Open With - 查看我的打开方式";
            // 
            // Form
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1482, 853);
            Controls.Add(panel);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MinimumSize = new System.Drawing.Size(1500, 900);
            Name = "Form";
            Text = "SeeMyOpenWith";
            Load += Form_Load;
            panel.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabPage.ResumeLayout(false);
            contextMenuStripRegList.ResumeLayout(false);
            tabPageAbout.ResumeLayout(false);
            tabPageAbout.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.ColumnHeader AppName;
    }
}

