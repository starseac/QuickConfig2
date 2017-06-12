using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickConfig.Controls.DbInit
{
    public partial class sdeCoordinateSystemSet : UserControl
    {
        public sdeCoordinateSystemSet()
        {
            InitializeComponent();
            setPCS();
            setGCS();
        }

        private string _name;
        public string Name {
            get { return _name; }
            set { this._name = value; }
        }

        public string _cs_type;
        public string CS_TYPE
        {
            get { return getCS_TYPE(); }
            set { setCS_TYPE(value); }
        }

        private string getCS_TYPE() {
            string type="";
            if(this.tabControl1.SelectedIndex==0){
                type = "pcs";
            }
            else if (this.tabControl1.SelectedIndex == 1)
            {
                type = "gcs";
            }
            else if (this.tabControl1.SelectedIndex == 2)
            {
                type = "";            
            }
            return type;        
        }

        private void setCS_TYPE(string type) {
          
            if ( type=="pcs")
            {
               this.tabControl1.SelectedIndex=0;
            }
            else if (type == "gcs")
            {
                this.tabControl1.SelectedIndex = 1;
            }
            else if (type == "")
            {
                this.tabControl1.SelectedIndex = 2;
            }

            _cs_type = type;
        
        }


        public string WKID
        {
            get { return getWKID(); }
            set { setWKID(value); }

        }

        public string Prjpath {
            get { return this.txt_PRJPath.Text.ToString(); }
            set { this.txt_PRJPath.Text = value; }
        
        }

       private string  getWKID (){
           string wkid="";
           if (_cs_type == "pcs")
           {
               wkid = this.txt_PCS.SelectedValue.ToString();
           
           }
           else  if (_cs_type == "gcs")
           {
               wkid = this.txt_GCS.SelectedValue.ToString();

           }
           else if (_cs_type == "")
           {
               wkid = "";
           }
           return wkid;
       
       }

       private void setWKID(string wkid) {
           if (_cs_type == "pcs")
           {
                this.txt_PCS.SelectedValue=wkid;
           }
           else if (_cs_type == "gcs")
           {
               this.txt_GCS.SelectedValue=wkid;
           }              
       
       }


        private void setPCS(){
          Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("西安1980 3度分带 25度带", "2349");
            dic.Add("西安1980 3度分带 26度带", "2350");
            dic.Add("西安1980 3度分带 27度带", "2351");
            dic.Add("西安1980 3度分带 28度带", "2352");
            dic.Add("西安1980 3度分带 29度带", "2353");
            dic.Add("西安1980 3度分带 30度带", "2354");
            dic.Add("西安1980 3度分带 31度带", "2355");
            dic.Add("西安1980 3度分带 32度带", "2356");
            dic.Add("西安1980 3度分带 33度带", "2357");
            dic.Add("西安1980 3度分带 34度带", "2358");
            dic.Add("西安1980 3度分带 35度带", "2359");
            dic.Add("西安1980 3度分带 36度带", "2360");
            dic.Add("西安1980 3度分带 37度带", "2361");
            dic.Add("西安1980 3度分带 38度带", "2362");
            dic.Add("西安1980 3度分带 39度带", "2363");
            dic.Add("西安1980 3度分带 40度带", "2364");
            dic.Add("西安1980 3度分带 41度带", "2365");
            dic.Add("西安1980 3度分带 42度带", "2366");
            dic.Add("西安1980 3度分带 43度带", "2367");
            dic.Add("西安1980 3度分带 44度带", "2368");
            dic.Add("西安1980 3度分带 45度带", "2369");
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Id", typeof(string));
            //然后把你想要加的数据加进DataTable 里
            foreach (var item in dic)
            {
                dt.Rows.Add(new object[] { item.Key, item.Value });
            }

            this.txt_PCS.Items.Clear();
            this.txt_PCS.DataSource = dt;
            this.txt_PCS.DisplayMember = "Name";
            this.txt_PCS.ValueMember = "Id";
        
        }


        private void setGCS()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("北京 1954", "4214");           
            dic.Add("西安1980", "4610");
            dic.Add("2000中国大地坐标系", "4490");
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Id", typeof(string));
            //然后把你想要加的数据加进DataTable 里
            foreach (var item in dic)
            {
                dt.Rows.Add(new object[] { item.Key, item.Value });
            }

            this.txt_GCS.Items.Clear();
            this.txt_GCS.DataSource = dt;
            this.txt_GCS.DisplayMember = "Name";
            this.txt_GCS.ValueMember = "Id";
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                _cs_type = "pcs";
            }
            else if (this.tabControl1.SelectedIndex == 1)
            {
                _cs_type = "gcs";
            }
            else if (this.tabControl1.SelectedIndex == 2)
            {
                _cs_type = "";
            }
        }

        private void btn_path_Click(object sender, EventArgs e)
        {
            string Path = Common.filePath("prj");
            this.txt_PRJPath.Text = Path == "" ? this.txt_PRJPath.Text : Path;
        }


       
    }
}
