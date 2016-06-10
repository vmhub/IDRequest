using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
namespace IDTaotlus.Helpers
{
    static class HelperMethods
    {
        const string conStr = @"Data Source =fakeDB.sqlite;version=3;";

        /*Adjusts the width of a combobox based on biggest value.
         * Kohandab comboboxi laiust sõltudes textist.
         */
        public static int dropWidth(ComboBox cb)
        {
            int max = 0;
            int tmp;
            foreach (var item in cb.Items)
            {
                tmp = TextRenderer.MeasureText(item.ToString(), cb.Font).Width;
                if (tmp > max)
                {
                    max = tmp;
                }
            }
            return max;
        }
        /*Inserts data into DOCUMENTS table.
         * Sisestab andmeid DOCUMENTS table'isse.
         * 
         */
        public static void insertDoc(Documents doc)
        {
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex) { Log(ex.ToString()); }
                using (SQLiteCommand cmd = new SQLiteCommand(@"insert into documents (isikukood,docnumber,expdate,issdate) values 
                (@isik,@doc,@exp,@iss)", con))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@isik", doc.isikukood);
                        cmd.Parameters.AddWithValue("@doc", doc.docNumber);
                        cmd.Parameters.AddWithValue("@exp", doc.expDate);
                        cmd.Parameters.AddWithValue("@iss", doc.issDate);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex) { Log(ex.ToString()); }
                }
            }
        }
        /*Inserts data into IDREQUEST table if a user has a previous document.
        * Sisestab andmeid IDREQUEST table'isse kui inimesele oli varem dokument olnud.
        * 
         */
        public static void insertReq(IDRequest doc)
        {
            string docid = null;
            docid = getDocId(doc);
            insertIdReq(doc, docid);
        }
        /*Gets the data from DOCUMENTS table and returns it in an Documents object form.
         * Võtab andmeid DOCUMENTS table'ist ja annab seda tagasi Documents objekti vormis.
         */

        public static Documents getDoc(string isik)
        {
            Documents docs = null;
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex) { Log(ex.ToString()); }
                using (SQLiteCommand cmd = new SQLiteCommand(@"select * from documents where isikukood = @isik order by docid desc limit 1", con))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@isik", isik);
                        using (SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                if (dr.HasRows)
                                {
                                    docs = new Documents
                                    {
                                        docid = Convert.ToUInt32(dr[0].ToString()),
                                        isikukood = Convert.ToUInt32(dr[1].ToString()),
                                        docNumber = (string)dr[2],
                                        expDate = (string)dr[3],
                                        issDate = (string)dr[4],
                                    };
                                    return docs;
                                }
                            }
                        }

                    }
                    catch (Exception ex) { Log(ex.ToString()); }
                }
            } return null;
        }

        /*Gets the data from IDREQUEST table and returns it in an IDRequest object form.
           * Võtab andmeid IDREQUEST table'ist ja annab seda tagasi IDRequest objekti vormis.
           */
        public static IDRequest fillObj(string isik)
        {
            IDRequest req = null;
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex) { Log(ex.ToString()); }
                using (SQLiteCommand cmd = new SQLiteCommand("select * from idrequest where isikukood = @isik order by reqid desc limit 1", con))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@isik", isik);
                        using (SQLiteDataReader dr = cmd.ExecuteReader())
                        {

                            while (dr.Read())
                            {
                                if (dr.HasRows)
                                {
                                    req = new IDRequest
                                    {
                                        reqId = Convert.ToUInt32(dr["reqid"].ToString()),
                                        address = (string)dr["address"],
                                        bDay = (string)dr["bday"],
                                        country = (string)dr["country"],
                                        county = (string)dr["county"],
                                        delivery = Convert.ToUInt16(dr["delivery"].ToString()),
                                        firstName = (string)dr["fname"],
                                        gender = Convert.ToByte(dr["gender"].ToString()),
                                        isikukood = Convert.ToUInt32(dr["isikukood"].ToString()),
                                        lastName = (string)dr["lname"],
                                        nationality = (string)dr["nationality"],
                                        owner = Convert.ToUInt32(dr["owner"].ToString()),
                                        photo = (byte[])dr["photo"],
                                        pin = Convert.ToUInt32(dr["pin"].ToString()),
                                        representative = dr["representative"].ToString(),
                                        reqState = Convert.ToByte(dr["reqstate"].ToString())
                                    };
                                    if (dr["prevdoc"] == DBNull.Value)
                                    {
                                        return req;
                                    }
                                    else
                                    {
                                        req.prevDoc = getDoc(isik);
                                        return req;
                                    }

                                }

                            }
                        }

                    }
                    catch (Exception ec) { Log(ec.ToString()); }
                    return null;
                }
            }
        }


        /*Inerts data into IDREQUEST table from IDRequest object.
         * Sisestab andmeid IDREQUEST table'isse kasutades IDRequest object'i.
         */
        public static void insertIdReq(IDRequest doc, object val)
        {
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex) { Log(ex.ToString()); }
                using (SQLiteCommand cmd = new SQLiteCommand(@"insert into idrequest (owner,fname,lname,isikukood,gender,
                nationality,bday,photo,address,county,country,pin,prevdoc,delivery,reqstate,representative) values 
                (@own,@fname,@lname,@isik,@gen,@nat,@bday,@photo,@addr,@county,@country,@pin,@prev,@deliv,@state,@reppie)", con))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@isik", doc.isikukood);
                        cmd.Parameters.AddWithValue("@own", doc.owner);
                        cmd.Parameters.AddWithValue("@fname", doc.firstName);
                        cmd.Parameters.AddWithValue("@lname", doc.lastName);
                        cmd.Parameters.AddWithValue("@gen", doc.gender);
                        cmd.Parameters.AddWithValue("@nat", doc.nationality);
                        cmd.Parameters.AddWithValue("@bday", doc.bDay);
                        cmd.Parameters.Add("@photo", System.Data.DbType.Binary, doc.photo.Length);
                        cmd.Parameters["@photo"].Value = doc.photo;
                        cmd.Parameters.AddWithValue("@addr", doc.address);
                        cmd.Parameters.AddWithValue("@county", doc.county);
                        cmd.Parameters.AddWithValue("@country", doc.country);
                        cmd.Parameters.AddWithValue("@pin", doc.pin);
                        cmd.Parameters.AddWithValue("@prev", val);
                        cmd.Parameters.AddWithValue("@deliv", doc.delivery);
                        cmd.Parameters.AddWithValue("@state", doc.reqState);
                        cmd.Parameters.AddWithValue("@reppie", doc.representative);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex) { Log(ex.ToString()); }
                }
            }
        }
        /*Checks if the user has previously sent a request.
         * Kontrollib kas kasutaja on varem saatnud taotluse.
         */
        public static string checkState(string isik)
        {
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex) { Log(ex.ToString()); }
                using (SQLiteCommand cmd = new SQLiteCommand("select reqstate from idrequest where isikukood = @isik order by reqid desc limit 1", con))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@isik", isik);
                        using (SQLiteDataReader dr = cmd.ExecuteReader())
                        {

                            while (dr.Read())
                            {
                                if (dr.HasRows)
                                    return (dr["reqstate"].ToString());
                            }
                        }

                    }
                    catch (Exception ec) { Log(ec.ToString()); }
                    return null;
                }
            }
        }
        /*Checks whether this username/password exists.
         * Kontrollib kas selline kasutaja on süsteemis olemas.
         */
        public static string checkCred(out string userid, string user, string pass)
        {
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex) { Log(ex.ToString()); }
                using (SQLiteCommand cmd = new SQLiteCommand("select userid,isikukood from users where username=@username and password=@password", con))
                {
                    cmd.Parameters.AddWithValue("@username", user);
                    cmd.Parameters.AddWithValue("@password", pass);
                    try
                    {
                        using (SQLiteDataReader dr = cmd.ExecuteReader())
                        {

                            while (dr.Read())
                            {
                                if (dr.HasRows)
                                {
                                    userid = dr[0].ToString();
                                    return (dr[1].ToString());
                                }
                            }
                        }
                    }
                    catch (Exception ec) { Log(ec.ToString()); }
                    userid = null;
                    return null;
                }
            }
        }
        /* Get last id from IDREQUEST table.
         * Leia viimast ID IDREQUEST table'ist.
         */
        public static string getReqId(IDRequest doc)
        {
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex) { Log(ex.ToString()); }
                using (SQLiteCommand cmd = new SQLiteCommand("select reqid from idrequest where isikukood = @isik order by reqid desc limit 1", con))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@isik",doc.isikukood);
                        using (SQLiteDataReader dr = cmd.ExecuteReader())
                        {

                            while (dr.Read())
                            {
                                if (dr.HasRows)
                                    return (dr["reqid"].ToString());
                            }
                        }

                    }
                    catch (Exception ec) { Log(ec.ToString()); }
                    return null;
                }
            }
        }
        /* Get last id from DOCUMENTS table.
        * Leia viimast id DOCUMENTS table'ist.
        */
        public static string getDocId(IDRequest doc)
        {

            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {

                try
                {
                    con.Open();
                }
                catch (Exception ex) { Log(ex.ToString()); }
                using (SQLiteCommand cmd = new SQLiteCommand(@"select docid from documents where isikukood = @isik order by docid desc limit 1", con))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@isik", doc.isikukood);
                        using (SQLiteDataReader dr = cmd.ExecuteReader())
                        {

                            while (dr.Read())
                            {
                                if (dr.HasRows)
                                    return dr["docid"].ToString();
                            }
                        }

                    }
                    catch (Exception ex) { Log(ex.ToString()); }
                }

            } return null;
        }
        //Logger
        public static void Log(string exc)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                w.WriteLine("{0} {1}", DateTime.Now.ToLongDateString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :{0}", exc);
            }
        }
    }
}












