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

            listImg.SelectedIndexChanged += new EventHandler(listImg_SelectedIndexChanged);
            listImg.ShowItemToolTips = true;
        }

        void listImg_SelectedIndexChanged(object sender, EventArgs e)
        {
            //list
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
            //this.ShowDialog();

            ImageList images = new ImageList();
            images.ImageSize = new Size(150, 150);
            images.ColorDepth = ColorDepth.Depth32Bit;
            //

            // first populate list
            //for (int i = 0; i < Links.Count; i++)
            //{
            //    string filename = UrlHelper.GetFilename(Links[i].Source);
            //    listImg.Items.Add(filename, i);
            //}

            // show images


            //listImg.BeginUpdate();


            for (int i = 0; i < Links.Count; i++)
            {
                //ImageLinkParams oparams = links[i];
                Image img = LoadImage(i);

                //img = null; //ToDo: Temp supress, remove this

                if (img == null)
                    img = Image.FromFile(Properties.Settings.Default.xPath);

                
                if (img != null)
                {
                    
                    Image imgThumb = img.GetThumbnailImage(180, 180, null, new IntPtr());
                    images.Images.Add(imgThumb);
                    string filename = UrlHelper.GetFilename(Links[i].Source);
                    ListViewItem item = new ListViewItem(filename, i);
                    
                    item.ToolTipText = Links[i].Source;
                    listImg.Items.Add(item);
                    listImg.LargeImageList = images;
                    


                }

                //links[i] = oparams;
            }

            //listImg.EndUpdate();
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
                if (listImg.Items[i].Checked == true || listImg.Items[i].Selected)
                {
                    if (Links[i].Status != "Invalid")
                        Links[i].Status = "Selected";
                }
            }

            if (OnSelectionCompleted != null)
                OnSelectionCompleted(this);

            this.Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SelectItems(SelectMode.All);
        }

        private void SelectItems(SelectMode mode)
        {
            foreach (ListViewItem item in listImg.Items)
            {
                switch (mode)
                {
                    case SelectMode.All:
                        item.Selected = true;
                        break;

                    case SelectMode.None:
                        item.Selected = false;
                        break;

                    case SelectMode.Inverse:
                        item.Selected = !item.Selected;
                        break;
                }
            }
        }

        private enum SelectMode
        { 
            All,
            None,
            Inverse
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            SelectItems(SelectMode.None);
        }

        private void btnSelectInverse_Click(object sender, EventArgs e)
        {
            SelectItems(SelectMode.Inverse);
        }
    }
}
