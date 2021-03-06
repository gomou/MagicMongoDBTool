﻿using MagicMongoDBTool.Module;
using MongoDB.Bson;
using System;
using System.Windows.Forms;
namespace MagicMongoDBTool.UserController
{
    public partial class UserRolesPanel : UserControl
    {
        public UserRolesPanel()
        {
            InitializeComponent();
            if (!SystemManager.IsUseDefaultLanguage)
            {
                grpRoles.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Roles);
            }
        }
        public Boolean IsAdmin
        {
            set
            {
                if (!value)
                {
                    //Note:Any Database Roles
                    //You must specify the following “any” database roles on the admin databases. 
                    //These roles apply to all databases in a mongod instance and are roughly equivalent to their single-database equivalents.
                    //If you add any of these roles to a user privilege document outside of the admin database,
                    //the privilege will have no effect. However, only the specification of the roles must occur in the admin database, 
                    //with delegated authentication credentials, users can gain these privileges by authenticating to another database.
                    chkdbAdminAnyDatabase.Enabled = false;
                    chkreadAnyDatabase.Enabled = false;
                    chkreadWriteAnyDatabase.Enabled = false;
                    chkuserAdminAnyDatabase.Enabled = false;
                }
            }
        }
        public BsonArray getRoles()
        {
            BsonArray roles = new BsonArray();
            foreach (Control item in this.grpRoles.Controls)
            {
                if (item.Name.StartsWith("chk"))
                {
                    if (((CheckBox)item).Checked)
                    {
                        roles.Add(item.Name.Substring(3));
                    }
                }
            }
            return roles;
        }
        public void setRoles(BsonArray value)
        {
            {
                foreach (String item in value)
                {
                    ((CheckBox)(grpRoles.Controls.Find("chk" + item, true)[0])).Checked = true;
                }
            }
        }
    }
}
