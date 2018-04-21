namespace K_means_project
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.k_select = new System.Windows.Forms.NumericUpDown();
            this.k_label = new System.Windows.Forms.Label();
            this.heading = new System.Windows.Forms.Label();
            this.subheading = new System.Windows.Forms.Label();
            this.stats = new System.Windows.Forms.GroupBox();
            this.label_state_2 = new System.Windows.Forms.Label();
            this.label_state_1 = new System.Windows.Forms.Label();
            this.label_iteration_count_2 = new System.Windows.Forms.Label();
            this.label_iteration_count_1 = new System.Windows.Forms.Label();
            this.label_element_count_2 = new System.Windows.Forms.Label();
            this.label_element_count_1 = new System.Windows.Forms.Label();
            this.button_start_anew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.k_select)).BeginInit();
            this.stats.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(122, 126);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(447, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Пуск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // k_select
            // 
            this.k_select.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.k_select.Location = new System.Drawing.Point(346, 92);
            this.k_select.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.k_select.Name = "k_select";
            this.k_select.Size = new System.Drawing.Size(47, 22);
            this.k_select.TabIndex = 2;
            this.k_select.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.k_select.ValueChanged += new System.EventHandler(this.k_select_ValueChanged);
            // 
            // k_label
            // 
            this.k_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.k_label.Location = new System.Drawing.Point(122, 92);
            this.k_label.Name = "k_label";
            this.k_label.Size = new System.Drawing.Size(218, 20);
            this.k_label.TabIndex = 3;
            this.k_label.Text = "K (количество кластеров):";
            // 
            // heading
            // 
            this.heading.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.heading.Location = new System.Drawing.Point(122, 25);
            this.heading.Name = "heading";
            this.heading.Size = new System.Drawing.Size(400, 33);
            this.heading.TabIndex = 4;
            this.heading.Text = "K-means clustering";
            this.heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subheading
            // 
            this.subheading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.subheading.Location = new System.Drawing.Point(122, 53);
            this.subheading.Name = "subheading";
            this.subheading.Size = new System.Drawing.Size(400, 23);
            this.subheading.TabIndex = 5;
            this.subheading.Text = "(кластеризация методом k-means)";
            this.subheading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stats
            // 
            this.stats.Controls.Add(this.label_state_2);
            this.stats.Controls.Add(this.label_state_1);
            this.stats.Controls.Add(this.label_iteration_count_2);
            this.stats.Controls.Add(this.label_iteration_count_1);
            this.stats.Controls.Add(this.label_element_count_2);
            this.stats.Controls.Add(this.label_element_count_1);
            this.stats.Location = new System.Drawing.Point(122, 532);
            this.stats.Name = "stats";
            this.stats.Size = new System.Drawing.Size(400, 100);
            this.stats.TabIndex = 6;
            this.stats.TabStop = false;
            this.stats.Text = "Информация";
            // 
            // label_state_2
            // 
            this.label_state_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_state_2.Location = new System.Drawing.Point(96, 60);
            this.label_state_2.Name = "label_state_2";
            this.label_state_2.Size = new System.Drawing.Size(283, 17);
            this.label_state_2.TabIndex = 5;
            this.label_state_2.Text = "готов к началу кластеризации (нажмите \"Пуск\")";
            // 
            // label_state_1
            // 
            this.label_state_1.AutoSize = true;
            this.label_state_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_state_1.Location = new System.Drawing.Point(7, 60);
            this.label_state_1.Name = "label_state_1";
            this.label_state_1.Size = new System.Drawing.Size(83, 17);
            this.label_state_1.TabIndex = 4;
            this.label_state_1.Text = "Состояние:";
            // 
            // label_iteration_count_2
            // 
            this.label_iteration_count_2.AutoSize = true;
            this.label_iteration_count_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_iteration_count_2.Location = new System.Drawing.Point(170, 41);
            this.label_iteration_count_2.Name = "label_iteration_count_2";
            this.label_iteration_count_2.Size = new System.Drawing.Size(16, 17);
            this.label_iteration_count_2.TabIndex = 3;
            this.label_iteration_count_2.Text = "0";
            // 
            // label_iteration_count_1
            // 
            this.label_iteration_count_1.AutoSize = true;
            this.label_iteration_count_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_iteration_count_1.Location = new System.Drawing.Point(7, 40);
            this.label_iteration_count_1.Name = "label_iteration_count_1";
            this.label_iteration_count_1.Size = new System.Drawing.Size(154, 17);
            this.label_iteration_count_1.TabIndex = 2;
            this.label_iteration_count_1.Text = "Выполнено итераций:";
            // 
            // label_element_count_2
            // 
            this.label_element_count_2.AutoSize = true;
            this.label_element_count_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_element_count_2.Location = new System.Drawing.Point(139, 20);
            this.label_element_count_2.Name = "label_element_count_2";
            this.label_element_count_2.Size = new System.Drawing.Size(16, 17);
            this.label_element_count_2.TabIndex = 1;
            this.label_element_count_2.Text = "0";
            // 
            // label_element_count_1
            // 
            this.label_element_count_1.AutoSize = true;
            this.label_element_count_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_element_count_1.Location = new System.Drawing.Point(7, 20);
            this.label_element_count_1.Name = "label_element_count_1";
            this.label_element_count_1.Size = new System.Drawing.Size(132, 17);
            this.label_element_count_1.TabIndex = 0;
            this.label_element_count_1.Text = "Количество точек:";
            // 
            // button_start_anew
            // 
            this.button_start_anew.Location = new System.Drawing.Point(539, 552);
            this.button_start_anew.Name = "button_start_anew";
            this.button_start_anew.Size = new System.Drawing.Size(89, 23);
            this.button_start_anew.TabIndex = 7;
            this.button_start_anew.Text = "Перезапуск";
            this.button_start_anew.UseVisualStyleBackColor = true;
            this.button_start_anew.Click += new System.EventHandler(this.button_start_anew_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 662);
            this.Controls.Add(this.button_start_anew);
            this.Controls.Add(this.stats);
            this.Controls.Add(this.subheading);
            this.Controls.Add(this.heading);
            this.Controls.Add(this.k_label);
            this.Controls.Add(this.k_select);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.k_select)).EndInit();
            this.stats.ResumeLayout(false);
            this.stats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown k_select;
        private System.Windows.Forms.Label k_label;
        private System.Windows.Forms.Label heading;
        private System.Windows.Forms.Label subheading;
        private System.Windows.Forms.GroupBox stats;
        private System.Windows.Forms.Label label_element_count_2;
        private System.Windows.Forms.Label label_element_count_1;
        private System.Windows.Forms.Label label_iteration_count_2;
        private System.Windows.Forms.Label label_iteration_count_1;
        private System.Windows.Forms.Label label_state_2;
        private System.Windows.Forms.Label label_state_1;
        private System.Windows.Forms.Button button_start_anew;
    }
}

