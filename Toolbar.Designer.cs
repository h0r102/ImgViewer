
namespace ImgViewer
{
	partial class Toolbar
	{
		/// <summary> 
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region コンポーネント デザイナーで生成されたコード

		/// <summary> 
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.clockwiseButton = new System.Windows.Forms.Button();
			this.maximizeButton = new System.Windows.Forms.Button();
			this.scaledownButton = new System.Windows.Forms.Button();
			this.scaleupButton = new System.Windows.Forms.Button();
			this.endButton = new System.Windows.Forms.Button();
			this.nextButton = new System.Windows.Forms.Button();
			this.prevButton = new System.Windows.Forms.Button();
			this.homeButton = new System.Windows.Forms.Button();
			this.fileButton = new System.Windows.Forms.Button();
			this.counterclockwiseButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// clockwiseButton
			// 
			this.clockwiseButton.Location = new System.Drawing.Point(343, 7);
			this.clockwiseButton.Name = "clockwiseButton";
			this.clockwiseButton.Size = new System.Drawing.Size(36, 36);
			this.clockwiseButton.TabIndex = 19;
			this.clockwiseButton.UseVisualStyleBackColor = true;
			// 
			// maximizeButton
			// 
			this.maximizeButton.Location = new System.Drawing.Point(301, 7);
			this.maximizeButton.Name = "maximizeButton";
			this.maximizeButton.Size = new System.Drawing.Size(36, 36);
			this.maximizeButton.TabIndex = 18;
			this.maximizeButton.UseVisualStyleBackColor = true;
			// 
			// scaledownButton
			// 
			this.scaledownButton.Location = new System.Drawing.Point(259, 7);
			this.scaledownButton.Name = "scaledownButton";
			this.scaledownButton.Size = new System.Drawing.Size(36, 36);
			this.scaledownButton.TabIndex = 17;
			this.scaledownButton.UseVisualStyleBackColor = true;
			// 
			// scaleupButton
			// 
			this.scaleupButton.Location = new System.Drawing.Point(217, 7);
			this.scaleupButton.Name = "scaleupButton";
			this.scaleupButton.Size = new System.Drawing.Size(36, 36);
			this.scaleupButton.TabIndex = 16;
			this.scaleupButton.UseVisualStyleBackColor = true;
			// 
			// endButton
			// 
			this.endButton.Location = new System.Drawing.Point(175, 7);
			this.endButton.Name = "endButton";
			this.endButton.Size = new System.Drawing.Size(36, 36);
			this.endButton.TabIndex = 15;
			this.endButton.UseVisualStyleBackColor = true;
			// 
			// nextButton
			// 
			this.nextButton.Location = new System.Drawing.Point(133, 7);
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size(36, 36);
			this.nextButton.TabIndex = 14;
			this.nextButton.UseVisualStyleBackColor = true;
			// 
			// prevButton
			// 
			this.prevButton.Location = new System.Drawing.Point(91, 7);
			this.prevButton.Name = "prevButton";
			this.prevButton.Size = new System.Drawing.Size(36, 36);
			this.prevButton.TabIndex = 13;
			this.prevButton.UseVisualStyleBackColor = true;
			// 
			// homeButton
			// 
			this.homeButton.Location = new System.Drawing.Point(49, 7);
			this.homeButton.Name = "homeButton";
			this.homeButton.Size = new System.Drawing.Size(36, 36);
			this.homeButton.TabIndex = 12;
			this.homeButton.UseVisualStyleBackColor = true;
			// 
			// fileButton
			// 
			this.fileButton.Location = new System.Drawing.Point(7, 7);
			this.fileButton.Name = "fileButton";
			this.fileButton.Size = new System.Drawing.Size(36, 36);
			this.fileButton.TabIndex = 11;
			this.fileButton.UseVisualStyleBackColor = true;
			// 
			// counterclockwiseButton
			// 
			this.counterclockwiseButton.Location = new System.Drawing.Point(385, 7);
			this.counterclockwiseButton.Name = "counterclockwiseButton";
			this.counterclockwiseButton.Size = new System.Drawing.Size(36, 36);
			this.counterclockwiseButton.TabIndex = 20;
			this.counterclockwiseButton.UseVisualStyleBackColor = true;
			// 
			// toolbar
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.counterclockwiseButton);
			this.Controls.Add(this.clockwiseButton);
			this.Controls.Add(this.maximizeButton);
			this.Controls.Add(this.scaledownButton);
			this.Controls.Add(this.scaleupButton);
			this.Controls.Add(this.endButton);
			this.Controls.Add(this.nextButton);
			this.Controls.Add(this.prevButton);
			this.Controls.Add(this.homeButton);
			this.Controls.Add(this.fileButton);
			this.Name = "toolbar";
			this.Size = new System.Drawing.Size(960, 50);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button clockwiseButton;
		private System.Windows.Forms.Button maximizeButton;
		private System.Windows.Forms.Button scaledownButton;
		private System.Windows.Forms.Button scaleupButton;
		private System.Windows.Forms.Button endButton;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.Button prevButton;
		private System.Windows.Forms.Button homeButton;
		private System.Windows.Forms.Button fileButton;
		private System.Windows.Forms.Button counterclockwiseButton;
	}
}
