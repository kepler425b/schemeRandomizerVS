using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EnvDTE80;
using Microsoft;

namespace schemeRandomizerVS
{
    class Program
    {
        static void Main(string[] args)
        {

        List<string> targetStack = new List<string> { };

            List<string> plainTextTree = new List<string> { "Plain Text", "Identifier", "Operator", "CSS Property Name",
                "HTML Operator", "HTML Server-Side Script", "HTML Tag Delimiter", "outlining.collapsehintadornment", "CppEnumSemanticTokenFormat",
            "CppMemberFieldSemanticTokenFormat", "CppGlobalVariableSemanticTokenFormat" };

            List<string> commentTree = new List<string> { "Comment", "xml doc comment - text", "xml doc comment - delimiter,xml doc comment - name", "CSS Comment", "HTML Comment",
            "Script Comment", "XML Comment", "XAML Comment", "Line Number"};

            List<string> selectedTextTree = new List<string> { "Selected Text", "brace matching", "Indicator Margin", "RazorCode",
            "Script Identifier", "Script Operator", "XML Delimiter", "XML Text", "XAML Delimiter", "XAML Text", "CurrentLineActiveFormat",
            "CurrentLineInactiveFormat", "Inactive Selected Text", "CppLocalVariableSemanticTokenFormat", "CppParameterSemanticTokenFormat",
                "CppStaticMemberFieldSemanticTokenFormat" };

            List<string> numberTree = new List<string> { "Number", "CSS Property Value", "CSS Selector", "HTML Attribute", "HTML Entity",
            "Script Number", "XML Attribute", "XAML Attribute", "XAML Markup Extension Parameter Name" };

            List<string> stringTree = new List<string> { "String", "string - verbatim", "urlformat", "CSS String Value", "HTML Attribute Value",
            "Script String", "XML Attribute Quotes", "XML Attribute Value", "XML CData Section", "XAML Attribute Value", "XAML CData Section",
            "Warning", "XAML Markup Extension Parameter Value"};

            List<string> classNameTree = new List<string> { "class name", "CppNamespaceSemanticTokenFormat", "CppTypeSemanticTokenFormat" };

            List<string> enumTree = new List<string> { "enum name", "delegate name", "struct name", "Compiler Error", "CppFunctionSemanticTokenFormat",
            "CppMacroSemanticTokenFormat", "CppMemberFunctionSemanticTokenFormat", "CppStaticMemberFunctionSemanticTokenFormat" };

            List<string> interfaceNameTree = new List<string> { "interface name", "Preprocessor Keyword", "Keyword", "CSS Keyword", "Script Keyword" };

            List<string> htmlElementNameTree = new List<string> { "HTML Element Name", "XML Name", "XAML Markup Extension Class", "XAML Name",
              "Syntax Error", "XAML Attribute Quotes", "Current Statement" };

            // "outlining.square" same as plain text just a bit darker


            var random = new Random();

            int iter = 0;
            XDocument doc = XDocument.Load("one-dark_vs2015.vssettings");
            var color2 = String.Format("#{0:X6}", random.Next(0x10000000));

            foreach (XElement xe in doc.Descendants("Items").Elements())
            {
                targetStack.Insert(iter, xe.Attribute("Name").Value);
                iter++;
            }

            int HexToInt(string hex)
            {
                if (hex.StartsWith("#", StringComparison.OrdinalIgnoreCase))
                {
                    hex = hex.Substring(2);
                }
                return Int32.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            }

            string IntToHex(int value)
            {
                return String.Format("0x{0:X}", value);
            }
            void PAINTPlainTextTree(string color)
            {
                int intHEX = HexToInt(color);
                double temp = intHEX * 0.75;
                int result = (int)Math.Truncate(temp);
                string resultHEX = IntToHex(result);

                for (int i = 0; i < plainTextTree.Count(); i++)
                { 
                    var element = doc.Descendants("Item").Where(arg => arg.Attribute("Name").Value == plainTextTree[i]).Single();
                    var square = doc.Descendants("Item").Where(arg => arg.Attribute("Name").Value == "outlining.square").Single();
                    element.Attribute("Foreground").Value = color;
                    
                    square.Attribute("Foreground").Value = resultHEX;
                }
            }

            void PAINTCommentTree(string color)
            {
                for (int i = 0; i < commentTree.Count(); i++)
                {
                    var element = doc.Descendants("Item").Where(arg => arg.Attribute("Name").Value == commentTree[i]).Single();
                    element.Attribute("Foreground").Value = color;
                }
            }

            void PAINTSelectedTextTree(string color)
            {
                for (int i = 0; i < selectedTextTree.Count(); i++)
                {
                    var element = doc.Descendants("Item").Where(arg => arg.Attribute("Name").Value == selectedTextTree[i]).Single();
                    element.Attribute("Foreground").Value = color;
                }
            }

            void PAINTNumberTree(string color)
            {
                for (int i = 0; i < numberTree.Count(); i++)
                {
                    var element = doc.Descendants("Item").Where(arg => arg.Attribute("Name").Value == numberTree[i]).Single();
                    element.Attribute("Foreground").Value = color;
                }
            }

            void PAINTStringTree(string color)
            {
                for (int i = 0; i < stringTree.Count(); i++)
                {
                    var element = doc.Descendants("Item").Where(arg => arg.Attribute("Name").Value == stringTree[i]).Single();
                    element.Attribute("Foreground").Value = color;
                }
            }

            void PAINTClassNameTree(string color)
            {
                for (int i = 0; i < classNameTree.Count(); i++)
                {
                    var element = doc.Descendants("Item").Where(arg => arg.Attribute("Name").Value == classNameTree[i]).Single();
                    element.Attribute("Foreground").Value = color;
                }
            }

            void PAINTEnumTree(string color)
            {
                for (int i = 0; i < enumTree.Count(); i++)
                {
                    var element = doc.Descendants("Item").Where(arg => arg.Attribute("Name").Value == enumTree[i]).Single();
                    element.Attribute("Foreground").Value = color;
                }
            }

            void PAINTInterfaceNameTree(string color)
            {
                for (int i = 0; i < interfaceNameTree.Count(); i++)
                {
                    var element = doc.Descendants("Item").Where(arg => arg.Attribute("Name").Value == interfaceNameTree[i]).Single();
                    element.Attribute("Foreground").Value = color;
                }
            }

            void PAINTHtmlElementTree(string color)
            {
                for (int i = 0; i < htmlElementNameTree.Count(); i++)
                {
                    var element = doc.Descendants("Item").Where(arg => arg.Attribute("Name").Value == htmlElementNameTree[i]).Single();
                    element.Attribute("Foreground").Value = color;
                }
            }


       
            var PlainTextTreeCOLOR = String.Format("#{0:X6}", random.Next(0x10000000));
            PAINTPlainTextTree(PlainTextTreeCOLOR);

            var CommentTreeCOLOR = String.Format("#{0:X6}", random.Next(0x10000000));
            PAINTCommentTree(CommentTreeCOLOR);

            var SelectedTextCOLOR = String.Format("#{0:X6}", random.Next(0x10000000));
            PAINTSelectedTextTree(SelectedTextCOLOR);

            var NumberTreeCOLOR = String.Format("#{0:X6}", random.Next(0x10000000));
            PAINTNumberTree(NumberTreeCOLOR);

            var StringTreeCOLOR = String.Format("#{0:X6}", random.Next(0x10000000));
            PAINTStringTree(StringTreeCOLOR);

            var ClassNameTreeCOLOR = String.Format("#{0:X6}", random.Next(0x10000000));
            PAINTClassNameTree(ClassNameTreeCOLOR);

            var EnumTreeCOLOR = String.Format("#{0:X6}", random.Next(0x10000000));
            PAINTEnumTree(EnumTreeCOLOR);

            var InterfaceNameTreeCOLOR = String.Format("#{0:X6}", random.Next(0x10000000));
            PAINTInterfaceNameTree(InterfaceNameTreeCOLOR);

            var HtmlElementTreeCOLOR = String.Format("#{0:X6}", random.Next(0x10000000));
            PAINTHtmlElementTree(HtmlElementTreeCOLOR);

            doc.Save("altered.vssettings");
        }
    }
}
