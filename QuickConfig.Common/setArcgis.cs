using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.esriSystem;

namespace QuickConfig.Common
{
   public class setArcgis
    {
        public static void init()
        {
            try
            {
                ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Engine);
            }
            catch (Exception eg)
            {
                throw eg;
            }
        }

        public static void grant() {
            IAoInitialize pao = new AoInitializeClass();
            pao.Initialize(esriLicenseProductCode.esriLicenseProductCodeStandard);       
        
        }

       
    }
}
