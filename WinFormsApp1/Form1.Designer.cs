namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            transparency = new Button();
            color = new Button();
            helloWorld = new Button();
            superButton = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            SuspendLayout();
            // 
            // transparency
            // 
            transparency.Location = new Point(37, 12);
            transparency.Name = "transparency";
            transparency.Size = new Size(107, 29);
            transparency.TabIndex = 0;
            transparency.Text = "Прозорість";
            transparency.UseVisualStyleBackColor = true;
            transparency.Click += transparency_Click;
            // 
            // color
            // 
            color.Location = new Point(150, 12);
            color.Name = "color";
            color.Size = new Size(117, 29);
            color.TabIndex = 1;
            color.Text = "Колір тіла";
            color.UseVisualStyleBackColor = true;
            color.Click += color_Click;
            // 
            // helloWorld
            // 
            helloWorld.Location = new Point(273, 12);
            helloWorld.Name = "helloWorld";
            helloWorld.Size = new Size(108, 29);
            helloWorld.TabIndex = 2;
            helloWorld.Text = "Hello World";
            helloWorld.UseVisualStyleBackColor = true;
            helloWorld.Click += helloWorld_Click;
            // 
            // superButton
            // 
            superButton.Location = new Point(37, 65);
            superButton.Name = "superButton";
            superButton.Size = new Size(344, 29);
            superButton.TabIndex = 3;
            superButton.Text = "супермегакнопка";
            superButton.UseVisualStyleBackColor = true;
            superButton.Click += superButton_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(37, 129);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(333, 24);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "\"супермегакнопка\" поглинає \"Прозорість\" ";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(37, 168);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(319, 24);
            checkBox2.TabIndex = 5;
            checkBox2.Text = "\"супермегакнопка\" поглинає \"Колір тіла\"";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(37, 211);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(330, 24);
            checkBox3.TabIndex = 6;
            checkBox3.Text = "\"супермегакнопка\" поглинає \"Hello World\"";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 395);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(superButton);
            Controls.Add(helloWorld);
            Controls.Add(color);
            Controls.Add(transparency);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button transparency;
        private Button color;
        private Button helloWorld;
        private Button superButton;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
    }
}
