using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SansTech.Net.Http;

namespace FormSmartGetIm
{
    public partial class ImViewer : Form
    {
        public ImViewer()
        {
            InitializeComponent();
        }

        public void ShowList(ImageLinkParser lparse)
        {
            ImageList images = new ImageList();
            images.ImageSize = new Size(150, 150);

            for (int i = 0; i < lparse.GoodUrls.Count; i++)
            {
                Image bmp = LoadImage(lparse.GoodUrls[i].Link);
                if (bmp != null)
                {
                    images.Images.Add(bmp);
                    listImg.Items.Add(lparse.GoodUrls[i].Filename, i);
                }
            }
            this.ShowDialog();
        }

        private Bitmap LoadImage(string url)
        {
            try
            {
                System.Net.WebRequest request =
                    System.Net.WebRequest.Create(url);

                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream =
                    response.GetResponseStream();

                Bitmap bmp = new Bitmap(responseStream);
                //Image img = Image.FromStream(responseStream);

                responseStream.Dispose();
                //img.Save(path);

                return bmp;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return null;

        }
    }
}
