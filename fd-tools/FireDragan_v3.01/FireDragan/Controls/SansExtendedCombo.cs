using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
//using System.Linq;

namespace FireDragan
{
    class SansExtendedCombo : ComboBox
    {
        #region Constructor
        public SansExtendedCombo()
		{
            DrawMode		= DrawMode.OwnerDrawVariable;
            _separatorStyle = DashStyle.Solid;
            _separators		= new ArrayList();

            _separatorStyle		= DashStyle.Solid;
            _separatorColor		= Color.Black;
            _separatorMargin	= 1;
            _separatorWidth		= 1;
            _autoAdjustItemHeight = false;

            //lstBindingList = new BindingList<string>(
            //                        FontFamily.Families.Select(b => b.Name).ToList());
            //base.DataSource = lstBindingList;
            base.Leave += new System.EventHandler(this.OnLeave);
		}
       
		#endregion

		#region Medthods

		public void AddString(string s)
		{
			Items.Add(s);
		}

		public void AddStringWithSeparator(string s)
		{
			Items.Add(s);
			_separators.Add(s);
		}

		public void SetSeparator(int pos)
		{
			_separators.Add(pos);
		}

		#endregion

		#region Properties
        [Description("Gets or sets max number of recent items"), Category("ExtComobo")]
        [Browsable(true)]
        [DefaultValue(true)]
        public bool  Rememeber
        {
            get { return _isRememeber; }
            set { _isRememeber = value; }
        }
        
        [Description("Gets or sets max number of recent items"), Category("ExtComobo")]
        [Browsable(true)]
        [DefaultValue(0)] 
        public int MaxRecentItems 
        {
            get{return _intMaxRecentItems;}
            set { _intMaxRecentItems = value; }
        }
        
        [Description("Gets or sets the Separator Style"), Category("ExtComobo")]
		public DashStyle SeparatorStyle
		{
			get{ return _separatorStyle; }
			set{ _separatorStyle = value; }
		}

        [Description("Gets or sets the Separator Color"), Category("ExtComobo")]
		public Color SeparatorColor
		{
			get{ return _separatorColor; }
			set{ _separatorColor = value; }
		}

        [Description("Gets or sets the Separator Width"), Category("ExtComobo")]
		public int SeparatorWidth
		{
			get{ return _separatorWidth; }
			set{ _separatorWidth = value; }
		}

        [Description("Gets or sets the Separator Margin"), Category("ExtComobo")]
		public int SeparatorMargin
		{
			get{ return _separatorMargin; }
			set{ _separatorMargin = value; }
		}

		[Description("Gets or sets Auto Adjust Item Height"), Category("Separator")]
		public bool AutoAdjustItemHeight
		{
			get{ return _autoAdjustItemHeight; }
			set{ _autoAdjustItemHeight = value; }
		}

		#endregion

		#region Overrides

		protected override void OnMeasureItem(MeasureItemEventArgs e)
		{
			if (_autoAdjustItemHeight)
				e.ItemHeight += _separatorWidth;

			base.OnMeasureItem(e);
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			if (-1 == e.Index) return;
 
			bool sep = false;
			object o;
			for (int i=0; !sep && i<_separators.Count; i++)
			{ 
				o = _separators[i];

				if (o is string)
				{
					if ((string)this.Items[e.Index] == o as string) 
						sep = true;
				}
				else 
				{
					int pos = (int)o;
					if (pos<0) pos += Items.Count;

					if (e.Index == pos) sep = true;
				}
			}

			e.DrawBackground();
			Graphics g = e.Graphics;
			int y = e.Bounds.Location.Y +_separatorWidth-1;	

			if (sep)
			{
				Pen pen = new Pen(_separatorColor, _separatorWidth);
				pen.DashStyle = _separatorStyle;

				g.DrawLine(pen, e.Bounds.Location.X+_separatorMargin, y, e.Bounds.Location.X+e.Bounds.Width-_separatorMargin, y);
				y++;
			}

			Brush br = DrawItemState.Selected == (DrawItemState.Selected & e.State)? SystemBrushes.HighlightText: new SolidBrush(e.ForeColor);
			g.DrawString(Items[e.Index].ToString (), e.Font, br, e.Bounds.Left, y+1);	
			//			e.DrawFocusRectangle();

			base.OnDrawItem(e);
		}

        protected void OnLeave(object sender, EventArgs e) 
        {
            if (base.Text == null )
                return;

            if (RecentItems ==  null)
                RecentItems = new RecentItemsContainer("ExtCombo", MaxRecentItems, Rememeber);

            RecentItems.Add(base.Text);
            //
            List<RecentItemsList> strlis = RecentItems.Get();

            foreach (RecentItemsList str in strlis)
            {
               lstBindingList.Insert(0, str.ReceneItems );
            }
            base.DataSource = lstBindingList;
            SetSeparator(strlis.Count);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        //[System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing )
            {
                lstBindingList.Clear();
                lstBindingList = null;
                _separators = null;
                RecentItems = null;
            }
            base.Dispose(disposing);
        }

        ///// <summary>
        ///// Call this Method to Bind the Fonts
        ///// </summary>
        //public void BindFonts()
        //{
        //    lstBindingList = new BindingList<string>(
        //                                      FontFamily.Families.Select(b => b.Name).ToList());
        //    base.DataSource = lstBindingList;
        //}
		#endregion

		#region Data members

		ArrayList	_separators;
		DashStyle	_separatorStyle;
		Color		_separatorColor;
		int			_separatorWidth;
		int			_separatorMargin;
		bool		_autoAdjustItemHeight;
        int          _intMaxRecentItems;
        bool         _isRememeber;
        RecentItemsContainer RecentItems = null;
        private BindingList<string> lstBindingList; 
        
		#endregion
       
    }
}
