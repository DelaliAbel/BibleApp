﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BibleApp.Lookup {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class StringData {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StringData() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BibleApp.Lookup.StringData", typeof(StringData).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;traduction&quot;: &quot;Louis Segond&quot;,
        ///  &quot;contenuBible&quot;: [
        ///    {
        ///      &quot;titre&quot;: &quot;Ancien Testament&quot;,
        ///      &quot;livres&quot;: [
        ///        {
        ///          &quot;abreviation&quot;: null,
        ///          &quot;nomLivre&quot;: &quot;Genèse&quot;,
        ///          &quot;contenuChapitre&quot;: [
        ///            {
        ///              &quot;numeroChapitre&quot;: &quot;1&quot;,
        ///              &quot;contenuVersets&quot;: [
        ///                {
        ///                  &quot;numeroVerset&quot;: &quot;1&quot;,
        ///                  &quot;verset&quot;: &quot;Ljfmlkjqsoihazrefklmj&quot;
        ///                }
        ///              ]
        ///            },
        ///            {
        ///              &quot;num [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string BibleMap {
            get {
                return ResourceManager.GetString("BibleMap", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Decriotn valueejl.
        /// </summary>
        internal static string Test {
            get {
                return ResourceManager.GetString("Test", resourceCulture);
            }
        }
    }
}
