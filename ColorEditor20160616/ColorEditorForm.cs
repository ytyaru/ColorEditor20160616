/**
 * ColorEditor20160616
 *
 * These codes are licensed under CC0.
 * http://creativecommons.org/publicdomain/zero/1.0/deed.ja
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColorEditor20160616
{
    public partial class ColorEditorForm : Form
    {
        EventHandler numericUpDown1ValueChanged;
        EventHandler numericUpDown2ValueChanged;
        EventHandler numericUpDown3ValueChanged;
        EventHandler trackBar1ValueChanged;
        EventHandler trackBar2ValueChanged;
        EventHandler trackBar3ValueChanged;

        Color selectedColor;

        public ColorEditorForm()
        {
            InitializeComponent();

            //ダブルバッファリングを有効にする
            this.SetStyle(
               ControlStyles.DoubleBuffer |
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint,
               true);

            //// 「エラー	1	'System.Windows.Forms.TrackBar' 型の修飾子をとおして プロテクト メンバー 'System.Windows.Forms.Control.SetStyle(System.Windows.Forms.ControlStyles, bool)' にアクセスすることはできません。修飾子は 'ColorEditor20160616.ColorEditorForm' 型、またはそれから派生したものでなければなりません。	C:\root\pj\Do\ColorEditor20160616\ColorEditor20160616\ColorEditorForm.cs	40	28	ColorEditor20160616」
            //this.trackBar1.SetStyle(
            //   ControlStyles.DoubleBuffer |
            //   ControlStyles.UserPaint |
            //   ControlStyles.AllPaintingInWmPaint,
            //   true);
            //this.trackBar1.SetStyle(ControlStyles.Opaque, true);
            //// NumericUpDown, Label, Panel も同じ

            this.trackBar1.GetType().InvokeMember(
               "DoubleBuffered",
               System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
               null,
               this.trackBar1,
               new object[] { true });

            //// 「コントロールは透明な背景色をサポートしません。」
            //this.trackBar1.BackColor = Color.Transparent;
            //this.trackBar2.BackColor = Color.Transparent;
            //this.trackBar3.BackColor = Color.Transparent;
            //// 「コントロールは透明な背景色をサポートしません。」
            //this.numericUpDown1.BackColor = Color.Transparent;
            //this.numericUpDown2.BackColor = Color.Transparent;
            //this.numericUpDown3.BackColor = Color.Transparent;

            this.panel1.BackColor = Color.Transparent;

            // this.BackColorでいい。PictureBoxいらない
            this.pictureBox1.Visible = false;
            //this.pictureBox1.BackColor = Color.Transparent;

            this.label1.BackColor = Color.Transparent;
            this.label2.BackColor = Color.Transparent;
            this.label3.BackColor = Color.Transparent;

            this.numericUpDown1ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.numericUpDown2ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            this.numericUpDown3ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);

            this.trackBar1ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            this.trackBar2ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            this.trackBar3ValueChanged += new System.EventHandler(this.trackBar3_ValueChanged);

            this.numericUpDown1.ValueChanged += this.numericUpDown1ValueChanged;
            this.numericUpDown2.ValueChanged += this.numericUpDown2ValueChanged;
            this.numericUpDown3.ValueChanged += this.numericUpDown3ValueChanged;

            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            this.trackBar3.ValueChanged += new System.EventHandler(this.trackBar3_ValueChanged);

            this.trackBar1.ValueChanged += this.trackBar1ValueChanged;
            this.trackBar2.ValueChanged += this.trackBar2ValueChanged;
            this.trackBar3.ValueChanged += this.trackBar3ValueChanged;

            this.selectedColor = Color.FromArgb(0, 0, 0);
            this.SetUIColor();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.trackBar1.ValueChanged -= this.trackBar1ValueChanged;
            this.trackBar1.Value = (int)this.numericUpDown1.Value;
            this.trackBar1.ValueChanged += this.trackBar1ValueChanged;

            this.SetUIColor();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            this.trackBar2.ValueChanged -= this.trackBar2ValueChanged;
            this.trackBar2.Value = (int)this.numericUpDown2.Value;
            this.trackBar2.ValueChanged += this.trackBar2ValueChanged;

            this.SetUIColor();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            this.trackBar3.ValueChanged -= this.trackBar3ValueChanged;
            this.trackBar3.Value = (int)this.numericUpDown3.Value;
            this.trackBar3.ValueChanged += this.trackBar3ValueChanged;

            this.SetUIColor();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDown1.ValueChanged -= this.numericUpDown1ValueChanged;
            this.numericUpDown1.Value = this.trackBar1.Value;
            this.numericUpDown1.ValueChanged += this.numericUpDown1ValueChanged;

            this.SetUIColor();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDown2.ValueChanged -= this.numericUpDown2ValueChanged;
            this.numericUpDown2.Value = this.trackBar2.Value;
            this.numericUpDown2.ValueChanged += this.numericUpDown2ValueChanged;

            this.SetUIColor();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDown3.ValueChanged -= this.numericUpDown3ValueChanged;
            this.numericUpDown3.Value = this.trackBar3.Value;
            this.numericUpDown3.ValueChanged += this.numericUpDown3ValueChanged;

            this.SetUIColor();
        }

        private void SetUIColor()
        {
            this.selectedColor = Color.FromArgb(
                (int)this.numericUpDown1.Value,
                (int)this.numericUpDown2.Value,
                (int)this.numericUpDown3.Value);

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            
            //this.BackColor = this.selectedColor;
            this.BackColor = this.selectedColor;
            //this.pictureBox1.BackColor = this.selectedColor;
            //this.panel1.BackColor = this.selectedColor;

            // 「コントロールは透明な背景色をサポートしません。」
            this.trackBar1.BackColor = this.selectedColor;
            this.trackBar2.BackColor = this.selectedColor;
            this.trackBar3.BackColor = this.selectedColor;
            // コントロールは透明な背景色をサポートしません。
            this.numericUpDown1.BackColor = this.selectedColor;
            this.numericUpDown2.BackColor = this.selectedColor;
            this.numericUpDown3.BackColor = this.selectedColor;

            Color foreColor = Color.FromArgb(
                this.selectedColor.R ^ 0xff,
                this.selectedColor.G ^ 0xff,
                this.selectedColor.B ^ 0xff);
            if ((80 < this.selectedColor.R && this.selectedColor.R < 180) &&
                (100 < this.selectedColor.G && this.selectedColor.G < 180))
            {
                foreColor = Color.Black;
            }
            //if ((80 < this.selectedColor.R && this.selectedColor.R < 180) &&
            //    (100 < this.selectedColor.G && this.selectedColor.G < 180) &&
            //    (-1 < this.selectedColor.B && this.selectedColor.B < 230))
            //{
            //    foreColor = Color.Black;
            //}

            this.label1.ForeColor = foreColor;
            this.label2.ForeColor = foreColor;
            this.label3.ForeColor = foreColor;
            this.numericUpDown1.ForeColor = foreColor;
            this.numericUpDown2.ForeColor = foreColor;
            this.numericUpDown3.ForeColor = foreColor;

            //this.label1.ForeColor = Color.FromArgb(
            //    this.selectedColor.R ^ 0xff,
            //    this.selectedColor.G ^ 0xff,
            //    this.selectedColor.B ^ 0xff);
            //this.label2.ForeColor = Color.FromArgb(
            //    this.selectedColor.R ^ 0xff,
            //    this.selectedColor.G ^ 0xff,
            //    this.selectedColor.B ^ 0xff);
            //this.label3.ForeColor = Color.FromArgb(
            //    this.selectedColor.R ^ 0xff,
            //    this.selectedColor.G ^ 0xff,
            //    this.selectedColor.B ^ 0xff);
            //this.numericUpDown1.ForeColor = Color.FromArgb(
            //    this.selectedColor.R ^ 0xff,
            //    this.selectedColor.G ^ 0xff,
            //    this.selectedColor.B ^ 0xff);
            //this.numericUpDown2.ForeColor = Color.FromArgb(
            //    this.selectedColor.R ^ 0xff,
            //    this.selectedColor.G ^ 0xff,
            //    this.selectedColor.B ^ 0xff);
            //this.numericUpDown3.ForeColor = Color.FromArgb(
            //    this.selectedColor.R ^ 0xff,
            //    this.selectedColor.G ^ 0xff,
            //    this.selectedColor.B ^ 0xff);

            //this.numericUpDown1.Invalidate();
            //this.numericUpDown2.Invalidate();
            //this.numericUpDown3.Invalidate();

            //this.numericUpDown1.Update();
            //this.numericUpDown2.Update();
            //this.numericUpDown3.Update();

            this.numericUpDown1.Refresh();
            this.numericUpDown2.Refresh();
            this.numericUpDown3.Refresh();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
