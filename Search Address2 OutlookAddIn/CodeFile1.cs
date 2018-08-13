using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Search_Address2_OutlookAddIn {
    internal class MailAddress {
        private readonly AddressKind addressKind;
        private readonly TextBox textBox;
        private readonly ListBox listBox;
        private readonly ReplyToAddress replyToAddress;

        internal static bool IsValidAddress(string s) {
            const string VALID_ADDRESS = @"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            return System.Text.RegularExpressions.Regex.IsMatch(s, VALID_ADDRESS);
        }

        internal MailAddress(Button buttonKind, TextBox textBox, ListBox listBox, Label dispSwitch, Label listReplyTo) {
            addressKind = new AddressKind(this, buttonKind);
            this.textBox = textBox;
            this.listBox = listBox;
            replyToAddress = new ReplyToAddress(dispSwitch, listReplyTo);
        }

        internal List<string> Search(string s, int maxRecords) {
            if (s.Length == 0) {
                return null;
            }

            var connection = new ADODB.Connection { Provider = "ADsDSOObject", CommandTimeout = 3 };
            connection.Open("Active Directory Provider");
            var cmd = new ADODB.Command { ActiveConnection = connection };

            Properties.Settings Default = Properties.Settings.Default;
            string[] sa = s.Split(' ');
            string query = sa.Length == 1 ?
                Default.Filter1.Replace("{0}", s) : Default.Filter2.Replace("{0}", sa[0]).Replace("{1}", sa[1]);

            cmd.CommandText = $"<LDAP://{Default.Host}:{Default.Port}/{Default.Base}>;(|{query});cn,mail;subtree";

            ADODB.Recordset rc;
            try {
                rc = cmd.Execute(out object RecordsAffected);
                if (rc.EOF || rc.BOF) {
                    return null;
                }
            } catch (Exception) {
                return null;
            }

            var addressList = new List<string>();
            rc.MoveFirst();
            for (int i = 0; i < maxRecords && !rc.EOF; rc.MoveNext(), i++) {
                try {
                    addressList.Add($"{rc.Fields[0].Value[0]} <{rc.Fields[1].Value[0]}>");
                } catch (Exception) {
                    continue;
                }
            }
            return addressList;
        }

        internal void Move(Outlook.MailItem mail) {
            if (addressKind.Transfer(mail, GetAddress())) {
                listBox.Items.Clear();
                listBox.Visible = false;
                textBox.Clear();
                textBox.Focus();
            }
        }

        private string GetAddress() {
            return
                listBox.Items.Count > 0 ? listBox.SelectedItem.ToString() :
                IsValidAddress(textBox.Text) ? textBox.Text : null;
        }

        private class ReplyToAddress {
            private readonly Label dispSwitch;
            private readonly Label list;

            internal ReplyToAddress(Label dispSwitch, Label list) {
                this.dispSwitch = dispSwitch;
                this.list = list;
            }

            internal void Add(Outlook.MailItem mail) {
                list.Text = mail.ReplyRecipientNames.Replace("; ", System.Environment.NewLine);
                dispSwitch.Visible = true;
            }
        }

        private class AddressKind {
            private MailAddress parent;
            private enum Kinds { TO, CC, BCC, REPLY_TO, UNDEF };
            private readonly Dictionary<string, Kinds> kindTable;
            private readonly Button buttonKind;

            internal AddressKind(MailAddress parent, Button buttonKind) {
                this.parent = parent;
                this.buttonKind = buttonKind;
                kindTable = new Dictionary<string, Kinds>() {
                    {"To:", Kinds.TO}, {"Cc:", Kinds.CC}, {"Bcc:", Kinds.BCC}, {"Reply-To:", Kinds.REPLY_TO}
                };
            }

            internal bool Transfer(Outlook.MailItem mail, string address) {
                if (address == null) {
                    return false;
                }

                switch (Kind()) {
                    case Kinds.TO:
                        mail.To += ";" + address;
                        break;
                    case Kinds.CC:
                        mail.CC += ";" + address;
                        break;
                    case Kinds.BCC:
                        mail.BCC += ";" + address;
                        break;
                    case Kinds.REPLY_TO:
                        mail.ReplyRecipients.Add(address);
                        parent.replyToAddress.Add(mail);
                        break;
                    default:
                        return false;
                }
                return true;
            }

            private Kinds Kind() {
                return kindTable.TryGetValue(buttonKind.Text, out Kinds kind) ? kind : Kinds.UNDEF;
            }
        }
    }
}
