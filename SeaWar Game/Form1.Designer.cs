namespace SeaWar_Game
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMyField = new System.Windows.Forms.Panel();
            this.panelAIField = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelMyField
            // 
            this.panelMyField.Location = new System.Drawing.Point(56, 28);
            this.panelMyField.Name = "panelMyField";
            this.panelMyField.Size = new System.Drawing.Size(300, 300);
            this.panelMyField.TabIndex = 0;
            // 
            // panelAIField
            // 
            this.panelAIField.Location = new System.Drawing.Point(401, 28);
            this.panelAIField.Name = "panelAIField";
            this.panelAIField.Size = new System.Drawing.Size(300, 300);
            this.panelAIField.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelAIField);
            this.Controls.Add(this.panelMyField);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMyField;
        private System.Windows.Forms.Panel panelAIField;
    }
}

