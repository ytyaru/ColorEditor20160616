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

            // 以下のProtectedメソッドをclass継承せずに実行する
            //   TrackBar.SetStyle(ControlStyles.Opaque, true);
            //   背景を描画しなくする。ちらつきを防止するため。
            Type t = typeof(System.Windows.Forms.Control);
            System.Reflection.MethodInfo mi = t.GetMethod("SetStyle",
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Public);
            mi.Invoke(this.trackBar1, new object[] { ControlStyles.Opaque, true });
            mi.Invoke(this.trackBar2, new object[] { ControlStyles.Opaque, true });
            mi.Invoke(this.trackBar3, new object[] { ControlStyles.Opaque, true });

            this.panel1.BackColor = Color.Transparent;
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

            this.BackColor = this.selectedColor;
            this.Update();

            this.panel1.BackColor = this.selectedColor;
            this.panel1.Update();

            this.numericUpDown1.BackColor = this.selectedColor;
            this.numericUpDown2.BackColor = this.selectedColor;
            this.numericUpDown3.BackColor = this.selectedColor;

            // 文字色は背景色と反対の色にする
            Color foreColor = Color.FromArgb(
                this.selectedColor.R ^ 0xff,
                this.selectedColor.G ^ 0xff,
                this.selectedColor.B ^ 0xff);
            if ((80 < this.selectedColor.R && this.selectedColor.R < 180) &&
                (100 < this.selectedColor.G && this.selectedColor.G < 180))
            {
                foreColor = Color.Black;
            }
            this.label1.ForeColor = foreColor;
            this.label2.ForeColor = foreColor;
            this.label3.ForeColor = foreColor;
            this.numericUpDown1.ForeColor = foreColor;
            this.numericUpDown2.ForeColor = foreColor;
            this.numericUpDown3.ForeColor = foreColor;

            // 1pixcel分の下線をクリアする（Windows NumericUpDown のバグ？）
            this.numericUpDown1.Refresh();
            this.numericUpDown2.Refresh();
            this.numericUpDown3.Refresh();
        }
    }
}
