/// <author>Peter Torok (torok.peter@progterv.info)</author>

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using StrengthReport.Layouting;

namespace StrengthReport.Measuring {
    public class FunctionBox {
        private FunctionBox() { }
        /// <summary>
        /// Get all classes inherited from FunctionAbstract
        /// </summary>
        /// <returns></returns>
        public static List<FunctionAbstract> GetFunctionClasses() {
            Assembly asm = Assembly.GetExecutingAssembly();
            List<FunctionAbstract> returnList = new List<FunctionAbstract>();

            foreach (Type type in asm.GetTypes()) {
                if (type.IsSubclassOf(typeof(FunctionAbstract))) {
                    Object o = asm.CreateInstance(type.FullName);
                    if (o != null && o is FunctionAbstract)
                        returnList.Add((FunctionAbstract)o);
                }
            }
            return returnList;
        }


        /// <summary>
        /// Get names of all classes inherited from FunctionAbstract
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFunctionNames() {
            Assembly asm = Assembly.GetExecutingAssembly();
            List<string> returnList = new List<string>();

            foreach (Type type in asm.GetTypes()) {
                if (type.BaseType == typeof(FunctionAbstract)) {
                    returnList.Add(type.Name);
                }
            }
            return returnList;
        }
    }
}
