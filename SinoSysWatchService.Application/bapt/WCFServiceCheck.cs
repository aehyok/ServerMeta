using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.WatchNode;
using SinoSystemWatch.Base.Application;
using System.Web.Script.Serialization;
using System.Configuration;
using SinoSZJS.Base.WCF.Client;
using SinoSZJS.Base.Authorize;
using System.Collections;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.CodeDom.Compiler;

namespace SinoSysWatchService.Application.bapt
{
    public class WCFServiceCheck : ICheckProject
    {
        public int Check(ref string json)
        {
            List<WCFServiceStatus> WcfInfo = GetWCFStatus();
            int _ret = CheckError(WcfInfo);
            var jser = new JavaScriptSerializer();
            //序列化
            json = jser.Serialize(WcfInfo);

            return _ret;
            return 0;
        }

        private int CheckError(List<WCFServiceStatus> WcfInfo)
        {
            int _ret = 0;
            foreach (WCFServiceStatus _ws in WcfInfo)
            {
                _ret = Math.Max(_ws.WcfStauts, _ret);
            }
            return _ret;
        }

        private List<WCFServiceStatus> GetWCFStatus()
        {
            List<WCFServiceStatus> _ret = new List<WCFServiceStatus>();
            CheckWCFServiceConfigSection WcfServiceList = (CheckWCFServiceConfigSection)ConfigurationManager.GetSection("CheckWCFServiceList");
            foreach (CheckWCFServiceConfigurationElement _el in WcfServiceList.PluginCollection)
            {
                WCFServiceStatus _wss = new WCFServiceStatus();
                _wss.Name = _el.Name;
                _wss.Description = _el.Description;
                _wss.WCFType = _el.Type;
                string _err = "";
                _wss.WcfStauts = CheckWcfRequest_old(_el.Type, _el.URL, ref _err);
                _wss.WcfError = _err;
                _ret.Add(_wss);
            }

            return _ret;
        }

        private int CheckWcfRequest_new(string typeStr, string serviceUri, ref string _err)
        {
            ArrayList endPoints = new ArrayList();

            try
            {
                MetadataExchangeClient mexClient = new MetadataExchangeClient(new EndpointAddress(serviceUri));//serviceUri参数是WCF Web Service Metadata的地址,在服务端的配置文件里定义,一般为Endpoint的地址加上/mex
                mexClient.ResolveMetadataReferences = true;
                MetadataSet metaDocs = mexClient.GetMetadata();
                WsdlImporter importer = new WsdlImporter(metaDocs);
                ServiceContractGenerator contractGenerator = new ServiceContractGenerator();

                foreach (ServiceEndpoint endPoint in importer.ImportAllEndpoints())
                {

                    endPoints.Add(endPoint);//将Endpoint存起来供以后调用方法时用
                }
                foreach (ContractDescription contract in importer.ImportAllContracts())
                {
                    contractGenerator.GenerateServiceContractType(contract);
                }
                if (contractGenerator.Errors.Count != 0)
                {
                    _err = "接口错误！";
                    return 3;
                }

                return 1;
            }
            catch (Exception ex)
            {
                _err = ex.Message;
                return 3;
            }


            //CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
            //CodeGeneratorOptions options = new CodeGeneratorOptions();
            //IndentedTextWriter textWriter = new IndentedTextWriter(new StreamWriter(proxyClass));
            //provider.GenerateCodeFromCompileUnit(contractGenerator.TargetCompileUnit, textWriter, options);
            //textWriter.Close();
        }

        private int CheckWcfRequest_old(string wcfType, string wcfURL, ref string _err)
        {
            ICommunicationObject _obj = null;
            int _ret = 0;
            _err = "";
            try
            {

                #region 检测接口
                switch (wcfType)
                {
                    case "csCommonService":
                        SinoSZJSCommonService.CommonServiceClient _scs = new SinoSZJSCommonService.CommonServiceClient();
                        _scs.Endpoint.Address = new EndpointAddress(wcfURL);
                        _obj = _scs as ICommunicationObject;
                        break;
                    case "csMetaDataService":
                        SinoSZJSMetaDataService.MetaDataServiceClient _msc = new SinoSZJSMetaDataService.MetaDataServiceClient();
                        _obj = _msc as ICommunicationObject;
                        break;
                    case "csReportService":
                        SinoSZJSReportService.ReportServiceClient _rsc = new SinoSZJSReportService.ReportServiceClient();
                        _obj = _rsc as ICommunicationObject;
                        break;
                    case "csUserManagerService":
                        SinoSZJSUserManagerService.UserManagerServiceClient _umsc = new SinoSZJSUserManagerService.UserManagerServiceClient();
                        _obj = _umsc as ICommunicationObject;
                        break;
                    case "csAuthorizeService":
                        AuthorizeService.AuthorizeServiceClient _asc = new AuthorizeService.AuthorizeServiceClient();
                        _asc.Endpoint.Address = new EndpointAddress(wcfURL);
                        _obj = _asc as ICommunicationObject;
                        break;
                    case "csMetaDataQueryService":
                        SinoSZJSMetaDataQueryService.MetaDataQueryServiceClient _mdqsc = new SinoSZJSMetaDataQueryService.MetaDataQueryServiceClient();
                        _obj = _mdqsc as ICommunicationObject;
                        break;
                    case "csSinoBestMTS":
                        SinSZJSSinoBestMTS.SinoBestMTSClient _sbmts = new SinSZJSSinoBestMTS.SinoBestMTSClient();
                        _obj = _sbmts as ICommunicationObject;
                        break;
                    default:
                        _err = "无法识别此种类型WCF接口";
                        return 3;
                }
                #endregion
                if (_obj != null)
                {
                    _ret = TryOpenClient(_obj, ref _err);
                }
                return _ret;
            }
            catch (Exception ex)
            {
                _err = string.Format("无法测试接口！{0}", ex.Message);
                return 3;
            }

        }

        private int TryOpenClient(ICommunicationObject ClientObj, ref string _err)
        {
            try
            {
                _err = "";
                ClientObj.Open();
                ClientObj.Close();
                return 1;
            }
            catch (Exception ex)
            {
                _err = ex.Message;
                ClientObj.Abort();
                return 3;
            }
        }
    }
}
