using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.definebtns;

namespace QuickConfig.Controls.ToolSet
{
    public partial class btnSet : UserControl
    {
        public btnSet()
        {
            InitializeComponent();
        }

        private void addControl(Control ctl) {
            this.flowLayoutPanel1.Controls.Add(ctl);
            allBtnControls.Add(ctl);
        
        }

        public Btn btn {
            get { return getBtn(); }
            set { this._btn = value; }
        }

        Btn _btn;

       List<Control> allBtnControls;

        private Btn getBtn()
        {
            Btn newbtn = new Btn();

            btnDescSet newBDS = allBtnControls.Find((Control ctl)=>ctl is btnDescSet) as btnDescSet;

            newbtn.Name = newBDS.Name;
            newbtn.Desc = newBDS.Desc;
            newbtn.Type = newBDS.Type;
            newbtn.Filename = newBDS.Filename;
            newbtn.Execuser = "";
            newbtn.Install = newBDS.Install;

            execUserSet newEUS = allBtnControls.Find((Control ctl) => ctl is execUserSet) as execUserSet;
            if(newEUS!=null){
                newbtn.Execuser = newEUS.Execuser;            
            }

            List<Control> inputList = allBtnControls.FindAll((Control ctl) => ctl is InputSet) ;
            List<Input> inputCLassList = new List<Input>();
            foreach (Control input in inputList) {
                InputSet inputset = input as InputSet;
                Input inputClass = new Input();
                inputClass.Label = inputset.Label;
                inputClass.Key = inputset.Key;
                inputClass.Value = inputset.Value;
                inputCLassList.Add(inputClass);
            }

            newbtn.InputList = inputCLassList;

            return newbtn;
        }

        public string ConfigName;

        public void setValue() {
            allBtnControls = new List<Control>();
            int height = 0;
            btnDescSet bds=new btnDescSet();
            bds.ConfigName = ConfigName;
            bds.setValue(_btn);           
            addControl(bds);
            height += bds.Height;

            if (_btn.Type == "sql")
            {
                execUserSet eus = new execUserSet();
                eus.ConfigName = ConfigName;
                eus.setUserList();
                eus.setValue(_btn.Execuser);
                addControl(eus);
                height += eus.Height;
            
            }

            foreach (Input input in _btn.InputList)
            {
                InputSet inputset=new InputSet();
                inputset.setValue(input);
                addControl(inputset);
                height += inputset.Height;

            }

            this.Height = height+20;
        
        }
    }
}
