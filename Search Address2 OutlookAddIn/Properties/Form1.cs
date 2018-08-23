using System;
using System.Windows.Forms;
using System.Threading;
using MailItem = Microsoft.Office.Interop.Outlook.MailItem;
using Inspector = Microsoft.Office.Interop.Outlook.Inspector;
using System.Collections.Generic;

namespace Search_Address2_OutlookAddIn {
    public partial class FormSearchAddress : Form {
        const int MAXLINES = 6;

        private readonly Inspector myInspector;
        private readonly MailAddress mailAddress;
        private int timerCount;
        private Thread searchThread;
        private readonly int maxRecords;
        private readonly int offsetX;
        private readonly int offsetY;

        public FormSearchAddress(Inspector inspector) {
            InitializeComponent();
            maxRecords = (int)Properties.Settings.Default.MaxRecords;
            offsetX = (int)Properties.Settings.Default.Offset_X;
            offsetY = (int)Properties.Settings.Default.Offset_Y;
            Left = inspector.Left + offsetX;
            Top = inspector.Top + offsetY;
            listBoxKind.SelectedIndex = 0;
            timerCount = 0;
            searchThread = null;
            myInspector = inspector;

            mailAddress = new MailAddress(buttonKind, textBoxAddress, listBoxAddress, labelReplyTo, labelReplyToList);
            if (mailAddress.Connection == null) {
                textBoxAddress.MouseHover += new System.EventHandler((object sender, EventArgs e) => { label1.Visible = true; });
                textBoxAddress.MouseLeave += new System.EventHandler((object sender, EventArgs e) => { label1.Visible = false; });
            }

            if (((MailItem)inspector.CurrentItem).ReplyRecipientNames != null) {
                labelReplyToList.Text = inspector.CurrentItem.ReplyRecipientNames.Replace("; ", System.Environment.NewLine);
                labelReplyTo.Visible = true;
            }
        }

        private void TextBoxAddress_TextChanged(object sender, EventArgs e) {
            if (searchThread != null && searchThread.IsAlive) {
                searchThread.Abort();
            }
            (searchThread = new Thread(() => {
                Invoke(new Action(() => {
                    textBoxAddress.ForeColor = System.Drawing.Color.Red;
                    listBoxAddress.Items.Clear();
                    listBoxAddress.Visible = false;
                }));
                string s = ((TextBox)sender).Text.Trim();
                List<string> addressList = mailAddress.Search(s, maxRecords);
                Invoke(new Action(() => {
                    if (addressList == null) {
                        textBoxAddress.ForeColor = MailAddress.IsValidAddress(s) ? System.Drawing.Color.Blue : System.Drawing.Color.Gray;
                    } else {
                        textBoxAddress.ForeColor = System.Drawing.Color.Black;
                        listBoxAddress.Items.AddRange(addressList.ToArray());
                        listBoxAddress.Height = listBoxAddress.ItemHeight * ((addressList.Count < MAXLINES ? addressList.Count : MAXLINES) + 1);
                        listBoxAddress.SelectedIndex = 0;
                        listBoxAddress.Visible = true;
                    }
                }));
            })).Start();
        }

        private void TextBoxAddress_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyData) {
                case Keys.Enter:
                    mailAddress.Move(myInspector.CurrentItem);
                    break;
                case Keys.Up:
                    if (listBoxAddress.Items.Count == 0) {
                        decSelection(listBoxKind);
                    }
                    break;
                case Keys.Down:
                    if (listBoxAddress.Items.Count == 0) {
                        incSelection(listBoxKind);
                    } else {
                        initSelection(listBoxAddress);
                    }
                    break;
            }

            void initSelection(ListBox listBox) {
                listBox.Focus();
                if (listBox.Items.Count > 1) {
                    listBox.SelectedIndex = 1;
                }
            }

            void incSelection(ListBox listBox) {
                if (listBox.SelectedIndex < listBox.Items.Count - 1) {
                    listBox.SelectedIndex++;
                }
            }

            void decSelection(ListBox listBox) {
                if (listBox.SelectedIndex > 0) {
                    listBox.SelectedIndex--;
                }
            }
        }

        private void ListBoxAddress_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                mailAddress.Move(myInspector.CurrentItem);
            }
        }

        private void ListBoxAddress_Click(object sender, EventArgs e) {
            mailAddress.Move(myInspector.CurrentItem);
        }

        private void ButtonKind_Click(object sender, EventArgs e) {
            if (listBoxKind.Visible) {
                textBoxAddress.Focus();
            } else {
                listBoxKind.Visible = true;
                listBoxKind.Focus();
            }
        }

        private void ListBoxKind_Click(object sender, EventArgs e) {
            textBoxAddress.Focus();
        }

        private void ListBoxKind_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                textBoxAddress.Focus();
            }
        }

        private void ListBoxKind_SelectedIndexChanged(object sender, EventArgs e) {
            buttonKind.Text = ((ListBox)sender).SelectedItem.ToString();
        }

        private void TextBoxAddress_Enter(object sender, EventArgs e) {
            listBoxKind.Visible = false;
        }

        internal void TimerOn() {
            timerCount = 0;
            timerWatch.Enabled = true;
        }

        private void TimerWatch_Tick(object sender, EventArgs e) {
            const int FOLLOW_SEC = 5;
            if (timerCount++ < FOLLOW_SEC * 1000 / ((System.Windows.Forms.Timer)sender).Interval) {
                try {
                    FollowInspector(myInspector);
                } catch (Exception) {
                    return;
                }
            } else {
                ((System.Windows.Forms.Timer)sender).Enabled = false;
            }
        }

        private void FollowInspector(Inspector inspector) {
            Invoke(new Action<Inspector>((ins) => {
                Left = inspector.Left + offsetX;
                Top = inspector.Top + offsetY;
            }), inspector);
        }

        private void LabelReplyTo_MouseHover(object sender, EventArgs e) {
            labelReplyToList.Visible = true;
        }

        private void LabelReplyTo_MouseLeave(object sender, EventArgs e) {
            labelReplyToList.Visible = false;
        }
    }
}