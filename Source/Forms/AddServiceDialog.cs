﻿//
// Copyright (c) 2012-2013, Oracle and/or its affiliates. All rights reserved.
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License as
// published by the Free Software Foundation; version 2 of the
// License.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
// 02110-1301  USA
//

namespace MySql.Notifier
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Linq;
  using System.Management;
  using System.Windows.Forms;
  using MySql.Notifier.Properties;
  using MySQL.Utility;

  public partial class AddServiceDialog : MachineAwareForm
  {
    private class ListViewItemComparer : IComparer
    {
      private int col;
      private SortOrder order;

      public ListViewItemComparer()
      {
        col = 0;
        order = SortOrder.Ascending;
      }

      public ListViewItemComparer(int column, SortOrder order)
      {
        col = column;
        this.order = order;
      }

      public int Compare(object x, object y)
      {
        int returnVal = -1;

        returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);

        if (order == SortOrder.Descending)
          returnVal *= -1;

        return returnVal;
      }
    }

    private int sortColumn = -1;
    private string lastFilter = String.Empty;
    private string lastTextFilter = String.Empty;
    //public ServiceType ServiceType {get; set;}
    private ServiceType serviceType = ServiceType.Local;

    public AccountLogin Login { get; set; }

    public AddServiceDialog(Machine remoteMachine)
    {
      InitializeComponent();
      serverType.SelectedIndex = 0;      
      lstServices.ColumnClick += new ColumnClickEventHandler(lstServices_ColumnClick);
      RemoteMachine = remoteMachine;
    }

    public List<MySQLService> ServicesToAdd { get; set; }

    private void RefreshList()
    {
      try
      {
        string currentFilter = filter.Checked ? Settings.Default.AutoAddPattern.Trim() : null;

        //TODO: Restore filtert persistance ▼
        //if (currentFilter == lastFilter && txtFilter.Text == lastTextFilter) return;

        lstServices.BeginUpdate();
        lastFilter = currentFilter;
        lastTextFilter = txtFilter.Text;

        lstServices.Items.Clear();

        List<ManagementObject> services = Service.GetInstances(lastFilter);

        if (RemoteMachine != null && serviceType == ServiceType.Remote)
        {
          services.Clear();
          foreach (ManagementObject mo in RemoteMachine.GetServices(currentFilter))
            services.Add(mo);
        }

        if (!String.IsNullOrEmpty(lastTextFilter))
        {
          services = services.Where(t => t.Properties["DisplayName"].Value.ToString().ToLower().Contains(lastTextFilter.ToLower())).ToList();
        }

        foreach (ManagementObject item in services)
        {
          ListViewItem newItem = new ListViewItem();
          newItem.Text = item.Properties["DisplayName"].Value.ToString();
          newItem.Tag = item.Properties["Name"].Value.ToString();
          newItem.SubItems.Add(item.Properties["State"].Value.ToString());

          lstServices.Items.Add(newItem);
        }

        lstServices.EndUpdate();
      }
      catch (Exception ex)
      {
        using (var errorDialog = new MessageDialog(Resources.HighSeverityError, ex.Message, true))
        {
          errorDialog.ShowDialog(this);
          MySQLNotifierTrace.GetSourceTrace().WriteError(ex.Message, 1);
        }
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
    AccountLogin Login = null;
    if(RemoteMachine!=null)
      Login = new AccountLogin(RemoteMachine.Name, RemoteMachine.User, RemoteMachine.UnprotectedPassword);
      Cursor.Current = Cursors.WaitCursor;

      //TODO: Add machinery to lists here. Verify if machine already exist on list.
      ServicesToAdd = new List<MySQLService>();
      foreach (ListViewItem lvi in lstServices.SelectedItems)
      {
        ServicesToAdd.Add(new MySQLService(lvi.Tag as string, true, true, Login));
      }
    }

    private void filter_CheckedChanged(object sender, EventArgs e)
    {
      RefreshList();
    }

    private void lstServices_SelectedIndexChanged(object sender, EventArgs e)
    {
      btnOK.Enabled = lstServices.SelectedItems.Count > 0;
    }

    private void lstServices_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      if (e.Column != sortColumn)
      {
        sortColumn = e.Column;
        lstServices.Sorting = SortOrder.Ascending;
      }
      else
      {
        if (lstServices.Sorting == SortOrder.Ascending)
          lstServices.Sorting = SortOrder.Descending;
        else
          lstServices.Sorting = SortOrder.Ascending;
      }

      lstServices.Sort();
      lstServices.ListViewItemSorter = new ListViewItemComparer(e.Column, lstServices.Sorting);
    }

    private void txtFilter_TextChanged(object sender, EventArgs e)
    {
      if (!timerForFiltering.Enabled)
      {
        timerForFiltering.Enabled = true;
      }
    }

    private void timerForFiltering_Tick(object sender, EventArgs e)
    {
      RefreshList();
      timerForFiltering.Enabled = false;
    }

    private void server_SelectedIndexChanged(object sender, EventArgs e)
    {
      serviceType = (ServiceType)serverType.SelectedIndex;
      DialogResult dr = DialogResult.None;

      if (serviceType == ServiceType.Remote)
      {
        using (var windowsConnectionDialog = new WindowsConnectionDialog(RemoteMachine))
        {
          dr = windowsConnectionDialog.ShowDialog();          
          RemoteMachine = (dr != DialogResult.Cancel) ? windowsConnectionDialog.RemoteMachine : RemoteMachine;          
        }
      }

      RefreshList();
    }
  }
}