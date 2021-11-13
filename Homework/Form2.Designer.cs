
namespace Homework
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.historyModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.historyModelBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.DataSource = this.historyModelBindingSource;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 53);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(776, 385);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // historyModelBindingSource
            // 
            this.historyModelBindingSource.DataSource = typeof(ApiClient.HistoryModel);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(102)))), ((int)(((byte)(126)))));
            this.button1.Location = new System.Drawing.Point(10, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "1D";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(102)))), ((int)(((byte)(126)))));
            this.button2.Location = new System.Drawing.Point(60, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 25);
            this.button2.TabIndex = 2;
            this.button2.Text = "7D";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(102)))), ((int)(((byte)(126)))));
            this.button3.Location = new System.Drawing.Point(111, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 25);
            this.button3.TabIndex = 3;
            this.button3.Text = "1M";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(102)))), ((int)(((byte)(126)))));
            this.button4.Location = new System.Drawing.Point(162, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(45, 25);
            this.button4.TabIndex = 4;
            this.button4.Text = "3M";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(102)))), ((int)(((byte)(126)))));
            this.button5.Location = new System.Drawing.Point(216, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(45, 25);
            this.button5.TabIndex = 5;
            this.button5.Text = "1Y";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 35);
            this.panel1.TabIndex = 6;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.historyModelBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.BindingSource historyModelBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel1;
    }
}