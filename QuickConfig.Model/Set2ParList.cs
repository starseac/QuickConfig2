using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using QuickConfig.Model.app;
using QuickConfig.Model.db;
using QuickConfig.Model.pars;

namespace QuickConfig.Model
{
    public class parset
    {
        public string id;
        public string key;
        public string value;

    }


    public class Set2ParList
    {

        public List<parset> getList(Set set)
        {
            List<parset> parsList = new List<parset>();

            setPars(parsList, set.Apps.Name, set.Apps);
            foreach (ServiceApp sa in set.Apps.ServiceAppList)
            {
                setPars(parsList, sa.Name, sa);
            }
            foreach (WebApp sa in set.Apps.WebAppList)
            {
                setPars(parsList, sa.Name, sa);
            }
            foreach (App sa in set.Apps.AppList)
            {
                setPars(parsList, sa.Name, sa);
            }
            foreach (Ftp sa in set.Apps.FtpList)
            {
                setPars(parsList, sa.Name, sa);
            }
            foreach (Gxml sa in set.Apps.GxmlList)
            {
                setPars(parsList, sa.Name, sa);
            }

            setPars(parsList, set.Db.Name, set.Db);
            setPars(parsList, set.Db.DbSystemUser.Name, set.Db.DbSystemUser);
            foreach (DbUser sa in set.Db.DbUserList)
            {
                setPars(parsList, sa.Name, sa);
            }
            foreach (DbSdeUser sa in set.Db.DbSdeUserList)
            {
                setPars(parsList, sa.Name, sa);
            }

            foreach (Par sa in set.Pars.ParList)
            {
                setPars(parsList, sa.Key, sa);
            }

            setPars(parsList, set.Backup.Name, set.Backup);

            return parsList;

        }

        private void setPars(List<parset> parsList, string id, Object obj)
        {
            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string) || pi.PropertyType == typeof(bool))
                {
                    parset ps = new parset();
                    ps.id = id.ToLower();
                    ps.key = pi.Name.ToLower();
                    try
                    {
                        ps.value = pi.GetValue(obj, null).ToString();
                    }
                    catch (Exception eg)
                    {
                        ps.value = "";
                    }
                    parsList.Add(ps);
                }
            }

        }


    }
}
