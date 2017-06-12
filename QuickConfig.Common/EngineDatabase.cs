﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geometry;
using System.Windows.Forms;
using System.IO;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.Geoprocessor;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.Carto;

namespace QuickConfig.Common
{
    public class EngineDatabase
    {
       

        #region 获取IWorkspace

        public IWorkspace getSDEWorkspace(string server, string instance, string user, string password)
        {
            IPropertySet propertyset = new PropertySetClass();
            propertyset.SetProperty("server", server);
            propertyset.SetProperty("instance", instance);
            // propertyset.SetProperty("database", this.txt_database.Text);
            propertyset.SetProperty("user", user);
            propertyset.SetProperty("password", password);
            propertyset.SetProperty("version", @"SDE.DEFAULT");
            IWorkspaceFactory workspaceFactory = new SdeWorkspaceFactory();
            IWorkspace workspace = null;
            try
            {
                workspace = workspaceFactory.Open(propertyset, 0);
            }
            catch (Exception eg)
            {
                throw eg;


            }
            return workspace;

        }

        public IWorkspace getMDBWorkspace(string mdbfilepath)
        {
            IWorkspaceFactory pWsFac = new AccessWorkspaceFactoryClass();
            IWorkspace pWs = pWsFac.OpenFromFile(mdbfilepath, 0);

            return pWs;
        }
        public IWorkspace getFGDBWorkspace(string gdbfilepath)
        {
            IWorkspaceFactory pWsFac = new FileGDBWorkspaceFactoryClass();
            IWorkspace pWs = pWsFac.OpenFromFile(gdbfilepath, 0);

            return pWs;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath">文件路径或文件夹路径</param>
        /// <param name="type">
        /// esriDataSourcesGDB.AccessWorkspaceFactory
        //• esriDataSourcesFile.ArcInfoWorkspaceFactory
        //• esriDataSourcesFile.CadWorkspaceFactory
        //• esriDataSourcesGDB.FileGDBWorkspaceFactory
        //• esriDataSourcesOleDB.OLEDBWorkspaceFactory
        //• esriDataSourcesFile.PCCoverageWorkspaceFactory
        //• esriDataSourcesRaster.RasterWorkspaceFactory
        //• esriDataSourcesGDB.SdeWorkspaceFactory      
        //• esriDataSourcesFile.ShapefileWorkspaceFactory
        //• esriDataSourcesOleDB.TextFileWorkspaceFactory
        //• esriDataSourcesFile.TinWorkspaceFactory
        //• esriDataSourcesFile.VpfWorkspaceFactory        
        /// </param>
        /// <returns></returns>
        public IWorkspace getWorkspace(string filepath, string type)
        {
            IWorkspaceName pWorkspaceName = new WorkspaceNameClass();
            pWorkspaceName.WorkspaceFactoryProgID = type;
            pWorkspaceName.PathName = filepath;
            IName pName = pWorkspaceName as IName;
            IWorkspace pWorkspace = pName.Open() as IWorkspace;
            return pWorkspace;
        }
        #endregion


        #region featureclass

        public IFeatureClass openFeatureClass(IWorkspace pWs, string featureName)
        {
            IFeatureWorkspace pFWs = pWs as IFeatureWorkspace;
            IFeatureClass pFClass = pFWs.OpenFeatureClass(featureName);
            return pFClass;
        }

        public bool isFeatureClassEdit(IFeatureClass pFeatureClass)
        {
            IDatasetEdit pDataEdit = pFeatureClass as IDatasetEdit;
            return pDataEdit.IsBeingEdited();
        }

        public bool isFeatureClassExist(IWorkspace pWs, string featureName)
        {
            IFeatureWorkspace pFWs = pWs as IFeatureWorkspace;
            try
            {
                IFeatureClass pFClass = pFWs.OpenFeatureClass(featureName);

                if (pFClass != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception eg)
            {
                return false;
            }

        }


        public void deleteFeatureClass(IWorkspace pWs, string featureName)
        {
            IFeatureWorkspace pFWs = pWs as IFeatureWorkspace;
            IFeatureClass pFClass = pFWs.OpenFeatureClass(featureName);
            IDataset ds = pFClass as IDataset;
            ds.Delete();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workspace"></param>
        /// <param name="featureName"></param>
        /// <param name="fields"></param>
        /// <param name="featuretype"></param>
        /// <returns></returns>
        public IFeatureClass createFeatureClass(IWorkspace workspace, string featureName, IFields fields, string featuretype)
        {
            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;
            deleteFeatureClass(workspace, featureName);
            IFeatureClass pFtClass = featureWorkspace.CreateFeatureClass(featureName, fields, null, null, esriFeatureType.esriFTSimple, "SHAPE", null);
            return pFtClass;
        }

        public IFeatureClass readShpFile(string filePath)
        {
            int lastIndex = filePath.LastIndexOf(@"\");
            string filefolderpath = filePath.Substring(0, lastIndex);
            string filename = filePath.Substring(lastIndex + 1);
            IWorkspaceFactory shpwpf = new ShapefileWorkspaceFactoryClass();
            IWorkspace shpwp = shpwpf.OpenFromFile(filefolderpath, 0);
            IFeatureWorkspace shpfwp = shpwp as IFeatureWorkspace;
            IFeatureClass shpfc = shpfwp.OpenFeatureClass(filename);
            return shpfc;
        }

        #endregion

        #region 空间参考



    /// <summary>  
    /// 根据prj文件创建空间参考  
    /// </summary>  
    /// <param name="strProFile">空间参照文件</param>  
    /// <returns></returns>  
    public static ISpatialReference CreateSpatialReference(string strProFile)  
    {  
        ISpatialReferenceFactory pSpatialReferenceFactory = new SpatialReferenceEnvironmentClass();  
        ISpatialReference pSpatialReference = pSpatialReferenceFactory.CreateESRISpatialReferenceFromPRJFile(strProFile);  
        return pSpatialReference;             
    }  



    /// <summary>  
    /// 创建地理坐标系  
    /// </summary>  
    /// <param name="gcType">esriSRProjCS4Type</param>  
    /// <returns></returns>  
    public static ISpatialReference CreateGeographicCoordinate(esriSRProjCS4Type gcsType)  
    {  
        ISpatialReferenceFactory pSpatialReferenceFactory = new SpatialReferenceEnvironmentClass();  
        ISpatialReference pSpatialReference = pSpatialReferenceFactory.CreateGeographicCoordinateSystem((int)gcsType);  
        return pSpatialReference;  
    }  


    /// <summary>  
    /// 创建投影坐标系  
    /// </summary>  
    /// <param name="pcType">esriSRProjCS4Type</param>  
    /// <returns></returns>  
    public static ISpatialReference CreateProjectedCoordinate(esriSRProjCS4Type pcsType)  
    {  
        ISpatialReferenceFactory2 pSpatialReferenceFactory = new SpatialReferenceEnvironmentClass();  
        ISpatialReference pSpatialReference = pSpatialReferenceFactory.CreateProjectedCoordinateSystem((int)pcsType);  
        return pSpatialReference;  
    }  



    /// <summary>  
    /// 获取空投影  
    /// </summary>  
    /// <returns></returns>  
    public static ISpatialReference CreateUnKnownSpatialReference()  
    {  
        ISpatialReference pSpatialReference = new UnknownCoordinateSystemClass();  
        pSpatialReference.SetDomain(0, 99999999, 0, 99999999);//设置空间范围  
        return pSpatialReference;  
    }  



    /// <summary>  
    /// 获取要素集空间参考  
    /// </summary>  
    /// <param name="pFeatureDataset">要素集</param>  
    /// <returns></returns>  
    public static ISpatialReference GetSpatialReference(IFeatureDataset pFeatureDataset)  
    {  
        IGeoDataset pGeoDataset = pFeatureDataset as IGeoDataset;  
        ISpatialReference pSpatialReference = pGeoDataset.SpatialReference;  
        return pSpatialReference;             
    }  



    /// <summary>  
    /// 获取要素层空间参考  
    /// </summary>  
    /// <param name="pFeatureLayer">要素层</param>  
    /// <returns></returns>  
    public static ISpatialReference GetSpatialReference(IFeatureLayer pFeatureLayer)  
    {IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;  
        IGeoDataset pGeoDataset = pFeatureClass as IGeoDataset;  
        ISpatialReference pSpatialReference = pGeoDataset.SpatialReference;  
        return pSpatialReference;             
    }  


    /// <summary>  
    /// 获取要素类空间参考  
    /// </summary>  
    /// <param name="pFeatureClass">要素类</param>  
    /// <returns></returns>  
    public static ISpatialReference GetSpatialReference(IFeatureClass pFeatureClass)  
    {  
        IGeoDataset pGeoDataset = pFeatureClass as IGeoDataset;  
        ISpatialReference pSpatialReference = pGeoDataset.SpatialReference;  
        return pSpatialReference;             
    }  



    /// <summary>  
    /// 修改要素集空间参考  
    /// </summary>  
    /// <param name="pFeatureDataset">要素集</param>  
    /// <param name="pSpatialReference">新空间参考</param>  
    public static void AlterSpatialReference(IFeatureDataset pFeatureDataset, ISpatialReference pSpatialReference)  
    {  
        IGeoDataset pGeoDataset = pFeatureDataset as IGeoDataset;  
        IGeoDatasetSchemaEdit pGeoDatasetSchemaEdit = pGeoDataset as IGeoDatasetSchemaEdit;  
        if (pGeoDatasetSchemaEdit.CanAlterSpatialReference == true)  
            pGeoDatasetSchemaEdit.AlterSpatialReference(pSpatialReference);  
    }  



    /// <summary>  
    /// 修改要素类空间参考  
    /// </summary>  
    /// <param name="pFeatureClass">要素类</param>  
    /// <param name="pSpatialReference">新空间参考</param>  
    public static void AlterSpatialReference(IFeatureClass pFeatureClass, ISpatialReference pSpatialReference)  
    {  
        IGeoDataset pGeoDataset = pFeatureClass as IGeoDataset;  
        IGeoDatasetSchemaEdit pGeoDatasetSchemaEdit = pGeoDataset as IGeoDatasetSchemaEdit;  
        if (pGeoDatasetSchemaEdit.CanAlterSpatialReference == true)  
            pGeoDatasetSchemaEdit.AlterSpatialReference(pSpatialReference);  
    }  

    #endregion


        #region featuredataset


    public void createFeatureDataset(IWorkspace workspace, IFeatureWorkspace featureworkspace, IFeatureDataset featuredataset, ISpatialReference spatialRef, string user, string featureDatasetName)
        {
            featureworkspace = workspace as IFeatureWorkspace;
            //定义空间参考
           // ISpatialReferenceFactory spatialReferenceFactory = new SpatialReferenceEnvironment();
            ISpatialReference spatialReference = spatialRef;           
            spatialReference.SetDomain(-1000, -1000, 1000, 1000);

            IEnumDatasetName enumDatasetName;
            IDatasetName datasetName;
            string dsName = "";
            enumDatasetName = workspace.get_DatasetNames(esriDatasetType.esriDTFeatureDataset);
            datasetName = enumDatasetName.Next();
            bool isExist = false;

            //创建适量数据集
            // string featureDatasetName = "TEST";
            if (user == "")
            {
                dsName = featureDatasetName.ToUpper().ToString();
            }
            else
            {
                dsName = user.ToUpper().ToString() + "." + featureDatasetName.ToUpper().ToString();
            }
            while (datasetName != null)
            {
                if (datasetName.Name == dsName)
                {
                    isExist = true;
                   // MessageBox.Show("要素集已存在!");
                    Form form = new Form();
                    form.SetBounds(300, 300, 300, 300);
                    setMessage.MessageShow("", "要素集已存在!", form);
                    return;
                }
                datasetName = enumDatasetName.Next();

            }

            if (isExist == false)
            {
                featuredataset = featureworkspace.CreateFeatureDataset(featureDatasetName, spatialReference);
                //MessageBox.Show("要素集创建成功!");
                Form form = new Form();
                form.SetBounds(300, 300, 300, 300);
                setMessage.MessageShow("", "要素集创建成功!", form);
               
            }

        }

        public bool isFeatureDatasetExist(IWorkspace workspace, string featuredatasetname)
        {
            IFeatureWorkspace pFWs = workspace as IFeatureWorkspace;
            try
            {
                IFeatureDataset pFClass = pFWs.OpenFeatureDataset(featuredatasetname);

                if (pFClass != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception eg)
            {
                return false;
            }
        }

        public void deleteFeatureDataset(IWorkspace workspace, string featuredatasetname)
        {
            IFeatureWorkspace pFWs = workspace as IFeatureWorkspace;
            IFeatureDataset pFClass = pFWs.OpenFeatureDataset(featuredatasetname);
            IDataset ds = pFClass as IDataset;
            ds.Delete();
        }

        #endregion

        #region create file
        public bool createGDBFile(string gdbfolderpath, string filename)
        {
            // IWorkspace workspace = null;
            IWorkspaceName workspaceName = null;
            // IName name = null;
            try
            {
                IWorkspaceFactory wsf = new FileGDBWorkspaceFactoryClass();
                workspaceName = wsf.Create(gdbfolderpath, filename, null, 0);
                // name = workspaceName as IName;

                if (workspaceName != null)
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception eg)
            {
                return false;
            }
        }


        public bool createMDBFile(string mdbfolderpath, string filename)
        {
            // IWorkspace workspace = null;
            IWorkspaceName workspaceName = null;
            // IName name = null;
            try
            {
                IWorkspaceFactory wsf = new AccessWorkspaceFactoryClass();
                workspaceName = wsf.Create(mdbfolderpath, filename, null, 0);
                // name = workspaceName as IName;

                if (workspaceName != null)
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception eg)
            {
                return false;
            }

        }


        public string createSDE(string dbtype, string instance, string db_admin, string db_admin_password, string sde_admin, string sde_admin_password, string tablespacename, string authorfilepath)
        {
            CreateEnterpriseGeodatabase createSDE = new CreateEnterpriseGeodatabase();
            createSDE.database_platform = dbtype;
            createSDE.instance_name = instance;
            createSDE.database_admin = db_admin;
            createSDE.database_admin_password = db_admin_password;
            createSDE.gdb_admin_name = sde_admin;
            createSDE.gdb_admin_password = sde_admin_password;
            createSDE.tablespace_name = tablespacename;
            createSDE.authorization_file = authorfilepath;

            Geoprocessor gp = new Geoprocessor();
            //设置参数  
            
            //执行Intersect工具  
           string ans=RunTool(gp, createSDE, null);

           return ans;
        }


        private string RunTool(Geoprocessor geoprocessor, IGPProcess process, ITrackCancel TC)
        {
            // Set the overwrite output option to true  
            geoprocessor.OverwriteOutput = true;
            string ans = "";
            try
            {
                geoprocessor.Execute(process, null);
                ans=ReturnMessages(geoprocessor);

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                ans = ReturnMessages(geoprocessor);
            }

            return ans;
        }

        // Function for returning the tool messages.  
        private string ReturnMessages(Geoprocessor gp)
        {
            string ms = "";
            if (gp.MessageCount > 0)
            {
                for (int Count = 0; Count <= gp.MessageCount - 1; Count++)
                {
                    ms += gp.GetMessage(Count);
                }
            }
            return ms;
        }

        #endregion


        #region table

        public void deleteTable(IWorkspace pWorkspace, string tableName)
        {
            IFeatureWorkspace pFWs = pWorkspace as IFeatureWorkspace;
            ITable pFClass = pFWs.OpenTable(tableName);
            IDataset ds = pFClass as IDataset;
            ds.Delete();

        }

        public bool isTableExist(IWorkspace pWorkspace, string tableName)
        {
            IFeatureWorkspace pFWs = pWorkspace as IFeatureWorkspace;
              ITable pFClass =null;
            try
            {
                 pFClass = pFWs.OpenTable(tableName);
            }catch(Exception eg){
                return false;
            }
            if (pFClass != null)
            {
                return true;
            }
            else {
                return false;
            }

        }

        public ITable CreateTable(IWorkspace pWorkspace, string tableName, string tableAliasName, IFields flds)
        {
            if (pWorkspace == null) return null;
            IFeatureWorkspace aFeaWorkspace = pWorkspace as IFeatureWorkspace;
            if (aFeaWorkspace == null) return null;
            ITable aTable = null;
            try
            {
                if (isTableExist(pWorkspace, tableName))
                {
                    deleteTable(pWorkspace, tableName);
                }               
                aTable = aFeaWorkspace.CreateTable(tableName, flds, null, null, null);
            }
            catch (Exception ex)
            {
                return null;
            }

            return aTable;
        }

        #endregion



        #region 导入导出

        public void importSHP2SDE(IFeatureWorkspace featureworkspace, IFeatureDataset featuredataset, string featureDatasetName, string fileName)
        {

            int lastIndex = fileName.LastIndexOf(@"\");
            string filepath = fileName.Substring(0, lastIndex);
            string file = fileName.Substring(lastIndex + 1);
            //读取shp文件
            IWorkspaceFactory shpwpf = new ShapefileWorkspaceFactoryClass();
            IWorkspace shpwp = shpwpf.OpenFromFile(filepath, 0);
            IFeatureWorkspace shpfwp = shpwp as IFeatureWorkspace;
            IFeatureClass shpfc = shpfwp.OpenFeatureClass(file);


            //导入shp文件
            IFeatureClass sdeFeatureClass = null;
            IFeatureClassDescription featureClassDescription = new FeatureClassDescriptionClass();
            IObjectClassDescription objectClassDescription = featureClassDescription as IObjectClassDescription;
            IFields fields = shpfc.Fields;
            IFieldChecker fieldChecker = new FieldCheckerClass();
            IEnumFieldError enumFieldError = null;
            IFields validateFields = null;
            fieldChecker.ValidateWorkspace = featureworkspace as IWorkspace;
            fieldChecker.Validate(fields, out enumFieldError, out validateFields);
            featuredataset = featureworkspace.OpenFeatureDataset(featureDatasetName);

            try
            {
                sdeFeatureClass =featureworkspace.OpenFeatureClass(shpfc.AliasName);
            }
            catch(Exception eg)
            {
                //在sde数据库中创建feature class
                sdeFeatureClass = featuredataset.CreateFeatureClass(shpfc.AliasName, validateFields, objectClassDescription.InstanceCLSID,
                    objectClassDescription.ClassExtensionCLSID, shpfc.FeatureType,
                    shpfc.ShapeFieldName, "");
            }

          
            //if (sdeFeatureClass == null || sdeFeatureClass.FeatureDataset.Name != featureDatasetName)
            //{
                
            //}

            //开始编辑sde featureclass
            IFeatureCursor featureCursor = shpfc.Search(null, true);
            IFeature feature = featureCursor.NextFeature();
            IFeatureCursor sdeFeatureCursor = sdeFeatureClass.Insert(true);
            IFeatureBuffer sdeFeatureBuffer;
            //导入数据
            while (feature != null)
            {
                sdeFeatureBuffer = sdeFeatureClass.CreateFeatureBuffer();
                IField shpField = new FieldClass();
                IFields shpFields = feature.Fields;
                for (int i = 0; i < shpFields.FieldCount; i++)
                {
                    shpField = shpFields.get_Field(i);
                    string fieldname = "";

                    if (shpField.Name == "FID")
                    {
                        fieldname = "OBJECTID";
                    }
                    else if (shpField.Name == "Shape")
                    {
                        fieldname = "SHAPE";
                    }
                    else if (shpField.Name == "SHAPE_Leng")
                    {
                        fieldname = "SHAPE.LEN";
                    }
                    else if (shpField.Name == "SHAPE_Area")
                    {
                        fieldname = "SHAPE.AREA";
                    }
                    else
                    {
                        fieldname = shpField.Name;
                    }
                    int index = sdeFeatureBuffer.Fields.FindField(fieldname);
                    if (index != -1 && index != 0 && fieldname != "SHAPE.LEN" && fieldname != "SHAPE.AREA")
                    {
                        if(shpField.Editable){
                         sdeFeatureBuffer.set_Value(index, feature.get_Value(i));
                        }
                    }
                }
                sdeFeatureCursor.InsertFeature(sdeFeatureBuffer);
                sdeFeatureCursor.Flush();
                feature = featureCursor.NextFeature();
            }

        }

        public string importGDB2SDEWithWorkspace(string server,string instance,string user,string password,string gdbfolder,string cs_type,string wkid,string prjpath) {
           IWorkspace workspace=this.getSDEWorkspace(server, instance, user, password);
           return this.importGDB2SDE(workspace, gdbfolder, cs_type,wkid,prjpath, user);
        
        }

        public string importGDB2SDE(IWorkspace workspace,  string gdpfolderPath,string cs_type,string wkid,string prjpath, string user)
        {
            IFeatureWorkspace featureworkspace = null;
            IFeatureDataset featuredataset = null;

            string ans = "";
            if (gdpfolderPath != "")
            {
                IWorkspaceFactory pWsFt;

                pWsFt = new FileGDBWorkspaceFactoryClass();
                IWorkspace pWs = pWsFt.OpenFromFile(gdpfolderPath, 0);
                IEnumDataset pEDataset = pWs.get_Datasets(esriDatasetType.esriDTAny);
                IDataset pDataset = pEDataset.Next();
                while (pDataset != null)
                {
                    //如果是数据集
                    if (pDataset.Type == esriDatasetType.esriDTFeatureDataset)
                    {
                        //return;
                        //创建 featureDataset
                        //ISpatialReferenceFactory spatialReferenceFactory = new SpatialReferenceEnvironment();
                        ISpatialReference spatialReference = null;

                        if (cs_type == "pcs")
                        {
                            spatialReference = CreateProjectedCoordinate((esriSRProjCS4Type)Convert.ToInt32(wkid));
                        }
                        else if (cs_type == "pcs")
                        {
                            spatialReference = CreateGeographicCoordinate((esriSRProjCS4Type)Convert.ToInt32(wkid));

                        }
                        else if (cs_type == "")
                        {
                            spatialReference = CreateSpatialReference(prjpath);
                        }


                        createFeatureDataset(workspace, featureworkspace, featuredataset, spatialReference, user, pDataset.Name);
                        featureworkspace = workspace as IFeatureWorkspace;


                        IEnumDataset pESubDataset = pDataset.Subsets;
                        IDataset pSubDataset = pESubDataset.Next();
                        while (pSubDataset != null)
                        {
                            //导入featuredateset下的 featureclass
                            IFeatureWorkspace shpfwp = pWs as IFeatureWorkspace;
                            IFeatureClass shpfc = shpfwp.OpenFeatureClass(pSubDataset.Name);


                            //导入featureclass
                            IFeatureClass sdeFeatureClass = null;
                            IFeatureClassDescription featureClassDescription = new FeatureClassDescriptionClass();
                            IObjectClassDescription objectClassDescription = featureClassDescription as IObjectClassDescription;
                            IFields fields = shpfc.Fields;
                            IFieldChecker fieldChecker = new FieldCheckerClass();
                            IEnumFieldError enumFieldError = null;
                            IFields validateFields = null;
                            fieldChecker.ValidateWorkspace = featureworkspace as IWorkspace;
                            fieldChecker.Validate(fields, out enumFieldError, out validateFields);
                            featuredataset = featureworkspace.OpenFeatureDataset(pDataset.Name);

                            try
                            {
                                sdeFeatureClass = featureworkspace.OpenFeatureClass(pSubDataset.Name);
                                deleteFeatureClass(workspace, pSubDataset.Name);
                                ans+= "已存在的要素:"+pSubDataset.Name+"删除成功\r\n";
                            }
                            catch
                            {
                                ans += "创建要素:" + pSubDataset.Name + "\r\n";
                            }

                            //在sde数据库中创建feature class
                            if (sdeFeatureClass == null || sdeFeatureClass.FeatureDataset.Name != pDataset.Name)
                            {
                                sdeFeatureClass = featuredataset.CreateFeatureClass(pSubDataset.Name, validateFields, objectClassDescription.InstanceCLSID,
                                    objectClassDescription.ClassExtensionCLSID, shpfc.FeatureType,
                                    shpfc.ShapeFieldName, "");
                            }

                            //导入featureclass 的数据
                            //开始编辑sde featureclass
                            IFeatureCursor featureCursor = shpfc.Search(null, true);
                            IFeature feature = featureCursor.NextFeature();
                            IFeatureCursor sdeFeatureCursor = sdeFeatureClass.Insert(true);
                            IFeatureBuffer sdeFeatureBuffer;
                            //导入数据
                            while (feature != null)
                            {
                                sdeFeatureBuffer = sdeFeatureClass.CreateFeatureBuffer();
                                IField shpField = new FieldClass();
                                IFields shpFields = feature.Fields;
                                for (int i = 0; i < shpFields.FieldCount; i++)
                                {
                                    shpField = shpFields.get_Field(i);
                                    string fieldname = "";

                                    if (shpField.Name == "FID")
                                    {
                                        fieldname = "OBJECTID";
                                    }
                                    else if (shpField.Name == "Shape")
                                    {
                                        fieldname = "SHAPE";
                                    }
                                    else if (shpField.Name == "SHAPE_Leng")
                                    {
                                        fieldname = "SHAPE.LEN";
                                    }
                                    else if (shpField.Name == "SHAPE_Area")
                                    {
                                        fieldname = "SHAPE.AREA";
                                    }
                                    else
                                    {
                                        fieldname = shpField.Name;
                                    }
                                    int index = sdeFeatureBuffer.Fields.FindField(fieldname);
                                    if (index != -1 && index != 0 && fieldname != "SHAPE.LEN" && fieldname != "SHAPE.AREA")
                                    {
                                        if(shpField.Editable){
                                             sdeFeatureBuffer.set_Value(index, feature.get_Value(i));
                                        }
                                    }
                                }
                                sdeFeatureCursor.InsertFeature(sdeFeatureBuffer);
                                sdeFeatureCursor.Flush();
                                feature = featureCursor.NextFeature();
                            }


                            ans+="要素:" + pSubDataset.Name + "数据导入完成\r\n";
                            pSubDataset = pESubDataset.Next();
                        }
                       
                    }
                    else if (pDataset.Type == esriDatasetType.esriDTTable)
                    {
                        // 创建表          

                        ITable table = pDataset as ITable;
                        IFields fields = table.Fields;
                        ITable sdeTable = CreateTable(workspace, pDataset.Name, pDataset.Name, fields);
                        ///导入数据                      

                        ICursor cursor = table.Search(null, true);
                        IRow row = cursor.NextRow();
                        ICursor sdeCursor = sdeTable.Insert(true);
                        IRowBuffer sdeBuffer;
                        //导入数据
                        while (row != null)
                        {
                            sdeBuffer = sdeTable.CreateRowBuffer();
                            IField shpField = new FieldClass();
                            IFields shpFields = row.Fields;
                            for (int i = 0; i < shpFields.FieldCount; i++)
                            {
                                shpField = shpFields.get_Field(i);
                                string fieldname = shpField.Name;
                                int index = sdeBuffer.Fields.FindField(fieldname);
                                if (index != -1 && fieldname!="OBJECTID")
                                {
                                    if(shpField.Editable){
                                        sdeBuffer.set_Value(index, row.get_Value(i));
                                    }
                                }
                            }
                            sdeCursor.InsertRow(sdeBuffer);
                            sdeCursor.Flush();
                            row = cursor.NextRow();


                            // FeatureClassBox.Items.Add("table_" + pDataset.Name);
                        }
                        ans += "表:" + pDataset.Name + "数据导入完成\r\n";

                    }

                    pDataset = pEDataset.Next();
                }
               
            }

            Marshal.ReleaseComObject(workspace);

            return ans;
        }

        public string exportSDE2GDBWithWorkspace(string server, string instance, string user, string password,string gdbfolder)
        {
            IWorkspace workspace = this.getSDEWorkspace(server, instance, user, password);
            return this.exportSDE2GDB(workspace, gdbfolder, user);
        }

        public string exportSDE2GDB(IWorkspace workspace, string gdpfolderPath, string user)
        {
            IFeatureWorkspace featureworkspace = null;
            IFeatureDataset featuredataset = null;

            string ans = "";
            if (gdpfolderPath != "")
            {
                IWorkspace gdbWS = getFGDBWorkspace(gdpfolderPath);
                IEnumDataset pEDataset = workspace.get_Datasets(esriDatasetType.esriDTAny);
                IDataset pDataset = pEDataset.Next();

                while (pDataset != null)
                {
                    //如果是数据集
                    if (pDataset.Type == esriDatasetType.esriDTFeatureDataset && pDataset.Name.Contains(user.ToUpper().ToString() + "."))
                    {

                        //创建 featureDataset

                        ISpatialReference spatialReference = null;

                        spatialReference = GetSpatialReference(pDataset as IFeatureDataset);


                        createFeatureDataset(gdbWS, featureworkspace, featuredataset, spatialReference, "", pDataset.Name.Replace(user.ToUpper().ToString() + ".", ""));
                        featureworkspace = gdbWS as IFeatureWorkspace;
                        ans += "要素集创建成功\r\n";

                        IEnumDataset pESubDataset = pDataset.Subsets;
                        IDataset pSubDataset = pESubDataset.Next();
                        while (pSubDataset != null)
                        {
                            //导入featuredateset下的 featureclass
                            IFeatureWorkspace shpfwp = workspace as IFeatureWorkspace;
                            IFeatureClass shpfc = shpfwp.OpenFeatureClass(pSubDataset.Name);


                            //导入featureclass
                            IFeatureClass sdeFeatureClass = null;
                            IFeatureClassDescription featureClassDescription = new FeatureClassDescriptionClass();
                            IObjectClassDescription objectClassDescription = featureClassDescription as IObjectClassDescription;
                            IFields fields = shpfc.Fields;
                            IFieldChecker fieldChecker = new FieldCheckerClass();
                            IEnumFieldError enumFieldError = null;
                            IFields validateFields = null;
                            fieldChecker.ValidateWorkspace = featureworkspace as IWorkspace;
                            fieldChecker.Validate(fields, out enumFieldError, out validateFields);
                            featuredataset = featureworkspace.OpenFeatureDataset(pDataset.Name.Replace(user.ToUpper().ToString() + ".", ""));

                            try
                            {
                                sdeFeatureClass = featureworkspace.OpenFeatureClass(pSubDataset.Name.Replace(user.ToUpper().ToString() + ".", ""));
                            }
                            catch
                            {

                            }

                            //在sde数据库中创建feature class
                            if (sdeFeatureClass == null || sdeFeatureClass.FeatureDataset.Name != pDataset.Name.Replace(user.ToUpper().ToString() + ".", ""))
                            {
                                sdeFeatureClass = featuredataset.CreateFeatureClass(pSubDataset.Name.Replace(user.ToUpper().ToString() + ".", ""), validateFields, objectClassDescription.InstanceCLSID,
                                    objectClassDescription.ClassExtensionCLSID, shpfc.FeatureType,
                                    shpfc.ShapeFieldName, "");
                                ans += "要素" + pSubDataset.Name.Replace(user.ToUpper().ToString() + ".", "") + "创建成功,";
                            }

                            //导入featureclass 的数据
                            //开始编辑sde featureclass
                            IFeatureCursor featureCursor = shpfc.Search(null, true);
                            IFeature feature = featureCursor.NextFeature();
                            IFeatureCursor sdeFeatureCursor = sdeFeatureClass.Insert(true);
                            IFeatureBuffer sdeFeatureBuffer;
                            //导入数据
                            while (feature != null)
                            {
                                sdeFeatureBuffer = sdeFeatureClass.CreateFeatureBuffer();
                                IField shpField = new FieldClass();
                                IFields shpFields = feature.Fields;
                                for (int i = 0; i < shpFields.FieldCount; i++)
                                {
                                    shpField = shpFields.get_Field(i);
                                    string fieldname = "";

                                    if (shpField.Name == "FID")
                                    {
                                        fieldname = "OBJECTID";
                                    }
                                    else if (shpField.Name == "Shape")
                                    {
                                        fieldname = "SHAPE";
                                    }
                                    else if (shpField.Name == "SHAPE_Leng")
                                    {
                                        fieldname = "SHAPE.LEN";
                                    }
                                    else if (shpField.Name == "SHAPE_Area")
                                    {
                                        fieldname = "SHAPE.AREA";
                                    }
                                    else
                                    {
                                        fieldname = shpField.Name;
                                    }
                                    int index = sdeFeatureBuffer.Fields.FindField(fieldname);
                                    if (index != -1 && index != 0 && fieldname != "SHAPE.LEN" && fieldname != "SHAPE.AREA")
                                    {
                                        if (shpField.Editable)
                                        {
                                            sdeFeatureBuffer.set_Value(index, feature.get_Value(i));
                                        }
                                    }
                                }
                                sdeFeatureCursor.InsertFeature(sdeFeatureBuffer);
                                sdeFeatureCursor.Flush();
                                feature = featureCursor.NextFeature();
                            }

                            ans += "要素" + pSubDataset.Name.Replace(user.ToUpper().ToString() + ".", "") + "数据导出成功\r\n";
                           // MessageBox.Show("" + pSubDataset.Name + "数据导入完成");
                            pSubDataset = pESubDataset.Next();
                        }
                    }
                    else

                        if (pDataset.Type == esriDatasetType.esriDTTable && pDataset.Name.Contains(user.ToUpper().ToString() + "."))
                        {
                            // 创建表          

                            ITable table = pDataset as ITable;
                            IFields fields = table.Fields;
                            ITable sdeTable = CreateTable(gdbWS, pDataset.Name.Replace(user.ToUpper().ToString() + ".", ""), pDataset.BrowseName, fields);
                            ans += "表:" + pDataset.Name.Replace(user.ToUpper().ToString() + ".", "") + "创建成功,";
                            ///导入数据                      

                            ICursor cursor = table.Search(null, true);
                            IRow row = cursor.NextRow();
                            ICursor sdeCursor = sdeTable.Insert(true);
                            IRowBuffer sdeBuffer;
                            //导入数据
                            while (row != null)
                            {
                                sdeBuffer = sdeTable.CreateRowBuffer();
                                IField shpField = new FieldClass();
                                IFields shpFields = row.Fields;
                                for (int i = 0; i < shpFields.FieldCount; i++)
                                {
                                    shpField = shpFields.get_Field(i);
                                    string fieldname = shpField.Name;
                                    int index = sdeBuffer.Fields.FindField(fieldname);
                                    if (index != -1 &&fieldname!="OBJECTID")
                                    {
                                        if(shpField.Editable){
                                            sdeBuffer.set_Value(index, row.get_Value(i));
                                        }
                                    }
                                }
                                sdeCursor.InsertRow(sdeBuffer);
                                sdeCursor.Flush();
                                row = cursor.NextRow();


                                // FeatureClassBox.Items.Add("table_" + pDataset.Name);
                            }
                            ans += "表:" + pDataset.Name.Replace(user.ToUpper().ToString() + ".", "") + "数据导出成功\r\n";
                           // MessageBox.Show("" + pDataset.Name + "表数据导入完成");

                        }
                    pDataset = pEDataset.Next();
                }
                Marshal.ReleaseComObject(gdbWS);
            }
            Marshal.ReleaseComObject(workspace);
           

            return ans;

        }


        #endregion

        //private void SetDataSource(string sMxdPath, string sTargetPath)
        //{
        //    ////获取MapDocment
        //    IMapDocument pMapDocument = new MapDocumentClass();
        //    pMapDocument.Open(sMxdPath, "");

        //    ////创建一个MapControl
        //    IMapControl2 pMapControl = new MapControlClass();
        //    string sFileName = sMxdPath;
        //    pMapControl.LoadMxFile(sFileName, null, null);

        //    ////创建一个工作空间
        //    IWorkspaceFactory pWorkFactory = new AccessWorkspaceFactoryClass();
        //    IWorkspace pWorkspace = pWorkFactory.OpenFromFile(sTargetPath, 0);

        //    ////获取工作空间中的全部Dataset
        //    IEnumDataset pEnumDataSet = pWorkspace.get_Datasets(esriDatasetType.esriDTFeatureDataset);
        //    IDataset pDataSet = pEnumDataSet.Next();
        //    ISpatialReference pRef = (pDataSet as IGeoDataset).SpatialReference;

        //    string sDistrictCode = string.Empty;
        //    string sScale = string.Empty;

        //    if (pDataSet != null)
        //    {
        //        UID uid = new UIDClass();
        //        uid.Value = "{" + typeof(IFeatureLayer).GUID.ToString() + "}";
        //        IEnumLayer pEnumLayer = pMapControl.Map.get_Layers(uid, true);
        //        IFeatureLayer pFeaLyr = pEnumLayer.Next() as IFeatureLayer;
        //        IFeatureWorkspace pFeaClsWks = pWorkspace as IFeatureWorkspace;
        //        while (pFeaLyr != null)
        //        {
        //            string sDsName = ((pFeaLyr as IDataLayer).DataSourceName as IDatasetName).Name;
        //            if ((pWorkspace as IWorkspace2).get_NameExists(esriDatasetType.esriDTFeatureClass, sDsName))
        //            {
        //                pFeaLyr.FeatureClass = pFeaClsWks.OpenFeatureClass(sDsName);
        //                pFeaLyr.Name = pFeaLyr.Name;
        //            }

        //            pFeaLyr = pEnumLayer.Next() as IFeatureLayer;
        //        }
        //        //释放资源，防止出现Ox80040228，出现资源锁定错误
        //        ESRI.ArcGIS.ADF.ComReleaser.ReleaseCOMObject(pWorkspace);
        //        ESRI.ArcGIS.ADF.ComReleaser.ReleaseCOMObject(pFeaClsWks);
        //        //pMapControl.Map.SpatialReference = pRef;
        //        //IMxdContents pMxdC;
        //        //pMxdC = pMapControl.Map as IMxdContents;
        //        //pMapDocument.Open((pMapControl as IMapControl3).DocumentFilename, "");
        //        //pMapDocument.ReplaceContents(pMxdC);
        //        //pMapDocument.Save(true, true);
        //    }
        //}






    }
}
