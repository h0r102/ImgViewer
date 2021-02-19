
namespace ImgViewer
{
	partial class MainForm
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

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.imageSizeLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.dataSizeLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.scaleLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.pointerPositionLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.canvas = new System.Windows.Forms.PictureBox();
			this.toolbar = new ImgViewer.Toolbar();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageSizeLabel,
            this.dataSizeLabel,
            this.scaleLabel,
            this.pointerPositionLabel});
			this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.statusStrip1.Location = new System.Drawing.Point(0, 539);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(984, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// imageSizeLabel
			// 
			this.imageSizeLabel.Name = "imageSizeLabel";
			this.imageSizeLabel.Size = new System.Drawing.Size(118, 17);
			this.imageSizeLabel.Text = "toolStripStatusLabel1";
			// 
			// dataSizeLabel
			// 
			this.dataSizeLabel.Name = "dataSizeLabel";
			this.dataSizeLabel.Size = new System.Drawing.Size(118, 17);
			this.dataSizeLabel.Text = "toolStripStatusLabel1";
			// 
			// scaleLabel
			// 
			this.scaleLabel.Name = "scaleLabel";
			this.scaleLabel.Size = new System.Drawing.Size(118, 17);
			this.scaleLabel.Text = "toolStripStatusLabel2";
			// 
			// pointerPositionLabel
			// 
			this.pointerPositionLabel.Name = "pointerPositionLabel";
			this.pointerPositionLabel.Size = new System.Drawing.Size(118, 17);
			this.pointerPositionLabel.Text = "toolStripStatusLabel1";
			// 
			// canvas
			// 
			this.canvas.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.canvas.Location = new System.Drawing.Point(0, 50);
			this.canvas.Name = "canvas";
			this.canvas.Size = new System.Drawing.Size(984, 486);
			this.canvas.TabIndex = 1;
			this.canvas.TabStop = false;
			// 
			// toolbar
			// 
			this.toolbar.Location = new System.Drawing.Point(0, 0);
			this.toolbar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.toolbar.Name = "toolbar";
			this.toolbar.Size = new System.Drawing.Size(960, 50);
			this.toolbar.TabIndex = 2;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.toolbar);
			this.Controls.Add(this.canvas);
			this.Controls.Add(this.statusStrip1);
			this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MainForm";
			this.Text = "ImgViewer";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.PictureBox canvas;
		private ImgViewer.Toolbar toolbar;
		private System.Windows.Forms.ToolStripStatusLabel imageSizeLabel;
		private System.Windows.Forms.ToolStripStatusLabel dataSizeLabel;
		private System.Windows.Forms.ToolStripStatusLabel scaleLabel;
		private System.Windows.Forms.ToolStripStatusLabel pointerPositionLabel;
	}
}

