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
        public List<UrlTrackParams> Links { get; set; }

        public event OnSelectionComplete OnSelectionCompleted;

        public delegate void OnSelectionComplete(ImViewer sender);

        public ImViewer()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            Links = new List<UrlTrackParams>();
            this.listImg.CheckBoxes = true;
        }

        public void AssignLinks(List<ImageLinks> links)
        {
            foreach (ImageLinks link in links)
            { 
                Links.Add(new UrlTrackParams(link));
            }
        }

        public void ShowList()
        {
            ImageList images = new ImageList();
            images.ImageSize = new Size(150, 150);

            for (int i = 0; i < Links.Count; i++)
            {
                //ImageLinkParams oparams = links[i];
                Image bmp = LoadImage(i);

                if (bmp != null)
                {
                    images.Images.Add(bmp);
                    string filename = UrlHelper.GetFilename(Links[i].Source);
                    listImg.Items.Add(filename, i);
                    listImg.LargeImageList = images;
                }

                //links[i] = oparams;
            }
            this.ShowDialog();
        }

        private Bitmap LoadImage(int i)
        {
            try
            {
                System.Net.WebRequest request =
                    System.Net.WebRequest.Create(Links[i].Source);

                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream =
                    response.GetResponseStream();

                Bitmap bmp = new Bitmap(responseStream);
                Links[i].Status = "Found";
                //Image img = Image.FromStream(responseStream);

                responseStream.Dispose();
                //img.Save(path);

                return bmp;
            }
            catch (Exception e)
            {
                Links[i].Status = "Invalid";
                //MessageBox.Show(e.ToString());
            }
            return null;

        }

        private void tsbtnOk_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listImg.Items.Count; i++)
            {
                if (listImg.Items[i].Checked == true)
                {
                    if (Links[i].Status != "Invalid")
                        Links[i].Status = "Selected";
                }
            }

            if (OnSelectionCompleted != null)
                OnSelectionCompleted(this);

            this.Close();
        }
    }
}
