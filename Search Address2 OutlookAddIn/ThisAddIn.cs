using System;
using System.Collections.Generic;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Search_Address2_OutlookAddIn {
    public partial class ThisAddIn {
        private static Dictionary<Outlook.Inspector, FormSearchAddress> formTable;

        static ThisAddIn() {
            formTable = new Dictionary<Outlook.Inspector, FormSearchAddress>();
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e) {
            Application.OptionsPagesAdd += Application_OptionsPagesAdd;
            Application.ItemLoad += new Outlook.ApplicationEvents_11_ItemLoadEventHandler(Application_ItemLoad);
        }

        private void Application_OptionsPagesAdd(Outlook.PropertyPages pages) {
            pages.Add(new MyPropPage1(), "LDAP");
            pages.Add(new MyPropPage2(), "Location");
        }

        private void Application_ItemLoad(object Item) {
            if (Item is Outlook.MailItem) {
                Globals.ThisAddIn.Application.Inspectors.NewInspector += new Outlook.InspectorsEvents_NewInspectorEventHandler(NewInspector);
            }
        }

        private void NewInspector(Outlook.Inspector inspector) {
            if (((Outlook.MailItem)inspector.CurrentItem).Sender != null) {
                return;
            }

            var thread = new System.Threading.Thread(() => {
                FormSearchAddress form;
                lock (formTable) {
                    if (formTable.ContainsKey(inspector)) {
                        return;
                    }
                    form = new FormSearchAddress(inspector);
                    formTable.Add(inspector, form);
                }
                ((Outlook.ItemEvents_10_Event)inspector.CurrentItem).Close += new Outlook.ItemEvents_10_CloseEventHandler(MailClose);
                inspector.BeforeMove += new Outlook.InspectorEvents_10_BeforeMoveEventHandler(InspectorBeforeChange);
                inspector.BeforeSize += new Outlook.InspectorEvents_10_BeforeSizeEventHandler(InspectorBeforeChange);
                form.ShowDialog();
            });
            thread.SetApartmentState(System.Threading.ApartmentState.STA);
            thread.Start();
        }

        private void InspectorBeforeChange(ref bool cancel) {
            Outlook.Inspector inspector = Application.ActiveInspector();
            try {
                if (formTable.TryGetValue(inspector, out FormSearchAddress form)) {
                    form.TimerOn();
                }
            } catch (Exception) {
                return;
            }
        }

        private void MailClose(ref bool cancel) {
            Outlook.Inspector inspector = Application.ActiveInspector();
            try {
                lock (formTable) {
                    if (formTable.TryGetValue(inspector, out FormSearchAddress form)) {
                        formTable.Remove(inspector);
                        form.Invoke(new Action(() => {
                            form.Close();
                            form.Dispose();
                        }));
                    } 
                }
            } catch (Exception) {
                return;
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}