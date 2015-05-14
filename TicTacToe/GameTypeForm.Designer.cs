namespace TicTacToe
{
    partial class GameTypeForm
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
            this.player = new System.Windows.Forms.Button();
            this.computer = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.DialogResult = System.Windows.Forms.DialogResult.No;
            this.player.Location = new System.Drawing.Point(12, 50);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(75, 23);
            this.player.TabIndex = 0;
            this.player.Text = "Player";
            this.player.UseVisualStyleBackColor = true;
            // 
            // computer
            // 
            this.computer.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.computer.Location = new System.Drawing.Point(93, 50);
            this.computer.Name = "computer";
            this.computer.Size = new System.Drawing.Size(75, 23);
            this.computer.TabIndex = 1;
            this.computer.Text = "Computer";
            this.computer.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(267, 32);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Do you want to play against the computer or a person?";
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(201, 50);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // GameTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 83);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.computer);
            this.Controls.Add(this.player);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(304, 122);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(304, 122);
            this.Name = "GameTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game Type";
            this.Load += new System.EventHandler(this.GameTypeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button player;
        private System.Windows.Forms.Button computer;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button cancel;
    }
}