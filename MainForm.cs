using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgViewer
{
	public partial class MainForm : Form
	{
		private string[] _img_lists;
		private string _img_path;
		private Bitmap _image;
		private Graphics _img_graph;
		private Single _angle;
		private Single _scale;
		private System.Drawing.Drawing2D.Matrix _img_mat;
		private bool _mouse_down_flg = false;
		private PointF _old_point;

		public MainForm(string img_path=null)
		{
			InitializeComponent();
			// メインフォームイベントの追加
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			_img_path = img_path;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			// オブジェクトの初期化
			CreateGraphics(canvas, ref _img_graph);
			_img_mat = new System.Drawing.Drawing2D.Matrix();
			// キャンバスイベントの追加
			canvas.DragDrop += new System.Windows.Forms.DragEventHandler(this.canvas_DragDrop);
			canvas.DragEnter += new System.Windows.Forms.DragEventHandler(this.canvas_DragEnter);
			canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
			canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
			canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
			canvas.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseWheel);
			canvas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDoubleClick);
			toolbar.fileButtonClick += new System.Windows.Forms.MouseEventHandler(this.toolbar_fileButtonClick);
			toolbar.homeButtonClick += new System.Windows.Forms.MouseEventHandler(this.toolbar_homeButtonClick);
			toolbar.prevButtonClick += new System.Windows.Forms.MouseEventHandler(this.toolbar_prevButtonClick);
			toolbar.nextButtonClick += new System.Windows.Forms.MouseEventHandler(this.toolbar_nextButtonClick);
			toolbar.endButtonClick += new System.Windows.Forms.MouseEventHandler(this.toolbar_endButtonClick);
			toolbar.scaleupButtonClick += new System.Windows.Forms.MouseEventHandler(this.toolbar_scaleupButtonClick);
			toolbar.scaledownButtonClick += new System.Windows.Forms.MouseEventHandler(this.toolbar_scaledownButtonClick);
			toolbar.maximizeButtonClick += new System.Windows.Forms.MouseEventHandler(this.toolbar_maximizeButtonClick);
			toolbar.clockwiseButtonClick += new System.Windows.Forms.MouseEventHandler(this.toolbar_clockwiseButtonClick);
			toolbar.counterclockwiseButtonClick += new System.Windows.Forms.MouseEventHandler(this.toolbar_counterclockwiseButtonClick);

			// キャンバスへのDragDropを有効化
			canvas.AllowDrop = true;
			// 画像ファイルであれば開く
			if (IsImageFile(_img_path))
			{
				OpenImageFile(_img_path);
				string dir_path = System.IO.Path.GetDirectoryName(_img_path);
				_img_lists = FindImageFiles(dir_path);
			}
			// 画像ファイルでなければスルー
			else
			{
				_img_path = null;
				imageSizeLabel.Text = $"ImageSize: ";
				dataSizeLabel.Text = $"DataSize: ";
				scaleLabel.Text = $"scale: ";
			}
		}


		/// イベントモジュール
		/// メインフォームイベント
		private void MainForm_Resize(object sender, EventArgs e)
		{
			// Graphicsオブジェクトの再確保
			CreateGraphics(canvas, ref _img_graph);
			canvas.Location = new Point(toolbar.Location.X, toolbar.Location.Y + toolbar.Height);
			canvas.Size = new Size(Width - 14, Height - 114);
			
			// 描画
			RedrawImage();
		}

		/// キャンバスイベント
		private void canvas_DragEnter(object sender, DragEventArgs e)
		{
			// コントロール内にドラッグされたとき実行
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				// ドラッグされたデータ形式を調べ、ファイルのときはコピー
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				// ファイル以外は受け付けない
				e.Effect = DragDropEffects.None;
			}
		}
		private void canvas_DragDrop(object sender, DragEventArgs e)
		{
			// コントロール内にドラッグされたとき実行
			// ドロップされたファイル名を取得（複数の場合、先頭のファイル）
			_img_path = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];

			// 画像ファイルであれば開く
			if (IsImageFile(_img_path))
			{
				OpenImageFile(_img_path);
				string dir_path = System.IO.Path.GetDirectoryName(_img_path);
				_img_lists = FindImageFiles(dir_path);
			}
			// 画像ファイルでなければスルー
			else
			{
				_img_path = null;
				return;
			}
		}
		private void canvas_MouseDown(object sender, MouseEventArgs e)
		{
			switch (e.Button)
			{
				// 左ボタン
				case MouseButtons.Left:
					canvas.Focus();
					_old_point.X = e.X;
					_old_point.Y = e.Y;
					_mouse_down_flg = true;
					break;
				// 下ボタン
				case MouseButtons.XButton1:
					OpenPreviousImage();
					break;
				// 上ボタン
				case MouseButtons.XButton2:
					OpenNextImage();
					break;
				default:
					break;
			}
		}
		private void canvas_MouseMove(object sender, MouseEventArgs e)
		{
			// マウスをクリックしながら移動するとき、画像を移動する
			if (_mouse_down_flg == true)
			{
				// 画像の移動
				_img_mat.Translate(e.X - _old_point.X, e.Y - _old_point.Y, System.Drawing.Drawing2D.MatrixOrder.Append);
				// 描画
				RedrawImage();
			}
			// ポインタ位置の保持
			_old_point.X = e.X;
			_old_point.Y = e.Y;
			pointerPositionLabel.Text = $"x: {_old_point.X}, y: {_old_point.Y}";
		}
		private void canvas_MouseUp(object sender, MouseEventArgs e)
		{
			_mouse_down_flg = false;
		}
		private void canvas_MouseWheel(object sender, MouseEventArgs e)
		{
			// ホイールを上に回す
			if (e.Delta > 0)
			{
				// マウスをクリックしているとき、右回転する
				if (_mouse_down_flg == true)
				{
					// ポインタ位置周りに回転
					RotateImage(5f, e.Location);
				}
				// マウスをクリックしていないとき、拡大する
				else
				{
					ScaleImage(1.5f, e.Location);
				}
			}
			// ホイールを下に回す
			else
			{
				// マウスをクリックしているとき、左回転する
				if (_mouse_down_flg == true)
				{
					// ポインタ位置周りに回転
					RotateImage(-5f, e.Location);
				}
				// マウスをクリックしていないとき、縮小する
				else
				{
					ScaleImage(1.0f / 1.5f, e.Location);
				}
			}
		}
		private void canvas_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			switch (e.Button)
			{
				// 左ボタン
				case MouseButtons.Left:
					// ダブルクリックでキャンバスのサイズに画像サイズをあわせる
					ZoomFitImage();
					break;
				default:
					break;
			}

		}

		/// ツールバーイベント
		private void toolbar_fileButtonClick(object sender, MouseEventArgs e)
		{
			OpenFileDialogBox();
		}
		private void toolbar_homeButtonClick(object sender, MouseEventArgs e)
		{
			OpenHomeImage();
		}
		private void toolbar_prevButtonClick(object sender, MouseEventArgs e)
		{
			OpenPreviousImage();
		}
		private void toolbar_nextButtonClick(object sender, MouseEventArgs e)
		{
			OpenNextImage();
		}
		private void toolbar_endButtonClick(object sender, MouseEventArgs e)
		{
			OpenEndImage();
		}
		private void toolbar_scaleupButtonClick(object sender, MouseEventArgs e)
		{
			ScaleImage(1.5f, new Point(canvas.Width / 2, canvas.Height / 2));
		}
		private void toolbar_scaledownButtonClick(object sender, MouseEventArgs e)
		{
			ScaleImage(1.0f / 1.5f, new Point(canvas.Width / 2, canvas.Height / 2));
		}
		private void toolbar_maximizeButtonClick(object sender, MouseEventArgs e)
		{
			ZoomFitImage();
		}
		private void toolbar_clockwiseButtonClick(object sender, MouseEventArgs e)
		{
			RotateImage(90f, new Point(canvas.Width / 2, canvas.Height / 2));
		}
		private void toolbar_counterclockwiseButtonClick(object sender, MouseEventArgs e)
		{
			RotateImage(-90f, new Point(canvas.Width / 2, canvas.Height / 2));
		}

		/// end イベントモジュール


		/// 画像処理モジュール

		/// <summary>
		/// Graphicsオブジェクトの作成
		/// </summary>
		/// <param name="pic">描画先のPictureBox</param>
		/// <param name="graph">Graphicsオブジェクト</param>
		public static void CreateGraphics(PictureBox pic, ref Graphics graph)
		{
			if (graph != null)
			{
				graph.Dispose();
				graph = null;
			}
			if (pic.Image != null)
			{
				pic.Image.Dispose();
				pic.Image = null;
			}
			if ((pic.Width == 0) || (pic.Height == 0))
			{
				return;
			}
			pic.Image = new Bitmap(pic.Width, pic.Height);
			graph = Graphics.FromImage(pic.Image);
			graph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
		}
		/// <summary>
		/// 画像ファイルか否かの確認
		/// </summary>
		/// <param name="file_path">画像ファイルパス</param>
		public bool IsImageFile(string file_path)
		{
			string[] extensions = new string[]
			{
				".bmp", ".gif", ".jpg", ".jpeg", ".png", ".tif"
			};
			if (System.IO.Path.GetExtension(file_path) == null)
			{
				return false;
			}
			else if (Array.IndexOf(extensions, System.IO.Path.GetExtension(file_path).ToLower()) != -1)
			{
				return true;
			}
			return false;
		}
		/// <summary>
		/// 画像ファイルを開く
		/// </summary>
		/// <param name="file_path">画像ファイルパス</param>
		public void OpenImageFile(string file_path)
		{
			if (this._image != null)
			{
				this._image.Dispose();
			}
			_image = new Bitmap(file_path);
			// 画像をキャンバスに合わせて表示する行列の計算
			ZoomFitImage();
			imageSizeLabel.Text = $"ImageSize: {_image.Width}x{_image.Height}";
			double data_size = Math.Round((double)new System.IO.FileInfo(_img_path).Length / 1024 / 1024, 3);
			dataSizeLabel.Text = $"DataSize: {data_size}MB";
		}
		/// <summary>
		/// ファイルを開く
		/// </summary>
		public void OpenFileDialogBox()
		{
			// ファイルを開くダイアログボックスの作成
			var file = new OpenFileDialog();
			// ファイルフィルタ
			file.Filter = "Image File(*.bmp,*.gif,*.jpg,*.jpeg,*.png,*.tif)|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tif|Bitmap(*.bmp)|*.bmp|Jpeg(*.jpg,*.jpeg)|*.jpg;*.jpeg|PNG(*.png)|*.png";
			// ダイアログボックスの表示
			if (file.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}
			_img_path = file.FileName;
			OpenImageFile(_img_path);
			string dir_path = System.IO.Path.GetDirectoryName(_img_path);
			_img_lists = FindImageFiles(dir_path);

		}
		public void OpenPreviousImage()
		{
			if (_img_path == null)
			{
				return;
			}
			int index = Array.IndexOf(_img_lists, _img_path);
			if (index < 1 || index > _img_lists.Length - 1)
			{
				return;
			}
			_img_path = _img_lists[index - 1];
			OpenImageFile(_img_path);
		}
		public void OpenNextImage()
		{
			if (_img_path == null)
			{
				return;
			}
			int index = Array.IndexOf(_img_lists, _img_path);
			if (index < 0 || index > _img_lists.Length - 2)
			{
				return;
			}
			_img_path = _img_lists[index + 1];
			OpenImageFile(_img_path);
		}
		public void OpenHomeImage()
		{
			if (_img_path == null)
			{
				return;
			}
			_img_path = _img_lists[0];
			OpenImageFile(_img_path);
		}
		public void OpenEndImage()
		{
			if (_img_path == null)
			{
				return;
			}
			_img_path = _img_lists[_img_lists.Length - 1];
			OpenImageFile(_img_path);
		}
		/// <summary>
		/// 画像の拡大・縮小
		/// </summary>
		public void ScaleImage(Single scale, Point center)
		{
			_img_mat.RotateAt(-_angle, center);

			if (scale > 1.0f)
			{
				// 最大100倍
				if (Math.Abs(_scale) < 100)
				{
					_img_mat.ScaleAt(scale, center);
					scaleLabel.Text = $"scale: {_img_mat.Elements[0]}";
				}
			}
			else
			{
				// 最小0.01倍
				if (Math.Abs(_scale) > 0.01)
				{
					_img_mat.ScaleAt(scale, center);
					scaleLabel.Text = $"scale: {_img_mat.Elements[0]}";
				}
			}
			_img_mat.RotateAt(_angle, center);
			_scale = _img_mat.Elements[0];
			// 描画
			RedrawImage();
		}
		/// <summary>
		/// 画像サイズをウィンドウサイズに合わせる
		/// </summary>
		public void ZoomFitImage()
		{
			_img_mat.ZoomFit(canvas, _image);
			scaleLabel.Text = $"scale: {_img_mat.Elements[0]}";
			// 描画
			RedrawImage();
		}
		/// <summary>
		/// 画像の回転
		/// </summary>
		public void RotateImage(Single angle, Point center)
		{
			_angle = angle;
			_img_mat.RotateAt(_angle, center, System.Drawing.Drawing2D.MatrixOrder.Append);
			// 描画
			RedrawImage();
		}
		/// <summary>
		/// 画像の描画
		/// </summary>
		public void RedrawImage()
		{
			// ピクチャボックスの背景で画像を削除
			_img_graph.Clear(canvas.BackColor);
			// アフィン変換行列に基づいて画像の描画
			_img_graph.DrawImage(_image, _img_mat);
			// 更新
			canvas.Refresh();
		}
		/// <summary>
		/// フォルダ内の画像ファイルを取得
		/// </summary>
		/// <param name="dir_path">ディレクトリパス</param>
		public string[] FindImageFiles(string dir_path)
		{
			string[] files = System.IO.Directory.GetFiles(dir_path, "*", System.IO.SearchOption.TopDirectoryOnly);
			List<string> image_files = new List<string>();
			foreach (var name in files)
			{
				if (IsImageFile(name))
				{
					image_files.Add(name);
				}
			}
			return image_files.ToArray();
		}
		/// end 画像処理モジュール




	}
}
