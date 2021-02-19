using System;
using System.Windows.Forms;

namespace ImgViewer
{
	public partial class Toolbar : UserControl
	{
		public event MouseEventHandler fileButtonClick;
		public event MouseEventHandler homeButtonClick;
		public event MouseEventHandler prevButtonClick;
		public event MouseEventHandler nextButtonClick;
		public event MouseEventHandler endButtonClick;
		public event MouseEventHandler scaleupButtonClick;
		public event MouseEventHandler scaledownButtonClick;
		public event MouseEventHandler maximizeButtonClick;
		public event MouseEventHandler clockwiseButtonClick;
		public event MouseEventHandler counterclockwiseButtonClick;
		public Toolbar()
		{
			InitializeComponent();
			this.Load += Toolbar_Load;
		}

		private void Toolbar_Load(object sender, EventArgs e)
		{
			fileButton.BackgroundImageLayout = ImageLayout.Zoom;
			fileButton.BackgroundImage = Properties.Resources.file;
			fileButton.MouseClick += fileButton_MouseClick;
			homeButton.BackgroundImageLayout = ImageLayout.Zoom;
			homeButton.BackgroundImage = Properties.Resources.home;
			homeButton.MouseClick += homeButton_MouseClick;
			prevButton.BackgroundImageLayout = ImageLayout.Zoom;
			prevButton.BackgroundImage = Properties.Resources.prev;
			prevButton.MouseClick += prevButton_MouseClick;
			nextButton.BackgroundImageLayout = ImageLayout.Zoom;
			nextButton.BackgroundImage = Properties.Resources.next;
			nextButton.MouseClick += nextButton_MouseClick;
			endButton.BackgroundImageLayout = ImageLayout.Zoom;
			endButton.BackgroundImage = Properties.Resources.end;
			endButton.MouseClick += endButton_MouseClick;
			scaleupButton.BackgroundImageLayout = ImageLayout.Zoom;
			scaleupButton.BackgroundImage = Properties.Resources.scaleup;
			scaleupButton.MouseClick += scaleupButton_MouseClick;
			scaledownButton.BackgroundImageLayout = ImageLayout.Zoom;
			scaledownButton.BackgroundImage = Properties.Resources.scaledown;
			scaledownButton.MouseClick += scaledownButton_MouseClick;
			maximizeButton.BackgroundImageLayout = ImageLayout.Zoom;
			maximizeButton.BackgroundImage = Properties.Resources.maximize;
			maximizeButton.MouseClick += maximizeButton_MouseClick;
			clockwiseButton.BackgroundImageLayout = ImageLayout.Zoom;
			clockwiseButton.BackgroundImage = Properties.Resources.clockwise;
			clockwiseButton.MouseClick += clockwiseButton_MouseClick;
			counterclockwiseButton.BackgroundImageLayout = ImageLayout.Zoom;
			counterclockwiseButton.BackgroundImage = Properties.Resources.counterclockwise;
			counterclockwiseButton.MouseClick += counterclockwiseButton_MouseClick;
		}



		private void fileButton_MouseClick(object sender, MouseEventArgs e)
		{
			this.fileButtonClick(sender, e);
		}
		private void homeButton_MouseClick(object sender, MouseEventArgs e)
		{
			this.homeButtonClick(sender, e);
		}
		private void prevButton_MouseClick(object sender, MouseEventArgs e)
		{
			this.prevButtonClick(sender, e);
		}
		private void nextButton_MouseClick(object sender, MouseEventArgs e)
		{
			this.nextButtonClick(sender, e);
		}
		private void endButton_MouseClick(object sender, MouseEventArgs e)
		{
			this.endButtonClick(sender, e);
		}
		private void scaleupButton_MouseClick(object sender, MouseEventArgs e)
		{
			this.scaleupButtonClick(sender, e);
		}
		private void scaledownButton_MouseClick(object sender, MouseEventArgs e)
		{
			this.scaledownButtonClick(sender, e);
		}
		private void maximizeButton_MouseClick(object sender, MouseEventArgs e)
		{
			this.maximizeButtonClick(sender, e);
		}
		private void clockwiseButton_MouseClick(object sender, MouseEventArgs e)
		{
			this.clockwiseButtonClick(sender, e);
		}
		private void counterclockwiseButton_MouseClick(object sender, MouseEventArgs e)
		{
			this.counterclockwiseButtonClick(sender, e);
		}

	}
}
