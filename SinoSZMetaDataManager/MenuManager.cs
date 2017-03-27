using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;

using SinoSZJS.Base.MenuType;
using DevExpress.XtraEditors.Controls;
using SinoSZPluginFramework.ClientPlugin;
using SinoSZJS.Base.Authorize;
using SinoSZClientBase;
using SinoSZJS.Base.MetaData.Define;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager
{
	public partial class MenuManager : DevExpress.XtraEditors.XtraUserControl, IControlMenu
	{
		private bool _haveChange = false;
		private bool _initFinished = false;

		private MD_Menu _menuDefine = null;
		private MenuTypeCollection _mts = MenuTypeCreator.CreateNewMenuTypeCollection();
		public MenuManager()
		{
			InitializeComponent();
		}

		public MenuManager(MD_Menu _menu, IApplication _app)
		{
			InitializeComponent();
			_menuDefine = _menu;
			InitMenuType(_app);
			InitIcons();
			RefreshData();
			_initFinished = true;
		}

		/// <summary>
		/// 初始化图标列表
		/// </summary>
		private void InitIcons()
		{
			this.TE_ICON.Properties.Items.Add(new ImageComboBoxItem("默认图标", "-1", 0));

			//if (SessionClass.SystemImageList != null)
			//{
			//        List<Image> _imgs = SessionClass.SystemImageList as List<Image>;
			//        int i = 0;
			//        foreach (Image _img in _imgs)
			//        {
			//                i++;
			//                this.imageList1.Images.Add(_img);
			//                this.TE_ICON.Properties.Items.Add(new ImageComboBoxItem(i.ToString(), i.ToString(), i));
			//        }
			//}

			Dictionary<string, Image> _sysIcons = SinoSZResources.Images;
			int i = 0;
			foreach (string _name in _sysIcons.Keys)
			{
				i++;
				this.imageList1.Images.Add(_sysIcons[_name]);
				this.TE_ICON.Properties.Items.Add(_name);
			}

		}

		private void TE_ICON_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			if (this.TE_ICON.EditValue == null)
			{
				this.Pic_Show.Image = null;
			}
			else
			{
				string _selectedImg = this.TE_ICON.EditValue.ToString();
				if (SinoSZResources.Images.ContainsKey(_selectedImg))
				{
					Image _img = SinoSZResources.Images[_selectedImg];
					this.Pic_Show.Image = _img;
				}
				else
				{
					this.Pic_Show.Image = null;
				}
			}

		}

		/// <summary>
		/// 初始化菜单选择项
		/// </summary>
		/// <param name="_application"></param>
		private void InitMenuType(IApplication _application)
		{
			this.TE_MenuType.Properties.Items.Clear();
			IPluginService _ps = (IPluginService)_application.GetService(typeof(IPluginService));
			if (_ps == null) return;
			MenuType _webType = new MenuType("BS客户端菜单", "WEB.MENU", "<URL></URL>\r\n<网页参数></网页参数>\r\n<权限定义>1:xxx权:父权限序号,2:xxxx权:父权限序号</权限定义>");
			this.TE_MenuType.Properties.Items.Add(_webType);
                        MenuType _slType = new MenuType("Silverlight客户端菜单", "SL_.MENU", "<URL></URL>\r\n<网页参数></网页参数>\r\n<权限定义>1:xxx权:父权限序号,2:xxxx权:父权限序号</权限定义>");
                        this.TE_MenuType.Properties.Items.Add(_slType);

			foreach (string _pName in _ps.GetAllPluginNames())
			{
				IPlugin _plugin = _ps.GetPluginInstance(_pName);
				if (_plugin != null)
				{
					List<MenuType> _mts = _plugin.GetMenuDefines();
					if (_mts != null)
					{
						foreach (MenuType _mt in _mts)
						{
							this.TE_MenuType.Properties.Items.Add(_mt);
						}
					}
				}
			}
		}


		private void RefreshData()
		{
			if (_menuDefine == null) return;
			this.TE_CS.EditValue = _menuDefine.MenuParameter;
			this.TE_DISPLAYORDER.EditValue = _menuDefine.DisplayOrder;

			this.TE_ICON.EditValue = _menuDefine.MenuIcon;
			if (SinoSZResources.Images.ContainsKey(_menuDefine.MenuIcon))
			{
				Image _img = SinoSZResources.Images[_menuDefine.MenuIcon];
				this.Pic_Show.Image = _img;
			}
			else
			{
				this.Pic_Show.Image = null;
			}

			this.TE_ID.EditValue = _menuDefine.MenuID;
			this.TE_MENUNAME.EditValue = _menuDefine.MenuName;
			this.TE_MenuType.EditValue = _menuDefine.MenuType;
			for (int i = 0; i < this.TE_MenuType.Properties.Items.Count; i++)
			{
				MenuType _mt = this.TE_MenuType.Properties.Items[i] as MenuType;
				if (_mt.TypeCommandName == _menuDefine.MenuType)
				{
					this.TE_MenuType.SelectedItem = _mt;
					break;
				}
			}

			this.TE_TOOLBAR.SelectedIndex = (_menuDefine.ShowInToolBar) ? 0 : 1;
			this.TE_TOOLTIP.EditValue = _menuDefine.MenuToolTip;
			this._haveChange = false;
		}

		#region IControlMenu Members

		public List<FrmMenuGroup> GetControlMenu()
		{
			FrmMenuGroup _thisGroup = new FrmMenuGroup("修改保存");
			_thisGroup.MenuItems = new List<FrmMenuItem>();

			FrmMenuItem _item = new FrmMenuItem("保存", "保存", global::SinoSZMetaDataManager.Properties.Resources.xx, _haveChange);
			_thisGroup.MenuItems.Add(_item);

			_item = new FrmMenuItem("取消", "取消", global::SinoSZMetaDataManager.Properties.Resources.x1, _haveChange);
			_thisGroup.MenuItems.Add(_item);
			List<FrmMenuGroup> _ret = new List<FrmMenuGroup>();
			_ret.Add(_thisGroup);
			return _ret;
		}

		public bool HaveDataChanged()
		{
			return _haveChange && _initFinished;
		}

		public event EventHandler<EventArgs> DataChanged;

		public event EventHandler<EventArgs> MenuChanged;

		public bool CloseControl()
		{
			if (HaveDataChanged())
			{
				DialogResult _res = XtraMessageBox.Show("是否保存数据修改?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (_res == DialogResult.Yes)
				{
					SaveData();
				}
				else
				{
					RefreshData();
				}
			}
			return true;
		}

		private void SaveData()
		{
			this._menuDefine.DisplayOrder = (int)this.TE_DISPLAYORDER.EditValue;
			this._menuDefine.MenuIcon = (this.TE_ICON.SelectedItem == null) ? "-1" : this.TE_ICON.SelectedItem.ToString();
			this._menuDefine.MenuName = this.TE_MENUNAME.EditValue.ToString();
			this._menuDefine.MenuParameter = this.TE_CS.EditValue.ToString();
			this._menuDefine.MenuToolTip = this.TE_TOOLTIP.EditValue.ToString();
			if (this.TE_MenuType.SelectedItem == null)
			{
				if (this.TE_MenuType.EditValue == null)
				{
					this._menuDefine.MenuType = "";
				}
				else
				{
					this._menuDefine.MenuType = this.TE_MenuType.EditValue.ToString();
				}
			}
			else
			{
				MenuType _mt = this.TE_MenuType.SelectedItem as MenuType;
				if (_mt == null) this._menuDefine.MenuType = "";
				else this._menuDefine.MenuType = _mt.TypeCommandName;
			}

			this._menuDefine.ShowInToolBar = (this.TE_TOOLBAR.SelectedIndex == 0);
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                _mdc.SaveMenuDefine(this._menuDefine);
                this._haveChange = false;
                RaiseDataChanged();
            }
		}

		public bool DoCommand(string _cmdName)
		{
			switch (_cmdName)
			{
				case "保存":
					SaveData();
					break;
				case "取消":
					RefreshData();
					break;
			}
			return true;
		}

		public void RaiseDataChanged()
		{

			if (HaveDataChanged() && DataChanged != null)
			{
				DataChanged(this, new EventArgs());
			}

		}

		private void RaiseMenuChanged()
		{
			if (MenuChanged != null)
			{
				MenuChanged(this, new EventArgs());
			}
		}
		#endregion

		private void TE_ID_EditValueChanged(object sender, EventArgs e)
		{

		}

		private void TE_MENUNAME_EditValueChanged(object sender, EventArgs e)
		{
			this._haveChange = true;
			RaiseDataChanged();
		}

		private void TE_DISPLAYORDER_EditValueChanged(object sender, EventArgs e)
		{
			this._haveChange = true;
			RaiseDataChanged();
		}



		private void TE_TOOLTIP_EditValueChanged(object sender, EventArgs e)
		{
			this._haveChange = true;
			RaiseDataChanged();
		}

		private void TE_ICON_EditValueChanged(object sender, EventArgs e)
		{
			this._haveChange = true;
			RaiseDataChanged();
		}

		private void TE_TOOLBAR_SelectedIndexChanged(object sender, EventArgs e)
		{
			this._haveChange = true;
			RaiseDataChanged();
		}

		private void TE_CS_EditValueChanged(object sender, EventArgs e)
		{
			this._haveChange = true;
			RaiseDataChanged();
		}

		private void TE_MenuType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_initFinished)
			{
				string _menutype = this.TE_MenuType.SelectedItem as string;
				MenuTypeBase _menu = MenuTypeCreator.CreateMenuType(_menutype);
				this.TE_CS.EditValue = _menu.MenuTypeParameters;
			}
			this._haveChange = true;
			RaiseDataChanged();
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			if (this.TE_MenuType.SelectedItem != null)
			{
				MenuType _mt = this.TE_MenuType.SelectedItem as MenuType;
				if (_mt != null)
				{
					string _oldstr = (this.TE_CS.EditValue == null) ? "" : this.TE_CS.EditValue.ToString();
					this.TE_CS.EditValue = _oldstr + _mt.TypeParameterDefine;
				}
			}
		}


		private void TE_ICON_EditValueChanged_1(object sender, EventArgs e)
		{
			this._haveChange = true;
			RaiseDataChanged();
		}





	}
}
