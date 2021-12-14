using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ImgViewer
{
	public static class AffineImage
	{
        /// <summary>
        /// アフィン変換行列(mat)に基づいて画像を描画する
        /// </summary>
        /// <param name="g">描画先のGraphicsオブジェクト</param>
        /// <param name="bmp">描画するBitmapオブジェクト</param>
        /// <param name="mat">アフィン変換行列</param>
        public static void DrawImage(this Graphics graph, Bitmap bmp, System.Drawing.Drawing2D.Matrix mat)
		{
            if ((graph == null) || (bmp == null))
			{
                return;
			}
            // 画像の画素の外側の領域
            var srcRect = new RectangleF(-0.5f, -0.5f, bmp.Width, bmp.Height);
            // 画像の左上、右上、左下の座標
            var points = new PointF[]
            {
                new PointF(srcRect.Left, srcRect.Top),
                new PointF(srcRect.Right, srcRect.Top),
                new PointF(srcRect.Left, srcRect.Bottom)
            };
            // アフィン変換で描画先の座標に変換する
            mat.TransformPoints(points);
            // 描画
            graph.DrawImage(bmp, points, srcRect, GraphicsUnit.Pixel);
		}
        /// <summary>
        /// 画像をピクチャボックスに合わせて表示するアフィン変換行列の計算（拡張メソッド）
        /// </summary>
        /// <param name="mat">アフィン変換行列</param>
        /// <param name="pic">描画先のピクチャボックス</param>
        /// <param name="bmp">描画するBitmapオブジェクト</param>
        public static void ZoomFit(this System.Drawing.Drawing2D.Matrix mat, PictureBox pic, Bitmap bmp)
		{
            if (bmp == null)
			{
                return;
			}
            // アフィン変換行列の初期化
            mat.Reset();
            // 0.5画素分移動
            mat.Translate(0.5f, 0.5f, System.Drawing.Drawing2D.MatrixOrder.Append);
            int src_width = bmp.Width;
            int src_height = bmp.Height;
            int dst_width = pic.Width;
            int dst_height = pic.Height;
            float scale = 1;
            // 縦方向に画像表示をあわせる場合
            if (src_height * dst_width > src_width * dst_height)
			{
                // スケール
                scale = dst_height / (float)src_height;
                mat.Scale(scale, scale, System.Drawing.Drawing2D.MatrixOrder.Append);
                // 中央へ平行移動
                mat.Translate((dst_width - src_width * scale) / 2f, 0f, System.Drawing.Drawing2D.MatrixOrder.Append);
			}
            // 横方向に画像表示をあわせる場合
            else
            {
                // スケール
                scale = dst_width / (float)src_width;
                mat.Scale(scale, scale, System.Drawing.Drawing2D.MatrixOrder.Append);
                // 中央へ平行移動
                mat.Translate(0f, (dst_height - src_height * scale) / 2f, System.Drawing.Drawing2D.MatrixOrder.Append);
            }

        }
        /// <summary>
        /// 指定した点を中心に拡大縮小するアフィン変換行列の計算
        /// </summary>
        /// <param name="mat">アフィン変換行列</param>
        /// <param name="scale">拡大縮小の倍率</param>
        /// <param name="center">拡大縮小の中心座標</param>
        public static void ScaleAt(this System.Drawing.Drawing2D.Matrix mat, float scale, PointF center)
		{
            // 原点へ移動
            mat.Translate(-center.X, -center.Y, System.Drawing.Drawing2D.MatrixOrder.Append);
            // 拡大・縮小
            mat.Scale(scale, scale, System.Drawing.Drawing2D.MatrixOrder.Append);
            // 元の座標へ移動
            mat.Translate(center.X, center.Y, System.Drawing.Drawing2D.MatrixOrder.Append);
        }

        /// <summary>
        /// 指定した矩形の画像を作成する
        /// </summary>
        /// <param name="mat">アフィン変換行列</param>
        /// <param name="rect">描画範囲</param>
        /// <param name="origin">元画像</param>
        /// <param name="clone">描画先画像</param>
        public static void CloneRectImage(this System.Drawing.Drawing2D.Matrix mat, RectangleF rect, Bitmap origin, ref Bitmap clone)
        {
            if (origin == null)
            {
                return;
            }
            if (rect.Width <= 0 || rect.Height <= 0)
			{
                return;
			}
			Graphics graph = Graphics.FromImage(clone);
            // 画像の左上、右上、左下の座標
            var points = new PointF[]
            {
                new PointF(0, 0),
                new PointF(clone.Width, 0),
                new PointF(0, clone.Height)
            };
            //// アフィン変換で描画先の座標に変換する
            //mat.TransformPoints(points);
            // 描画
            graph.DrawImage(origin, points, rect, GraphicsUnit.Pixel);
        }
    }
}
