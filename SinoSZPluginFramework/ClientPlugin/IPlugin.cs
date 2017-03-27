using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework.ClientPlugin;

namespace SinoSZPluginFramework
{
        /// <summary>
        /// �ͻ��˲��
        /// </summary>
        public interface IPlugin
        {
                /// <summary>
                /// Ӧ�ó���
                /// </summary>
                IApplication Application { get;set;}
                /// <summary>
                /// �������
                /// </summary>
                String Name { get;set;}
                /// <summary>
                /// �������
                /// </summary>
                String Description { get;set;}
                /// <summary>
                /// ������ط���
                /// </summary>
                void Load();
                /// <summary>
                /// ��������Ա�û�������ط���
                /// </summary>
                void SuperLoad();
                /// <summary>
                /// ���ж�ط���
                /// </summary>
                void UnLoad();
                /// <summary>
                /// ����ʱ�¼�
                /// </summary>
                event EventHandler<EventArgs> Loading;                
                /// <summary>
                /// ���ز˵���
                /// </summary>
                /// <param name="_menuGroup"></param>
                /// <param name="_xmlparam"></param>
                void Load(FrmMenuGroup _menuGroup,string _xmlparam);
                /// <summary>
                /// ȡ����ṩ�Ĳ˵��ӿ�
                /// </summary>
                /// <returns></returns>
                List<MenuType> GetMenuDefines();

                /// <summary>
                /// ȡPortal����
                /// </summary>
                /// <param name="_portalItemName"></param>
                /// <param name="_param"></param>
                /// <returns></returns>
                object LoadPortalItem(string _portalItemName, string _param);

                /// <summary>
                /// ȡָ������˵�
                /// </summary>
                /// <param name="_commandName"></param>
                /// <returns></returns>
                FrmMenuItem GetMenuItem(string _commandName,string _displayTitle,string _param);
        }
}
