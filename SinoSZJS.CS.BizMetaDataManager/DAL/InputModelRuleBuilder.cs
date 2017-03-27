using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using SinoSZJS.Base.Misc;
using SinoSZJS.Base.InputModel;

namespace SinoSZJS.CS.BizMetaDataManager.DAL
{
	public class InputModelRuleBuilder
	{
		public static string BinPath = "";
		public static Assembly CreateRuleAssembly(string DllFileName, string _code)
		{
			//创建编译器实例。
			CSharpCodeProvider provider = new CSharpCodeProvider();
			//设置编译参数。
			CompilerParameters paras = new CompilerParameters();
			paras.GenerateExecutable = false;
			paras.GenerateInMemory = true;
			//paras.OutputAssembly = BinPath + @"\IMRule_" + DllFileName + ".DLL";

			paras.ReferencedAssemblies.Add("System.dll");
			paras.ReferencedAssemblies.Add("System.Data.dll");
			paras.ReferencedAssemblies.Add("System.Configuration.dll");

			string _sinoszbasecalss = BinPath + @"\SinoSZJS.Base.dll";
			string _sinoSZMetaDataBase = BinPath + @"\SinoSZMetaDataBase.dll";
			paras.ReferencedAssemblies.Add(_sinoszbasecalss);
			paras.ReferencedAssemblies.Add(_sinoSZMetaDataBase);
			//创建动态代码。
			StringBuilder classSource = new StringBuilder();

			classSource.Append(_code);

			//System.Diagnostics.Debug.WriteLine(classSource.ToString());

			//编译代码。
			CompilerResults result = provider.CompileAssemblyFromSource(paras, classSource.ToString());


			result.TempFiles.KeepFiles = true;

			//获取编译后的程序集。
			Assembly assembly = result.CompiledAssembly;

			return assembly;
		}

		public static bool CheckByRuleAssembly(Assembly _ruleAssmbly, MD_InputEntity _entity, ref Dictionary<string, string> ErrorList)
		{
			object Class1 = _ruleAssmbly.CreateInstance("CheckRule");
			MethodInfo _minfo = Class1.GetType().GetMethod("Check");
			object[] _inputObj = new object[1];
			_inputObj[0] = _entity;
			string _ret = (string)_minfo.Invoke(Class1, _inputObj);
			if (_ret == "") return true;
			ErrorList.Add(Guid.NewGuid().ToString(), _ret);
			return false;

		}

		public static List<Assembly> CreateRuleAssemblys(MD_InputModel InputModel)
		{
			List<Assembly> _ret = new List<Assembly>();
			if (InputModel == null) return _ret;
			if (InputModel.Groups.Count > 0)
			{
				foreach (MD_InputModel_ColumnGroup _group in InputModel.Groups)
				{
					foreach (MD_InputModel_Column _column in _group.Columns)
					{
						if (_column.InputRule.Trim() != "")
						{
							try
							{
								_ret.Add(CreateRuleAssembly(_column.ColumnID, _column.InputRule));
							}
							catch (Exception e)
							{
								string _errStr = string.Format("创建{1}.{2}的验证规则失败！错误信息：{0}", e.Message, InputModel.ModelFullName, _column.ColumnName);
								throw new Exception(_errStr);
							}

						}
					}
				}
			}
			else
			{
				foreach (MD_InputModel_Column _column in InputModel.Columns)
				{
					if (_column.InputRule.Trim() != "")
					{
						try
						{
							_ret.Add(CreateRuleAssembly(_column.ColumnID,_column.InputRule));
						}
						catch (Exception e)
						{
							string _errStr = string.Format("创建{1}.{2}的验证规则失败！错误信息：{0}", e.Message, InputModel.ModelFullName, _column.ColumnName);
							throw new Exception(_errStr);
						}
					}
				}
			}
			return _ret;
		}
	}
}
